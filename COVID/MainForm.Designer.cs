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
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startButton = new System.Windows.Forms.Button();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.f0Label = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.oLabel = new System.Windows.Forms.Label();
            this.cLabel = new System.Windows.Forms.Label();
            this.pLabel = new System.Windows.Forms.Label();
            this.f0MinTextBox = new System.Windows.Forms.TextBox();
            this.f0MaxTextBox = new System.Windows.Forms.TextBox();
            this.rMaxTextBox = new System.Windows.Forms.TextBox();
            this.rMinTextBox = new System.Windows.Forms.TextBox();
            this.oMaxTextBox = new System.Windows.Forms.TextBox();
            this.oMinTextBox = new System.Windows.Forms.TextBox();
            this.cMaxTextBox = new System.Windows.Forms.TextBox();
            this.cMinTextBox = new System.Windows.Forms.TextBox();
            this.pMaxTextBox = new System.Windows.Forms.TextBox();
            this.pMinTextBox = new System.Windows.Forms.TextBox();
            this.skipLabel = new System.Windows.Forms.Label();
            this.skipTextBox = new System.Windows.Forms.TextBox();
            this.windowTextBox = new System.Windows.Forms.TextBox();
            this.windowLabel = new System.Windows.Forms.Label();
            this.isWeightedCheckBox = new System.Windows.Forms.CheckBox();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.stepLabel = new System.Windows.Forms.Label();
            this.factorTextBox = new System.Windows.Forms.TextBox();
            this.factorLabel = new System.Windows.Forms.Label();
            this.limitCCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BorderlineColor = System.Drawing.Color.Gray;
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1724, 682);
            this.chart.TabIndex = 0;
            this.chart.Text = "Chart";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(1946, 458);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 36);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(12, 700);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox.Size = new System.Drawing.Size(1724, 586);
            this.consoleTextBox.TabIndex = 2;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(1946, 500);
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
            this.f0Label.Location = new System.Drawing.Point(1781, 15);
            this.f0Label.Name = "f0Label";
            this.f0Label.Size = new System.Drawing.Size(28, 20);
            this.f0Label.TabIndex = 4;
            this.f0Label.Text = "F0";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(1788, 47);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(21, 20);
            this.rLabel.TabIndex = 5;
            this.rLabel.Text = "R";
            // 
            // oLabel
            // 
            this.oLabel.AutoSize = true;
            this.oLabel.Location = new System.Drawing.Point(1788, 79);
            this.oLabel.Name = "oLabel";
            this.oLabel.Size = new System.Drawing.Size(21, 20);
            this.oLabel.TabIndex = 6;
            this.oLabel.Text = "O";
            // 
            // cLabel
            // 
            this.cLabel.AutoSize = true;
            this.cLabel.Location = new System.Drawing.Point(1788, 111);
            this.cLabel.Name = "cLabel";
            this.cLabel.Size = new System.Drawing.Size(20, 20);
            this.cLabel.TabIndex = 7;
            this.cLabel.Text = "C";
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(1789, 143);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(19, 20);
            this.pLabel.TabIndex = 8;
            this.pLabel.Text = "P";
            // 
            // f0MinTextBox
            // 
            this.f0MinTextBox.Location = new System.Drawing.Point(1815, 12);
            this.f0MinTextBox.Name = "f0MinTextBox";
            this.f0MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MinTextBox.TabIndex = 9;
            // 
            // f0MaxTextBox
            // 
            this.f0MaxTextBox.Location = new System.Drawing.Point(1921, 12);
            this.f0MaxTextBox.Name = "f0MaxTextBox";
            this.f0MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MaxTextBox.TabIndex = 10;
            // 
            // rMaxTextBox
            // 
            this.rMaxTextBox.Location = new System.Drawing.Point(1921, 44);
            this.rMaxTextBox.Name = "rMaxTextBox";
            this.rMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMaxTextBox.TabIndex = 13;
            // 
            // rMinTextBox
            // 
            this.rMinTextBox.Location = new System.Drawing.Point(1815, 44);
            this.rMinTextBox.Name = "rMinTextBox";
            this.rMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMinTextBox.TabIndex = 12;
            // 
            // oMaxTextBox
            // 
            this.oMaxTextBox.Location = new System.Drawing.Point(1921, 76);
            this.oMaxTextBox.Name = "oMaxTextBox";
            this.oMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMaxTextBox.TabIndex = 16;
            // 
            // oMinTextBox
            // 
            this.oMinTextBox.Location = new System.Drawing.Point(1815, 76);
            this.oMinTextBox.Name = "oMinTextBox";
            this.oMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMinTextBox.TabIndex = 15;
            // 
            // cMaxTextBox
            // 
            this.cMaxTextBox.Location = new System.Drawing.Point(1921, 108);
            this.cMaxTextBox.Name = "cMaxTextBox";
            this.cMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.cMaxTextBox.TabIndex = 19;
            // 
            // cMinTextBox
            // 
            this.cMinTextBox.Location = new System.Drawing.Point(1815, 108);
            this.cMinTextBox.Name = "cMinTextBox";
            this.cMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.cMinTextBox.TabIndex = 18;
            // 
            // pMaxTextBox
            // 
            this.pMaxTextBox.Location = new System.Drawing.Point(1921, 140);
            this.pMaxTextBox.Name = "pMaxTextBox";
            this.pMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMaxTextBox.TabIndex = 22;
            // 
            // pMinTextBox
            // 
            this.pMinTextBox.Location = new System.Drawing.Point(1815, 140);
            this.pMinTextBox.Name = "pMinTextBox";
            this.pMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMinTextBox.TabIndex = 21;
            // 
            // skipLabel
            // 
            this.skipLabel.AutoSize = true;
            this.skipLabel.Location = new System.Drawing.Point(1769, 234);
            this.skipLabel.Name = "skipLabel";
            this.skipLabel.Size = new System.Drawing.Size(40, 20);
            this.skipLabel.TabIndex = 24;
            this.skipLabel.Text = "Skip";
            // 
            // skipTextBox
            // 
            this.skipTextBox.Location = new System.Drawing.Point(1815, 231);
            this.skipTextBox.Name = "skipTextBox";
            this.skipTextBox.Size = new System.Drawing.Size(100, 26);
            this.skipTextBox.TabIndex = 25;
            // 
            // windowTextBox
            // 
            this.windowTextBox.Location = new System.Drawing.Point(1815, 263);
            this.windowTextBox.Name = "windowTextBox";
            this.windowTextBox.Size = new System.Drawing.Size(100, 26);
            this.windowTextBox.TabIndex = 26;
            // 
            // windowLabel
            // 
            this.windowLabel.AutoSize = true;
            this.windowLabel.Location = new System.Drawing.Point(1744, 266);
            this.windowLabel.Name = "windowLabel";
            this.windowLabel.Size = new System.Drawing.Size(65, 20);
            this.windowLabel.TabIndex = 27;
            this.windowLabel.Text = "Window";
            // 
            // isWeightedCheckBox
            // 
            this.isWeightedCheckBox.AutoSize = true;
            this.isWeightedCheckBox.Location = new System.Drawing.Point(1815, 359);
            this.isWeightedCheckBox.Name = "isWeightedCheckBox";
            this.isWeightedCheckBox.Size = new System.Drawing.Size(103, 24);
            this.isWeightedCheckBox.TabIndex = 28;
            this.isWeightedCheckBox.Text = "Weighted";
            this.isWeightedCheckBox.UseVisualStyleBackColor = true;
            // 
            // stepTextBox
            // 
            this.stepTextBox.Location = new System.Drawing.Point(1815, 295);
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.Size = new System.Drawing.Size(100, 26);
            this.stepTextBox.TabIndex = 29;
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Location = new System.Drawing.Point(1766, 298);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(43, 20);
            this.stepLabel.TabIndex = 30;
            this.stepLabel.Text = "Step";
            // 
            // factorTextBox
            // 
            this.factorTextBox.Location = new System.Drawing.Point(1815, 327);
            this.factorTextBox.Name = "factorTextBox";
            this.factorTextBox.Size = new System.Drawing.Size(100, 26);
            this.factorTextBox.TabIndex = 31;
            // 
            // factorLabel
            // 
            this.factorLabel.AutoSize = true;
            this.factorLabel.Location = new System.Drawing.Point(1754, 330);
            this.factorLabel.Name = "factorLabel";
            this.factorLabel.Size = new System.Drawing.Size(55, 20);
            this.factorLabel.TabIndex = 32;
            this.factorLabel.Text = "Factor";
            // 
            // limitCCheckBox
            // 
            this.limitCCheckBox.AutoSize = true;
            this.limitCCheckBox.Location = new System.Drawing.Point(1815, 389);
            this.limitCCheckBox.Name = "limitCCheckBox";
            this.limitCCheckBox.Size = new System.Drawing.Size(83, 24);
            this.limitCCheckBox.TabIndex = 33;
            this.limitCCheckBox.Text = "Limit C";
            this.limitCCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2033, 1298);
            this.Controls.Add(this.limitCCheckBox);
            this.Controls.Add(this.factorLabel);
            this.Controls.Add(this.factorTextBox);
            this.Controls.Add(this.stepLabel);
            this.Controls.Add(this.stepTextBox);
            this.Controls.Add(this.isWeightedCheckBox);
            this.Controls.Add(this.windowLabel);
            this.Controls.Add(this.windowTextBox);
            this.Controls.Add(this.skipTextBox);
            this.Controls.Add(this.skipLabel);
            this.Controls.Add(this.pMaxTextBox);
            this.Controls.Add(this.pMinTextBox);
            this.Controls.Add(this.cMaxTextBox);
            this.Controls.Add(this.cMinTextBox);
            this.Controls.Add(this.oMaxTextBox);
            this.Controls.Add(this.oMinTextBox);
            this.Controls.Add(this.rMaxTextBox);
            this.Controls.Add(this.rMinTextBox);
            this.Controls.Add(this.f0MaxTextBox);
            this.Controls.Add(this.f0MinTextBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.cLabel);
            this.Controls.Add(this.oLabel);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.f0Label);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.startButton);
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
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label f0Label;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.Label oLabel;
        private System.Windows.Forms.Label cLabel;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TextBox f0MinTextBox;
        private System.Windows.Forms.TextBox f0MaxTextBox;
        private System.Windows.Forms.TextBox rMaxTextBox;
        private System.Windows.Forms.TextBox rMinTextBox;
        private System.Windows.Forms.TextBox oMaxTextBox;
        private System.Windows.Forms.TextBox oMinTextBox;
        private System.Windows.Forms.TextBox cMaxTextBox;
        private System.Windows.Forms.TextBox cMinTextBox;
        private System.Windows.Forms.TextBox pMaxTextBox;
        private System.Windows.Forms.TextBox pMinTextBox;
        private System.Windows.Forms.Label skipLabel;
        private System.Windows.Forms.TextBox skipTextBox;
        private System.Windows.Forms.TextBox windowTextBox;
        private System.Windows.Forms.Label windowLabel;
        private System.Windows.Forms.CheckBox isWeightedCheckBox;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.TextBox factorTextBox;
        private System.Windows.Forms.Label factorLabel;
        private System.Windows.Forms.CheckBox limitCCheckBox;
    }
}

