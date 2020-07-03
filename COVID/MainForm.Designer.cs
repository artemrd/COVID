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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startButton = new System.Windows.Forms.Button();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.f0Label = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.cLabel = new System.Windows.Forms.Label();
            this.pLabel = new System.Windows.Forms.Label();
            this.f0MinTextBox = new System.Windows.Forms.TextBox();
            this.f0MaxTextBox = new System.Windows.Forms.TextBox();
            this.rMaxTextBox = new System.Windows.Forms.TextBox();
            this.rMinTextBox = new System.Windows.Forms.TextBox();
            this.cMaxTextBox = new System.Windows.Forms.TextBox();
            this.cMinTextBox = new System.Windows.Forms.TextBox();
            this.pMaxTextBox = new System.Windows.Forms.TextBox();
            this.pMinTextBox = new System.Windows.Forms.TextBox();
            this.stepFactorTextBox = new System.Windows.Forms.TextBox();
            this.stepFactorLabel = new System.Windows.Forms.Label();
            this.filterFactorTextBox = new System.Windows.Forms.TextBox();
            this.filterFactorLabel = new System.Windows.Forms.Label();
            this.trainingParametersLabel = new System.Windows.Forms.Label();
            this.modelParametersLabel = new System.Windows.Forms.Label();
            this.f0StepsTextBox = new System.Windows.Forms.TextBox();
            this.rStepsTextBox = new System.Windows.Forms.TextBox();
            this.cStepsTextBox = new System.Windows.Forms.TextBox();
            this.pStepsTextBox = new System.Windows.Forms.TextBox();
            this.cEndDayStepsTextBox = new System.Windows.Forms.TextBox();
            this.cEndDayMaxTextBox = new System.Windows.Forms.TextBox();
            this.cEndDayMinTextBox = new System.Windows.Forms.TextBox();
            this.cedLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.returnDateTextBox = new System.Windows.Forms.TextBox();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.iMinTextBox = new System.Windows.Forms.TextBox();
            this.iMaxTextBox = new System.Windows.Forms.TextBox();
            this.iStepsTextBox = new System.Windows.Forms.TextBox();
            this.iLabel = new System.Windows.Forms.Label();
            this.windowTextBox = new System.Windows.Forms.TextBox();
            this.windowLabel = new System.Windows.Forms.Label();
            this.skipTextBox = new System.Windows.Forms.TextBox();
            this.skipLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BorderlineColor = System.Drawing.Color.Gray;
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1724, 682);
            this.chart.TabIndex = 99;
            this.chart.TabStop = false;
            this.chart.Text = "Chart";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(2057, 489);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 36);
            this.startButton.TabIndex = 26;
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
            this.consoleTextBox.TabIndex = 99;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(2057, 531);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 36);
            this.stopButton.TabIndex = 27;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // f0Label
            // 
            this.f0Label.AutoSize = true;
            this.f0Label.Location = new System.Drawing.Point(1786, 35);
            this.f0Label.Name = "f0Label";
            this.f0Label.Size = new System.Drawing.Size(28, 20);
            this.f0Label.TabIndex = 1;
            this.f0Label.Text = "F0";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(1793, 99);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(21, 20);
            this.rLabel.TabIndex = 5;
            this.rLabel.Text = "R";
            // 
            // cLabel
            // 
            this.cLabel.AutoSize = true;
            this.cLabel.Location = new System.Drawing.Point(1794, 131);
            this.cLabel.Name = "cLabel";
            this.cLabel.Size = new System.Drawing.Size(20, 20);
            this.cLabel.TabIndex = 7;
            this.cLabel.Text = "C";
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(1795, 198);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(19, 20);
            this.pLabel.TabIndex = 8;
            this.pLabel.Text = "P";
            // 
            // f0MinTextBox
            // 
            this.f0MinTextBox.Location = new System.Drawing.Point(1820, 32);
            this.f0MinTextBox.Name = "f0MinTextBox";
            this.f0MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MinTextBox.TabIndex = 0;
            // 
            // f0MaxTextBox
            // 
            this.f0MaxTextBox.Location = new System.Drawing.Point(1926, 32);
            this.f0MaxTextBox.Name = "f0MaxTextBox";
            this.f0MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MaxTextBox.TabIndex = 1;
            // 
            // rMaxTextBox
            // 
            this.rMaxTextBox.Location = new System.Drawing.Point(1926, 96);
            this.rMaxTextBox.Name = "rMaxTextBox";
            this.rMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMaxTextBox.TabIndex = 7;
            // 
            // rMinTextBox
            // 
            this.rMinTextBox.Location = new System.Drawing.Point(1820, 96);
            this.rMinTextBox.Name = "rMinTextBox";
            this.rMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMinTextBox.TabIndex = 6;
            // 
            // cMaxTextBox
            // 
            this.cMaxTextBox.Location = new System.Drawing.Point(1926, 128);
            this.cMaxTextBox.Name = "cMaxTextBox";
            this.cMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.cMaxTextBox.TabIndex = 13;
            // 
            // cMinTextBox
            // 
            this.cMinTextBox.Location = new System.Drawing.Point(1820, 128);
            this.cMinTextBox.Name = "cMinTextBox";
            this.cMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.cMinTextBox.TabIndex = 12;
            // 
            // pMaxTextBox
            // 
            this.pMaxTextBox.Location = new System.Drawing.Point(1926, 192);
            this.pMaxTextBox.Name = "pMaxTextBox";
            this.pMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMaxTextBox.TabIndex = 19;
            // 
            // pMinTextBox
            // 
            this.pMinTextBox.Location = new System.Drawing.Point(1820, 192);
            this.pMinTextBox.Name = "pMinTextBox";
            this.pMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMinTextBox.TabIndex = 18;
            // 
            // stepFactorTextBox
            // 
            this.stepFactorTextBox.Location = new System.Drawing.Point(1926, 276);
            this.stepFactorTextBox.Name = "stepFactorTextBox";
            this.stepFactorTextBox.Size = new System.Drawing.Size(100, 26);
            this.stepFactorTextBox.TabIndex = 21;
            // 
            // stepFactorLabel
            // 
            this.stepFactorLabel.AutoSize = true;
            this.stepFactorLabel.Location = new System.Drawing.Point(1832, 279);
            this.stepFactorLabel.Name = "stepFactorLabel";
            this.stepFactorLabel.Size = new System.Drawing.Size(88, 20);
            this.stepFactorLabel.TabIndex = 30;
            this.stepFactorLabel.Text = "Step factor";
            // 
            // filterFactorTextBox
            // 
            this.filterFactorTextBox.Location = new System.Drawing.Point(1926, 308);
            this.filterFactorTextBox.Name = "filterFactorTextBox";
            this.filterFactorTextBox.Size = new System.Drawing.Size(100, 26);
            this.filterFactorTextBox.TabIndex = 22;
            // 
            // filterFactorLabel
            // 
            this.filterFactorLabel.AutoSize = true;
            this.filterFactorLabel.Location = new System.Drawing.Point(1831, 311);
            this.filterFactorLabel.Name = "filterFactorLabel";
            this.filterFactorLabel.Size = new System.Drawing.Size(89, 20);
            this.filterFactorLabel.TabIndex = 32;
            this.filterFactorLabel.Text = "Filter factor";
            // 
            // trainingParametersLabel
            // 
            this.trainingParametersLabel.AutoSize = true;
            this.trainingParametersLabel.Location = new System.Drawing.Point(1922, 253);
            this.trainingParametersLabel.Name = "trainingParametersLabel";
            this.trainingParametersLabel.Size = new System.Drawing.Size(150, 20);
            this.trainingParametersLabel.TabIndex = 33;
            this.trainingParametersLabel.Text = "Training parameters";
            // 
            // modelParametersLabel
            // 
            this.modelParametersLabel.AutoSize = true;
            this.modelParametersLabel.Location = new System.Drawing.Point(1816, 9);
            this.modelParametersLabel.Name = "modelParametersLabel";
            this.modelParametersLabel.Size = new System.Drawing.Size(137, 20);
            this.modelParametersLabel.TabIndex = 34;
            this.modelParametersLabel.Text = "Model parameters";
            // 
            // f0StepsTextBox
            // 
            this.f0StepsTextBox.Location = new System.Drawing.Point(2032, 32);
            this.f0StepsTextBox.Name = "f0StepsTextBox";
            this.f0StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0StepsTextBox.TabIndex = 2;
            // 
            // rStepsTextBox
            // 
            this.rStepsTextBox.Location = new System.Drawing.Point(2032, 96);
            this.rStepsTextBox.Name = "rStepsTextBox";
            this.rStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.rStepsTextBox.TabIndex = 8;
            // 
            // cStepsTextBox
            // 
            this.cStepsTextBox.Location = new System.Drawing.Point(2032, 128);
            this.cStepsTextBox.Name = "cStepsTextBox";
            this.cStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.cStepsTextBox.TabIndex = 14;
            // 
            // pStepsTextBox
            // 
            this.pStepsTextBox.Location = new System.Drawing.Point(2032, 192);
            this.pStepsTextBox.Name = "pStepsTextBox";
            this.pStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.pStepsTextBox.TabIndex = 20;
            // 
            // cEndDayStepsTextBox
            // 
            this.cEndDayStepsTextBox.Location = new System.Drawing.Point(2032, 160);
            this.cEndDayStepsTextBox.Name = "cEndDayStepsTextBox";
            this.cEndDayStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.cEndDayStepsTextBox.TabIndex = 17;
            // 
            // cEndDayMaxTextBox
            // 
            this.cEndDayMaxTextBox.Location = new System.Drawing.Point(1926, 160);
            this.cEndDayMaxTextBox.Name = "cEndDayMaxTextBox";
            this.cEndDayMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.cEndDayMaxTextBox.TabIndex = 16;
            // 
            // cEndDayMinTextBox
            // 
            this.cEndDayMinTextBox.Location = new System.Drawing.Point(1820, 160);
            this.cEndDayMinTextBox.Name = "cEndDayMinTextBox";
            this.cEndDayMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.cEndDayMinTextBox.TabIndex = 15;
            // 
            // cedLabel
            // 
            this.cedLabel.AutoSize = true;
            this.cedLabel.Location = new System.Drawing.Point(1771, 163);
            this.cedLabel.Name = "cedLabel";
            this.cedLabel.Size = new System.Drawing.Size(43, 20);
            this.cedLabel.TabIndex = 40;
            this.cedLabel.Text = "CED";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(2057, 573);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 36);
            this.resetButton.TabIndex = 28;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // returnDateTextBox
            // 
            this.returnDateTextBox.Location = new System.Drawing.Point(1926, 431);
            this.returnDateTextBox.Name = "returnDateTextBox";
            this.returnDateTextBox.Size = new System.Drawing.Size(100, 26);
            this.returnDateTextBox.TabIndex = 25;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(1846, 434);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(74, 20);
            this.endDateLabel.TabIndex = 101;
            this.endDateLabel.Text = "End date";
            // 
            // iMinTextBox
            // 
            this.iMinTextBox.Location = new System.Drawing.Point(1820, 64);
            this.iMinTextBox.Name = "iMinTextBox";
            this.iMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.iMinTextBox.TabIndex = 3;
            // 
            // iMaxTextBox
            // 
            this.iMaxTextBox.Location = new System.Drawing.Point(1926, 64);
            this.iMaxTextBox.Name = "iMaxTextBox";
            this.iMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.iMaxTextBox.TabIndex = 4;
            // 
            // iStepsTextBox
            // 
            this.iStepsTextBox.Location = new System.Drawing.Point(2032, 64);
            this.iStepsTextBox.Name = "iStepsTextBox";
            this.iStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.iStepsTextBox.TabIndex = 5;
            // 
            // iLabel
            // 
            this.iLabel.AutoSize = true;
            this.iLabel.Location = new System.Drawing.Point(1800, 67);
            this.iLabel.Name = "iLabel";
            this.iLabel.Size = new System.Drawing.Size(14, 20);
            this.iLabel.TabIndex = 105;
            this.iLabel.Text = "I";
            // 
            // windowTextBox
            // 
            this.windowTextBox.Location = new System.Drawing.Point(1926, 340);
            this.windowTextBox.Name = "windowTextBox";
            this.windowTextBox.Size = new System.Drawing.Size(100, 26);
            this.windowTextBox.TabIndex = 23;
            // 
            // windowLabel
            // 
            this.windowLabel.AutoSize = true;
            this.windowLabel.Location = new System.Drawing.Point(1855, 343);
            this.windowLabel.Name = "windowLabel";
            this.windowLabel.Size = new System.Drawing.Size(65, 20);
            this.windowLabel.TabIndex = 107;
            this.windowLabel.Text = "Window";
            // 
            // skipTextBox
            // 
            this.skipTextBox.Location = new System.Drawing.Point(1926, 373);
            this.skipTextBox.Name = "skipTextBox";
            this.skipTextBox.Size = new System.Drawing.Size(100, 26);
            this.skipTextBox.TabIndex = 24;
            // 
            // skipLabel
            // 
            this.skipLabel.AutoSize = true;
            this.skipLabel.Location = new System.Drawing.Point(1880, 376);
            this.skipLabel.Name = "skipLabel";
            this.skipLabel.Size = new System.Drawing.Size(40, 20);
            this.skipLabel.TabIndex = 109;
            this.skipLabel.Text = "Skip";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2144, 1298);
            this.Controls.Add(this.skipLabel);
            this.Controls.Add(this.skipTextBox);
            this.Controls.Add(this.windowLabel);
            this.Controls.Add(this.windowTextBox);
            this.Controls.Add(this.iLabel);
            this.Controls.Add(this.iStepsTextBox);
            this.Controls.Add(this.iMaxTextBox);
            this.Controls.Add(this.iMinTextBox);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.returnDateTextBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.cEndDayStepsTextBox);
            this.Controls.Add(this.cEndDayMaxTextBox);
            this.Controls.Add(this.cEndDayMinTextBox);
            this.Controls.Add(this.cedLabel);
            this.Controls.Add(this.pStepsTextBox);
            this.Controls.Add(this.cStepsTextBox);
            this.Controls.Add(this.rStepsTextBox);
            this.Controls.Add(this.f0StepsTextBox);
            this.Controls.Add(this.modelParametersLabel);
            this.Controls.Add(this.trainingParametersLabel);
            this.Controls.Add(this.filterFactorLabel);
            this.Controls.Add(this.filterFactorTextBox);
            this.Controls.Add(this.stepFactorLabel);
            this.Controls.Add(this.stepFactorTextBox);
            this.Controls.Add(this.pMaxTextBox);
            this.Controls.Add(this.pMinTextBox);
            this.Controls.Add(this.cMaxTextBox);
            this.Controls.Add(this.cMinTextBox);
            this.Controls.Add(this.rMaxTextBox);
            this.Controls.Add(this.rMinTextBox);
            this.Controls.Add(this.f0MaxTextBox);
            this.Controls.Add(this.f0MinTextBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.cLabel);
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
        private System.Windows.Forms.Label cLabel;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TextBox f0MinTextBox;
        private System.Windows.Forms.TextBox f0MaxTextBox;
        private System.Windows.Forms.TextBox rMaxTextBox;
        private System.Windows.Forms.TextBox rMinTextBox;
        private System.Windows.Forms.TextBox cMaxTextBox;
        private System.Windows.Forms.TextBox cMinTextBox;
        private System.Windows.Forms.TextBox pMaxTextBox;
        private System.Windows.Forms.TextBox pMinTextBox;
        private System.Windows.Forms.TextBox stepFactorTextBox;
        private System.Windows.Forms.Label stepFactorLabel;
        private System.Windows.Forms.TextBox filterFactorTextBox;
        private System.Windows.Forms.Label filterFactorLabel;
        private System.Windows.Forms.Label trainingParametersLabel;
        private System.Windows.Forms.Label modelParametersLabel;
        private System.Windows.Forms.TextBox f0StepsTextBox;
        private System.Windows.Forms.TextBox rStepsTextBox;
        private System.Windows.Forms.TextBox cStepsTextBox;
        private System.Windows.Forms.TextBox pStepsTextBox;
        private System.Windows.Forms.TextBox cEndDayStepsTextBox;
        private System.Windows.Forms.TextBox cEndDayMaxTextBox;
        private System.Windows.Forms.TextBox cEndDayMinTextBox;
        private System.Windows.Forms.Label cedLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox returnDateTextBox;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.TextBox iMinTextBox;
        private System.Windows.Forms.TextBox iMaxTextBox;
        private System.Windows.Forms.TextBox iStepsTextBox;
        private System.Windows.Forms.Label iLabel;
        private System.Windows.Forms.TextBox windowTextBox;
        private System.Windows.Forms.Label windowLabel;
        private System.Windows.Forms.TextBox skipTextBox;
        private System.Windows.Forms.Label skipLabel;
    }
}

