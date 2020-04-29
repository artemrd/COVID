using System;
using System.Collections.Generic;

namespace COVID
{
    public class Model
    {
        const double dt = 0.001;

        public Model(double f0, double i, double r, DateTime startDate, double orderDay, double c1, double c2, double p, double returnDay)
        {
            this.F0 = f0;
            this.I = i;
            this.R = r;
            this.StartDate = startDate;
            this.OrderDay = orderDay;
            this.C1 = c1;
            this.C2 = c2;
            this.P = p;
            this.ReturnDay = returnDay;
        }

        // Initial value
        public double F0 { get; }

        // Incubation time
        public double I { get; }

        // Recovery time
        public double R { get; }

        // Start and 'stay home' order day.
        public DateTime StartDate { get; }

        public double OrderDay { get; }

        // Contagiousness
        public double C1 { get; }

        public double C2 { get; }

        // Population
        public double P { get; }

        public double ReturnDay { get; }

        public void Calculate(double[] results, List<double> valuesCache)
        {
            valuesCache.Clear();

            var currentPoint = 0;

            var i = 0;
            var iShift = (int)Math.Round(I / dt);
            var rShift = (int)Math.Round(R / dt);
            double value = F0;
            valuesCache.Add(value);
            while (currentPoint < results.Length)
            {
                double t = i * dt;

                if (t >= currentPoint)
                {
                    results[currentPoint] = value;
                    currentPoint++;
                    if (currentPoint >= results.Length)
                    {
                        break;
                    }
                }

                int t_i = i - iShift;
                int t_ri = i - rShift - iShift;
                double t_iValue = t_i < 0 ? 0 : valuesCache[t_i];
                double t_riValue = t_ri < 0 ? 0 : valuesCache[t_ri];
                if (t < OrderDay || (ReturnDay > 0 && t > ReturnDay))
                {
                    value = value + C1 * (t_iValue - t_riValue) * (P - value) * dt;
                }
                else
                {
                    value = value + C2 * (t_iValue - t_riValue) * (P - value) * dt;
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
                $"I: {I}{separator}" +
                $"R: {R}{separator}" +
                $"OrderDate: {this.StartDate.AddDays(Math.Round(OrderDay)).ToShortDateString()} ({OrderDay}){separator}" +
                $"C1: {C1}{separator}" +
                $"C2: {C2}{separator}" +
                $"P: {P}{separator}" +
                (ReturnDay > 0 ? $"OrderDate: {this.StartDate.AddDays(Math.Round(ReturnDay)).ToShortDateString()} ({ReturnDay}){separator}" : "") +
                $"bestModel = new Model({F0}, {I}, {R}, startDate, {OrderDay}, {C1}, {C2}, {P}, {ReturnDay});";
        }
    }
}
