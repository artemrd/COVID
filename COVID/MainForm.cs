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

                var values = new List<double>();

                var f0Range = new ParameterRange(0.2, 0.3, 0.01);
                var rRange = new ParameterRange(10, 20, 1);
                var cRange = new ParameterRange(1E-6, 1E-5, 1E-6);
                var pRange = new ParameterRange(10000, 100000, 1000);

                var model = FindBestModel(null, f0Range, rRange, cRange, pRange, timePoints, results, actualData, values);

                ConsoleWriteLine();

                for (int i = 0; i < 1; i++)
                {
                    f0Range = new ParameterRange(model.F0 - f0Range.Step, model.F0 + f0Range.Step, f0Range.Step / 10);
                    rRange = new ParameterRange(model.R - rRange.Step, model.R + rRange.Step, rRange.Step / 10);
                    cRange = new ParameterRange(model.C - cRange.Step, model.C + cRange.Step, cRange.Step / 10);
                    pRange = new ParameterRange(model.P - pRange.Step, model.P + pRange.Step, pRange.Step / 10);

                    model = FindBestModel(model, f0Range, rRange, cRange, pRange, timePoints, results, actualData, values);

                    ConsoleWriteLine();
                }

                var error = CalculateError(model, timePoints, results, actualData, values);

                timePoints = new double[actualData.Length * 2];
                for (int i = 0; i < timePoints.Length; i++)
                {
                    timePoints[i] = i;
                }
                results = new double[timePoints.Length];

                model.Calculate(timePoints, results, values);
                int turningPoint = -1;
                for (int i = 0; i < timePoints.Length; i++)
                {
                    string d2 = "";
                    if (i > 0 && i < results.Length - 1)
                    {
                        if (results[i - 1] + results[i + 1] - 2 * results[i] > 0)
                        {
                            d2 = "+";
                            turningPoint = -1;
                        }
                        else if (results[i - 1] + results[i + 1] - 2 * results[i] < 0)
                        {
                            d2 = "-";
                            if (turningPoint < 0)
                            {
                                turningPoint = i;
                            }
                        }
                    }

                    string ad2 = "";
                    if (i > 0 && i < actualData.Length - 1)
                    {
                        if (actualData[i - 1] + actualData[i + 1] - 2 * actualData[i] > 0)
                        {
                            ad2 = "+";
                        }
                        else if (actualData[i - 1] + actualData[i + 1] - 2 * actualData[i] < 0)
                        {
                            ad2 = "-";
                        }
                    }

                    if (i < actualData.Length)
                    {
                        ConsoleWriteLine($"{startDate.AddDays(i).ToShortDateString(),-10} {timePoints[i],-8} {results[i],-24} {Math.Round(results[i]),-8} {d2,-1} {actualData[i],-8} {ad2}");
                    }
                    else
                    {
                        ConsoleWriteLine($"{startDate.AddDays(i).ToShortDateString(),-10} {timePoints[i],-8} {results[i],-24} {Math.Round(results[i]),-8} {d2,-1} {"",-8} {ad2}");
                    }
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
            if (consoleTextBox.InvokeRequired)
            {
                consoleTextBox.Invoke(new Action<string>(ConsoleWriteLineDelegate), new object[] { text });
            }
            else
            {
                ConsoleWriteLineDelegate(text);
            }
        }

        private void ConsoleWriteLineDelegate(string text)
        {
            consoleTextBox.AppendText(text);
            consoleTextBox.AppendText("\r\n");
        }

        void PopulateChart(double[] actualData, double[] modelData, DateTime startDate, int turningPoint)
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
        }

        Model FindBestModel(Model bestModel, ParameterRange f0Range, ParameterRange rRange, ParameterRange cRange, ParameterRange pRange, double[] timePoints, double[] results, double[] actualData, List<double> values)
        {
            double bestError = 0;
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, timePoints, results, actualData, values);
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
                            var error = CalculateError(model, timePoints, results, actualData, values);
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

        static double CalculateError(Model model, double[] timePoints, double[] results, double[] actualData, List<double> values)
        {
            model.Calculate(timePoints, results, values);
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
