namespace _20142178_20110370_Nhom15_QLHotel
{
    partial class EmployeeListForm
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
            this.lblEmployeeList = new System.Windows.Forms.Label();
            this.btnShowTimeSheet = new System.Windows.Forms.Button();
            this.comboBoxSelectRole = new System.Windows.Forms.ComboBox();
            this.lblSelectRole = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataGridViewEmployeeList = new System.Windows.Forms.DataGridView();
            this.panelInfoUser = new System.Windows.Forms.Panel();
            this.lblRoleUser = new System.Windows.Forms.Label();
            this.lblWelcomeEmployee = new System.Windows.Forms.Label();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).BeginInit();
            this.panelInfoUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmployeeList
            // 
            this.lblEmployeeList.AutoSize = true;
            this.lblEmployeeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeList.ForeColor = System.Drawing.Color.White;
            this.lblEmployeeList.Location = new System.Drawing.Point(341, 166);
            this.lblEmployeeList.Name = "lblEmployeeList";
            this.lblEmployeeList.Size = new System.Drawing.Size(288, 38);
            this.lblEmployeeList.TabIndex = 157;
            this.lblEmployeeList.Text = "EMPLOYEE LIST";
            // 
            // btnShowTimeSheet
            // 
            this.btnShowTimeSheet.BackColor = System.Drawing.Color.Olive;
            this.btnShowTimeSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTimeSheet.ForeColor = System.Drawing.Color.White;
            this.btnShowTimeSheet.Location = new System.Drawing.Point(376, 675);
            this.btnShowTimeSheet.Name = "btnShowTimeSheet";
            this.btnShowTimeSheet.Size = new System.Drawing.Size(229, 48);
            this.btnShowTimeSheet.TabIndex = 156;
            this.btnShowTimeSheet.TabStop = false;
            this.btnShowTimeSheet.Text = "Show TimeSheet";
            this.btnShowTimeSheet.UseVisualStyleBackColor = false;
            this.btnShowTimeSheet.Click += new System.EventHandler(this.btnShowTimeSheet_Click);
            // 
            // comboBoxSelectRole
            // 
            this.comboBoxSelectRole.FormattingEnabled = true;
            this.comboBoxSelectRole.Location = new System.Drawing.Point(479, 229);
            this.comboBoxSelectRole.Name = "comboBoxSelectRole";
            this.comboBoxSelectRole.Size = new System.Drawing.Size(157, 24);
            this.comboBoxSelectRole.TabIndex = 155;
            this.comboBoxSelectRole.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectRole_SelectedIndexChanged);
            // 
            // lblSelectRole
            // 
            this.lblSelectRole.AutoSize = true;
            this.lblSelectRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectRole.ForeColor = System.Drawing.Color.White;
            this.lblSelectRole.Location = new System.Drawing.Point(329, 224);
            this.lblSelectRole.Name = "lblSelectRole";
            this.lblSelectRole.Size = new System.Drawing.Size(144, 29);
            this.lblSelectRole.TabIndex = 154;
            this.lblSelectRole.Text = "Select Role:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(745, 675);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 48);
            this.btnCancel.TabIndex = 153;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(159, 675);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(99, 48);
            this.btnPrint.TabIndex = 152;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // dataGridViewEmployeeList
            // 
            this.dataGridViewEmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeList.Location = new System.Drawing.Point(37, 289);
            this.dataGridViewEmployeeList.Name = "dataGridViewEmployeeList";
            this.dataGridViewEmployeeList.RowHeadersWidth = 51;
            this.dataGridViewEmployeeList.RowTemplate.Height = 24;
            this.dataGridViewEmployeeList.Size = new System.Drawing.Size(891, 353);
            this.dataGridViewEmployeeList.TabIndex = 151;
            this.dataGridViewEmployeeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployeeList_CellDoubleClick);
            // 
            // panelInfoUser
            // 
            this.panelInfoUser.BackColor = System.Drawing.Color.Teal;
            this.panelInfoUser.Controls.Add(this.lblRoleUser);
            this.panelInfoUser.Controls.Add(this.lblWelcomeEmployee);
            this.panelInfoUser.Controls.Add(this.pictureBoxUser);
            this.panelInfoUser.Location = new System.Drawing.Point(0, 1);
            this.panelInfoUser.Name = "panelInfoUser";
            this.panelInfoUser.Size = new System.Drawing.Size(979, 115);
            this.panelInfoUser.TabIndex = 158;
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
            // EmployeeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(978, 771);
            this.Controls.Add(this.panelInfoUser);
            this.Controls.Add(this.lblEmployeeList);
            this.Controls.Add(this.btnShowTimeSheet);
            this.Controls.Add(this.comboBoxSelectRole);
            this.Controls.Add(this.lblSelectRole);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGridViewEmployeeList);
            this.Name = "EmployeeListForm";
            this.Text = "EmployeeListForm";
            this.Load += new System.EventHandler(this.EmployeeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).EndInit();
            this.panelInfoUser.ResumeLayout(false);
            this.panelInfoUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmployeeList;
        private System.Windows.Forms.Button btnShowTimeSheet;
        private System.Windows.Forms.ComboBox comboBoxSelectRole;
        private System.Windows.Forms.Label lblSelectRole;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeList;
        private System.Windows.Forms.Panel panelInfoUser;
        private System.Windows.Forms.Label lblRoleUser;
        private System.Windows.Forms.Label lblWelcomeEmployee;
        private System.Windows.Forms.PictureBox pictureBoxUser;
    }
}