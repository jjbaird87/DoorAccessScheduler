namespace DoorOpenAccessScheduler.UI
{
    partial class ConfigurationForm
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
            this.tabSchedules = new System.Windows.Forms.TabControl();
            this.tabpgStandard = new System.Windows.Forms.TabPage();
            this.btnSaveWeekSchedule = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAccessSchedules = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDayOfTheWeek = new System.Windows.Forms.ComboBox();
            this.tabpgExclusions = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveHoliday = new System.Windows.Forms.Button();
            this.btnDeleteHolidaySlot = new System.Windows.Forms.Button();
            this.btnAddHolidaySlot = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHolidayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtHolidayStart = new System.Windows.Forms.DateTimePicker();
            this.dtHolidayEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvHolidaySlots = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddHoliday = new System.Windows.Forms.Button();
            this.btnRemoveHoliday = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbHolidaySchedule = new System.Windows.Forms.ComboBox();
            this.tabSchedules.SuspendLayout();
            this.tabpgStandard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccessSchedules)).BeginInit();
            this.tabpgExclusions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidaySlots)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSchedules
            // 
            this.tabSchedules.Controls.Add(this.tabpgStandard);
            this.tabSchedules.Controls.Add(this.tabpgExclusions);
            this.tabSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSchedules.Location = new System.Drawing.Point(0, 0);
            this.tabSchedules.Name = "tabSchedules";
            this.tabSchedules.SelectedIndex = 0;
            this.tabSchedules.Size = new System.Drawing.Size(479, 601);
            this.tabSchedules.TabIndex = 0;
            // 
            // tabpgStandard
            // 
            this.tabpgStandard.Controls.Add(this.btnSaveWeekSchedule);
            this.tabpgStandard.Controls.Add(this.btnDeleteRow);
            this.tabpgStandard.Controls.Add(this.btnAddRow);
            this.tabpgStandard.Controls.Add(this.label2);
            this.tabpgStandard.Controls.Add(this.dgvAccessSchedules);
            this.tabpgStandard.Controls.Add(this.label1);
            this.tabpgStandard.Controls.Add(this.cmbDayOfTheWeek);
            this.tabpgStandard.Location = new System.Drawing.Point(4, 22);
            this.tabpgStandard.Name = "tabpgStandard";
            this.tabpgStandard.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgStandard.Size = new System.Drawing.Size(471, 575);
            this.tabpgStandard.TabIndex = 0;
            this.tabpgStandard.Text = "Schedules";
            this.tabpgStandard.UseVisualStyleBackColor = true;
            // 
            // btnSaveWeekSchedule
            // 
            this.btnSaveWeekSchedule.Location = new System.Drawing.Point(206, 389);
            this.btnSaveWeekSchedule.Name = "btnSaveWeekSchedule";
            this.btnSaveWeekSchedule.Size = new System.Drawing.Size(75, 23);
            this.btnSaveWeekSchedule.TabIndex = 5;
            this.btnSaveWeekSchedule.Text = "Save";
            this.btnSaveWeekSchedule.UseVisualStyleBackColor = true;
            this.btnSaveWeekSchedule.Click += new System.EventHandler(this.btnSaveWeekSchedule_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(368, 389);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRow.TabIndex = 4;
            this.btnDeleteRow.Text = "Delete Row";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(287, 389);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Open Door Schedules:";
            // 
            // dgvAccessSchedules
            // 
            this.dgvAccessSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccessSchedules.Location = new System.Drawing.Point(16, 73);
            this.dgvAccessSchedules.MultiSelect = false;
            this.dgvAccessSchedules.Name = "dgvAccessSchedules";
            this.dgvAccessSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccessSchedules.Size = new System.Drawing.Size(427, 310);
            this.dgvAccessSchedules.TabIndex = 1;
            this.dgvAccessSchedules.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAccessSchedules_CellValidating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Day of the week:";
            // 
            // cmbDayOfTheWeek
            // 
            this.cmbDayOfTheWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayOfTheWeek.FormattingEnabled = true;
            this.cmbDayOfTheWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbDayOfTheWeek.Location = new System.Drawing.Point(107, 17);
            this.cmbDayOfTheWeek.Name = "cmbDayOfTheWeek";
            this.cmbDayOfTheWeek.Size = new System.Drawing.Size(336, 21);
            this.cmbDayOfTheWeek.TabIndex = 0;
            this.cmbDayOfTheWeek.SelectedIndexChanged += new System.EventHandler(this.cmbDayOfTheWeek_SelectedIndexChanged);
            // 
            // tabpgExclusions
            // 
            this.tabpgExclusions.Controls.Add(this.groupBox1);
            this.tabpgExclusions.Controls.Add(this.btnAddHoliday);
            this.tabpgExclusions.Controls.Add(this.btnRemoveHoliday);
            this.tabpgExclusions.Controls.Add(this.label6);
            this.tabpgExclusions.Controls.Add(this.cmbHolidaySchedule);
            this.tabpgExclusions.Location = new System.Drawing.Point(4, 22);
            this.tabpgExclusions.Name = "tabpgExclusions";
            this.tabpgExclusions.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgExclusions.Size = new System.Drawing.Size(471, 575);
            this.tabpgExclusions.TabIndex = 1;
            this.tabpgExclusions.Text = "Holiday Schedule";
            this.tabpgExclusions.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveHoliday);
            this.groupBox1.Controls.Add(this.btnDeleteHolidaySlot);
            this.groupBox1.Controls.Add(this.btnAddHolidaySlot);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtHolidayName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtHolidayStart);
            this.groupBox1.Controls.Add(this.dtHolidayEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvHolidaySlots);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(19, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 496);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Holiday Schedule";
            // 
            // btnSaveHoliday
            // 
            this.btnSaveHoliday.Location = new System.Drawing.Point(177, 461);
            this.btnSaveHoliday.Name = "btnSaveHoliday";
            this.btnSaveHoliday.Size = new System.Drawing.Size(75, 23);
            this.btnSaveHoliday.TabIndex = 0;
            this.btnSaveHoliday.Text = "Save";
            this.btnSaveHoliday.UseVisualStyleBackColor = true;
            this.btnSaveHoliday.Click += new System.EventHandler(this.btnSaveHoliday_Click);
            // 
            // btnDeleteHolidaySlot
            // 
            this.btnDeleteHolidaySlot.Location = new System.Drawing.Point(339, 461);
            this.btnDeleteHolidaySlot.Name = "btnDeleteHolidaySlot";
            this.btnDeleteHolidaySlot.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteHolidaySlot.TabIndex = 9;
            this.btnDeleteHolidaySlot.Text = "Delete Row";
            this.btnDeleteHolidaySlot.UseVisualStyleBackColor = true;
            this.btnDeleteHolidaySlot.Click += new System.EventHandler(this.btnDeleteHolidaySlot_Click);
            // 
            // btnAddHolidaySlot
            // 
            this.btnAddHolidaySlot.Location = new System.Drawing.Point(258, 461);
            this.btnAddHolidaySlot.Name = "btnAddHolidaySlot";
            this.btnAddHolidaySlot.Size = new System.Drawing.Size(75, 23);
            this.btnAddHolidaySlot.TabIndex = 8;
            this.btnAddHolidaySlot.Text = "Add Row";
            this.btnAddHolidaySlot.UseVisualStyleBackColor = true;
            this.btnAddHolidaySlot.Click += new System.EventHandler(this.btnAddHolidaySlot_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Name:";
            // 
            // txtHolidayName
            // 
            this.txtHolidayName.Location = new System.Drawing.Point(92, 39);
            this.txtHolidayName.Name = "txtHolidayName";
            this.txtHolidayName.Size = new System.Drawing.Size(322, 20);
            this.txtHolidayName.TabIndex = 6;
            this.txtHolidayName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHolidayName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Holiday Start:";
            // 
            // dtHolidayStart
            // 
            this.dtHolidayStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtHolidayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHolidayStart.Location = new System.Drawing.Point(92, 65);
            this.dtHolidayStart.Name = "dtHolidayStart";
            this.dtHolidayStart.Size = new System.Drawing.Size(322, 20);
            this.dtHolidayStart.TabIndex = 0;
            this.dtHolidayStart.CloseUp += new System.EventHandler(this.dtHolidayStart_CloseUp);
            this.dtHolidayStart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtHolidayStart_KeyUp);
            // 
            // dtHolidayEnd
            // 
            this.dtHolidayEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtHolidayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHolidayEnd.Location = new System.Drawing.Point(92, 96);
            this.dtHolidayEnd.Name = "dtHolidayEnd";
            this.dtHolidayEnd.Size = new System.Drawing.Size(322, 20);
            this.dtHolidayEnd.TabIndex = 1;
            this.dtHolidayEnd.CloseUp += new System.EventHandler(this.dtHolidayEnd_CloseUp);
            this.dtHolidayEnd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtHolidayEnd_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Holiday End:";
            // 
            // dgvHolidaySlots
            // 
            this.dgvHolidaySlots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHolidaySlots.Location = new System.Drawing.Point(19, 145);
            this.dgvHolidaySlots.MultiSelect = false;
            this.dgvHolidaySlots.Name = "dgvHolidaySlots";
            this.dgvHolidaySlots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHolidaySlots.Size = new System.Drawing.Size(395, 310);
            this.dgvHolidaySlots.TabIndex = 4;
            this.dgvHolidaySlots.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvHolidaySlots_CellValidating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Open Door Schedules:";
            // 
            // btnAddHoliday
            // 
            this.btnAddHoliday.Location = new System.Drawing.Point(376, 16);
            this.btnAddHoliday.Name = "btnAddHoliday";
            this.btnAddHoliday.Size = new System.Drawing.Size(26, 21);
            this.btnAddHoliday.TabIndex = 9;
            this.btnAddHoliday.Text = "+";
            this.btnAddHoliday.UseVisualStyleBackColor = true;
            this.btnAddHoliday.Click += new System.EventHandler(this.btnAddHoliday_Click);
            // 
            // btnRemoveHoliday
            // 
            this.btnRemoveHoliday.Location = new System.Drawing.Point(407, 16);
            this.btnRemoveHoliday.Name = "btnRemoveHoliday";
            this.btnRemoveHoliday.Size = new System.Drawing.Size(26, 21);
            this.btnRemoveHoliday.TabIndex = 8;
            this.btnRemoveHoliday.Text = "-";
            this.btnRemoveHoliday.UseVisualStyleBackColor = true;
            this.btnRemoveHoliday.Click += new System.EventHandler(this.btnRemoveHoliday_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Holiday Schedule:";
            // 
            // cmbHolidaySchedule
            // 
            this.cmbHolidaySchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHolidaySchedule.FormattingEnabled = true;
            this.cmbHolidaySchedule.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbHolidaySchedule.Location = new System.Drawing.Point(110, 16);
            this.cmbHolidaySchedule.Name = "cmbHolidaySchedule";
            this.cmbHolidaySchedule.Size = new System.Drawing.Size(260, 21);
            this.cmbHolidaySchedule.TabIndex = 6;
            this.cmbHolidaySchedule.SelectedIndexChanged += new System.EventHandler(this.cmbHolidaySchedule_SelectedIndexChanged);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 601);
            this.Controls.Add(this.tabSchedules);
            this.Name = "ConfigurationForm";
            this.Text = "Door Access Schedules Config";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.tabSchedules.ResumeLayout(false);
            this.tabpgStandard.ResumeLayout(false);
            this.tabpgStandard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccessSchedules)).EndInit();
            this.tabpgExclusions.ResumeLayout(false);
            this.tabpgExclusions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidaySlots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSchedules;
        private System.Windows.Forms.TabPage tabpgStandard;
        private System.Windows.Forms.TabPage tabpgExclusions;
        private System.Windows.Forms.DataGridView dgvAccessSchedules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDayOfTheWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHolidayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtHolidayStart;
        private System.Windows.Forms.DateTimePicker dtHolidayEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvHolidaySlots;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddHoliday;
        private System.Windows.Forms.Button btnRemoveHoliday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbHolidaySchedule;
        private System.Windows.Forms.Button btnDeleteHolidaySlot;
        private System.Windows.Forms.Button btnAddHolidaySlot;
        private System.Windows.Forms.Button btnSaveHoliday;
        private System.Windows.Forms.Button btnSaveWeekSchedule;
    }
}

