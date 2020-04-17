using System;
using System.Windows.Forms;

namespace COVID
{
    public class ParameterRange
    {
        public double Min;
        public double Max;
        public double Steps;
        public double Diff;

        public ParameterRange(TextBox minTextBox, TextBox maxTextBox, TextBox stepsTextBox)
        {
            this.Min = Convert.ToDouble(minTextBox.Text);
            this.Max = Convert.ToDouble(maxTextBox.Text);
            this.Steps = Convert.ToDouble(stepsTextBox.Text);
            this.Diff = this.Max - this.Min;
        }

        public ParameterRange(double min, double max, double steps)
        {
            this.Min = min;
            this.Max = max;
            this.Steps = steps;
            this.Diff = this.Max - this.Min;
        }

        public double GetRandom(Random rnd)
        {
            return Min + rnd.NextDouble() * Diff;
        }

        public void ToView(TextBox minTextBox, TextBox maxTextBox, TextBox stepsTextBox)
        {
            minTextBox.Text = Min.ToString();
            maxTextBox.Text = Max.ToString();
            stepsTextBox.Text = Steps.ToString();
        }

        public double Trim(double d)
        {
            return Math.Min(Math.Max(d, Min), Max);
        }
    }
}
