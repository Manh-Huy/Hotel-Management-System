namespace _20142178_20110370_Nhom15_QLHotel
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
            this.components = new System.ComponentModel.Container();
            this.panelInfoUser = new System.Windows.Forms.Panel();
            this.lblRoleUser = new System.Windows.Forms.Label();
            this.linkLabelRefresh = new System.Windows.Forms.LinkLabel();
            this.linkLabelEditInfo = new System.Windows.Forms.LinkLabel();
            this.lblWelcomeEmployee = new System.Windows.Forms.Label();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.contextMenuStripEmployee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnArrTimeSheet = new System.Windows.Forms.Button();
            this.btnTimeSheet = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnSalaryAllEmployee = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.contextMenuStripUserManagement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.authenticationUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStatic = new System.Windows.Forms.Button();
            this.panelInfoUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.contextMenuStripEmployee.SuspendLayout();
            this.contextMenuStripUserManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInfoUser
            // 
            this.panelInfoUser.BackColor = System.Drawing.Color.Teal;
            this.panelInfoUser.Controls.Add(this.lblRoleUser);
            this.panelInfoUser.Controls.Add(this.linkLabelRefresh);
            this.panelInfoUser.Controls.Add(this.linkLabelEditInfo);
            this.panelInfoUser.Controls.Add(this.lblWelcomeEmployee);
            this.panelInfoUser.Controls.Add(this.pictureBoxUser);
            this.panelInfoUser.Location = new System.Drawing.Point(2, 1);
            this.panelInfoUser.Name = "panelInfoUser";
            this.panelInfoUser.Size = new System.Drawing.Size(877, 115);
            this.panelInfoUser.TabIndex = 159;
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
            // linkLabelRefresh
            // 
            this.linkLabelRefresh.AutoSize = true;
            this.linkLabelRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelRefresh.LinkColor = System.Drawing.Color.White;
            this.linkLabelRefresh.Location = new System.Drawing.Point(144, 85);
            this.linkLabelRefresh.Name = "linkLabelRefresh";
            this.linkLabelRefresh.Size = new System.Drawing.Size(60, 18);
            this.linkLabelRefresh.TabIndex = 17;
            this.linkLabelRefresh.TabStop = true;
            this.linkLabelRefresh.Text = "Refresh";
            this.linkLabelRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRefresh_LinkClicked);
            // 
            // linkLabelEditInfo
            // 
            this.linkLabelEditInfo.AutoSize = true;
            this.linkLabelEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelEditInfo.LinkColor = System.Drawing.Color.White;
            this.linkLabelEditInfo.Location = new System.Drawing.Point(227, 85);
            this.linkLabelEditInfo.Name = "linkLabelEditInfo";
            this.linkLabelEditInfo.Size = new System.Drawing.Size(85, 18);
            this.linkLabelEditInfo.TabIndex = 16;
            this.linkLabelEditInfo.TabStop = true;
            this.linkLabelEditInfo.Text = "Edit my info";
            this.linkLabelEditInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEditInfo_LinkClicked);
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
            // contextMenuStripEmployee
            // 
            this.contextMenuStripEmployee.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEmployeeToolStripMenuItem,
            this.employeeListToolStripMenuItem,
            this.editRemoveToolStripMenuItem});
            this.contextMenuStripEmployee.Name = "contextMenuStripEmployee";
            this.contextMenuStripEmployee.Size = new System.Drawing.Size(243, 76);
            // 
            // addNewEmployeeToolStripMenuItem
            // 
            this.addNewEmployeeToolStripMenuItem.BackColor = System.Drawing.Color.Navy;
            this.addNewEmployeeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addNewEmployeeToolStripMenuItem.Name = "addNewEmployeeToolStripMenuItem";
            this.addNewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(242, 24);
            this.addNewEmployeeToolStripMenuItem.Text = "Add New Employee";
            this.addNewEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addNewEmployeeToolStripMenuItem_Click);
            // 
            // employeeListToolStripMenuItem
            // 
            this.employeeListToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.employeeListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.employeeListToolStripMenuItem.Name = "employeeListToolStripMenuItem";
            this.employeeListToolStripMenuItem.Size = new System.Drawing.Size(242, 24);
            this.employeeListToolStripMenuItem.Text = "Employee List";
            this.employeeListToolStripMenuItem.Click += new System.EventHandler(this.employeeListToolStripMenuItem_Click);
            // 
            // editRemoveToolStripMenuItem
            // 
            this.editRemoveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editRemoveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editRemoveToolStripMenuItem.Name = "editRemoveToolStripMenuItem";
            this.editRemoveToolStripMenuItem.Size = new System.Drawing.Size(242, 24);
            this.editRemoveToolStripMenuItem.Text = "Edit / Remove Employee";
            this.editRemoveToolStripMenuItem.Click += new System.EventHandler(this.editRemoveToolStripMenuItem_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.Color.White;
            this.btnEmployee.Location = new System.Drawing.Point(12, 122);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(127, 39);
            this.btnEmployee.TabIndex = 161;
            this.btnEmployee.TabStop = false;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnArrTimeSheet
            // 
            this.btnArrTimeSheet.BackColor = System.Drawing.Color.Gray;
            this.btnArrTimeSheet.Enabled = false;
            this.btnArrTimeSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrTimeSheet.ForeColor = System.Drawing.Color.White;
            this.btnArrTimeSheet.Location = new System.Drawing.Point(411, 122);
            this.btnArrTimeSheet.Name = "btnArrTimeSheet";
            this.btnArrTimeSheet.Size = new System.Drawing.Size(228, 39);
            this.btnArrTimeSheet.TabIndex = 162;
            this.btnArrTimeSheet.TabStop = false;
            this.btnArrTimeSheet.Text = "Arrange TimeSheet";
            this.btnArrTimeSheet.UseVisualStyleBackColor = false;
            this.btnArrTimeSheet.Click += new System.EventHandler(this.btnArrTimeSheet_Click);
            // 
            // btnTimeSheet
            // 
            this.btnTimeSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTimeSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeSheet.ForeColor = System.Drawing.Color.White;
            this.btnTimeSheet.Location = new System.Drawing.Point(145, 122);
            this.btnTimeSheet.Name = "btnTimeSheet";
            this.btnTimeSheet.Size = new System.Drawing.Size(127, 39);
            this.btnTimeSheet.TabIndex = 163;
            this.btnTimeSheet.TabStop = false;
            this.btnTimeSheet.Text = "TimeSheet";
            this.btnTimeSheet.UseVisualStyleBackColor = false;
            this.btnTimeSheet.Click += new System.EventHandler(this.btnTimeSheet_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalary.ForeColor = System.Drawing.Color.White;
            this.btnSalary.Location = new System.Drawing.Point(278, 122);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(127, 39);
            this.btnSalary.TabIndex = 164;
            this.btnSalary.TabStop = false;
            this.btnSalary.Text = "Salary";
            this.btnSalary.UseVisualStyleBackColor = false;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnSalaryAllEmployee
            // 
            this.btnSalaryAllEmployee.BackColor = System.Drawing.Color.Gray;
            this.btnSalaryAllEmployee.Enabled = false;
            this.btnSalaryAllEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalaryAllEmployee.ForeColor = System.Drawing.Color.White;
            this.btnSalaryAllEmployee.Location = new System.Drawing.Point(645, 122);
            this.btnSalaryAllEmployee.Name = "btnSalaryAllEmployee";
            this.btnSalaryAllEmployee.Size = new System.Drawing.Size(223, 39);
            this.btnSalaryAllEmployee.TabIndex = 165;
            this.btnSalaryAllEmployee.TabStop = false;
            this.btnSalaryAllEmployee.Text = "Salary All Employee";
            this.btnSalaryAllEmployee.UseVisualStyleBackColor = false;
            this.btnSalaryAllEmployee.Click += new System.EventHandler(this.btnSalaryAllEmployee_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.Gray;
            this.btnUserManagement.Enabled = false;
            this.btnUserManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(534, 167);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(228, 39);
            this.btnUserManagement.TabIndex = 166;
            this.btnUserManagement.TabStop = false;
            this.btnUserManagement.Text = "User Management";
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // contextMenuStripUserManagement
            // 
            this.contextMenuStripUserManagement.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripUserManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationUserToolStripMenuItem,
            this.userListToolStripMenuItem});
            this.contextMenuStripUserManagement.Name = "contextMenuStripUserManagement";
            this.contextMenuStripUserManagement.Size = new System.Drawing.Size(209, 52);
            // 
            // authenticationUserToolStripMenuItem
            // 
            this.authenticationUserToolStripMenuItem.BackColor = System.Drawing.Color.Olive;
            this.authenticationUserToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.authenticationUserToolStripMenuItem.Name = "authenticationUserToolStripMenuItem";
            this.authenticationUserToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.authenticationUserToolStripMenuItem.Text = "Authentication User";
            this.authenticationUserToolStripMenuItem.Click += new System.EventHandler(this.authenticationUserToolStripMenuItem_Click);
            // 
            // userListToolStripMenuItem
            // 
            this.userListToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.userListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userListToolStripMenuItem.Name = "userListToolStripMenuItem";
            this.userListToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.userListToolStripMenuItem.Text = "User List";
            this.userListToolStripMenuItem.Click += new System.EventHandler(this.userListToolStripMenuItem_Click);
            // 
            // btnStatic
            // 
            this.btnStatic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatic.ForeColor = System.Drawing.Color.White;
            this.btnStatic.Location = new System.Drawing.Point(67, 167);
            this.btnStatic.Name = "btnStatic";
            this.btnStatic.Size = new System.Drawing.Size(127, 39);
            this.btnStatic.TabIndex = 167;
            this.btnStatic.TabStop = false;
            this.btnStatic.Text = "Static";
            this.btnStatic.UseVisualStyleBackColor = false;
            this.btnStatic.Click += new System.EventHandler(this.btnStatic_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.btnStatic);
            this.Controls.Add(this.btnUserManagement);
            this.Controls.Add(this.btnSalaryAllEmployee);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnTimeSheet);
            this.Controls.Add(this.btnArrTimeSheet);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.panelInfoUser);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelInfoUser.ResumeLayout(false);
            this.panelInfoUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.contextMenuStripEmployee.ResumeLayout(false);
            this.contextMenuStripUserManagement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfoUser;
        private System.Windows.Forms.Label lblRoleUser;
        private System.Windows.Forms.LinkLabel linkLabelRefresh;
        private System.Windows.Forms.LinkLabel linkLabelEditInfo;
        private System.Windows.Forms.Label lblWelcomeEmployee;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEmployee;
        private System.Windows.Forms.ToolStripMenuItem addNewEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRemoveToolStripMenuItem;
        public System.Windows.Forms.Button btnArrTimeSheet;
        public System.Windows.Forms.Button btnTimeSheet;
        public System.Windows.Forms.Button btnSalary;
        public System.Windows.Forms.Button btnSalaryAllEmployee;
        public System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUserManagement;
        private System.Windows.Forms.ToolStripMenuItem authenticationUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userListToolStripMenuItem;
        private System.Windows.Forms.Button btnStatic;
        public System.Windows.Forms.Button btnEmployee;
    }
}