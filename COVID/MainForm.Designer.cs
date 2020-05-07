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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startButton = new System.Windows.Forms.Button();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.f0Label = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.oLabel = new System.Windows.Forms.Label();
            this.c1Label = new System.Windows.Forms.Label();
            this.pLabel = new System.Windows.Forms.Label();
            this.f0MinTextBox = new System.Windows.Forms.TextBox();
            this.f0MaxTextBox = new System.Windows.Forms.TextBox();
            this.rMaxTextBox = new System.Windows.Forms.TextBox();
            this.rMinTextBox = new System.Windows.Forms.TextBox();
            this.oMaxTextBox = new System.Windows.Forms.TextBox();
            this.oMinTextBox = new System.Windows.Forms.TextBox();
            this.c1MaxTextBox = new System.Windows.Forms.TextBox();
            this.c1MinTextBox = new System.Windows.Forms.TextBox();
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
            this.oStepsTextBox = new System.Windows.Forms.TextBox();
            this.c1StepsTextBox = new System.Windows.Forms.TextBox();
            this.pStepsTextBox = new System.Windows.Forms.TextBox();
            this.c2StepsTextBox = new System.Windows.Forms.TextBox();
            this.c2MaxTextBox = new System.Windows.Forms.TextBox();
            this.c2MinTextBox = new System.Windows.Forms.TextBox();
            this.c2Label = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.returnDateTextBox = new System.Windows.Forms.TextBox();
            this.returnDateLabel = new System.Windows.Forms.Label();
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
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1724, 682);
            this.chart.TabIndex = 99;
            this.chart.TabStop = false;
            this.chart.Text = "Chart";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(2024, 604);
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
            this.stopButton.Location = new System.Drawing.Point(2024, 646);
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
            this.f0Label.Location = new System.Drawing.Point(1753, 38);
            this.f0Label.Name = "f0Label";
            this.f0Label.Size = new System.Drawing.Size(28, 20);
            this.f0Label.TabIndex = 1;
            this.f0Label.Text = "F0";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(1760, 102);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(21, 20);
            this.rLabel.TabIndex = 5;
            this.rLabel.Text = "R";
            // 
            // oLabel
            // 
            this.oLabel.AutoSize = true;
            this.oLabel.Location = new System.Drawing.Point(1760, 134);
            this.oLabel.Name = "oLabel";
            this.oLabel.Size = new System.Drawing.Size(21, 20);
            this.oLabel.TabIndex = 6;
            this.oLabel.Text = "O";
            // 
            // c1Label
            // 
            this.c1Label.AutoSize = true;
            this.c1Label.Location = new System.Drawing.Point(1752, 166);
            this.c1Label.Name = "c1Label";
            this.c1Label.Size = new System.Drawing.Size(29, 20);
            this.c1Label.TabIndex = 7;
            this.c1Label.Text = "C1";
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(1762, 233);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(19, 20);
            this.pLabel.TabIndex = 8;
            this.pLabel.Text = "P";
            // 
            // f0MinTextBox
            // 
            this.f0MinTextBox.Location = new System.Drawing.Point(1787, 35);
            this.f0MinTextBox.Name = "f0MinTextBox";
            this.f0MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MinTextBox.TabIndex = 0;
            // 
            // f0MaxTextBox
            // 
            this.f0MaxTextBox.Location = new System.Drawing.Point(1893, 35);
            this.f0MaxTextBox.Name = "f0MaxTextBox";
            this.f0MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0MaxTextBox.TabIndex = 1;
            // 
            // rMaxTextBox
            // 
            this.rMaxTextBox.Location = new System.Drawing.Point(1893, 99);
            this.rMaxTextBox.Name = "rMaxTextBox";
            this.rMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMaxTextBox.TabIndex = 7;
            // 
            // rMinTextBox
            // 
            this.rMinTextBox.Location = new System.Drawing.Point(1787, 99);
            this.rMinTextBox.Name = "rMinTextBox";
            this.rMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMinTextBox.TabIndex = 6;
            // 
            // oMaxTextBox
            // 
            this.oMaxTextBox.Location = new System.Drawing.Point(1893, 131);
            this.oMaxTextBox.Name = "oMaxTextBox";
            this.oMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMaxTextBox.TabIndex = 10;
            // 
            // oMinTextBox
            // 
            this.oMinTextBox.Location = new System.Drawing.Point(1787, 131);
            this.oMinTextBox.Name = "oMinTextBox";
            this.oMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMinTextBox.TabIndex = 9;
            // 
            // c1MaxTextBox
            // 
            this.c1MaxTextBox.Location = new System.Drawing.Point(1893, 163);
            this.c1MaxTextBox.Name = "c1MaxTextBox";
            this.c1MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.c1MaxTextBox.TabIndex = 13;
            // 
            // c1MinTextBox
            // 
            this.c1MinTextBox.Location = new System.Drawing.Point(1787, 163);
            this.c1MinTextBox.Name = "c1MinTextBox";
            this.c1MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.c1MinTextBox.TabIndex = 12;
            // 
            // pMaxTextBox
            // 
            this.pMaxTextBox.Location = new System.Drawing.Point(1893, 227);
            this.pMaxTextBox.Name = "pMaxTextBox";
            this.pMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMaxTextBox.TabIndex = 19;
            // 
            // pMinTextBox
            // 
            this.pMinTextBox.Location = new System.Drawing.Point(1787, 227);
            this.pMinTextBox.Name = "pMinTextBox";
            this.pMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.pMinTextBox.TabIndex = 18;
            // 
            // stepFactorTextBox
            // 
            this.stepFactorTextBox.Location = new System.Drawing.Point(1893, 335);
            this.stepFactorTextBox.Name = "stepFactorTextBox";
            this.stepFactorTextBox.Size = new System.Drawing.Size(100, 26);
            this.stepFactorTextBox.TabIndex = 21;
            // 
            // stepFactorLabel
            // 
            this.stepFactorLabel.AutoSize = true;
            this.stepFactorLabel.Location = new System.Drawing.Point(1799, 338);
            this.stepFactorLabel.Name = "stepFactorLabel";
            this.stepFactorLabel.Size = new System.Drawing.Size(88, 20);
            this.stepFactorLabel.TabIndex = 30;
            this.stepFactorLabel.Text = "Step factor";
            // 
            // filterFactorTextBox
            // 
            this.filterFactorTextBox.Location = new System.Drawing.Point(1893, 367);
            this.filterFactorTextBox.Name = "filterFactorTextBox";
            this.filterFactorTextBox.Size = new System.Drawing.Size(100, 26);
            this.filterFactorTextBox.TabIndex = 22;
            // 
            // filterFactorLabel
            // 
            this.filterFactorLabel.AutoSize = true;
            this.filterFactorLabel.Location = new System.Drawing.Point(1798, 370);
            this.filterFactorLabel.Name = "filterFactorLabel";
            this.filterFactorLabel.Size = new System.Drawing.Size(89, 20);
            this.filterFactorLabel.TabIndex = 32;
            this.filterFactorLabel.Text = "Filter factor";
            // 
            // trainingParametersLabel
            // 
            this.trainingParametersLabel.AutoSize = true;
            this.trainingParametersLabel.Location = new System.Drawing.Point(1889, 312);
            this.trainingParametersLabel.Name = "trainingParametersLabel";
            this.trainingParametersLabel.Size = new System.Drawing.Size(150, 20);
            this.trainingParametersLabel.TabIndex = 33;
            this.trainingParametersLabel.Text = "Training parameters";
            // 
            // modelParametersLabel
            // 
            this.modelParametersLabel.AutoSize = true;
            this.modelParametersLabel.Location = new System.Drawing.Point(1783, 12);
            this.modelParametersLabel.Name = "modelParametersLabel";
            this.modelParametersLabel.Size = new System.Drawing.Size(137, 20);
            this.modelParametersLabel.TabIndex = 34;
            this.modelParametersLabel.Text = "Model parameters";
            // 
            // f0StepsTextBox
            // 
            this.f0StepsTextBox.Location = new System.Drawing.Point(1999, 35);
            this.f0StepsTextBox.Name = "f0StepsTextBox";
            this.f0StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.f0StepsTextBox.TabIndex = 2;
            // 
            // rStepsTextBox
            // 
            this.rStepsTextBox.Location = new System.Drawing.Point(1999, 99);
            this.rStepsTextBox.Name = "rStepsTextBox";
            this.rStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.rStepsTextBox.TabIndex = 8;
            // 
            // oStepsTextBox
            // 
            this.oStepsTextBox.Location = new System.Drawing.Point(1999, 131);
            this.oStepsTextBox.Name = "oStepsTextBox";
            this.oStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.oStepsTextBox.TabIndex = 11;
            // 
            // c1StepsTextBox
            // 
            this.c1StepsTextBox.Location = new System.Drawing.Point(1999, 163);
            this.c1StepsTextBox.Name = "c1StepsTextBox";
            this.c1StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.c1StepsTextBox.TabIndex = 14;
            // 
            // pStepsTextBox
            // 
            this.pStepsTextBox.Location = new System.Drawing.Point(1999, 227);
            this.pStepsTextBox.Name = "pStepsTextBox";
            this.pStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.pStepsTextBox.TabIndex = 20;
            // 
            // c2StepsTextBox
            // 
            this.c2StepsTextBox.Location = new System.Drawing.Point(1999, 195);
            this.c2StepsTextBox.Name = "c2StepsTextBox";
            this.c2StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.c2StepsTextBox.TabIndex = 17;
            // 
            // c2MaxTextBox
            // 
            this.c2MaxTextBox.Location = new System.Drawing.Point(1893, 195);
            this.c2MaxTextBox.Name = "c2MaxTextBox";
            this.c2MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.c2MaxTextBox.TabIndex = 16;
            // 
            // c2MinTextBox
            // 
            this.c2MinTextBox.Location = new System.Drawing.Point(1787, 195);
            this.c2MinTextBox.Name = "c2MinTextBox";
            this.c2MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.c2MinTextBox.TabIndex = 15;
            // 
            // c2Label
            // 
            this.c2Label.AutoSize = true;
            this.c2Label.Location = new System.Drawing.Point(1752, 198);
            this.c2Label.Name = "c2Label";
            this.c2Label.Size = new System.Drawing.Size(29, 20);
            this.c2Label.TabIndex = 40;
            this.c2Label.Text = "C2";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(2024, 688);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 36);
            this.resetButton.TabIndex = 28;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // returnDateTextBox
            // 
            this.returnDateTextBox.Location = new System.Drawing.Point(1893, 514);
            this.returnDateTextBox.Name = "returnDateTextBox";
            this.returnDateTextBox.Size = new System.Drawing.Size(100, 26);
            this.returnDateTextBox.TabIndex = 25;
            // 
            // returnDateLabel
            // 
            this.returnDateLabel.AutoSize = true;
            this.returnDateLabel.Location = new System.Drawing.Point(1793, 517);
            this.returnDateLabel.Name = "returnDateLabel";
            this.returnDateLabel.Size = new System.Drawing.Size(94, 20);
            this.returnDateLabel.TabIndex = 101;
            this.returnDateLabel.Text = "Return date";
            // 
            // iMinTextBox
            // 
            this.iMinTextBox.Location = new System.Drawing.Point(1787, 67);
            this.iMinTextBox.Name = "iMinTextBox";
            this.iMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.iMinTextBox.TabIndex = 3;
            // 
            // iMaxTextBox
            // 
            this.iMaxTextBox.Location = new System.Drawing.Point(1893, 67);
            this.iMaxTextBox.Name = "iMaxTextBox";
            this.iMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.iMaxTextBox.TabIndex = 4;
            // 
            // iStepsTextBox
            // 
            this.iStepsTextBox.Location = new System.Drawing.Point(1999, 67);
            this.iStepsTextBox.Name = "iStepsTextBox";
            this.iStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.iStepsTextBox.TabIndex = 5;
            // 
            // iLabel
            // 
            this.iLabel.AutoSize = true;
            this.iLabel.Location = new System.Drawing.Point(1767, 70);
            this.iLabel.Name = "iLabel";
            this.iLabel.Size = new System.Drawing.Size(14, 20);
            this.iLabel.TabIndex = 105;
            this.iLabel.Text = "I";
            // 
            // windowTextBox
            // 
            this.windowTextBox.Location = new System.Drawing.Point(1893, 399);
            this.windowTextBox.Name = "windowTextBox";
            this.windowTextBox.Size = new System.Drawing.Size(100, 26);
            this.windowTextBox.TabIndex = 23;
            // 
            // windowLabel
            // 
            this.windowLabel.AutoSize = true;
            this.windowLabel.Location = new System.Drawing.Point(1822, 402);
            this.windowLabel.Name = "windowLabel";
            this.windowLabel.Size = new System.Drawing.Size(65, 20);
            this.windowLabel.TabIndex = 107;
            this.windowLabel.Text = "Window";
            // 
            // skipTextBox
            // 
            this.skipTextBox.Location = new System.Drawing.Point(1893, 432);
            this.skipTextBox.Name = "skipTextBox";
            this.skipTextBox.Size = new System.Drawing.Size(100, 26);
            this.skipTextBox.TabIndex = 24;
            // 
            // skipLabel
            // 
            this.skipLabel.AutoSize = true;
            this.skipLabel.Location = new System.Drawing.Point(1847, 435);
            this.skipLabel.Name = "skipLabel";
            this.skipLabel.Size = new System.Drawing.Size(40, 20);
            this.skipLabel.TabIndex = 109;
            this.skipLabel.Text = "Skip";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2111, 1298);
            this.Controls.Add(this.skipLabel);
            this.Controls.Add(this.skipTextBox);
            this.Controls.Add(this.windowLabel);
            this.Controls.Add(this.windowTextBox);
            this.Controls.Add(this.iLabel);
            this.Controls.Add(this.iStepsTextBox);
            this.Controls.Add(this.iMaxTextBox);
            this.Controls.Add(this.iMinTextBox);
            this.Controls.Add(this.returnDateLabel);
            this.Controls.Add(this.returnDateTextBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.c2StepsTextBox);
            this.Controls.Add(this.c2MaxTextBox);
            this.Controls.Add(this.c2MinTextBox);
            this.Controls.Add(this.c2Label);
            this.Controls.Add(this.pStepsTextBox);
            this.Controls.Add(this.c1StepsTextBox);
            this.Controls.Add(this.oStepsTextBox);
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
            this.Controls.Add(this.c1MaxTextBox);
            this.Controls.Add(this.c1MinTextBox);
            this.Controls.Add(this.oMaxTextBox);
            this.Controls.Add(this.oMinTextBox);
            this.Controls.Add(this.rMaxTextBox);
            this.Controls.Add(this.rMinTextBox);
            this.Controls.Add(this.f0MaxTextBox);
            this.Controls.Add(this.f0MinTextBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.c1Label);
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
        private System.Windows.Forms.Label c1Label;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TextBox f0MinTextBox;
        private System.Windows.Forms.TextBox f0MaxTextBox;
        private System.Windows.Forms.TextBox rMaxTextBox;
        private System.Windows.Forms.TextBox rMinTextBox;
        private System.Windows.Forms.TextBox oMaxTextBox;
        private System.Windows.Forms.TextBox oMinTextBox;
        private System.Windows.Forms.TextBox c1MaxTextBox;
        private System.Windows.Forms.TextBox c1MinTextBox;
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
        private System.Windows.Forms.TextBox oStepsTextBox;
        private System.Windows.Forms.TextBox c1StepsTextBox;
        private System.Windows.Forms.TextBox pStepsTextBox;
        private System.Windows.Forms.TextBox c2StepsTextBox;
        private System.Windows.Forms.TextBox c2MaxTextBox;
        private System.Windows.Forms.TextBox c2MinTextBox;
        private System.Windows.Forms.Label c2Label;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox returnDateTextBox;
        private System.Windows.Forms.Label returnDateLabel;
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

