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
        ParameterRange f0Range;
        ParameterRange rRange;
        ParameterRange orderDayRange;
        ParameterRange cRange;
        ParameterRange pRange;
        Model bestModel;

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

            //double missFactor = (6604.0 / 6585) - 1;
            double missFactor = 0;
            for (int i = actualData.Length - 1; i >= 0; i--)
            {
                actualData[i] = actualData[i] * (1 + missFactor);
                missFactor = missFactor * missFactor;
            }

            var orderDate = DateTime.Parse("03/23/2020");
            var orderDay = (orderDate - startDate).TotalDays;

            f0Range = new ParameterRange(0.09, 0.15, 0.01);
            rRange = new ParameterRange(15, 30, 1);
            orderDayRange = new ParameterRange(orderDay - 2, orderDay + 7, 1);
            cRange = new ParameterRange(1E-6, 2E-5, 1E-6);
            pRange = new ParameterRange(10000, 50000, 2000);

            f0Range.ToView(f0MinTextBox, f0MaxTextBox, f0StepTextBox);
            rRange.ToView(rMinTextBox, rMaxTextBox, rStepTextBox);
            orderDayRange.ToView(oMinTextBox, oMaxTextBox, oStepTextBox);
            cRange.ToView(cMinTextBox, cMaxTextBox, cStepTextBox);
            pRange.ToView(pMinTextBox, pMaxTextBox, pStepTextBox);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            stop = false;
            calculateButton.Enabled = false;
            consoleTextBox.Clear();

            f0Range = new ParameterRange(f0MinTextBox, f0MaxTextBox, f0StepTextBox);
            rRange = new ParameterRange(rMinTextBox, rMaxTextBox, rStepTextBox);
            orderDayRange = new ParameterRange(oMinTextBox, oMaxTextBox, oStepTextBox);
            cRange = new ParameterRange(cMinTextBox, cMaxTextBox, cStepTextBox);
            pRange = new ParameterRange(pMinTextBox, pMaxTextBox, pStepTextBox);

            Task.Run(() =>
            {
                var timePoints = new double[actualData.Length];
                for (int i = 0; i < timePoints.Length; i++)
                {
                    timePoints[i] = i;
                }
                var results = new double[timePoints.Length];

                var valuesCache = new List<double>();

                // Explore parameters space.
                // var model = FindBestModel(timePoints, results, actualData, valuesCache);
                var model = FindBestModelRandom(timePoints, results, actualData, valuesCache);

                ConsoleWriteLine();

                // Fine tuning.
                for (int i = 0; i < 0; i++)
                {
                    f0Range = new ParameterRange(model.F0 - f0Range.Step, model.F0 + f0Range.Step, f0Range.Step / 10);
                    rRange = new ParameterRange(model.R - rRange.Step, model.R + rRange.Step, rRange.Step / 10);
                    orderDayRange = new ParameterRange(model.OrderDay - orderDayRange.Step, model.OrderDay + orderDayRange.Step, orderDayRange.Step / 10);
                    cRange = new ParameterRange(Math.Min(model.C1, model.C2) - cRange.Step, Math.Max(model.C1, model.C2) + cRange.Step, cRange.Step / 10);
                    pRange = new ParameterRange(Math.Min(model.P1, model.P2) - pRange.Step, Math.Max(model.P1, model.P2) + pRange.Step, pRange.Step / 10);

                    model = FindBestModel(timePoints, results, actualData, valuesCache);

                    ConsoleWriteLine();
                }

                var error = CalculateError(model, timePoints, results, actualData, valuesCache);

                // Extrapolate 3 months.
                timePoints = new double[actualData.Length + 60];
                for (int i = 0; i < timePoints.Length; i++)
                {
                    timePoints[i] = i;
                }
                results = new double[timePoints.Length];

                model.Calculate(timePoints, results, valuesCache);
                int turningPoint = -1;
                for (int i = 0; i < timePoints.Length; i++)
                {
                    string d2FLabel = string.Empty;
                    if (i > 0 && i < results.Length - 1)
                    {
                        double d2F = results[i - 1] + results[i + 1] - 2 * results[i];
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
                    ConsoleWriteLine($"{startDate.AddDays(i).ToShortDateString(),-10} {timePoints[i],-8} {results[i],-24} {Math.Round(results[i]),-8} {d2FLabel,-1} {actualDataPoint,-8} {ad2FLabel}");
                }
                ConsoleWriteLine();
                ConsoleWriteLine($"Error: {error}");
                ConsoleWriteLine(model.ToString("\r\n"));

                chart.Invoke(new Action<double[], double[], DateTime, int, double>(PopulateChart), new object[] { actualData, results, startDate, turningPoint, model.OrderDay });
            });
        }

        private void ConsoleWriteLine()
        {
            ConsoleWriteLine(string.Empty);
        }

        private void ConsoleWriteLine(string text)
        {
            var writeDelegate = new Action(() =>
            {
                consoleTextBox.AppendText(text);
                consoleTextBox.AppendText("\r\n");
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

        private void PopulateChart(double[] actualData, double[] modelData, DateTime startDate, int turningPoint, double orderDay)
        {
            chart.Series.Clear();

            {
                var modelSeries = chart.Series.Add("Model");
                modelSeries.ChartType = SeriesChartType.Line;
                modelSeries.Color = Color.DarkBlue;
                modelSeries.BorderWidth = 3;
                for (int i = 0; i < modelData.Length; i++)
                {
                    var point = modelSeries.Points[modelSeries.Points.AddXY(i, modelData[i])];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                }
            }

            {
                var actualSeries = chart.Series.Add("Actual");
                actualSeries.ChartType = SeriesChartType.Line;
                actualSeries.Color = Color.Red;
                actualSeries.BorderWidth = 3;
                for (int i = 0; i < actualData.Length; i++)
                {
                    var point = actualSeries.Points[actualSeries.Points.AddXY(i, actualData[i])];
                    point.AxisLabel = startDate.AddDays(i).ToShortDateString();
                }
            }

            {
                var turningPointSeries = chart.Series.Add("Turning point");
                turningPointSeries.ChartType = SeriesChartType.Point;
                turningPointSeries.Color = Color.Green;
                turningPointSeries.BorderWidth = 7;
                var point = turningPointSeries.Points[turningPointSeries.Points.AddXY(turningPoint, modelData[turningPoint])];
                point.Label = point.AxisLabel = startDate.AddDays(turningPoint).ToShortDateString();
            }

            {
                var orderDaySeries = chart.Series.Add("Order");
                orderDaySeries.ChartType = SeriesChartType.Point;
                orderDaySeries.Color = Color.DarkCyan;
                orderDaySeries.BorderWidth = 7;
                var iOrderDay = (int)Math.Round(orderDay);
                var point = orderDaySeries.Points[orderDaySeries.Points.AddXY(iOrderDay, modelData[iOrderDay])];
                point.Label = point.AxisLabel = startDate.AddDays(iOrderDay).ToShortDateString();
            }
        }

        private Model FindBestModel(
            double[] timePoints,
            double[] results,
            double[] actualData,
            List<double> valuesCache)
        {
            double bestError = 0;
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, timePoints, results, actualData, valuesCache);
                ConsoleWriteLine($"Error: {bestError}, {bestModel}");
            }
            for (var f0 = f0Range.Min; f0 <= f0Range.Max; f0 += f0Range.Step)
            {
                ConsoleWriteLine($"F0: {f0}");
                for (var r = rRange.Min; r <= rRange.Max; r += rRange.Step)
                {
                    for (var orderDay = orderDayRange.Min; orderDay <= orderDayRange.Max; orderDay += orderDayRange.Step)
                    {
                        for (var c1 = cRange.Min; c1 <= cRange.Max; c1 += cRange.Step)
                        {
                            for (var c2 = cRange.Min; c2 <= cRange.Max; c2 += cRange.Step)
                            {
                                for (var p1 = pRange.Min; p1 <= pRange.Max; p1 += pRange.Step)
                                {
                                    // var p2 = p1;
                                    for (var p2 = pRange.Min; p2 <= pRange.Max; p2 += pRange.Step)
                                    {
                                        var model = new Model(f0, r, startDate, orderDay, c1, c2, p1, p2);
                                        var error = CalculateError(model, timePoints, results, actualData, valuesCache);
                                        if (bestModel == null || bestError > error)
                                        {
                                            ConsoleWriteLine($"Error: {error}, {model}");
                                            bestModel = model;
                                            bestError = error;
                                        }
                                        if (stop)
                                        {
                                            return bestModel;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bestModel;
        }

        private Model FindBestModelRandom(
            double[] timePoints,
            double[] results,
            double[] actualData,
            List<double> valuesCache)
        {
            double bestError = 0;
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, timePoints, results, actualData, valuesCache);
                ConsoleWriteLine($"Error: {bestError}, {bestModel}");
            }

            var rnd = new Random();

            while (!stop)
            {
                //var p = pRange.GetRandom(rnd);
                var model = new Model(
                    f0Range.GetRandom(rnd),
                    rRange.GetRandom(rnd),
                    startDate,
                    orderDayRange.GetRandom(rnd),
                    cRange.GetRandom(rnd),
                    cRange.GetRandom(rnd),
                    pRange.GetRandom(rnd),
                    pRange.GetRandom(rnd));
                    //p,
                    //p);
                var error = CalculateError(model, timePoints, results, actualData, valuesCache);
                if (bestModel == null || bestError > error)
                {
                    bestModel = model;
                    bestError = error;
                    ConsoleWriteLine($"Error: {bestError}, {bestModel}");

                    bool cont;
                    do
                    {
                        cont = false;
                        foreach (var nearbyModel in GetNearbyModels(bestModel))
                        {
                            var nearbyError = CalculateError(nearbyModel, timePoints, results, actualData, valuesCache);
                            if (bestError > nearbyError)
                            {
                                bestModel = nearbyModel;
                                bestError = nearbyError;
                                ConsoleWriteLine($"Error: {bestError}, {bestModel}");
                                cont = true;
                            }
                        }
                    }
                    while (cont);
                }
            }

            return bestModel;
        }

        private IEnumerable<Model> GetNearbyModels(Model model)
        {
            var dF0 = model.F0 / 100;
            yield return new Model(model.F0 + dF0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0 - dF0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);

            var dR = model.R / 100;
            yield return new Model(model.F0, model.R + dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R - dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);

            var dO = model.OrderDay / 100;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay + dO, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay - dO, model.C1, model.C2, model.P1, model.P2);

            var dC1 = model.C1 / 100;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1 + dC1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1 - dC1, model.C2, model.P1, model.P2);

            var dC2 = model.C2 / 100;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 + dC2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 - dC2, model.P1, model.P2);

            var dP1 = model.P1 / 100;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1 + dP1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1 - dP1, model.P2);

            var dP2 = model.P2 / 100;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2 + dP2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2 - dP2);
        }

        private double CalculateError(Model model, double[] timePoints, double[] results, double[] actualData, List<double> valuesCache)
        {
            model.Calculate(timePoints, results, valuesCache);
            double error = 0;
            for (int i = 0; i < actualData.Length; i++)
            {
                var diff = results[i] - actualData[i];
                error += diff * diff;
            }
            return error;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stop = true;
            calculateButton.Enabled = true;
        }
    }
}
