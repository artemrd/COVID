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
            this.c1Label = new System.Windows.Forms.Label();
            this.p1Label = new System.Windows.Forms.Label();
            this.f0MinTextBox = new System.Windows.Forms.TextBox();
            this.f0MaxTextBox = new System.Windows.Forms.TextBox();
            this.rMaxTextBox = new System.Windows.Forms.TextBox();
            this.rMinTextBox = new System.Windows.Forms.TextBox();
            this.oMaxTextBox = new System.Windows.Forms.TextBox();
            this.oMinTextBox = new System.Windows.Forms.TextBox();
            this.c1MaxTextBox = new System.Windows.Forms.TextBox();
            this.c1MinTextBox = new System.Windows.Forms.TextBox();
            this.p1MaxTextBox = new System.Windows.Forms.TextBox();
            this.p1MinTextBox = new System.Windows.Forms.TextBox();
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
            this.p1StepsTextBox = new System.Windows.Forms.TextBox();
            this.c2StepsTextBox = new System.Windows.Forms.TextBox();
            this.c2MaxTextBox = new System.Windows.Forms.TextBox();
            this.c2MinTextBox = new System.Windows.Forms.TextBox();
            this.c2Label = new System.Windows.Forms.Label();
            this.p2StepsTextBox = new System.Windows.Forms.TextBox();
            this.p2MaxTextBox = new System.Windows.Forms.TextBox();
            this.p2MinTextBox = new System.Windows.Forms.TextBox();
            this.p2Label = new System.Windows.Forms.Label();
            this.oneOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.twoOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.resetButton = new System.Windows.Forms.Button();
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
            this.chart.TabIndex = 99;
            this.chart.TabStop = false;
            this.chart.Text = "Chart";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(2024, 483);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 36);
            this.startButton.TabIndex = 25;
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
            this.stopButton.Location = new System.Drawing.Point(2024, 525);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 36);
            this.stopButton.TabIndex = 26;
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
            this.f0Label.TabIndex = 4;
            this.f0Label.Text = "F0";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(1760, 70);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(21, 20);
            this.rLabel.TabIndex = 5;
            this.rLabel.Text = "R";
            // 
            // oLabel
            // 
            this.oLabel.AutoSize = true;
            this.oLabel.Location = new System.Drawing.Point(1760, 102);
            this.oLabel.Name = "oLabel";
            this.oLabel.Size = new System.Drawing.Size(21, 20);
            this.oLabel.TabIndex = 6;
            this.oLabel.Text = "O";
            // 
            // c1Label
            // 
            this.c1Label.AutoSize = true;
            this.c1Label.Location = new System.Drawing.Point(1752, 134);
            this.c1Label.Name = "c1Label";
            this.c1Label.Size = new System.Drawing.Size(29, 20);
            this.c1Label.TabIndex = 7;
            this.c1Label.Text = "C1";
            // 
            // p1Label
            // 
            this.p1Label.AutoSize = true;
            this.p1Label.Location = new System.Drawing.Point(1753, 198);
            this.p1Label.Name = "p1Label";
            this.p1Label.Size = new System.Drawing.Size(28, 20);
            this.p1Label.TabIndex = 8;
            this.p1Label.Text = "P1";
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
            this.rMaxTextBox.Location = new System.Drawing.Point(1893, 67);
            this.rMaxTextBox.Name = "rMaxTextBox";
            this.rMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMaxTextBox.TabIndex = 4;
            // 
            // rMinTextBox
            // 
            this.rMinTextBox.Location = new System.Drawing.Point(1787, 67);
            this.rMinTextBox.Name = "rMinTextBox";
            this.rMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.rMinTextBox.TabIndex = 3;
            // 
            // oMaxTextBox
            // 
            this.oMaxTextBox.Location = new System.Drawing.Point(1893, 99);
            this.oMaxTextBox.Name = "oMaxTextBox";
            this.oMaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMaxTextBox.TabIndex = 7;
            // 
            // oMinTextBox
            // 
            this.oMinTextBox.Location = new System.Drawing.Point(1787, 99);
            this.oMinTextBox.Name = "oMinTextBox";
            this.oMinTextBox.Size = new System.Drawing.Size(100, 26);
            this.oMinTextBox.TabIndex = 6;
            // 
            // c1MaxTextBox
            // 
            this.c1MaxTextBox.Location = new System.Drawing.Point(1893, 131);
            this.c1MaxTextBox.Name = "c1MaxTextBox";
            this.c1MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.c1MaxTextBox.TabIndex = 10;
            // 
            // c1MinTextBox
            // 
            this.c1MinTextBox.Location = new System.Drawing.Point(1787, 131);
            this.c1MinTextBox.Name = "c1MinTextBox";
            this.c1MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.c1MinTextBox.TabIndex = 9;
            // 
            // p1MaxTextBox
            // 
            this.p1MaxTextBox.Location = new System.Drawing.Point(1893, 195);
            this.p1MaxTextBox.Name = "p1MaxTextBox";
            this.p1MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.p1MaxTextBox.TabIndex = 16;
            // 
            // p1MinTextBox
            // 
            this.p1MinTextBox.Location = new System.Drawing.Point(1787, 195);
            this.p1MinTextBox.Name = "p1MinTextBox";
            this.p1MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.p1MinTextBox.TabIndex = 15;
            // 
            // stepFactorTextBox
            // 
            this.stepFactorTextBox.Location = new System.Drawing.Point(1893, 329);
            this.stepFactorTextBox.Name = "stepFactorTextBox";
            this.stepFactorTextBox.Size = new System.Drawing.Size(100, 26);
            this.stepFactorTextBox.TabIndex = 21;
            // 
            // stepFactorLabel
            // 
            this.stepFactorLabel.AutoSize = true;
            this.stepFactorLabel.Location = new System.Drawing.Point(1799, 332);
            this.stepFactorLabel.Name = "stepFactorLabel";
            this.stepFactorLabel.Size = new System.Drawing.Size(88, 20);
            this.stepFactorLabel.TabIndex = 30;
            this.stepFactorLabel.Text = "Step factor";
            // 
            // filterFactorTextBox
            // 
            this.filterFactorTextBox.Location = new System.Drawing.Point(1893, 361);
            this.filterFactorTextBox.Name = "filterFactorTextBox";
            this.filterFactorTextBox.Size = new System.Drawing.Size(100, 26);
            this.filterFactorTextBox.TabIndex = 22;
            // 
            // filterFactorLabel
            // 
            this.filterFactorLabel.AutoSize = true;
            this.filterFactorLabel.Location = new System.Drawing.Point(1798, 364);
            this.filterFactorLabel.Name = "filterFactorLabel";
            this.filterFactorLabel.Size = new System.Drawing.Size(89, 20);
            this.filterFactorLabel.TabIndex = 32;
            this.filterFactorLabel.Text = "Filter factor";
            // 
            // trainingParametersLabel
            // 
            this.trainingParametersLabel.AutoSize = true;
            this.trainingParametersLabel.Location = new System.Drawing.Point(1889, 306);
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
            this.rStepsTextBox.Location = new System.Drawing.Point(1999, 67);
            this.rStepsTextBox.Name = "rStepsTextBox";
            this.rStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.rStepsTextBox.TabIndex = 5;
            // 
            // oStepsTextBox
            // 
            this.oStepsTextBox.Location = new System.Drawing.Point(1999, 99);
            this.oStepsTextBox.Name = "oStepsTextBox";
            this.oStepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.oStepsTextBox.TabIndex = 8;
            // 
            // c1StepsTextBox
            // 
            this.c1StepsTextBox.Location = new System.Drawing.Point(1999, 131);
            this.c1StepsTextBox.Name = "c1StepsTextBox";
            this.c1StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.c1StepsTextBox.TabIndex = 11;
            // 
            // p1StepsTextBox
            // 
            this.p1StepsTextBox.Location = new System.Drawing.Point(1999, 195);
            this.p1StepsTextBox.Name = "p1StepsTextBox";
            this.p1StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.p1StepsTextBox.TabIndex = 17;
            // 
            // c2StepsTextBox
            // 
            this.c2StepsTextBox.Location = new System.Drawing.Point(1999, 163);
            this.c2StepsTextBox.Name = "c2StepsTextBox";
            this.c2StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.c2StepsTextBox.TabIndex = 14;
            // 
            // c2MaxTextBox
            // 
            this.c2MaxTextBox.Location = new System.Drawing.Point(1893, 163);
            this.c2MaxTextBox.Name = "c2MaxTextBox";
            this.c2MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.c2MaxTextBox.TabIndex = 13;
            // 
            // c2MinTextBox
            // 
            this.c2MinTextBox.Location = new System.Drawing.Point(1787, 163);
            this.c2MinTextBox.Name = "c2MinTextBox";
            this.c2MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.c2MinTextBox.TabIndex = 12;
            // 
            // c2Label
            // 
            this.c2Label.AutoSize = true;
            this.c2Label.Location = new System.Drawing.Point(1752, 166);
            this.c2Label.Name = "c2Label";
            this.c2Label.Size = new System.Drawing.Size(29, 20);
            this.c2Label.TabIndex = 40;
            this.c2Label.Text = "C2";
            // 
            // p2StepsTextBox
            // 
            this.p2StepsTextBox.Location = new System.Drawing.Point(1999, 227);
            this.p2StepsTextBox.Name = "p2StepsTextBox";
            this.p2StepsTextBox.Size = new System.Drawing.Size(100, 26);
            this.p2StepsTextBox.TabIndex = 20;
            // 
            // p2MaxTextBox
            // 
            this.p2MaxTextBox.Location = new System.Drawing.Point(1893, 227);
            this.p2MaxTextBox.Name = "p2MaxTextBox";
            this.p2MaxTextBox.Size = new System.Drawing.Size(100, 26);
            this.p2MaxTextBox.TabIndex = 19;
            // 
            // p2MinTextBox
            // 
            this.p2MinTextBox.Location = new System.Drawing.Point(1787, 227);
            this.p2MinTextBox.Name = "p2MinTextBox";
            this.p2MinTextBox.Size = new System.Drawing.Size(100, 26);
            this.p2MinTextBox.TabIndex = 18;
            // 
            // p2Label
            // 
            this.p2Label.AutoSize = true;
            this.p2Label.Location = new System.Drawing.Point(1753, 230);
            this.p2Label.Name = "p2Label";
            this.p2Label.Size = new System.Drawing.Size(28, 20);
            this.p2Label.TabIndex = 44;
            this.p2Label.Text = "P2";
            // 
            // oneOnlyCheckBox
            // 
            this.oneOnlyCheckBox.AutoSize = true;
            this.oneOnlyCheckBox.Location = new System.Drawing.Point(1893, 394);
            this.oneOnlyCheckBox.Name = "oneOnlyCheckBox";
            this.oneOnlyCheckBox.Size = new System.Drawing.Size(76, 24);
            this.oneOnlyCheckBox.TabIndex = 23;
            this.oneOnlyCheckBox.Text = "1 only";
            this.oneOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // twoOnlyCheckBox
            // 
            this.twoOnlyCheckBox.AutoSize = true;
            this.twoOnlyCheckBox.Location = new System.Drawing.Point(1893, 425);
            this.twoOnlyCheckBox.Name = "twoOnlyCheckBox";
            this.twoOnlyCheckBox.Size = new System.Drawing.Size(76, 24);
            this.twoOnlyCheckBox.TabIndex = 24;
            this.twoOnlyCheckBox.Text = "2 only";
            this.twoOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(2024, 567);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 36);
            this.resetButton.TabIndex = 27;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2111, 1298);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.twoOnlyCheckBox);
            this.Controls.Add(this.oneOnlyCheckBox);
            this.Controls.Add(this.p2StepsTextBox);
            this.Controls.Add(this.p2MaxTextBox);
            this.Controls.Add(this.p2MinTextBox);
            this.Controls.Add(this.p2Label);
            this.Controls.Add(this.c2StepsTextBox);
            this.Controls.Add(this.c2MaxTextBox);
            this.Controls.Add(this.c2MinTextBox);
            this.Controls.Add(this.c2Label);
            this.Controls.Add(this.p1StepsTextBox);
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
            this.Controls.Add(this.p1MaxTextBox);
            this.Controls.Add(this.p1MinTextBox);
            this.Controls.Add(this.c1MaxTextBox);
            this.Controls.Add(this.c1MinTextBox);
            this.Controls.Add(this.oMaxTextBox);
            this.Controls.Add(this.oMinTextBox);
            this.Controls.Add(this.rMaxTextBox);
            this.Controls.Add(this.rMinTextBox);
            this.Controls.Add(this.f0MaxTextBox);
            this.Controls.Add(this.f0MinTextBox);
            this.Controls.Add(this.p1Label);
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
        private System.Windows.Forms.Label p1Label;
        private System.Windows.Forms.TextBox f0MinTextBox;
        private System.Windows.Forms.TextBox f0MaxTextBox;
        private System.Windows.Forms.TextBox rMaxTextBox;
        private System.Windows.Forms.TextBox rMinTextBox;
        private System.Windows.Forms.TextBox oMaxTextBox;
        private System.Windows.Forms.TextBox oMinTextBox;
        private System.Windows.Forms.TextBox c1MaxTextBox;
        private System.Windows.Forms.TextBox c1MinTextBox;
        private System.Windows.Forms.TextBox p1MaxTextBox;
        private System.Windows.Forms.TextBox p1MinTextBox;
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
        private System.Windows.Forms.TextBox p1StepsTextBox;
        private System.Windows.Forms.TextBox c2StepsTextBox;
        private System.Windows.Forms.TextBox c2MaxTextBox;
        private System.Windows.Forms.TextBox c2MinTextBox;
        private System.Windows.Forms.Label c2Label;
        private System.Windows.Forms.TextBox p2StepsTextBox;
        private System.Windows.Forms.TextBox p2MaxTextBox;
        private System.Windows.Forms.TextBox p2MinTextBox;
        private System.Windows.Forms.Label p2Label;
        private System.Windows.Forms.CheckBox oneOnlyCheckBox;
        private System.Windows.Forms.CheckBox twoOnlyCheckBox;
        private System.Windows.Forms.Button resetButton;
    }
}

