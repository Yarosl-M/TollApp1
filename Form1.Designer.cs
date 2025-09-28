namespace TollApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            carArriveIntervalInput = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            toll1Interval = new NumericUpDown();
            label3 = new Label();
            CarArrivalInterval = new NumericUpDown();
            tollsInterval = new NumericUpDown();
            label4 = new Label();
            highwayToll2Interval = new NumericUpDown();
            label5 = new Label();
            toll1GateCount = new NumericUpDown();
            label6 = new Label();
            toll2GateCount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)carArriveIntervalInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toll1Interval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CarArrivalInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tollsInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)highwayToll2Interval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toll1GateCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toll2GateCount).BeginInit();
            SuspendLayout();
            // 
            // carArriveIntervalInput
            // 
            carArriveIntervalInput.DecimalPlaces = 3;
            carArriveIntervalInput.Location = new Point(3473, 49);
            carArriveIntervalInput.Margin = new Padding(15, 15, 15, 15);
            carArriveIntervalInput.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            carArriveIntervalInput.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            carArriveIntervalInput.Name = "carArriveIntervalInput";
            carArriveIntervalInput.Size = new Size(397, 34);
            carArriveIntervalInput.TabIndex = 0;
            carArriveIntervalInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(427, 24);
            label1.Name = "label1";
            label1.Size = new Size(520, 28);
            label1.TabIndex = 2;
            label1.Text = "dt1 (средний интервал подъезда к пункту № 1 с шоссе)";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(563, 190);
            label2.Name = "label2";
            label2.Size = new Size(384, 28);
            label2.TabIndex = 2;
            label2.Text = "n (число шлагбаумов на первом пункте)";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.Click += label2_Click_1;
            // 
            // toll1Interval
            // 
            toll1Interval.DecimalPlaces = 1;
            toll1Interval.Location = new Point(965, 65);
            toll1Interval.Margin = new Padding(15, 15, 15, 15);
            toll1Interval.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            toll1Interval.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            toll1Interval.Name = "toll1Interval";
            toll1Interval.Size = new Size(111, 34);
            toll1Interval.TabIndex = 1;
            toll1Interval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(611, 65);
            label3.Name = "label3";
            label3.Size = new Size(336, 28);
            label3.TabIndex = 2;
            label3.Text = "dt2 (среднее время обслуживания)";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CarArrivalInterval
            // 
            CarArrivalInterval.DecimalPlaces = 1;
            CarArrivalInterval.Location = new Point(965, 24);
            CarArrivalInterval.Margin = new Padding(15);
            CarArrivalInterval.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            CarArrivalInterval.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            CarArrivalInterval.Name = "CarArrivalInterval";
            CarArrivalInterval.Size = new Size(111, 34);
            CarArrivalInterval.TabIndex = 1;
            CarArrivalInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tollsInterval
            // 
            tollsInterval.DecimalPlaces = 1;
            tollsInterval.Location = new Point(965, 106);
            tollsInterval.Margin = new Padding(15);
            tollsInterval.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            tollsInterval.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            tollsInterval.Name = "tollsInterval";
            tollsInterval.Size = new Size(111, 34);
            tollsInterval.TabIndex = 1;
            tollsInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(483, 108);
            label4.Name = "label4";
            label4.Size = new Size(464, 28);
            label4.TabIndex = 2;
            label4.Text = "dt3 (интервал между первым и вторым пунктом)";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // highwayToll2Interval
            // 
            highwayToll2Interval.DecimalPlaces = 1;
            highwayToll2Interval.Location = new Point(965, 147);
            highwayToll2Interval.Margin = new Padding(15);
            highwayToll2Interval.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            highwayToll2Interval.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            highwayToll2Interval.Name = "highwayToll2Interval";
            highwayToll2Interval.Size = new Size(111, 34);
            highwayToll2Interval.TabIndex = 1;
            highwayToll2Interval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(427, 149);
            label5.Name = "label5";
            label5.Size = new Size(520, 28);
            label5.TabIndex = 2;
            label5.Text = "dt4 (средний интервал подъезда к пункту № 2 с шоссе)";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.Click += label2_Click_1;
            // 
            // toll1GateCount
            // 
            toll1GateCount.Location = new Point(965, 188);
            toll1GateCount.Margin = new Padding(15);
            toll1GateCount.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            toll1GateCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            toll1GateCount.Name = "toll1GateCount";
            toll1GateCount.Size = new Size(111, 34);
            toll1GateCount.TabIndex = 1;
            toll1GateCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(554, 231);
            label6.Name = "label6";
            label6.Size = new Size(393, 28);
            label6.TabIndex = 2;
            label6.Text = "n2 (число шлагбаумов на втором пункте)";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.Click += label2_Click_1;
            // 
            // toll2GateCount
            // 
            toll2GateCount.Location = new Point(965, 229);
            toll2GateCount.Margin = new Padding(15);
            toll2GateCount.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            toll2GateCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            toll2GateCount.Name = "toll2GateCount";
            toll2GateCount.Size = new Size(111, 34);
            toll2GateCount.TabIndex = 1;
            toll2GateCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 651);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(CarArrivalInterval);
            Controls.Add(toll2GateCount);
            Controls.Add(toll1GateCount);
            Controls.Add(highwayToll2Interval);
            Controls.Add(tollsInterval);
            Controls.Add(toll1Interval);
            Controls.Add(label1);
            Controls.Add(carArriveIntervalInput);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "TAKE A [ A Ride around Town on Your Specil Cungadero]";
            ((System.ComponentModel.ISupportInitialize)carArriveIntervalInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)toll1Interval).EndInit();
            ((System.ComponentModel.ISupportInitialize)CarArrivalInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)tollsInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)highwayToll2Interval).EndInit();
            ((System.ComponentModel.ISupportInitialize)toll1GateCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)toll2GateCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown carArriveIntervalInput;
        private Label label1;
        private Label label2;
        private NumericUpDown toll1Interval;
        private Label label3;
        private NumericUpDown CarArrivalInterval;
        private NumericUpDown tollsInterval;
        private Label label4;
        private NumericUpDown highwayToll2Interval;
        private Label label5;
        private NumericUpDown toll1GateCount;
        private Label label6;
        private NumericUpDown toll2GateCount;
    }
}
