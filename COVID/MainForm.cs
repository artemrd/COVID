using System;
using System.Collections.Generic;
using System.Drawing;
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
        Random rnd = new Random();

        // Model parameters.
        ParameterRange f0Range;
        ParameterRange rRange;
        ParameterRange orderDayRange;
        ParameterRange cRange;
        ParameterRange pRange;
        
        // Training parameters.
        double step;
        double factor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load data.
            var actualDataList = new List<double>();
            using (var actualDataStream = new System.IO.StreamReader(@"COVID.txt"))
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

            f0Range = new ParameterRange(0.05, 0.5);
            rRange = new ParameterRange(5, 15);
            orderDayRange = new ParameterRange(orderDay, orderDay + 10);
            cRange = new ParameterRange(1E-6, 2E-5);
            pRange = new ParameterRange(15000, 150000);
            
            step = 0.01;
            factor = 1.5;

            f0Range.ToView(f0MinTextBox, f0MaxTextBox);
            rRange.ToView(rMinTextBox, rMaxTextBox);
            orderDayRange.ToView(oMinTextBox, oMaxTextBox);
            cRange.ToView(cMinTextBox, cMaxTextBox);
            pRange.ToView(pMinTextBox, pMaxTextBox);
            
            stepTextBox.Text = step.ToString();
            factorTextBox.Text = factor.ToString();

            SetStop(true);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SetStop(false);

            try
            {
                f0Range = new ParameterRange(f0MinTextBox, f0MaxTextBox);
                rRange = new ParameterRange(rMinTextBox, rMaxTextBox);
                orderDayRange = new ParameterRange(oMinTextBox, oMaxTextBox);
                cRange = new ParameterRange(cMinTextBox, cMaxTextBox);
                pRange = new ParameterRange(pMinTextBox, pMaxTextBox);
                
                step = Convert.ToDouble(stepTextBox.Text);
                factor = Convert.ToDouble(factorTextBox.Text);
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

            // Extrapolate 2 months.
            var modelData = new double[actualData.Length + 60];
            var valuesCache = new List<double>();
            var model = bestModel;

            model.Calculate(modelData, valuesCache);
            var error = CalculateError(model, modelData, valuesCache);

            var noOrderModelData = new double[modelData.Length];
            var noOrderModel = new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C1, model.P1, model.P1);
            noOrderModel.Calculate(noOrderModelData, valuesCache);

            int turningPoint = -1;
            int noOrderTurningPoint = -1;
            for (int i = 0; i < modelData.Length; i++)
            {
                string d2FLabel = string.Empty;
                if (i > 0 && i < modelData.Length - 1)
                {
                    {
                        double d2F = modelData[i - 1] + modelData[i + 1] - 2 * modelData[i];
                        if (d2F > 0)
                        {
                            d2FLabel = "+";
                            turningPoint = -1;
                        }
                        else if (d2F < 0)
                        {
                            d2FLabel = "-";
                            if (turningPoint < 0)
                            {
                                turningPoint = i;
                            }
                        }
                    }

                    {
                        double noOrderD2F = noOrderModelData[i - 1] + noOrderModelData[i + 1] - 2 * noOrderModelData[i];
                        if (noOrderD2F > 0)
                        {
                            noOrderTurningPoint = -1;
                        }
                        else if (noOrderD2F < 0)
                        {
                            if (noOrderTurningPoint < 0)
                            {
                                noOrderTurningPoint = i;
                            }
                        }
                    }
                }

                string ad2FLabel = string.Empty;
                if (i > 0 && i < actualData.Length - 1)
                {
                    double ad2F = actualData[i - 1] + actualData[i + 1] - 2 * actualData[i];
                    if (ad2F > 0)
                    {
                        ad2FLabel = "+";
                    }
                    else if (ad2F < 0)
                    {
                        ad2FLabel = "-";
                    }
                }

                var actualDataPoint = string.Empty;
                if (i < actualData.Length)
                {
                    actualDataPoint = actualData[i].ToString();
                }
                // ConsoleWriteLine($"{startDate.AddDays(i).ToShortDateString(),-10} {i,-8} {modelData[i],-24} {Math.Round(modelData[i]),-8} {d2FLabel,-1} {actualDataPoint,-8} {ad2FLabel}");
            }
            //ConsoleWriteLine();
            ConsoleWriteLine(DateTime.Now.ToShortDateString());
            ConsoleWriteLine($"Error: {error}");
            ConsoleWriteLine(model.ToString(Environment.NewLine));
            ConsoleWriteLine($"F1: {Math.Round(noOrderModelData[noOrderModelData.Length - 1])}");
            ConsoleWriteLine($"F2: {Math.Round(modelData[modelData.Length - 1])}");
            ConsoleWriteLine();

            chart.Series.Clear();
            chart.Legends.Clear();

            var legend = chart.Legends.Add("Legend");
            legend.Docking = Docking.Bottom;
            legend.LegendStyle = LegendStyle.Row;

            {
                var modelDailySeries = chart.Series.Add("Model daily");
                modelDailySeries.Legend = legend.Name;
                modelDailySeries.Color = Color.LightBlue;
                modelDailySeries.YAxisType = AxisType.Secondary;
                for (int i = 1; i < modelData.Length; i++)
                {
                    var value = modelData[i] - modelData[i - 1];
                    var point = modelDailySeries.Points[modelDailySeries.Points.AddXY(i, value)];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                    point.ToolTip = Math.Round(value).ToString();
                }
            }

            {
                var actualDailySeries = chart.Series.Add("Actual daily");
                actualDailySeries.Legend = legend.Name;
                actualDailySeries.Color = Color.PaleVioletRed;
                actualDailySeries.YAxisType = AxisType.Secondary;
                for (int i = 1; i < actualData.Length; i++)
                {
                    var value = actualData[i] - actualData[i - 1];
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
                    if (i == modelData.Length - 1)
                    {
                        point.Label = point.ToolTip;
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
                        point.Label = point.ToolTip;
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

            if (turningPoint >= 0)
            {
                var turningPointSeries = chart.Series.Add("Turning point");
                turningPointSeries.Legend = legend.Name;
                turningPointSeries.ChartType = SeriesChartType.Point;
                turningPointSeries.Color = Color.DarkBlue;
                turningPointSeries.BorderWidth = 9;
                var point = turningPointSeries.Points[turningPointSeries.Points.AddXY(turningPoint, modelData[turningPoint])];
                point.Label = point.AxisLabel = startDate.AddDays(turningPoint).ToShortDateString();
            }

            if (noOrderTurningPoint >= 0)
            {
                var noOrderTurningPointSeries = chart.Series.Add("No order turning point");
                noOrderTurningPointSeries.Legend = legend.Name;
                noOrderTurningPointSeries.ChartType = SeriesChartType.Point;
                noOrderTurningPointSeries.Color = Color.DarkBlue;
                noOrderTurningPointSeries.BorderWidth = 5;
                var point = noOrderTurningPointSeries.Points[noOrderTurningPointSeries.Points.AddXY(noOrderTurningPoint, noOrderModelData[noOrderTurningPoint])];
                point.Label = point.AxisLabel = startDate.AddDays(noOrderTurningPoint).ToShortDateString();
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
            double bestError = 0;
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, results, valuesCache);
                chart.Invoke(new Action(DisplayBestModelData));
            }

            while (!stop)
            {
                foreach (var m in GetRandomModels())
                {
                    var model = m;
                    var error = CalculateError(model, results, valuesCache);
                    if (bestModel == null || bestError > error)
                    {
                        bestModel = model;
                        bestError = error;
                        chart.Invoke(new Action(DisplayBestModelData));
                    }

                    if (error < bestError * factor)
                    {
                        ConsoleWrite(".");
                        bool cont;
                        do
                        {
                            cont = false;
                            foreach (var nearbyModel in GetNearbyModels(model))
                            {
                                var nearbyError = CalculateError(nearbyModel, results, valuesCache);
                                if (error > nearbyError)
                                {
                                    model = nearbyModel;
                                    error = nearbyError;
                                    cont = true;
                                }
                            }
                        }
                        while (cont && !stop);

                        error = CalculateError(model, results, valuesCache);
                        if (bestError > error)
                        {
                            bestModel = model;
                            bestError = error;
                            chart.Invoke(new Action(DisplayBestModelData));
                        }
                    }
                }
            }
        }

        private IEnumerable<Model> GetRandomModels()
        {
            yield return new Model(
                f0Range.GetRandom(rnd),
                rRange.GetRandom(rnd),
                startDate,
                orderDayRange.GetRandom(rnd),
                cRange.GetRandom(rnd),
                cRange.GetRandom(rnd),
                pRange.GetRandom(rnd),
                pRange.GetRandom(rnd));

            var randomization = rnd.NextDouble();
            if (bestModel != null)
            {
                yield return new Model(
                    rnd.NextDouble() > randomization ? bestModel.F0 : f0Range.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.R : rRange.GetRandom(rnd),
                    startDate,
                    rnd.NextDouble() > randomization ? bestModel.OrderDay : orderDayRange.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.C1 : cRange.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.C2 : cRange.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.P1 : pRange.GetRandom(rnd),
                    rnd.NextDouble() > randomization ? bestModel.P2 : pRange.GetRandom(rnd));
            }
        }

        private IEnumerable<Model> GetNearbyModels(Model model)
        {
            var dF0 = f0Range.Diff * step;
            yield return new Model(model.F0 + dF0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0 - dF0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);

            var dR = rRange.Diff * step;
            yield return new Model(model.F0, model.R + dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R - dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);

            var dO = orderDayRange.Diff * step;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay + dO, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay - dO, model.C1, model.C2, model.P1, model.P2);

            var dC = cRange.Diff * step;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1 + dC, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1 - dC, model.C2, model.P1, model.P2);

            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 + dC, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 - dC, model.P1, model.P2);

            var dP = pRange.Diff * step;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1 + dP, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1 - dP, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2 + dP);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2 - dP);
        }

        private double CalculateError(Model model, double[] results, List<double> valuesCache)
        {
            model.Calculate(results, valuesCache);
            double error = 0;

            for (int i = 1; i < actualData.Length; i++)
            {
                var value1 = results[i] - results[i - 1];
                var value2 = actualData[i] - actualData[i - 1];
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
        }
    }
}
