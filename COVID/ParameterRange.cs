namespace COVID
{
    public class ParameterRange
    {
        public double Min;
        public double Max;
        public double Step;

        public ParameterRange(double min, double max, double step)
        {
            this.Min = min;
            this.Max = max;
            this.Step = step;
        }
    }
}
