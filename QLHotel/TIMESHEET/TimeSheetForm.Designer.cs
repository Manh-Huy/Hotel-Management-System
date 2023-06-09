namespace _20142178_20110370_Nhom15_QLHotel
{
    partial class TimeSheetForm
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
            this.dataGridViewTimeSheet = new System.Windows.Forms.DataGridView();
            this.btnArrange = new System.Windows.Forms.Button();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.dataGridViewEmployeeList = new System.Windows.Forms.DataGridView();
            this.dataGridViewSelectEmloyee = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxNumDays = new System.Windows.Forms.ComboBox();
            this.lblNumberOfDay = new System.Windows.Forms.Label();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.lblEmployeeSelected = new System.Windows.Forms.Label();
            this.lblEmployeeList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectEmloyee)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTimeSheet
            // 
            this.dataGridViewTimeSheet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTimeSheet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTimeSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimeSheet.Location = new System.Drawing.Point(826, 38);
            this.dataGridViewTimeSheet.Name = "dataGridViewTimeSheet";
            this.dataGridViewTimeSheet.RowHeadersWidth = 51;
            this.dataGridViewTimeSheet.RowTemplate.Height = 24;
            this.dataGridViewTimeSheet.Size = new System.Drawing.Size(646, 528);
            this.dataGridViewTimeSheet.TabIndex = 0;
            // 
            // btnArrange
            // 
            this.btnArrange.BackColor = System.Drawing.Color.Olive;
            this.btnArrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrange.ForeColor = System.Drawing.Color.White;
            this.btnArrange.Location = new System.Drawing.Point(398, 489);
            this.btnArrange.Name = "btnArrange";
            this.btnArrange.Size = new System.Drawing.Size(164, 39);
            this.btnArrange.TabIndex = 132;
            this.btnArrange.Text = "Arrange";
            this.btnArrange.UseVisualStyleBackColor = false;
            this.btnArrange.Click += new System.EventHandler(this.btnArrange_Click);
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(379, 32);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(143, 24);
            this.comboBoxRole.TabIndex = 133;
            this.comboBoxRole.SelectedIndexChanged += new System.EventHandler(this.comboBoxRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(290, 27);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(70, 29);
            this.lblRole.TabIndex = 134;
            this.lblRole.Text = "Role:";
            // 
            // dataGridViewEmployeeList
            // 
            this.dataGridViewEmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmployeeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeList.Location = new System.Drawing.Point(31, 182);
            this.dataGridViewEmployeeList.Name = "dataGridViewEmployeeList";
            this.dataGridViewEmployeeList.RowHeadersWidth = 51;
            this.dataGridViewEmployeeList.RowTemplate.Height = 24;
            this.dataGridViewEmployeeList.Size = new System.Drawing.Size(329, 284);
            this.dataGridViewEmployeeList.TabIndex = 135;
            this.dataGridViewEmployeeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployeeList_CellDoubleClick);
            // 
            // dataGridViewSelectEmloyee
            // 
            this.dataGridViewSelectEmloyee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSelectEmloyee.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSelectEmloyee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectEmloyee.Location = new System.Drawing.Point(389, 182);
            this.dataGridViewSelectEmloyee.Name = "dataGridViewSelectEmloyee";
            this.dataGridViewSelectEmloyee.RowHeadersWidth = 51;
            this.dataGridViewSelectEmloyee.RowTemplate.Height = 24;
            this.dataGridViewSelectEmloyee.Size = new System.Drawing.Size(329, 284);
            this.dataGridViewSelectEmloyee.TabIndex = 136;
            this.dataGridViewSelectEmloyee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectEmloyee_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Purple;
            this.panel1.Controls.Add(this.comboBoxNumDays);
            this.panel1.Controls.Add(this.lblNumberOfDay);
            this.panel1.Controls.Add(this.btnRemoveAll);
            this.panel1.Controls.Add(this.btnArrange);
            this.panel1.Controls.Add(this.btnAddAll);
            this.panel1.Controls.Add(this.lblEmployeeSelected);
            this.panel1.Controls.Add(this.lblEmployeeList);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.dataGridViewEmployeeList);
            this.panel1.Controls.Add(this.dataGridViewSelectEmloyee);
            this.panel1.Controls.Add(this.comboBoxRole);
            this.panel1.Location = new System.Drawing.Point(38, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 553);
            this.panel1.TabIndex = 137;
            // 
            // comboBoxNumDays
            // 
            this.comboBoxNumDays.FormattingEnabled = true;
            this.comboBoxNumDays.Items.AddRange(new object[] {
            "12",
            "24",
            "36",
            "48",
            "60"});
            this.comboBoxNumDays.Location = new System.Drawing.Point(257, 498);
            this.comboBoxNumDays.Name = "comboBoxNumDays";
            this.comboBoxNumDays.Size = new System.Drawing.Size(108, 24);
            this.comboBoxNumDays.TabIndex = 143;
            // 
            // lblNumberOfDay
            // 
            this.lblNumberOfDay.AutoSize = true;
            this.lblNumberOfDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfDay.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfDay.Location = new System.Drawing.Point(69, 493);
            this.lblNumberOfDay.Name = "lblNumberOfDay";
            this.lblNumberOfDay.Size = new System.Drawing.Size(182, 29);
            this.lblNumberOfDay.TabIndex = 142;
            this.lblNumberOfDay.Text = "Number of days";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAll.ForeColor = System.Drawing.Color.White;
            this.btnRemoveAll.Location = new System.Drawing.Point(473, 124);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(164, 39);
            this.btnRemoveAll.TabIndex = 141;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.BackColor = System.Drawing.Color.Green;
            this.btnAddAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAll.ForeColor = System.Drawing.Color.White;
            this.btnAddAll.Location = new System.Drawing.Point(110, 124);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(164, 39);
            this.btnAddAll.TabIndex = 140;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // lblEmployeeSelected
            // 
            this.lblEmployeeSelected.AutoSize = true;
            this.lblEmployeeSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeSelected.ForeColor = System.Drawing.Color.White;
            this.lblEmployeeSelected.Location = new System.Drawing.Point(439, 79);
            this.lblEmployeeSelected.Name = "lblEmployeeSelected";
            this.lblEmployeeSelected.Size = new System.Drawing.Size(224, 29);
            this.lblEmployeeSelected.TabIndex = 139;
            this.lblEmployeeSelected.Text = "Employee Selected";
            // 
            // lblEmployeeList
            // 
            this.lblEmployeeList.AutoSize = true;
            this.lblEmployeeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeList.ForeColor = System.Drawing.Color.White;
            this.lblEmployeeList.Location = new System.Drawing.Point(109, 79);
            this.lblEmployeeList.Name = "lblEmployeeList";
            this.lblEmployeeList.Size = new System.Drawing.Size(165, 29);
            this.lblEmployeeList.TabIndex = 138;
            this.lblEmployeeList.Text = "Employee List";
            // 
            // TimeSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1506, 620);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewTimeSheet);
            this.Name = "TimeSheetForm";
            this.Text = "TimeSheetForm";
            this.Load += new System.EventHandler(this.TimeSheetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectEmloyee)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTimeSheet;
        private System.Windows.Forms.Button btnArrange;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeList;
        private System.Windows.Forms.DataGridView dataGridViewSelectEmloyee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEmployeeSelected;
        private System.Windows.Forms.Label lblEmployeeList;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.ComboBox comboBoxNumDays;
        private System.Windows.Forms.Label lblNumberOfDay;
    }
}