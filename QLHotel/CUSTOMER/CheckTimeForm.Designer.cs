namespace _20142178_20110370_Nhom15_QLHotel
{
    partial class CheckTimeForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGotoMainForm = new System.Windows.Forms.Button();
            this.btnReturnRoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(881, 400);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnGotoMainForm
            // 
            this.btnGotoMainForm.BackColor = System.Drawing.Color.Navy;
            this.btnGotoMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGotoMainForm.ForeColor = System.Drawing.Color.White;
            this.btnGotoMainForm.Location = new System.Drawing.Point(531, 458);
            this.btnGotoMainForm.Name = "btnGotoMainForm";
            this.btnGotoMainForm.Size = new System.Drawing.Size(167, 35);
            this.btnGotoMainForm.TabIndex = 23;
            this.btnGotoMainForm.Text = "Main Form";
            this.btnGotoMainForm.UseVisualStyleBackColor = false;
            this.btnGotoMainForm.Click += new System.EventHandler(this.btnGotoMainForm_Click);
            // 
            // btnReturnRoom
            // 
            this.btnReturnRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReturnRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnRoom.ForeColor = System.Drawing.Color.White;
            this.btnReturnRoom.Location = new System.Drawing.Point(222, 458);
            this.btnReturnRoom.Name = "btnReturnRoom";
            this.btnReturnRoom.Size = new System.Drawing.Size(197, 35);
            this.btnReturnRoom.TabIndex = 24;
            this.btnReturnRoom.Text = "Return Room";
            this.btnReturnRoom.UseVisualStyleBackColor = false;
            this.btnReturnRoom.Click += new System.EventHandler(this.btnReturnRoom_Click);
            // 
            // CheckTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(974, 532);
            this.Controls.Add(this.btnReturnRoom);
            this.Controls.Add(this.btnGotoMainForm);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CheckTimeForm";
            this.Text = "CheckTimeForm";
            this.Load += new System.EventHandler(this.CheckTimeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGotoMainForm;
        private System.Windows.Forms.Button btnReturnRoom;
    }
}