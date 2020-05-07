using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COVID
{
    public partial class MainForm : Form
    {
        volatile bool stop = false;
        DateTime startDate;
        double[] actualData;
        Model bestModel;
        double bestError;
        Random rnd = new Random();

        // Model parameters.
        ParameterRange f0Range;
        ParameterRange iRange;
        ParameterRange rRange;
        ParameterRange orderDayRange;
        ParameterRange c1Range;
        ParameterRange c2Range;
        ParameterRange pRange;

        double returnDay = -1;

        // Training parameters.
        double stepFactor;
        double filterFactor;
        int window;
        int skip;

        double dF0;
        double dI;
        double dR;
        double dO;
        double dC1;
        double dC2;
        double dP;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load data.
            var actualDataList = new List<double>();
            using (var actualDataStream = new System.IO.StreamReader(@"COVIDD.txt"))
            {
                string line;
                while ((line = actualDataStream.ReadLine()) != null)
                {
                    var tokens = line.Split('\t');
                    if (tokens.Length == 2 && !string.IsNullOrEmpty(tokens[1]))
                    {
                        actualDataList.Add(Convert.ToDouble(tokens[1]));
                        if (actualDataList.Count == 1)
                        {
                            startDate = DateTime.Parse(tokens[0]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            actualData = actualDataList.ToArray();

            var orderDate = DateTime.Parse("03/23/2020");
            var orderDay = (orderDate - startDate).TotalDays;

            f0Range = new ParameterRange(0.01, 1, 10000);
            iRange = new ParameterRange(0, 0, 100000);
            rRange = new ParameterRange(1, 30, 100000);
            orderDayRange = new ParameterRange(orderDay, orderDay + 20, 10000);
            c1Range = new ParameterRange(1E-6, 5E-4, 100000);
            c2Range = new ParameterRange(1E-6, 5E-4, 100000);
            pRange = new ParameterRange(800, 50000, 100000);

            stepFactor = 100;
            filterFactor = 2;
            window = 1;
            skip = 0;

            f0Range.ToView(f0MinTextBox, f0MaxTextBox, f0StepsTextBox);
            iRange.ToView(iMinTextBox, iMaxTextBox, iStepsTextBox);
            rRange.ToView(rMinTextBox, rMaxTextBox, rStepsTextBox);
            orderDayRange.ToView(oMinTextBox, oMaxTextBox, oStepsTextBox);
            c1Range.ToView(c1MinTextBox, c1MaxTextBox, c1StepsTextBox);
            c2Range.ToView(c2MinTextBox, c2MaxTextBox, c2StepsTextBox);
            pRange.ToView(pMinTextBox, pMaxTextBox, pStepsTextBox);

            stepFactorTextBox.Text = stepFactor.ToString();
            filterFactorTextBox.Text = filterFactor.ToString();
            windowTextBox.Text = window.ToString();
            skipTextBox.Text = skip.ToString();
            returnDateTextBox.Text = "/6/1/2020";

            SetStop(true);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SetStop(false);

            try
            {
                f0Range = new ParameterRange(f0MinTextBox, f0MaxTextBox, f0StepsTextBox);
                iRange = new ParameterRange(iMinTextBox, iMaxTextBox, iStepsTextBox);
                rRange = new ParameterRange(rMinTextBox, rMaxTextBox, rStepsTextBox);
                orderDayRange = new ParameterRange(oMinTextBox, oMaxTextBox, oStepsTextBox);
                c1Range = new ParameterRange(c1MinTextBox, c1MaxTextBox, c1StepsTextBox);
                c2Range = new ParameterRange(c2MinTextBox, c2MaxTextBox, c2StepsTextBox);
                pRange = new ParameterRange(pMinTextBox, pMaxTextBox, pStepsTextBox);

                stepFactor = Convert.ToDouble(stepFactorTextBox.Text);
                filterFactor = Convert.ToDouble(filterFactorTextBox.Text);
                window = Convert.ToInt32(windowTextBox.Text);
                skip = Convert.ToInt32(skipTextBox.Text);

                dF0 = f0Range.Diff / f0Range.Steps * stepFactor;
                dI = iRange.Diff / iRange.Steps * stepFactor;
                dR = rRange.Diff / rRange.Steps * stepFactor;
                dO = orderDayRange.Diff / orderDayRange.Steps * stepFactor;
                dC1 = c1Range.Diff / c1Range.Steps * stepFactor;
                dC2 = c2Range.Diff / c2Range.Steps * stepFactor;
                dP = pRange.Diff / pRange.Steps * stepFactor;

                DateTime returnDate;
                if (DateTime.TryParse(returnDateTextBox.Text, out returnDate))
                {
                    returnDay = (returnDate - startDate).TotalDays;
                }
                else
                {
                    returnDay = -1;
                }

                if (bestModel != null)
                {
                    bestModel = new Model(bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P, returnDay);
                    DisplayBestModelData();
                }
            }
            catch (Exception ex)
            {
                ConsoleWriteLine(ex.ToString());
                SetStop(true);
            }

            Task.Run(() =>
            {
                var results = new double[actualData.Length];
                var valuesCache = new List<double>();

                FindBestModel(results, valuesCache);
            });
        }

        private void ConsoleWriteLine()
        {
            ConsoleWrite(Environment.NewLine);
        }

        private void ConsoleWriteLine(string text)
        {
            ConsoleWrite(text);
            ConsoleWrite(Environment.NewLine);
        }

        private void ConsoleWrite(string text)
        {
            var writeDelegate = new Action(() =>
            {
                consoleTextBox.AppendText(text);
            });

            if (consoleTextBox.InvokeRequired)
            {
                consoleTextBox.Invoke(writeDelegate);
            }
            else
            {
                writeDelegate();
            }
        }

        private void DisplayBestModelData()
        {
            consoleTextBox.Clear();
            chart.Series.Clear();
            chart.Legends.Clear();

            if (bestModel == null)
            {
                return;
            }

            // Extrapolate 2 months.
            int days = returnDay > 0 ? (int)returnDay + 240 : actualData.Length + 90;
            var modelData = new double[days];
            var valuesCache = new List<double>();
            var model = bestModel;

            model.Calculate(modelData, valuesCache);
            var error = CalculateError(model, modelData, valuesCache);

            var noOrderModelData = new double[modelData.Length];
            var noOrderModel = new Model(model.F0, model.I, model.R, model.StartDate, model.OrderDay, model.C1, model.C1, model.P, model.ReturnDay);
            noOrderModel.Calculate(noOrderModelData, valuesCache);

            HashSet<int> extremums = new HashSet<int>();
            HashSet<int> noOrderExtremums = new HashSet<int>();
            for (int i = 0; i < modelData.Length; i++)
            {
                if (i > 1 && i < modelData.Length - 2)
                {
                    {
                        double d = modelData[i] - modelData[i - 1];
                        double dMinus = modelData[i - 1] - modelData[i - 2];
                        double dPlus = modelData[i + 1] - modelData[i];
                        if (d > dMinus && d > dPlus)
                        {
                            extremums.Add(i);
                        }
                    }

                    {
                        double d = noOrderModelData[i] - noOrderModelData[i - 1];
                        double dMinus = noOrderModelData[i - 1] - noOrderModelData[i - 2];
                        double dPlus = noOrderModelData[i + 1] - noOrderModelData[i];
                        if (d > dMinus && d > dPlus && !extremums.Contains(i))
                        {
                            noOrderExtremums.Add(i);
                        }
                    }
                }
            }
            ConsoleWriteLine(DateTime.Now.ToShortDateString());
            ConsoleWriteLine($"Error: {error}");
            ConsoleWriteLine(model.ToString(Environment.NewLine));
            ConsoleWriteLine($"F1: {Math.Round(noOrderModelData[noOrderModelData.Length - 1])}");
            ConsoleWriteLine($"F2: {Math.Round(modelData[modelData.Length - 1])}");
            ConsoleWriteLine();

            var legend = chart.Legends.Add("Legend");
            legend.Docking = Docking.Bottom;
            legend.LegendStyle = LegendStyle.Row;

            {
                var modelDailySeries = chart.Series.Add("Model daily");
                modelDailySeries.Legend = legend.Name;
                modelDailySeries.Color = Color.LightBlue;
                modelDailySeries.YAxisType = AxisType.Secondary;
                for (int i = window; i < modelData.Length; i++)
                {
                    var value = modelData[i] - modelData[i - window];
                    var point = modelDailySeries.Points[modelDailySeries.Points.AddXY(i, value)];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                    point.ToolTip = Math.Round(value).ToString();
                    if (extremums.Contains(i))
                    {
                        point.Label = $"{Math.Round(value)} ({startDate.AddDays(i).ToShortDateString()})";
                    }
                }
            }

            {
                var actualDailySeries = chart.Series.Add("Actual daily");
                actualDailySeries.Legend = legend.Name;
                actualDailySeries.Color = Color.PaleVioletRed;
                actualDailySeries.YAxisType = AxisType.Secondary;
                for (int i = window; i < actualData.Length; i++)
                {
                    var value = actualData[i] - actualData[i - window];
                    var point = actualDailySeries.Points[actualDailySeries.Points.AddXY(i, value)];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                    point.ToolTip = Math.Round(value).ToString();
                }
            }

            {
                var modelSeries = chart.Series.Add("Model");
                modelSeries.Legend = legend.Name;
                modelSeries.ChartType = SeriesChartType.Line;
                modelSeries.Color = Color.DarkBlue;
                modelSeries.BorderWidth = 3;
                for (int i = 0; i < modelData.Length; i++)
                {
                    var point = modelSeries.Points[modelSeries.Points.AddXY(i, modelData[i])];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                    point.ToolTip = Math.Round(modelData[i]).ToString();
                    if (i == modelData.Length - 1 || i == actualData.Length - 1)
                    {
                        point.Label = $"{Math.Round(modelData[i])} ({Math.Round(modelData[i] / model.P * 100)}%)";
                    }
                }
            }

            {
                var noOrderModelSeries = chart.Series.Add("Model no order");
                noOrderModelSeries.Legend = legend.Name;
                noOrderModelSeries.ChartType = SeriesChartType.Line;
                noOrderModelSeries.Color = Color.DarkBlue;
                noOrderModelSeries.BorderWidth = 1;
                noOrderModelSeries.BorderDashStyle = ChartDashStyle.Dash;
                for (int i = 0; i < noOrderModelData.Length; i++)
                {
                    var point = noOrderModelSeries.Points[noOrderModelSeries.Points.AddXY(i, noOrderModelData[i])];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                    point.ToolTip = Math.Round(noOrderModelData[i]).ToString();
                    if (i == noOrderModelData.Length - 1)
                    {
                        point.Label = $"{Math.Round(noOrderModelData[i])} ({Math.Round(noOrderModelData[i] / noOrderModel.P * 100)}%)";
                    }
                    if (noOrderExtremums.Contains(i))
                    {
                        point.Label = startDate.AddDays(i).ToShortDateString();
                    }
                }
            }

            {
                var actualSeries = chart.Series.Add("Actual");
                actualSeries.Legend = legend.Name;
                actualSeries.ChartType = SeriesChartType.Line;
                actualSeries.Color = Color.Red;
                actualSeries.BorderWidth = 3;
                for (int i = 0; i < actualData.Length; i++)
                {
                    var point = actualSeries.Points[actualSeries.Points.AddXY(i, actualData[i])];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                    point.ToolTip = Math.Round(actualData[i]).ToString();
                }
            }

            {
                var orderDaySeries = chart.Series.Add("'Stay home' order date");
                orderDaySeries.Legend = legend.Name;
                orderDaySeries.ChartType = SeriesChartType.Point;
                orderDaySeries.Color = Color.Black;
                orderDaySeries.BorderWidth = 9;
                var iOrderDay = (int)Math.Round(model.OrderDay);
                var point = orderDaySeries.Points[orderDaySeries.Points.AddXY(iOrderDay, modelData[iOrderDay])];
                point.Label = point.AxisLabel = startDate.AddDays(iOrderDay).ToShortDateString();
            }
        }

        private void FindBestModel(double[] results, List<double> valuesCache)
        {
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, results, valuesCache);
                chart.Invoke(new Action(DisplayBestModelData));
            }

            while (!stop)
            {
                foreach (var model in GetRandomModels())
                {
                    var error = CalculateError(model, results, valuesCache);
                    if (bestModel == null || bestError > error)
                    {
                        bestModel = model;
                        bestError = error;
                        chart.Invoke(new Action(DisplayBestModelData));
                    }

                    if (error < bestError * filterFactor)
                    {
                        Optimize(model, error, results, valuesCache);
                    }
                }
            }

            PrintErrors(results, valuesCache);
        }

        Model CreateModel(Model baseModel, double f0, double i, double r, DateTime startDate, double orderDay, double c1, double c2, double p, double returnDay)
        {
            return new Model(
                f0Range.Trim(f0),
                iRange.Trim(i),
                rRange.Trim(r),
                startDate,
                orderDayRange.Trim(orderDay),
                c1Range.Trim(c1),
                c2Range.Trim(c2),
                pRange.Trim(p),
                returnDay);
        }

        void Optimize(Model model, double error, double[] results, List<double> valuesCache)
        {
            bool cont;
            int i = 0;
            ConsoleWrite("+");
            do
            {
                if (i > 1000 && bestError > error)
                {
                    bestModel = model;
                    bestError = error;
                    chart.Invoke(new Action(DisplayBestModelData));
                    i = 0;
                }

                cont = false;
                var nearbyModels = GetNearbyModels(model).ToArray();
                foreach (var nearbyModel in nearbyModels)
                {
                    var nearbyError = CalculateError(nearbyModel, results, valuesCache);
                    if (error > nearbyError)
                    {
                        model = nearbyModel;
                        error = nearbyError;
                        //ConsoleWrite(".");
                        cont = true;
                    }
                    i++;
                }

                //if (!cont)
                //{
                //    foreach (var nearbyModel in nearbyModels)
                //    {
                //        foreach (var nearbyModel2 in GetNearbyModels(nearbyModel))
                //        {
                //            var nearbyError2 = CalculateError(nearbyModel2, results, valuesCache);
                //            if (error > nearbyError2)
                //            {
                //                model = nearbyModel2;
                //                error = nearbyError2;
                //                ConsoleWrite(",");
                //                cont = true;
                //            }
                //            i++;
                //        }
                //    }
                //}
            }
            while (cont && !stop);

            if (bestError > error)
            {
                bestModel = model;
                bestError = error;
                chart.Invoke(new Action(DisplayBestModelData));
            }
        }

        private void PrintErrors(double[] results, List<double> valuesCache)
        {
            ConsoleWriteLine();
            var error = CalculateError(bestModel, results, valuesCache);

            {
                var plusModel = CreateModel(bestModel, bestModel.F0 + dF0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var minusModel = CreateModel(bestModel, bestModel.F0 - dF0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var plusError = CalculateError(plusModel, results, valuesCache);
                var minusError = CalculateError(minusModel, results, valuesCache);
                ConsoleWriteLine($"F0+: {plusError - error}");
                ConsoleWriteLine($"F0-: {error - minusError}");
            }

            {
                var plusModel = CreateModel(bestModel, bestModel.F0, bestModel.I + dI, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var minusModel = CreateModel(bestModel, bestModel.F0, bestModel.I - dI, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var plusError = CalculateError(plusModel, results, valuesCache);
                var minusError = CalculateError(minusModel, results, valuesCache);
                ConsoleWriteLine($"I+: {plusError - error}");
                ConsoleWriteLine($"I-: {error - minusError}");
            }

            {
                var plusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R + dR, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var minusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R - dR, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var plusError = CalculateError(plusModel, results, valuesCache);
                var minusError = CalculateError(minusModel, results, valuesCache);
                ConsoleWriteLine($"R+: {plusError - error}");
                ConsoleWriteLine($"R-: {error - minusError}");
            }

            {
                var plusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay + dO, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var minusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay - dO, bestModel.C1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var plusError = CalculateError(plusModel, results, valuesCache);
                var minusError = CalculateError(minusModel, results, valuesCache);
                ConsoleWriteLine($"O+: {plusError - error}");
                ConsoleWriteLine($"O-: {error - minusError}");
            }

            {
                var plusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1 + dC1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var minusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1 - dC1, bestModel.C2, bestModel.P, bestModel.ReturnDay);
                var plusError = CalculateError(plusModel, results, valuesCache);
                var minusError = CalculateError(minusModel, results, valuesCache);
                ConsoleWriteLine($"C1+: {plusError - error}");
                ConsoleWriteLine($"C1-: {error - minusError}");
            }

            {
                var plusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2 + dC2, bestModel.P, bestModel.ReturnDay);
                var minusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2 - dC2, bestModel.P, bestModel.ReturnDay);
                var plusError = CalculateError(plusModel, results, valuesCache);
                var minusError = CalculateError(minusModel, results, valuesCache);
                ConsoleWriteLine($"C2+: {plusError - error}");
                ConsoleWriteLine($"C2-: {error - minusError}");
            }

            {
                var plusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P + dP, bestModel.ReturnDay);
                var minusModel = CreateModel(bestModel, bestModel.F0, bestModel.I, bestModel.R, bestModel.StartDate, bestModel.OrderDay, bestModel.C1, bestModel.C2, bestModel.P - dP, bestModel.ReturnDay);
                var plusError = CalculateError(plusModel, results, valuesCache);
                var minusError = CalculateError(minusModel, results, valuesCache);
                ConsoleWriteLine($"P+: {plusError - error}");
                ConsoleWriteLine($"P-: {error - minusError}");
            }
        }

        private IEnumerable<Model> GetRandomModels()
        {
            // Pure random.
            var model = CreateModel(
                bestModel,
                f0Range.GetRandom(rnd),
                iRange.GetRandom(rnd),
                rRange.GetRandom(rnd),
                startDate,
                orderDayRange.GetRandom(rnd),
                c1Range.GetRandom(rnd),
                c2Range.GetRandom(rnd),
                pRange.GetRandom(rnd),
                returnDay);
            yield return model;

            // Randomized best.
            if (bestModel != null)
            {
                var randomization = rnd.NextDouble();
                yield return CreateModel(
                    bestModel,
                    rnd.NextDouble() > randomization ? bestModel.F0 : f0Range.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.I : iRange.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.R : rRange.GetRandom(rnd),
                    startDate,
                    rnd.NextDouble() > randomization ? bestModel.OrderDay : orderDayRange.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.C1 : c1Range.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.C2 : c2Range.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.P : pRange.GetRandom(rnd),
                    returnDay);

                yield return CreateModel(
                    bestModel,
                    bestModel.F0 + dF0 * (1.0 - rnd.NextDouble() * 2),
                    bestModel.I + dI * (1.0 - rnd.NextDouble() * 2),
                    bestModel.R + dR * (1.0 - rnd.NextDouble() * 2),
                    startDate,
                    bestModel.OrderDay + dO * (1.0 - rnd.NextDouble() * 2),
                    bestModel.C1 + dC1 * (1.0 - rnd.NextDouble() * 2),
                    bestModel.C2 + dC2 * (1.0 - rnd.NextDouble() * 2),
                    bestModel.P + dP * (1.0 - rnd.NextDouble() * 2),
                    returnDay);
            }
        }

        private IEnumerable<Model> GetNearbyModels(Model model)
        {
            yield return CreateModel(model, model.F0 + dF0, model.I, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P, model.ReturnDay);
            yield return CreateModel(model, model.F0 - dF0, model.I, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P, model.ReturnDay);

            yield return CreateModel(model, model.F0, model.I + dI, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P, model.ReturnDay);
            yield return CreateModel(model, model.F0, model.I - dI, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P, model.ReturnDay);

            yield return CreateModel(model, model.F0, model.I, model.R + dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P, model.ReturnDay);
            yield return CreateModel(model, model.F0, model.I, model.R - dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P, model.ReturnDay);

            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay + dO, model.C1, model.C2, model.P, model.ReturnDay);
            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay - dO, model.C1, model.C2, model.P, model.ReturnDay);

            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay, model.C1 + dC1, model.C2, model.P, model.ReturnDay);
            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay, model.C1 - dC1, model.C2, model.P, model.ReturnDay);

            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 + dC2, model.P, model.ReturnDay);
            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 - dC2, model.P, model.ReturnDay);

            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P + dP, model.ReturnDay);
            yield return CreateModel(model, model.F0, model.I, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P - dP, model.ReturnDay);

            yield return CreateModel(
                model,
                model.F0 + dF0 * (1.0 - rnd.NextDouble() * 2),
                model.I + dI * (1.0 - rnd.NextDouble() * 2),
                model.R + dR * (1.0 - rnd.NextDouble() * 2),
                startDate,
                model.OrderDay + dO * (1.0 - rnd.NextDouble() * 2),
                model.C1 + dC1 * (1.0 - rnd.NextDouble() * 2),
                model.C2 + dC2 * (1.0 - rnd.NextDouble() * 2),
                model.P + dP * (1.0 - rnd.NextDouble() * 2),
                returnDay);
        }

        private double CalculateError(Model model, double[] results, List<double> valuesCache)
        {
            model.Calculate(results, valuesCache);
            double error = 0;

            var end = actualData.Length - skip;

            for (int i = window; i < end; i++)
            {
                var value1 = results[i] - results[i - window];
                var value2 = actualData[i] - actualData[i - window];
                var diff = value1 - value2;

                error += diff * diff;
            }

            return error;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            SetStop(true);
        }

        private void SetStop(bool stop)
        {
            this.stop = stop;
            startButton.Enabled = this.stop;
            stopButton.Enabled = !this.stop;
            resetButton.Enabled = this.stop;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            bestModel = null;
            DisplayBestModelData();
        }
    }
}
