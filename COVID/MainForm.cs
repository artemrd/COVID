using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
                var dates = new List<string>();
                var actualData = new List<double>();
                using (var actualDataStream = new System.IO.StreamReader(@"D:\repos\COVID\COVID.txt"))
                {
                    string line;
                    while ((line = actualDataStream.ReadLine()) != null)
                    {
                        var tokens = line.Split('\t');
                        if (tokens.Length == 2 && !string.IsNullOrEmpty(tokens[1]))
                        {
                            dates.Add(tokens[0]);
                            actualData.Add(Convert.ToDouble(tokens[1]));
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                var timePoints = new double[actualData.Count];
                for (int i = 0; i < timePoints.Length; i++)
                {
                    timePoints[i] = i;
                }

                var values = new List<double>();

                //double f0 = 0.2; // Initial value
                //double r = 14; // Recovery time
                //double c = 3E-6; // Contagiousness
                //double p = 50000; // Population

                //var model = new Model(f0, r, c, p);
                //var originalModel = model;

                //var data = model.Calculate(timePoints, values);
                //double error = 0;
                //for (int i = 0; i < timePoints.Length; i++)
                //{
                //    var diff = data[i] - actualData[i];
                //    error = error + (diff * diff);
                //    ConsoleWriteLine($"{timePoints[i],-8}{data[i],-24}{Math.Round(data[i]),-8}{actualData[i]}");
                //}
                //ConsoleWriteLine($"Error: {error}");
                //ConsoleWriteLine();

                //bool updated;
                //bool shake = false;
                //int shakeCount = 0;
                //var rnd = new Random();
                //do
                //{
                //    updated = false;
                //    for (int i = 0; i < 100; i++)
                //    {
                //        double factor = 0.001;
                //        double df0 = model.F0 * rnd.NextDouble() * factor;
                //        double dr = model.R * rnd.NextDouble() * factor;
                //        double dc = model.C * rnd.NextDouble() * factor;
                //        double dp = model.P * rnd.NextDouble() * factor;

                //        if (shake)
                //        {
                //            df0 = model.F0 * rnd.NextDouble();
                //            dr = model.R * rnd.NextDouble();
                //            dc = model.C * rnd.NextDouble();
                //            dp = model.P * rnd.NextDouble();
                //            shake = false;
                //        }

                //        var newModel = GetBestModel(
                //            model,
                //            timePoints,
                //            actualData,
                //            values,
                //            new Model(model.F0 + df0, model.R, model.C, model.P),
                //            new Model(model.F0 - df0, model.R, model.C, model.P),
                //            new Model(model.F0, model.R + dr, model.C, model.P),
                //            new Model(model.F0, model.R - dr, model.C, model.P),
                //            new Model(model.F0, model.R, model.C + dc, model.P),
                //            new Model(model.F0, model.R, model.C - dc, model.P),
                //            new Model(model.F0, model.R, model.C, model.P + dp),
                //            new Model(model.F0, model.R, model.C, model.P - dp));

                //        //double df0 = model.F0 / 10;
                //        //double dr = model.R / 10;
                //        //double dc = model.C / 10;
                //        //double dp = model.P / 10;

                //        //var newModel = GetBestModel(
                //        //    model,
                //        //    timePoints,
                //        //    actualData,
                //        //    values,
                //        //    new Model(model.F0 + df0, model.R, model.C, model.P),
                //        //    new Model(model.F0 - df0, model.R, model.C, model.P),
                //        //    new Model(model.F0, model.R + dr, model.C, model.P),
                //        //    new Model(model.F0, model.R - dr, model.C, model.P),
                //        //    new Model(model.F0, model.R, model.C + dc, model.P),
                //        //    new Model(model.F0, model.R, model.C - dc, model.P),
                //        //    new Model(model.F0, model.R, model.C, model.P + dp),
                //        //    new Model(model.F0, model.R, model.C, model.P - dp));

                //        if (newModel != model)
                //        {
                //            model = newModel;
                //            updated = true;
                //        }
                //        else
                //        {
                //            if (shakeCount < 1000)
                //            {
                //                shakeCount++;
                //                shake = true;
                //                //ConsoleWriteLine($"Shake {shakeCount}");
                //            }
                //            else
                //            {
                //                break;
                //            }
                //        }
                //    }

                //    var newError = CalculateError(model, timePoints, actualData, values);
                //    if (updated)
                //    {
                //        ConsoleWriteLine($"Error: {newError}, F0: {model.F0}, R: {model.R}, C: {model.C}, P: {model.P}");
                //    }
                //    error = newError;
                //}
                //while (updated || shake);

                var f0Range = new ParameterRange(0.2, 0.3, 0.01); // COVID.txt
                //var f0Range = new ParameterRange(1, 100, 1); // COVID1.txt
                var rRange = new ParameterRange(10, 20, 1);
                var cRange = new ParameterRange(1E-6, 1E-5, 1E-6);
                var pRange = new ParameterRange(10000, 100000, 1000);

                //var f0Range = new ParameterRange(0.01, 1, 0.01);
                //var rRange = new ParameterRange(5, 100, 1);
                //var cRange = new ParameterRange(1E-6, 1E-5, 1E-6);
                //var pRange = new ParameterRange(10000, 100000, 1000);

                var model = FindBestModel(null, f0Range, rRange, cRange, pRange, timePoints, actualData, values);

                ConsoleWriteLine();

                for (int i = 0; i < 1; i++)
                {
                    f0Range = new ParameterRange(model.F0 - f0Range.Step, model.F0 + f0Range.Step, f0Range.Step / 10);
                    rRange = new ParameterRange(model.R - rRange.Step, model.R + rRange.Step, rRange.Step / 10);
                    cRange = new ParameterRange(model.C - cRange.Step, model.C + cRange.Step, cRange.Step / 10);
                    pRange = new ParameterRange(model.P - pRange.Step, model.P + pRange.Step, pRange.Step / 10);

                    model = FindBestModel(model, f0Range, rRange, cRange, pRange, timePoints, actualData, values);

                    ConsoleWriteLine();
                }

                var error = CalculateError(model, timePoints, actualData, values);

                timePoints = new double[actualData.Count * 2];
                for (int i = 0; i < timePoints.Length; i++)
                {
                    timePoints[i] = i;
                }

                var data = model.Calculate(timePoints, values);
                var startDate = DateTime.Parse(dates[0]);
                var date = startDate;
                int turningPoint = -1;
                for (int i = 0; i < timePoints.Length; i++)
                {
                    string d2 = "";
                    if (i > 0 && i < data.Length - 1)
                    {
                        if (data[i - 1] + data[i + 1] - 2 * data[i] > 0)
                        {
                            d2 = "+";
                            turningPoint = -1;
                        }
                        else if (data[i - 1] + data[i + 1] - 2 * data[i] < 0)
                        {
                            d2 = "-";
                            if (turningPoint < 0)
                            {
                                turningPoint = i;
                            }
                        }
                    }

                    string ad2 = "";
                    if (i > 0 && i < actualData.Count - 1)
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

                    if (i < actualData.Count)
                    {
                        ConsoleWriteLine($"{date.ToShortDateString(),-10} {timePoints[i],-8} {data[i],-24} {Math.Round(data[i]),-8} {d2,-1} {actualData[i],-8} {ad2}");
                    }
                    else
                    {
                        ConsoleWriteLine($"{date.ToShortDateString(),-10} {timePoints[i],-8} {data[i],-24} {Math.Round(data[i]),-8} {d2,-1} {"",-8} {ad2}");
                    }
                    date = date.AddDays(1);
                }
                ConsoleWriteLine();
                //ConsoleWriteLine($"F0: {originalModel.F0}, R: {originalModel.R}, C: {originalModel.C}, P: {originalModel.P}");
                //ConsoleWriteLine();
                ConsoleWriteLine($"Error: {error}");
                ConsoleWriteLine($"F0: {model.F0}");
                ConsoleWriteLine($"R: {model.R}");
                ConsoleWriteLine($"C: {model.C}");
                ConsoleWriteLine($"P: {model.P}");
                ConsoleWriteLine($"C * P: {model.C * model.P}");

                chart.Invoke(new Action<List<double>, double[], DateTime, int>(PopulateChart), new object[] { actualData, data, startDate, turningPoint });
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

        void PopulateChart(List<double> actualData, double[] modelData, DateTime start, int turningPoint)
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
                    point.AxisLabel = start.AddDays(i).ToShortDateString();
                }
            }

            {
                var actualSeries = chart.Series.Add("Actual");
                actualSeries.ChartType = SeriesChartType.Line;
                actualSeries.Color = Color.Red;
                actualSeries.BorderWidth = 3;
                for (int i = 0; i < actualData.Count; i++)
                {
                    var point = actualSeries.Points[actualSeries.Points.AddXY(i, actualData[i])];
                    point.AxisLabel = start.AddDays(i).ToShortDateString();
                }
            }

            {
                var turningPointSeries = chart.Series.Add("Turning point");
                turningPointSeries.ChartType = SeriesChartType.Point;
                turningPointSeries.Color = Color.Green;
                turningPointSeries.BorderWidth = 7;
                var point = turningPointSeries.Points[turningPointSeries.Points.AddXY(turningPoint, modelData[turningPoint])];
                point.Label = point.AxisLabel = start.AddDays(turningPoint).ToShortDateString();
            }
        }

        static Model GetBestModel(Model referenceModel, double[] timePoints, List<double> actualData, List<double> values, params Model[] models)
        {
            var referenceError = CalculateError(referenceModel, timePoints, actualData, values);
            var candidate = models.Select(model => (model, CalculateError(model, timePoints, actualData, values))).OrderBy(x => x.Item2).First();
            if (candidate.Item2 < referenceError)
            {
                return candidate.model;
            }
            else
            {
                return referenceModel;
            }
        }

        Model FindBestModel(Model bestModel, ParameterRange f0Range, ParameterRange rRange, ParameterRange cRange, ParameterRange pRange, double[] timePoints, List<double> actualData, List<double> values)
        {
            double bestError = 0;
            if (bestModel != null)
            {
                bestError = CalculateError(bestModel, timePoints, actualData, values);
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
                            var error = CalculateError(model, timePoints, actualData, values);
                            if (bestModel == null || bestError > error)
                            {
                                ConsoleWriteLine($"Error: {error}, F0: {model.F0}, R: {model.R}, C: {model.C}, P: {model.P}, C * P: {model.C * model.P}");
                                bestModel = model;
                                bestError = error;
                            }
                        }
                    }
                }
            }
            return bestModel;
        }

        static double CalculateError(Model model, double[] timePoints, List<double> actualData, List<double> values)
        {
            var data = model.Calculate(timePoints, values);
            double error = 0;
            for (int i = 0; i < data.Length; i++)
            {
                var diff = data[i] - actualData[i];
                error += diff * diff;
            }
            return error;
        }
    }
}
