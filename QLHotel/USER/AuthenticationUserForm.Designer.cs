namespace _20142178_20110370_Nhom15_QLHotel
{
    partial class AuthenticationUserForm
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
            this.lblUserAuthentication = new System.Windows.Forms.Label();
            this.ButtonRejectAll = new System.Windows.Forms.Button();
            this.ButtonApproveAll = new System.Windows.Forms.Button();
            this.ButtonReject = new System.Windows.Forms.Button();
            this.ButtonApprove = new System.Windows.Forms.Button();
            this.dataGridViewTemp_UserList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemp_UserList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserAuthentication
            // 
            this.lblUserAuthentication.AutoSize = true;
            this.lblUserAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAuthentication.ForeColor = System.Drawing.Color.White;
            this.lblUserAuthentication.Location = new System.Drawing.Point(40, 29);
            this.lblUserAuthentication.Name = "lblUserAuthentication";
            this.lblUserAuthentication.Size = new System.Drawing.Size(296, 36);
            this.lblUserAuthentication.TabIndex = 76;
            this.lblUserAuthentication.Text = "User Authentication";
            // 
            // ButtonRejectAll
            // 
            this.ButtonRejectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ButtonRejectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRejectAll.Location = new System.Drawing.Point(617, 458);
            this.ButtonRejectAll.Name = "ButtonRejectAll";
            this.ButtonRejectAll.Size = new System.Drawing.Size(146, 40);
            this.ButtonRejectAll.TabIndex = 75;
            this.ButtonRejectAll.Text = "Reject All";
            this.ButtonRejectAll.UseVisualStyleBackColor = false;
            this.ButtonRejectAll.Click += new System.EventHandler(this.ButtonRejectAll_Click);
            // 
            // ButtonApproveAll
            // 
            this.ButtonApproveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButtonApproveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonApproveAll.Location = new System.Drawing.Point(190, 458);
            this.ButtonApproveAll.Name = "ButtonApproveAll";
            this.ButtonApproveAll.Size = new System.Drawing.Size(146, 40);
            this.ButtonApproveAll.TabIndex = 74;
            this.ButtonApproveAll.Text = "Approve All";
            this.ButtonApproveAll.UseVisualStyleBackColor = false;
            this.ButtonApproveAll.Click += new System.EventHandler(this.ButtonApproveAll_Click);
            // 
            // ButtonReject
            // 
            this.ButtonReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ButtonReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonReject.Location = new System.Drawing.Point(427, 458);
            this.ButtonReject.Name = "ButtonReject";
            this.ButtonReject.Size = new System.Drawing.Size(112, 40);
            this.ButtonReject.TabIndex = 73;
            this.ButtonReject.Text = "Reject";
            this.ButtonReject.UseVisualStyleBackColor = false;
            this.ButtonReject.Click += new System.EventHandler(this.ButtonReject_Click);
            // 
            // ButtonApprove
            // 
            this.ButtonApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButtonApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonApprove.Location = new System.Drawing.Point(37, 458);
            this.ButtonApprove.Name = "ButtonApprove";
            this.ButtonApprove.Size = new System.Drawing.Size(112, 40);
            this.ButtonApprove.TabIndex = 72;
            this.ButtonApprove.Text = "Approve";
            this.ButtonApprove.UseVisualStyleBackColor = false;
            this.ButtonApprove.Click += new System.EventHandler(this.ButtonApprove_Click);
            // 
            // dataGridViewTemp_UserList
            // 
            this.dataGridViewTemp_UserList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTemp_UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemp_UserList.Location = new System.Drawing.Point(37, 94);
            this.dataGridViewTemp_UserList.Name = "dataGridViewTemp_UserList";
            this.dataGridViewTemp_UserList.RowHeadersWidth = 51;
            this.dataGridViewTemp_UserList.RowTemplate.Height = 24;
            this.dataGridViewTemp_UserList.Size = new System.Drawing.Size(726, 340);
            this.dataGridViewTemp_UserList.TabIndex = 71;
            // 
            // AuthenticationUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(800, 526);
            this.Controls.Add(this.lblUserAuthentication);
            this.Controls.Add(this.ButtonRejectAll);
            this.Controls.Add(this.ButtonApproveAll);
            this.Controls.Add(this.ButtonReject);
            this.Controls.Add(this.ButtonApprove);
            this.Controls.Add(this.dataGridViewTemp_UserList);
            this.Name = "AuthenticationUserForm";
            this.Text = "AuthenticationUserForm";
            this.Load += new System.EventHandler(this.AuthenticationUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemp_UserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserAuthentication;
        private System.Windows.Forms.Button ButtonRejectAll;
        private System.Windows.Forms.Button ButtonApproveAll;
        private System.Windows.Forms.Button ButtonReject;
        private System.Windows.Forms.Button ButtonApprove;
        private System.Windows.Forms.DataGridView dataGridViewTemp_UserList;
    }
}