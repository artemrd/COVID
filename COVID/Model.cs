using System;
using System.Collections.Generic;
using System.Text;

namespace COVID
{
    public class Model
    {
        const double dt = 0.001;

        public Model(double f0, double i, double r, DateTime startDate, CFactor[] c, double p)
        {
            this.F0 = f0;
            this.I = i;
            this.R = r;
            this.StartDate = startDate;
            this.C = c;
            this.P = p;
        }

        // Initial value
        public double F0 { get; }

        // Incubation time
        public double I { get; }

        // Recovery time
        public double R { get; }

        // Start and 'stay home' order day.
        public DateTime StartDate { get; }

        // Contagiousness
        public CFactor[] C { get; }

        // Population
        public double P { get; }

        public void Calculate(double[] results, List<double> valuesCache)
        {
            valuesCache.Clear();

            var currentPoint = 0;
            var currentCIndex = 0;
            var currentC = C[currentCIndex];

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

                if (t > currentC.EndDay && currentCIndex < C.Length - 1)
                {
                    currentCIndex++;
                    currentC = C[currentCIndex];
                }

                int t_i = i - iShift;
                int t_ri = i - rShift - iShift;
                double t_iValue = t_i < 0 ? 0 : valuesCache[t_i];
                double t_riValue = t_ri < 0 ? 0 : valuesCache[t_ri];
                value = value + currentC.Value * (t_iValue - t_riValue) * (P - value) * dt;
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
            var sb = new StringBuilder();
            sb.Append($"F0: {F0}{separator}");
            sb.Append($"I: {I}{separator}");
            sb.Append($"R: {R}{separator}");
            for (int i = 0; i < C.Length; i++)
            {
                sb.Append($"C{i}: {C[i].Value}");
                if (i < C.Length - 1)
                {
                    sb.Append($", end date: {this.StartDate.AddDays(Math.Round(C[i].EndDay)).ToShortDateString()}");
                }
                sb.Append(separator);
            }
            sb.Append($"P: {P}{separator}");
            //sb.Append($"bestModel = new Model({F0}, {I}, {R}, startDate, {OrderDay}, {C1}, {C2}, {P}, {ReturnDay});");
            return sb.ToString();
        }
    }

    public struct CFactor : IComparable<CFactor>
    {
        public double Value;
        public double EndDay;

        public CFactor(double value, double endDay)
        {
            Value = value;
            EndDay = endDay;
        }

        public int CompareTo(CFactor other)
        {
            return EndDay.CompareTo(other.EndDay);
        }
    }
}
