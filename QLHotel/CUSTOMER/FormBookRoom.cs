using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20142178_20110370_Nhom15_QLHotel
{
    public partial class FormBookRoom : Form
    {
        public FormBookRoom()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();   
        private void FormBookRoom_Load(object sender, EventArgs e)
        {
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            try
            {
                mydb.openConnection();
                string query = "SELECT IDroom, status, address, picture FROM Room WHERE status = 'empty'";

                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string roomId = reader["IDroom"].ToString();
                    string status = reader["status"].ToString();
                    string address = reader["address"].ToString();

                    byte[] imageData = (byte[])reader["picture"];
                    Image roomImage = Image.FromStream(new MemoryStream(imageData));

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = roomImage;
                    pictureBox.Tag = roomId;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = new Size(100, 100);

                    pictureBox.Click += new EventHandler(pictureBox_Click);

                    TextBox textBox = new TextBox();
                    //textBox.BackColor = Color.Blue; // Đặt màu nền là màu xanh
                    //textBox.ForeColor = Color.White; // Đặt màu chữ là màu trắng
                    textBox.BackColor = ColorTranslator.FromHtml("#05386B");
                    textBox.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

                    textBox.Font = new Font(textBox.Font.FontFamily, 14, FontStyle.Bold);  // Thiết lập cỡ chữ là 14

                    textBox.TextAlign = HorizontalAlignment.Center;  // Căn lề giữa ngang

                    // Căn lề giữa dọc (nếu TextBox có đủ chiều cao)
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Text = $"{roomId}\r\nStatus: {status}\r\nAddress: {address}";
                    textBox.Multiline = true;
                    textBox.Size = new Size(270, 100);
                    textBox.ReadOnly = true;

                    // Thêm PictureBox và TextBox vào FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(pictureBox);
                    flowLayoutPanel1.Controls.Add(textBox);



                }
                reader.Close();
                mydb.closeConnection();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Lấy thông tin phòng được chọn
            PictureBox pictureBox = (PictureBox)sender;
            string roomId = pictureBox.Tag.ToString(); // Lấy ID phòng từ thuộc tính Tag của PictureBox

            FormOder formNew = new FormOder(roomId);
            formNew.Show();
            this.Hide();
        }
    }
}
