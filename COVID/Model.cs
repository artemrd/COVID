using System;
using System.Collections.Generic;

namespace COVID
{
    public class Model
    {
        const double dt = 0.001;

        public Model(double f0, double r, double c, double p)
        {
            this.F0 = f0;
            this.R = r;
            this.C = c;
            this.P = p;
        }

        // Initial value
        public double F0 { get; }

        // Recovery time
        public double R { get; }

        // Contagiousness
        public double C { get; }

        // Population
        public double P { get; }

        public double[] Calculate(double[] timePoints, List<double> values)
        {
            values.Clear();
            var results = new double[timePoints.Length];

            var currentPointIndex = 0;
            var currentPoint = timePoints[currentPointIndex];

            var i = 0;
            var rShift = (int)Math.Round(R / dt);
            double value = F0;
            values.Add(value);
            while (currentPointIndex < timePoints.Length)
            {
                double t = i * dt;

                if (t >= currentPoint)
                {
                    results[currentPointIndex] = value;
                    currentPointIndex++;
                    if (currentPointIndex < timePoints.Length)
                    {
                        currentPoint = timePoints[currentPointIndex];
                    }
                    else
                    {
                        break;
                    }
                }

                int t_r = i - rShift;
                double t_rValue = t_r < 0 ? 0 : values[t_r];
                value = value + C * (value - t_rValue) * (P - value) * dt;
                values.Add(value);

                i++;
            }

            return results;
        }
    }
}
