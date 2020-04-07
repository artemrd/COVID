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
        Random rnd = new Random();

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

            f0Range = new ParameterRange(0.05, 0.2);
            rRange = new ParameterRange(15, 30);
            orderDayRange = new ParameterRange(orderDay, orderDay + 10);
            cRange = new ParameterRange(1E-6, 2E-5);
            pRange = new ParameterRange(10000, 30000);

            f0Range.ToView(f0MinTextBox, f0MaxTextBox);
            rRange.ToView(rMinTextBox, rMaxTextBox);
            orderDayRange.ToView(oMinTextBox, oMaxTextBox);
            cRange.ToView(cMinTextBox, cMaxTextBox);
            pRange.ToView(pMinTextBox, pMaxTextBox);

            stopButton.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            stop = false;
            startButton.Enabled = false;
            stopButton.Enabled = true;
            consoleTextBox.Clear();

            f0Range = new ParameterRange(f0MinTextBox, f0MaxTextBox);
            rRange = new ParameterRange(rMinTextBox, rMaxTextBox);
            orderDayRange = new ParameterRange(oMinTextBox, oMaxTextBox);
            cRange = new ParameterRange(cMinTextBox, cMaxTextBox);
            pRange = new ParameterRange(pMinTextBox, pMaxTextBox);

            Task.Run(() =>
            {
                var timePoints = new double[actualData.Length];
                for (int i = 0; i < timePoints.Length; i++)
                {
                    timePoints[i] = i;
                }
                var results = new double[timePoints.Length];

                var valuesCache = new List<double>();

                var model = FindBestModel(timePoints, results, actualData, valuesCache);

                ConsoleWriteLine();

                var error = CalculateError(model, timePoints, results, actualData, valuesCache);

                // Extrapolate 2 months.
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
                ConsoleWriteLine(DateTime.Now.ToShortDateString());
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
                var turningPointSeries = chart.Series.Add("Turning point");
                turningPointSeries.Legend = legend.Name;
                turningPointSeries.ChartType = SeriesChartType.Point;
                turningPointSeries.Color = Color.Green;
                turningPointSeries.BorderWidth = 7;
                var point = turningPointSeries.Points[turningPointSeries.Points.AddXY(turningPoint, modelData[turningPoint])];
                point.Label = point.AxisLabel = startDate.AddDays(turningPoint).ToShortDateString();
            }

            {
                var orderDaySeries = chart.Series.Add("'Stay home' order date");
                orderDaySeries.Legend = legend.Name;
                orderDaySeries.ChartType = SeriesChartType.Point;
                orderDaySeries.Color = Color.DarkCyan;
                orderDaySeries.BorderWidth = 7;
                var iOrderDay = (int)Math.Round(orderDay);
                var point = orderDaySeries.Points[orderDaySeries.Points.AddXY(iOrderDay, modelData[iOrderDay])];
                point.Label = point.AxisLabel = startDate.AddDays(iOrderDay).ToShortDateString();
            }
        }

        private Model FindBestModel(double[] timePoints, double[] results, double[] actualData, List<double> valuesCache)
        {
            double bestError = 0;
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, timePoints, results, actualData, valuesCache);
                ConsoleWriteLine($"Error: {bestError}, {bestModel}");
            }

            while (!stop)
            {
                var c1 = cRange.GetRandom(rnd);
                var c2 = cRange.GetRandom(c1, rnd);
                var model = new Model(
                    f0Range.GetRandom(rnd),
                    rRange.GetRandom(rnd),
                    startDate,
                    orderDayRange.GetRandom(rnd),
                    c1,
                    c2,
                    pRange.GetRandom(rnd),
                    pRange.GetRandom(rnd));

                var error = CalculateError(model, timePoints, results, actualData, valuesCache);
                if (bestModel == null || bestError > error)
                {
                    bestModel = model;
                    bestError = error;
                    ConsoleWriteLine($"Error: {bestError}, {bestModel}");
                }

                if (error < bestError * 2)
                {
                    bool cont;
                    do
                    {
                        cont = false;
                        foreach (var nearbyModel in GetNearbyModels(model))
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
            double factor = 100;

            var dF0 = f0Range.Diff / factor;
            yield return new Model(model.F0 + dF0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0 - dF0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);

            var dR = rRange.Diff / factor;
            yield return new Model(model.F0, model.R + dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R - dR, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2);

            var dO = orderDayRange.Diff / factor;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay + dO, model.C1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay - dO, model.C1, model.C2, model.P1, model.P2);

            var dC1 = cRange.Diff / factor;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1 + dC1, model.C2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1 - dC1, model.C2, model.P1, model.P2);

            var dC2 = cRange.Diff / factor;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 + dC2, model.P1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2 - dC2, model.P1, model.P2);

            var dP1 = pRange.Diff / factor;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1 + dP1, model.P2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1 - dP1, model.P2);

            var dP2 = pRange.Diff / factor;
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2 + dP2);
            yield return new Model(model.F0, model.R, model.StartDate, model.OrderDay, model.C1, model.C2, model.P1, model.P2 - dP2);
        }

        private double CalculateError(Model model, double[] timePoints, double[] results, double[] actualData, List<double> valuesCache)
        {
            // Last days are underreported.
            var skip = 2;

            // Average over windowSize days.
            var windowSize = 3;

            model.Calculate(timePoints, results, valuesCache);
            double error = 0;
            for (int i = actualData.Length - 1 - skip; i >= windowSize; i--)
            {
                var diff = (results[i] - results[i - windowSize]) - (actualData[i] - actualData[i - windowSize]);
                error += diff * diff;
            }
            return error;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stop = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }
    }
}
