namespace _20142178_20110370_Nhom15_QLHotel
{
    partial class SalaryEmployeeForm
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
            this.dataGridViewSalaryList = new System.Windows.Forms.DataGridView();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.lblTotalPenalty = new System.Windows.Forms.Label();
            this.panelInfoUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalaryList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInfoUser
            // 
            this.panelInfoUser.BackColor = System.Drawing.Color.Teal;
            this.panelInfoUser.Controls.Add(this.lblRoleUser);
            this.panelInfoUser.Controls.Add(this.lblWelcomeEmployee);
            this.panelInfoUser.Controls.Add(this.pictureBoxUser);
            this.panelInfoUser.Location = new System.Drawing.Point(1, 0);
            this.panelInfoUser.Name = "panelInfoUser";
            this.panelInfoUser.Size = new System.Drawing.Size(775, 115);
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
            // dataGridViewSalaryList
            // 
            this.dataGridViewSalaryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSalaryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalaryList.Location = new System.Drawing.Point(84, 209);
            this.dataGridViewSalaryList.Name = "dataGridViewSalaryList";
            this.dataGridViewSalaryList.RowHeadersWidth = 51;
            this.dataGridViewSalaryList.RowTemplate.Height = 24;
            this.dataGridViewSalaryList.Size = new System.Drawing.Size(607, 247);
            this.dataGridViewSalaryList.TabIndex = 93;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.ForeColor = System.Drawing.Color.White;
            this.lblSalary.Location = new System.Drawing.Point(318, 149);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(153, 38);
            this.lblSalary.TabIndex = 159;
            this.lblSalary.Text = "SALARY";
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalary.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalary.Location = new System.Drawing.Point(54, 485);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(259, 36);
            this.lblTotalSalary.TabIndex = 162;
            this.lblTotalSalary.Text = "Total Salary: ";
            this.lblTotalSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalPenalty
            // 
            this.lblTotalPenalty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPenalty.ForeColor = System.Drawing.Color.White;
            this.lblTotalPenalty.Location = new System.Drawing.Point(469, 485);
            this.lblTotalPenalty.Name = "lblTotalPenalty";
            this.lblTotalPenalty.Size = new System.Drawing.Size(259, 36);
            this.lblTotalPenalty.TabIndex = 163;
            this.lblTotalPenalty.Text = "Total Penalty: ";
            this.lblTotalPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SalaryEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(773, 569);
            this.Controls.Add(this.lblTotalPenalty);
            this.Controls.Add(this.lblTotalSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.dataGridViewSalaryList);
            this.Controls.Add(this.panelInfoUser);
            this.Name = "SalaryEmployeeForm";
            this.Text = "SalaryEmployeeForm";
            this.Load += new System.EventHandler(this.SalaryEmployeeForm_Load);
            this.panelInfoUser.ResumeLayout(false);
            this.panelInfoUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalaryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInfoUser;
        private System.Windows.Forms.Label lblRoleUser;
        private System.Windows.Forms.Label lblWelcomeEmployee;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.DataGridView dataGridViewSalaryList;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblTotalSalary;
        private System.Windows.Forms.Label lblTotalPenalty;
    }
}