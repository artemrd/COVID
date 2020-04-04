namespace COVID
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.calculateButton = new System.Windows.Forms.Button();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.f0Label = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.oLabel = new System.Windows.Forms.Label();
            this.cLabel = new System.Windows.Forms.Label();
            this.pLabel = new System.Windows.Forms.Label();
            this.f0MinTextBox = new System.Windows.Forms.TextBox();
            this.f0MaxTextBox = new System.Windows.Forms.TextBox();
            this.f0StepTextBox = new System.Windows.Forms.TextBox();
            this.rStepTextBox = new System.Windows.Forms.TextBox();
            this.rMaxTextBox = new System.Windows.Forms.TextBox();
            this.rMinTextBox = new System.Windows.Forms.TextBox();
            this.oStepTextBox = new System.Windows.Forms.TextBox();
            this.oMaxTextBox = new System.Windows.Forms.TextBox();
            this.oMinTextBox = new System.Windows.Forms.TextBox();
            this.cStepTextBox = new System.Windows.Forms.TextBox();
            this.cMaxTextBox = new System.Windows.Forms.TextBox();
            this.cMinTextBox = new System.Windows.Forms.TextBox();
            this.pStepTextBox = new System.Windows.Forms.TextBox();
            this.pMaxTextBox = new System.Windows.Forms.TextBox();
            this.pMinTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BorderlineColor = System.Drawing.Color.Gray;
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1623, 674);
            this.chart.TabIndex = 0;
            this.chart.Text = "Chart";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(1450, 1284);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(104, 36);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(12, 692);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox.Size = new System.Drawing.Size(1623, 586);
            this.consoleTextBox.TabIndex = 2;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(1560, 1284);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 36);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // f0Label
            // 
            this.f0Label.AutoSize = true;
            this.f0Label.Location = new System.Drawing.Point(1674, 15);
            this.f0Label.Name = "f0Label";
            this.f0Label.Size = new System.Drawing.Size(28, 20);
            this.f0Label.TabIndex = 4;
            this.f0Label.Text = "F0";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(1681, 48);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(21, 20);
            this.rLabel.TabIndex = 5;
            this.rLabel.Text = "R";
            // 
            // oLabel
            // 
            this.oLabel.AutoSize = true;
            this.oLabel.Location = new System.Drawing.Point(1681, 80);
            this.oLabel.Name = "oLabel";
            this.oLabel.Size = new System.Drawing.Size(21, 20);
            this.oLabel.TabIndex = 6;
            this.oLabel.Text = "O";
            // 
            // cLabel
            // 
            this.cLabel.AutoSize = true;
            this.cLabel.Location = new System.Drawing.Point(1681, 112);
            this.cLabel.Name = "cLabel";
            this.cLabel.Size = new System.Drawing.Size(20, 20);
            this.cLabel.TabIndex = 7;
            this.cLabel.Text = "C";
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(1683, 144);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(19, 20);
            this.pLabel.TabIndex = 8;
            this.pLabel.Text = "P";
            // 
            // f0MinTextBox
            // 
            this.f0MinTextBox.Location = new System.Drawing.Point(1708, 13);
            this.f0MinTextBox.Name = "f0MinTextBox";
            this.f0MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MinTextBox.TabIndex = 9;
            // 
            // f0MaxTextBox
            // 
            this.f0MaxTextBox.Location = new System.Drawing.Point(1814, 13);
            this.f0MaxTextBox.Name = "f0MaxTextBox";
            this.f0MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MaxTextBox.TabIndex = 10;
            // 
            // f0StepTextBox
            // 
            this.f0StepTextBox.Location = new System.Drawing.Point(1920, 13);
            this.f0StepTextBox.Name = "f0StepTextBox";
            this.f0StepTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0StepTextBox.TabIndex = 11;
            // 
            // rStepTextBox
            // 
            this.rStepTextBox.Location = new System.Drawing.Point(1920, 45);
            this.rStepTextBox.Name = "rStepTextBox";
            this.rStepTextBox.Size = new System.Drawing.Size(100, 26);
            this.rStepTextBox.TabIndex = 14;
            // 
            // rMaxTextBox
            // 
            this.rMaxTextBox.Location = new System.Drawing.Point(1814, 45);
            this.rMaxTextBox.Name = "rMaxTextBox";
            this.rMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMaxTextBox.TabIndex = 13;
            // 
            // rMinTextBox
            // 
            this.rMinTextBox.Location = new System.Drawing.Point(1708, 45);
            this.rMinTextBox.Name = "rMinTextBox";
            this.rMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMinTextBox.TabIndex = 12;
            // 
            // oStepTextBox
            // 
            this.oStepTextBox.Location = new System.Drawing.Point(1920, 77);
            this.oStepTextBox.Name = "oStepTextBox";
            this.oStepTextBox.Size = new System.Drawing.Size(100, 26);
            this.oStepTextBox.TabIndex = 17;
            // 
            // oMaxTextBox
            // 
            this.oMaxTextBox.Location = new System.Drawing.Point(1814, 77);
            this.oMaxTextBox.Name = "oMaxTextBox";
            this.oMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMaxTextBox.TabIndex = 16;
            // 
            // oMinTextBox
            // 
            this.oMinTextBox.Location = new System.Drawing.Point(1708, 77);
            this.oMinTextBox.Name = "oMinTextBox";
            this.oMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMinTextBox.TabIndex = 15;
            // 
            // cStepTextBox
            // 
            this.cStepTextBox.Location = new System.Drawing.Point(1920, 109);
            this.cStepTextBox.Name = "cStepTextBox";
            this.cStepTextBox.Size = new System.Drawing.Size(100, 26);
            this.cStepTextBox.TabIndex = 20;
            // 
            // cMaxTextBox
            // 
            this.cMaxTextBox.Location = new System.Drawing.Point(1814, 109);
            this.cMaxTextBox.Name = "cMaxTextBox";
            this.cMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.cMaxTextBox.TabIndex = 19;
            // 
            // cMinTextBox
            // 
            this.cMinTextBox.Location = new System.Drawing.Point(1708, 109);
            this.cMinTextBox.Name = "cMinTextBox";
            this.cMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.cMinTextBox.TabIndex = 18;
            // 
            // pStepTextBox
            // 
            this.pStepTextBox.Location = new System.Drawing.Point(1920, 141);
            this.pStepTextBox.Name = "pStepTextBox";
            this.pStepTextBox.Size = new System.Drawing.Size(100, 26);
            this.pStepTextBox.TabIndex = 23;
            // 
            // pMaxTextBox
            // 
            this.pMaxTextBox.Location = new System.Drawing.Point(1814, 141);
            this.pMaxTextBox.Name = "pMaxTextBox";
            this.pMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMaxTextBox.TabIndex = 22;
            // 
            // pMinTextBox
            // 
            this.pMinTextBox.Location = new System.Drawing.Point(1708, 141);
            this.pMinTextBox.Name = "pMinTextBox";
            this.pMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMinTextBox.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2033, 1332);
            this.Controls.Add(this.pStepTextBox);
            this.Controls.Add(this.pMaxTextBox);
            this.Controls.Add(this.pMinTextBox);
            this.Controls.Add(this.cStepTextBox);
            this.Controls.Add(this.cMaxTextBox);
            this.Controls.Add(this.cMinTextBox);
            this.Controls.Add(this.oStepTextBox);
            this.Controls.Add(this.oMaxTextBox);
            this.Controls.Add(this.oMinTextBox);
            this.Controls.Add(this.rStepTextBox);
            this.Controls.Add(this.rMaxTextBox);
            this.Controls.Add(this.rMinTextBox);
            this.Controls.Add(this.f0StepTextBox);
            this.Controls.Add(this.f0MaxTextBox);
            this.Controls.Add(this.f0MinTextBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.cLabel);
            this.Controls.Add(this.oLabel);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.f0Label);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.chart);
            this.Name = "MainForm";
            this.Text = "COVID";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label f0Label;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.Label oLabel;
        private System.Windows.Forms.Label cLabel;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TextBox f0MinTextBox;
        private System.Windows.Forms.TextBox f0MaxTextBox;
        private System.Windows.Forms.TextBox f0StepTextBox;
        private System.Windows.Forms.TextBox rStepTextBox;
        private System.Windows.Forms.TextBox rMaxTextBox;
        private System.Windows.Forms.TextBox rMinTextBox;
        private System.Windows.Forms.TextBox oStepTextBox;
        private System.Windows.Forms.TextBox oMaxTextBox;
        private System.Windows.Forms.TextBox oMinTextBox;
        private System.Windows.Forms.TextBox cStepTextBox;
        private System.Windows.Forms.TextBox cMaxTextBox;
        private System.Windows.Forms.TextBox cMinTextBox;
        private System.Windows.Forms.TextBox pStepTextBox;
        private System.Windows.Forms.TextBox pMaxTextBox;
        private System.Windows.Forms.TextBox pMinTextBox;
    }
}

