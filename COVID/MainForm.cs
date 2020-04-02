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
        public MainForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            calculateButton.Enabled = false;

            Task.Run(() =>
            {
                // Load data.
                DateTime startDate = DateTime.MinValue;
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
                var actualData = actualDataList.ToArray();

                var timePoints = new double[actualData.Length];
                for (int i = 0; i < timePoints.Length; i++)
                {
                    timePoints[i] = i;
                }
                var results = new double[timePoints.Length];

                var valuesCache = new List<double>();

                // Explore parameters space.
                var f0Range = new ParameterRange(0.05, 0.15, 0.01);
                var rRange = new ParameterRange(10, 30, 1);
                var cRange = new ParameterRange(1E-6, 2E-5, 1E-6);
                var pRange = new ParameterRange(10000, 50000, 1000);

                var model = FindBestModel(null, f0Range, rRange, cRange, pRange, timePoints, results, actualData, valuesCache);

                ConsoleWriteLine();

                // Fine tuning.
                for (int i = 0; i < 1; i++)
                {
                    f0Range = new ParameterRange(model.F0 - f0Range.Step, model.F0 + f0Range.Step, f0Range.Step / 10);
                    rRange = new ParameterRange(model.R - rRange.Step, model.R + rRange.Step, rRange.Step / 10);
                    cRange = new ParameterRange(model.C - cRange.Step, model.C + cRange.Step, cRange.Step / 10);
                    pRange = new ParameterRange(model.P - pRange.Step, model.P + pRange.Step, pRange.Step / 10);

                    model = FindBestModel(model, f0Range, rRange, cRange, pRange, timePoints, results, actualData, valuesCache);

                    ConsoleWriteLine();
                }

                var error = CalculateError(model, timePoints, results, actualData, valuesCache);

                // Extrapolate 3 months.
                timePoints = new double[actualData.Length + 90];
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
                ConsoleWriteLine($"F0: {model.F0}");
                ConsoleWriteLine($"R: {model.R}");
                ConsoleWriteLine($"C: {model.C}");
                ConsoleWriteLine($"P: {model.P}");
                ConsoleWriteLine($"R * C * P: {model.R * model.C * model.P}");

                chart.Invoke(new Action<double[], double[], DateTime, int>(PopulateChart), new object[] { actualData, results, startDate, turningPoint });
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

        private void PopulateChart(double[] actualData, double[] modelData, DateTime startDate, int turningPoint)
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
                turningPointSeries.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Right;
            }
        }

        private Model FindBestModel(Model bestModel, ParameterRange f0Range, ParameterRange rRange, ParameterRange cRange, ParameterRange pRange, double[] timePoints, double[] results, double[] actualData, List<double> valuesCache)
        {
            double bestError = 0;
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, timePoints, results, actualData, valuesCache);
            }
            for (var f0 = f0Range.Min; f0 <= f0Range.Max; f0 += f0Range.Step)
            {
                for (var r = rRange.Min; r <= rRange.Max; r += rRange.Step)
                {
                    for (var c = cRange.Min; c <= cRange.Max; c += cRange.Step)
                    {
                        for (var p = pRange.Min; p <= pRange.Max; p += pRange.Step)
                        {
                            var model = new Model(f0, r, c, p);
                            var error = CalculateError(model, timePoints, results, actualData, valuesCache);
                            if (bestModel == null || bestError > error)
                            {
                                ConsoleWriteLine($"Error: {error}, F0: {model.F0}, R: {model.R}, C: {model.C}, P: {model.P}, R * C * P: {model.R * model.C * model.P}");
                                bestModel = model;
                                bestError = error;
                            }
                        }
                    }
                }
            }
            return bestModel;
        }

        private double CalculateError(Model model, double[] timePoints, double[] results, double[] actualData, List<double> valuesCache)
        {
            model.Calculate(timePoints, results, valuesCache);
            double error = 0;
            for (int i = 0; i < results.Length; i++)
            {
                var diff = results[i] - actualData[i];
                error += diff * diff;
            }
            return error;
        }
    }
}
