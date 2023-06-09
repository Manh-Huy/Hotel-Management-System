namespace _20142178_20110370_Nhom15_QLHotel
{
    partial class TimeSheetForEachEmployeeForm
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
            this.panelInfoUser = new System.Windows.Forms.Panel();
            this.lblRoleUser = new System.Windows.Forms.Label();
            this.lblWelcomeEmployee = new System.Windows.Forms.Label();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.dataGridViewTimesheetEmployeeList = new System.Windows.Forms.DataGridView();
            this.lblTimeSheet = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxRole = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCalculateSalary = new System.Windows.Forms.Button();
            this.panelCalculateSalary = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnDeleteCalculate = new System.Windows.Forms.Button();
            this.lblCalculate = new System.Windows.Forms.Label();
            this.lblTimeEnd = new System.Windows.Forms.Label();
            this.lblTimeStart = new System.Windows.Forms.Label();
            this.btnSelectToCalculate = new System.Windows.Forms.Button();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.dataGridViewSalaryList = new System.Windows.Forms.DataGridView();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.panelInfoUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimesheetEmployeeList)).BeginInit();
            this.panelCalculateSalary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalaryList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInfoUser
            // 
            this.panelInfoUser.BackColor = System.Drawing.Color.Teal;
            this.panelInfoUser.Controls.Add(this.lblRoleUser);
            this.panelInfoUser.Controls.Add(this.lblWelcomeEmployee);
            this.panelInfoUser.Controls.Add(this.pictureBoxUser);
            this.panelInfoUser.Location = new System.Drawing.Point(0, 1);
            this.panelInfoUser.Name = "panelInfoUser";
            this.panelInfoUser.Size = new System.Drawing.Size(1710, 115);
            this.panelInfoUser.TabIndex = 92;
            // 
            // lblRoleUser
            // 
            this.lblRoleUser.AutoSize = true;
            this.lblRoleUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRoleUser.Location = new System.Drawing.Point(143, 50);
            this.lblRoleUser.Name = "lblRoleUser";
            this.lblRoleUser.Size = new System.Drawing.Size(156, 20);
            this.lblRoleUser.TabIndex = 18;
            this.lblRoleUser.Text = "Role: (role name)";
            // 
            // lblWelcomeEmployee
            // 
            this.lblWelcomeEmployee.AutoSize = true;
            this.lblWelcomeEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeEmployee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWelcomeEmployee.Location = new System.Drawing.Point(143, 13);
            this.lblWelcomeEmployee.Name = "lblWelcomeEmployee";
            this.lblWelcomeEmployee.Size = new System.Drawing.Size(194, 20);
            this.lblWelcomeEmployee.TabIndex = 15;
            this.lblWelcomeEmployee.Text = "Welcome (user name)";
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.Location = new System.Drawing.Point(37, 13);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(80, 75);
            this.pictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUser.TabIndex = 14;
            this.pictureBoxUser.TabStop = false;
            // 
            // dataGridViewTimesheetEmployeeList
            // 
            this.dataGridViewTimesheetEmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTimesheetEmployeeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTimesheetEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimesheetEmployeeList.Location = new System.Drawing.Point(88, 309);
            this.dataGridViewTimesheetEmployeeList.Name = "dataGridViewTimesheetEmployeeList";
            this.dataGridViewTimesheetEmployeeList.RowHeadersWidth = 51;
            this.dataGridViewTimesheetEmployeeList.RowTemplate.Height = 24;
            this.dataGridViewTimesheetEmployeeList.Size = new System.Drawing.Size(767, 379);
            this.dataGridViewTimesheetEmployeeList.TabIndex = 152;
            this.dataGridViewTimesheetEmployeeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTimesheetEmployeeList_CellClick);
            // 
            // lblTimeSheet
            // 
            this.lblTimeSheet.AutoSize = true;
            this.lblTimeSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSheet.ForeColor = System.Drawing.Color.White;
            this.lblTimeSheet.Location = new System.Drawing.Point(356, 175);
            this.lblTimeSheet.Name = "lblTimeSheet";
            this.lblTimeSheet.Size = new System.Drawing.Size(213, 38);
            this.lblTimeSheet.TabIndex = 158;
            this.lblTimeSheet.Text = "TIMESHEET";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.White;
            this.lblFullName.Location = new System.Drawing.Point(129, 239);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(130, 29);
            this.lblFullName.TabIndex = 159;
            this.lblFullName.Text = "Full Name:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(265, 246);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.ReadOnly = true;
            this.textBoxFullName.Size = new System.Drawing.Size(179, 22);
            this.textBoxFullName.TabIndex = 160;
            // 
            // textBoxRole
            // 
            this.textBoxRole.Location = new System.Drawing.Point(598, 246);
            this.textBoxRole.Name = "textBoxRole";
            this.textBoxRole.ReadOnly = true;
            this.textBoxRole.Size = new System.Drawing.Size(119, 22);
            this.textBoxRole.TabIndex = 162;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(522, 239);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(70, 29);
            this.lblRole.TabIndex = 161;
            this.lblRole.Text = "Role:";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.Green;
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(134, 715);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(149, 48);
            this.btnCheckIn.TabIndex = 163;
            this.btnCheckIn.TabStop = false;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Navy;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(650, 715);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(149, 48);
            this.btnCheckOut.TabIndex = 164;
            this.btnCheckOut.TabStop = false;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(391, 715);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 48);
            this.btnSave.TabIndex = 165;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCalculateSalary
            // 
            this.btnCalculateSalary.BackColor = System.Drawing.Color.Teal;
            this.btnCalculateSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateSalary.ForeColor = System.Drawing.Color.White;
            this.btnCalculateSalary.Location = new System.Drawing.Point(88, 567);
            this.btnCalculateSalary.Name = "btnCalculateSalary";
            this.btnCalculateSalary.Size = new System.Drawing.Size(231, 48);
            this.btnCalculateSalary.TabIndex = 174;
            this.btnCalculateSalary.TabStop = false;
            this.btnCalculateSalary.Text = "Calculate Salary";
            this.btnCalculateSalary.UseVisualStyleBackColor = false;
            this.btnCalculateSalary.Click += new System.EventHandler(this.btnCalculateSalary_Click);
            // 
            // panelCalculateSalary
            // 
            this.panelCalculateSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelCalculateSalary.Controls.Add(this.btnShowAll);
            this.panelCalculateSalary.Controls.Add(this.btnDeleteCalculate);
            this.panelCalculateSalary.Controls.Add(this.lblCalculate);
            this.panelCalculateSalary.Controls.Add(this.lblTimeEnd);
            this.panelCalculateSalary.Controls.Add(this.btnCalculateSalary);
            this.panelCalculateSalary.Controls.Add(this.lblTimeStart);
            this.panelCalculateSalary.Controls.Add(this.btnSelectToCalculate);
            this.panelCalculateSalary.Controls.Add(this.textBoxEnd);
            this.panelCalculateSalary.Controls.Add(this.textBoxStart);
            this.panelCalculateSalary.Controls.Add(this.dataGridViewSalaryList);
            this.panelCalculateSalary.Controls.Add(this.btnCalculate);
            this.panelCalculateSalary.Enabled = false;
            this.panelCalculateSalary.Location = new System.Drawing.Point(897, 148);
            this.panelCalculateSalary.Name = "panelCalculateSalary";
            this.panelCalculateSalary.Size = new System.Drawing.Size(704, 642);
            this.panelCalculateSalary.TabIndex = 175;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(480, 197);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(163, 48);
            this.btnShowAll.TabIndex = 183;
            this.btnShowAll.TabStop = false;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnDeleteCalculate
            // 
            this.btnDeleteCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCalculate.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCalculate.Location = new System.Drawing.Point(377, 567);
            this.btnDeleteCalculate.Name = "btnDeleteCalculate";
            this.btnDeleteCalculate.Size = new System.Drawing.Size(231, 48);
            this.btnDeleteCalculate.TabIndex = 182;
            this.btnDeleteCalculate.TabStop = false;
            this.btnDeleteCalculate.Text = "Delete Calculate";
            this.btnDeleteCalculate.UseVisualStyleBackColor = false;
            this.btnDeleteCalculate.Click += new System.EventHandler(this.btnDeleteCalculate_Click);
            // 
            // lblCalculate
            // 
            this.lblCalculate.AutoSize = true;
            this.lblCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculate.ForeColor = System.Drawing.Color.White;
            this.lblCalculate.Location = new System.Drawing.Point(161, 27);
            this.lblCalculate.Name = "lblCalculate";
            this.lblCalculate.Size = new System.Drawing.Size(366, 38);
            this.lblCalculate.TabIndex = 181;
            this.lblCalculate.Text = "CALCULATE SALARY";
            // 
            // lblTimeEnd
            // 
            this.lblTimeEnd.AutoSize = true;
            this.lblTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeEnd.ForeColor = System.Drawing.Color.White;
            this.lblTimeEnd.Location = new System.Drawing.Point(363, 144);
            this.lblTimeEnd.Name = "lblTimeEnd";
            this.lblTimeEnd.Size = new System.Drawing.Size(124, 29);
            this.lblTimeEnd.TabIndex = 180;
            this.lblTimeEnd.Text = "Time End:";
            // 
            // lblTimeStart
            // 
            this.lblTimeStart.AutoSize = true;
            this.lblTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeStart.ForeColor = System.Drawing.Color.White;
            this.lblTimeStart.Location = new System.Drawing.Point(357, 102);
            this.lblTimeStart.Name = "lblTimeStart";
            this.lblTimeStart.Size = new System.Drawing.Size(130, 29);
            this.lblTimeStart.TabIndex = 179;
            this.lblTimeStart.Text = "Time Start:";
            // 
            // btnSelectToCalculate
            // 
            this.btnSelectToCalculate.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSelectToCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectToCalculate.ForeColor = System.Drawing.Color.White;
            this.btnSelectToCalculate.Location = new System.Drawing.Point(49, 102);
            this.btnSelectToCalculate.Name = "btnSelectToCalculate";
            this.btnSelectToCalculate.Size = new System.Drawing.Size(283, 48);
            this.btnSelectToCalculate.TabIndex = 178;
            this.btnSelectToCalculate.TabStop = false;
            this.btnSelectToCalculate.Text = "Select To Calculate Time";
            this.btnSelectToCalculate.UseVisualStyleBackColor = false;
            this.btnSelectToCalculate.Click += new System.EventHandler(this.btnSelectToCalculate_Click);
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Location = new System.Drawing.Point(493, 144);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(176, 22);
            this.textBoxEnd.TabIndex = 177;
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(493, 104);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(176, 22);
            this.textBoxStart.TabIndex = 176;
            // 
            // dataGridViewSalaryList
            // 
            this.dataGridViewSalaryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSalaryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalaryList.Location = new System.Drawing.Point(65, 261);
            this.dataGridViewSalaryList.Name = "dataGridViewSalaryList";
            this.dataGridViewSalaryList.RowHeadersWidth = 51;
            this.dataGridViewSalaryList.RowTemplate.Height = 24;
            this.dataGridViewSalaryList.Size = new System.Drawing.Size(578, 279);
            this.dataGridViewSalaryList.TabIndex = 175;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Purple;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(101, 161);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(231, 48);
            this.btnCalculate.TabIndex = 174;
            this.btnCalculate.TabStop = false;
            this.btnCalculate.Text = "Calculate Time";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // TimeSheetForEachEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1710, 829);
            this.Controls.Add(this.panelCalculateSalary);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.textBoxRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblTimeSheet);
            this.Controls.Add(this.dataGridViewTimesheetEmployeeList);
            this.Controls.Add(this.panelInfoUser);
            this.Name = "TimeSheetForEachEmployeeForm";
            this.Text = "TimeSheetForEachEmployeeForm";
            this.Load += new System.EventHandler(this.TimeSheetForEachEmployeeForm_Load);
            this.panelInfoUser.ResumeLayout(false);
            this.panelInfoUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimesheetEmployeeList)).EndInit();
            this.panelCalculateSalary.ResumeLayout(false);
            this.panelCalculateSalary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalaryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInfoUser;
        private System.Windows.Forms.Label lblRoleUser;
        private System.Windows.Forms.Label lblWelcomeEmployee;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.DataGridView dataGridViewTimesheetEmployeeList;
        private System.Windows.Forms.Label lblTimeSheet;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnCalculateSalary;
        private System.Windows.Forms.Label lblCalculate;
        private System.Windows.Forms.Label lblTimeEnd;
        private System.Windows.Forms.Label lblTimeStart;
        private System.Windows.Forms.Button btnSelectToCalculate;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.DataGridView dataGridViewSalaryList;
        private System.Windows.Forms.Button btnCalculate;
        public System.Windows.Forms.Panel panelCalculateSalary;
        public System.Windows.Forms.Button btnCheckIn;
        public System.Windows.Forms.Button btnCheckOut;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteCalculate;
        private System.Windows.Forms.Button btnShowAll;
    }
}