namespace _20142178_20110370_Nhom15_QLHotel
{
    partial class AllSalaryEmployeeForm
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
            this.lblTotalPenalty = new System.Windows.Forms.Label();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.dataGridViewSalaryList = new System.Windows.Forms.DataGridView();
            this.lblEmployeeList = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.dataGridViewEmployeeList = new System.Windows.Forms.DataGridView();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalaryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalPenalty
            // 
            this.lblTotalPenalty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPenalty.ForeColor = System.Drawing.Color.White;
            this.lblTotalPenalty.Location = new System.Drawing.Point(844, 440);
            this.lblTotalPenalty.Name = "lblTotalPenalty";
            this.lblTotalPenalty.Size = new System.Drawing.Size(259, 36);
            this.lblTotalPenalty.TabIndex = 167;
            this.lblTotalPenalty.Text = "Total Penalty: ";
            this.lblTotalPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalary.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalary.Location = new System.Drawing.Point(429, 440);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(259, 36);
            this.lblTotalSalary.TabIndex = 166;
            this.lblTotalSalary.Text = "Total Salary: ";
            this.lblTotalSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.ForeColor = System.Drawing.Color.White;
            this.lblSalary.Location = new System.Drawing.Point(691, 26);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(153, 38);
            this.lblSalary.TabIndex = 165;
            this.lblSalary.Text = "SALARY";
            // 
            // dataGridViewSalaryList
            // 
            this.dataGridViewSalaryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSalaryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalaryList.Location = new System.Drawing.Point(459, 114);
            this.dataGridViewSalaryList.Name = "dataGridViewSalaryList";
            this.dataGridViewSalaryList.RowHeadersWidth = 51;
            this.dataGridViewSalaryList.RowTemplate.Height = 24;
            this.dataGridViewSalaryList.Size = new System.Drawing.Size(607, 297);
            this.dataGridViewSalaryList.TabIndex = 164;
            // 
            // lblEmployeeList
            // 
            this.lblEmployeeList.AutoSize = true;
            this.lblEmployeeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeList.ForeColor = System.Drawing.Color.White;
            this.lblEmployeeList.Location = new System.Drawing.Point(118, 71);
            this.lblEmployeeList.Name = "lblEmployeeList";
            this.lblEmployeeList.Size = new System.Drawing.Size(165, 29);
            this.lblEmployeeList.TabIndex = 171;
            this.lblEmployeeList.Text = "Employee List";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(92, 26);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(70, 29);
            this.lblRole.TabIndex = 169;
            this.lblRole.Text = "Role:";
            // 
            // dataGridViewEmployeeList
            // 
            this.dataGridViewEmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmployeeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeList.Location = new System.Drawing.Point(37, 114);
            this.dataGridViewEmployeeList.Name = "dataGridViewEmployeeList";
            this.dataGridViewEmployeeList.RowHeadersWidth = 51;
            this.dataGridViewEmployeeList.RowTemplate.Height = 24;
            this.dataGridViewEmployeeList.Size = new System.Drawing.Size(329, 297);
            this.dataGridViewEmployeeList.TabIndex = 170;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(181, 31);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(143, 24);
            this.comboBoxRole.TabIndex = 168;
            this.comboBoxRole.SelectedIndexChanged += new System.EventHandler(this.comboBoxRole_SelectedIndexChanged);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Green;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(123, 437);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(148, 39);
            this.btnShow.TabIndex = 172;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // AllSalaryEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1145, 526);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblEmployeeList);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.dataGridViewEmployeeList);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.lblTotalPenalty);
            this.Controls.Add(this.lblTotalSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.dataGridViewSalaryList);
            this.Name = "AllSalaryEmployeeForm";
            this.Text = "AllSalaryEmployeeForm";
            this.Load += new System.EventHandler(this.AllSalaryEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalaryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalPenalty;
        private System.Windows.Forms.Label lblTotalSalary;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.DataGridView dataGridViewSalaryList;
        private System.Windows.Forms.Label lblEmployeeList;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeList;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Button btnShow;
    }
}