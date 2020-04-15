using System;
using System.Windows.Forms;

namespace COVID
{
    public class ParameterRange
    {
        public double Min;
        public double Max;
        public double Diff;

        public ParameterRange(TextBox minTextBox, TextBox maxTextBox)
        {
            this.Min = Convert.ToDouble(minTextBox.Text);
            this.Max = Convert.ToDouble(maxTextBox.Text);
            this.Diff = this.Max - this.Min;
        }

        public ParameterRange(double min, double max)
        {
            this.Min = min;
            this.Max = max;
            this.Diff = this.Max - this.Min;
        }

        public double GetRandom(Random rnd)
        {
            return Min + rnd.NextDouble() * Diff;
        }

        public void ToView(TextBox minTextBox, TextBox maxTextBox)
        {
            minTextBox.Text = Min.ToString();
            maxTextBox.Text = Max.ToString();
        }
    }
}
