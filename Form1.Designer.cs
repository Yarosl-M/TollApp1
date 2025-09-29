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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            toll2Table = new DataGridView();
            toll1Table = new DataGridView();
            label8 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            arrival2Queue = new ListBox();
            travel2List = new ListBox();
            arrival1Queue = new ListBox();
            tabPage2 = new TabPage();
            button1 = new Button();
            resetBtn = new Button();
            TollBooth1 = new DataGridViewTextBoxColumn();
            Toll1Car = new DataGridViewTextBoxColumn();
            toll1TimeLeft = new DataGridViewTextBoxColumn();
            TollBooth2 = new DataGridViewTextBoxColumn();
            Toll2Car = new DataGridViewTextBoxColumn();
            Toll2TimeLeft = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)carArriveIntervalInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toll1Interval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CarArrivalInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tollsInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)highwayToll2Interval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toll1GateCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toll2GateCount).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)toll2Table).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toll1Table).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // carArriveIntervalInput
            // 
            carArriveIntervalInput.DecimalPlaces = 3;
            carArriveIntervalInput.Location = new Point(3473, 49);
            carArriveIntervalInput.Margin = new Padding(15);
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
            label1.Location = new Point(210, 38);
            label1.Name = "label1";
            label1.Size = new Size(520, 28);
            label1.TabIndex = 2;
            label1.Text = "dt1 (средний интервал подъезда к пункту № 1 с шоссе)";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(346, 204);
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
            toll1Interval.Location = new Point(748, 79);
            toll1Interval.Margin = new Padding(15);
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
            label3.Location = new Point(394, 79);
            label3.Name = "label3";
            label3.Size = new Size(336, 28);
            label3.TabIndex = 2;
            label3.Text = "dt2 (среднее время обслуживания)";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CarArrivalInterval
            // 
            CarArrivalInterval.DecimalPlaces = 1;
            CarArrivalInterval.Location = new Point(748, 38);
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
            tollsInterval.Location = new Point(748, 120);
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
            label4.Location = new Point(266, 122);
            label4.Name = "label4";
            label4.Size = new Size(464, 28);
            label4.TabIndex = 2;
            label4.Text = "dt3 (интервал между первым и вторым пунктом)";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // highwayToll2Interval
            // 
            highwayToll2Interval.DecimalPlaces = 1;
            highwayToll2Interval.Location = new Point(748, 161);
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
            label5.Location = new Point(210, 163);
            label5.Name = "label5";
            label5.Size = new Size(520, 28);
            label5.TabIndex = 2;
            label5.Text = "dt4 (средний интервал подъезда к пункту № 2 с шоссе)";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.Click += label2_Click_1;
            // 
            // toll1GateCount
            // 
            toll1GateCount.Location = new Point(748, 202);
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
            label6.Location = new Point(337, 245);
            label6.Name = "label6";
            label6.Size = new Size(393, 28);
            label6.TabIndex = 2;
            label6.Text = "n2 (число шлагбаумов на втором пункте)";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.Click += label2_Click_1;
            // 
            // toll2GateCount
            // 
            toll2GateCount.Location = new Point(748, 243);
            toll2GateCount.Margin = new Padding(15);
            toll2GateCount.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            toll2GateCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            toll2GateCount.Name = "toll2GateCount";
            toll2GateCount.Size = new Size(111, 34);
            toll2GateCount.TabIndex = 1;
            toll2GateCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1076, 627);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(toll2Table);
            tabPage1.Controls.Add(toll1Table);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(arrival2Queue);
            tabPage1.Controls.Add(travel2List);
            tabPage1.Controls.Add(arrival1Queue);
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1068, 586);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Симуляция";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // toll2Table
            // 
            toll2Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            toll2Table.Columns.AddRange(new DataGridViewColumn[] { TollBooth2, Toll2Car, Toll2TimeLeft });
            toll2Table.Cursor = Cursors.Cross;
            toll2Table.Location = new Point(601, 296);
            toll2Table.Name = "toll2Table";
            toll2Table.RowHeadersWidth = 51;
            toll2Table.Size = new Size(461, 188);
            toll2Table.TabIndex = 3;
            // 
            // toll1Table
            // 
            toll1Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            toll1Table.Columns.AddRange(new DataGridViewColumn[] { TollBooth1, Toll1Car, toll1TimeLeft });
            toll1Table.Cursor = Cursors.Cross;
            toll1Table.Location = new Point(601, 54);
            toll1Table.Name = "toll1Table";
            toll1Table.RowHeadersWidth = 51;
            toll1Table.Size = new Size(461, 188);
            toll1Table.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 284);
            label8.Name = "label8";
            label8.Size = new Size(339, 28);
            label8.TabIndex = 1;
            label8.Text = "Очередь на второй пункт пропуска";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(732, 265);
            label11.Name = "label11";
            label11.Size = new Size(228, 28);
            label11.TabIndex = 1;
            label11.Text = "Второй пункт пропуска";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(709, 23);
            label10.Name = "label10";
            label10.Size = new Size(234, 28);
            label10.TabIndex = 1;
            label10.Text = "Первый пункт пропуска";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(355, 6);
            label9.Name = "label9";
            label9.Size = new Size(229, 28);
            label9.TabIndex = 1;
            label9.Text = "Едут ко второму пункту";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 6);
            label7.Name = "label7";
            label7.Size = new Size(343, 28);
            label7.TabIndex = 1;
            label7.Text = "Очередь на первый пункт пропуска";
            // 
            // arrival2Queue
            // 
            arrival2Queue.FormattingEnabled = true;
            arrival2Queue.ItemHeight = 28;
            arrival2Queue.Location = new Point(6, 312);
            arrival2Queue.Name = "arrival2Queue";
            arrival2Queue.SelectionMode = SelectionMode.None;
            arrival2Queue.Size = new Size(165, 172);
            arrival2Queue.TabIndex = 0;
            // 
            // travel2List
            // 
            travel2List.FormattingEnabled = true;
            travel2List.ItemHeight = 28;
            travel2List.Location = new Point(355, 34);
            travel2List.Name = "travel2List";
            travel2List.SelectionMode = SelectionMode.None;
            travel2List.Size = new Size(165, 172);
            travel2List.TabIndex = 0;
            // 
            // arrival1Queue
            // 
            arrival1Queue.FormattingEnabled = true;
            arrival1Queue.ItemHeight = 28;
            arrival1Queue.Location = new Point(6, 34);
            arrival1Queue.Name = "arrival1Queue";
            arrival1Queue.SelectionMode = SelectionMode.None;
            arrival1Queue.Size = new Size(165, 172);
            arrival1Queue.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(resetBtn);
            tabPage2.Controls.Add(CarArrivalInterval);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(toll1Interval);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(tollsInterval);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(highwayToll2Interval);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(toll1GateCount);
            tabPage2.Controls.Add(toll2GateCount);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1068, 594);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Параметры";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(523, 353);
            button1.Name = "button1";
            button1.Size = new Size(287, 51);
            button1.TabIndex = 3;
            button1.Text = "Применить новые значения";
            button1.UseVisualStyleBackColor = true;
            // 
            // resetBtn
            // 
            resetBtn.Location = new Point(259, 353);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(258, 51);
            resetBtn.TabIndex = 3;
            resetBtn.Text = "Значения по умолчанию";
            resetBtn.UseVisualStyleBackColor = true;
            resetBtn.Click += resetBtn_Click;
            // 
            // TollBooth1
            // 
            TollBooth1.HeaderText = "№";
            TollBooth1.MinimumWidth = 6;
            TollBooth1.Name = "TollBooth1";
            TollBooth1.ReadOnly = true;
            TollBooth1.SortMode = DataGridViewColumnSortMode.NotSortable;
            TollBooth1.Width = 125;
            // 
            // Toll1Car
            // 
            Toll1Car.HeaderText = "Автомобиль";
            Toll1Car.MinimumWidth = 6;
            Toll1Car.Name = "Toll1Car";
            Toll1Car.ReadOnly = true;
            Toll1Car.SortMode = DataGridViewColumnSortMode.NotSortable;
            Toll1Car.Width = 150;
            // 
            // toll1TimeLeft
            // 
            toll1TimeLeft.HeaderText = "Ост. время";
            toll1TimeLeft.MinimumWidth = 6;
            toll1TimeLeft.Name = "toll1TimeLeft";
            toll1TimeLeft.ReadOnly = true;
            toll1TimeLeft.SortMode = DataGridViewColumnSortMode.NotSortable;
            toll1TimeLeft.Width = 125;
            // 
            // TollBooth2
            // 
            TollBooth2.HeaderText = "№";
            TollBooth2.MinimumWidth = 6;
            TollBooth2.Name = "TollBooth2";
            TollBooth2.ReadOnly = true;
            TollBooth2.SortMode = DataGridViewColumnSortMode.NotSortable;
            TollBooth2.Width = 125;
            // 
            // Toll2Car
            // 
            Toll2Car.HeaderText = "Автомобиль";
            Toll2Car.MinimumWidth = 6;
            Toll2Car.Name = "Toll2Car";
            Toll2Car.ReadOnly = true;
            Toll2Car.SortMode = DataGridViewColumnSortMode.NotSortable;
            Toll2Car.Width = 150;
            // 
            // Toll2TimeLeft
            // 
            Toll2TimeLeft.HeaderText = "Ост. время";
            Toll2TimeLeft.MinimumWidth = 6;
            Toll2TimeLeft.Name = "Toll2TimeLeft";
            Toll2TimeLeft.ReadOnly = true;
            Toll2TimeLeft.SortMode = DataGridViewColumnSortMode.NotSortable;
            Toll2TimeLeft.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 651);
            Controls.Add(tabControl1);
            Controls.Add(carArriveIntervalInput);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "TAKE A [ A Ride around Town on Your Specil Cungadero]";
            ((System.ComponentModel.ISupportInitialize)carArriveIntervalInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)toll1Interval).EndInit();
            ((System.ComponentModel.ISupportInitialize)CarArrivalInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)tollsInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)highwayToll2Interval).EndInit();
            ((System.ComponentModel.ISupportInitialize)toll1GateCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)toll2GateCount).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)toll2Table).EndInit();
            ((System.ComponentModel.ISupportInitialize)toll1Table).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown carArriveIntervalInput;
        private NumericUpDown toll1Interval;
        private NumericUpDown CarArrivalInterval;
        private NumericUpDown tollsInterval;
        private NumericUpDown highwayToll2Interval;
        private NumericUpDown toll1GateCount;
        private NumericUpDown toll2GateCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Button resetBtn;
        private ListBox arrival1Queue;
        private Label label7;
        private Label label8;
        private ListBox arrival2Queue;
        private Label label10;
        private Label label9;
        private ListBox travel2List;
        private DataGridView toll1Table;
        private DataGridView toll2Table;
        private Label label11;
        private DataGridViewTextBoxColumn TollBooth2;
        private DataGridViewTextBoxColumn Toll2Car;
        private DataGridViewTextBoxColumn Toll2TimeLeft;
        private DataGridViewTextBoxColumn TollBooth1;
        private DataGridViewTextBoxColumn Toll1Car;
        private DataGridViewTextBoxColumn toll1TimeLeft;
    }
}
