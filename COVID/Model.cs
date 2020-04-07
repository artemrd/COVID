using System;
using System.Collections.Generic;

namespace COVID
{
    public class Model
    {
        const double dt = 0.001;

        public Model(double f0, double r, DateTime startDate, double orderDay, double c1, double c2, double p1, double p2)
        {
            this.F0 = f0;
            this.R = r;
            this.StartDate = startDate;
            this.OrderDay = orderDay;
            this.C1 = c1;
            this.C2 = c2;
            this.P1 = p1;
            this.P2 = p2;
        }

        // Initial value
        public double F0 { get; }

        // Recovery time
        public double R { get; }

        // Start and 'stay home' order day.
        public DateTime StartDate { get; }

        public double OrderDay { get; }

        // Contagiousness
        public double C1 { get; }

        public double C2 { get; }

        // Population
        public double P1 { get; }

        public double P2 { get; }

        public void Calculate(double[] timePoints, double[] results, List<double> valuesCache)
        {
            valuesCache.Clear();

            var currentPointIndex = 0;
            var currentPoint = timePoints[currentPointIndex];

            var i = 0;
            var rShift = (int)Math.Round(R / dt);
            double value = F0;
            valuesCache.Add(value);
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
                double t_rValue = t_r < 0 ? 0 : valuesCache[t_r];
                if (t < OrderDay)
                {
                    value = value + C1 * (value - t_rValue) * (P1 - value) * dt;
                }
                else
                {
                    value = value + C2 * (value - t_rValue) * (P2 - value) * dt;
                }
                valuesCache.Add(value);

                i++;
            }
        }

        public override string ToString()
        {
            return ToString(", ");
        }

        public string ToString(string separator)
        {
            return $"F0: {F0}{separator}" +
                $"R: {R}{separator}" +
                $"OrderDate: {this.StartDate.AddDays(Math.Round(OrderDay)).ToShortDateString()} ({OrderDay}){separator}" +
                $"C1: {C1}{separator}" +
                $"C2: {C2}{separator}" +
                $"P1: {P1}{separator}" +
                $"P2: {P2}{separator}" +
                $"R * C1 * P1: {R * C1 * P1}{separator}" +
                $"R * C2 * P2: {R * C2 * P2}{separator}" +
                $"1 - C2 / C1: {1.0 - C2 / C1}";
        }
    }
}
