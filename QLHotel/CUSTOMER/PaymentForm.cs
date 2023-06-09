//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
//using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
//using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Chunk = iTextSharp.text.Chunk;


namespace _20142178_20110370_Nhom15_QLHotel
{
    public partial class PaymentForm : Form
    {
        MY_DB mydb = new MY_DB();
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadRoomIDs();
            textBoxPay.Text = DateTime.Now.ToString();
        }

        private void LoadRoomIDs()
        {
            try
            {
                mydb.openConnection();
                string query = "SELECT DISTINCT roomID FROM Customer";
                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string roomID = reader.GetString(0);
                    comboBoxRoomID.Items.Add(roomID);
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void comboBoxRoomID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoomID = comboBoxRoomID.SelectedItem.ToString();
            GetCustomerDetails(selectedRoomID);
            CalculateTotalPrice();
        }

        private void GetCustomerDetails(string roomID)
        {
            mydb.openConnection();
            string query = "SELECT Name, Phone, Food, Price, Time, RentalDate FROM Customer WHERE roomID = @RoomID";
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.AddWithValue("@RoomID", roomID);
            SqlDataReader reader = command.ExecuteReader();

            Bill.Items.Clear();



            while (reader.Read())
            {
                string food = reader.GetString(2);
                string price = reader.GetString(3);
                //float price = 0;
                //if (float.TryParse(priceString, out price))
                //{
                string item = food + " - " + price.ToString();
                Bill.Items.Add(item);
                //}

                textBoxName.Text = reader.GetString(0);
                textBoxPhone.Text = reader.GetInt32(1).ToString();
                textBoxTime.Text = reader.GetString(4);
                textBoxRe.Text = reader.GetDateTime(5).ToString();


            }
            // Thêm dòng cuối cùng hiển thị tổng giá trị Time và 500000/day
            string startItem = "1 Day = 500 000 vnd";
            Bill.Items.Add(startItem);
            int totalDays = CalculateTotalDays();
            string totalPriceString = (totalDays * 500000).ToString() + " VND";
            string finalItem = "Total Day: " + textBoxTime.Text + " = " + totalPriceString;
            Bill.Items.Add(finalItem);



            reader.Close();
        }

        private int CalculateTotalDays()
        {
            string timeString = textBoxTime.Text.Trim();
            int time = 0;

            if (timeString.EndsWith(" Day") && int.TryParse(timeString.Substring(0, timeString.IndexOf(" ")), out time))
            {
                return time;
            }

            return 0;
        }

        private void CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            string selectedRoomID = comboBoxRoomID.SelectedItem.ToString();
            GetCustomerDetails(selectedRoomID);

            // Lấy giá trị của cột Price từ cơ sở dữ liệu
            string query = "SELECT Price FROM Customer WHERE roomID = @RoomID";
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.AddWithValue("@RoomID", selectedRoomID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    string priceString = reader.GetString(0);
                    decimal price = 0;
                    if (decimal.TryParse(priceString.Split(' ')[0], out price))
                    {
                        totalPrice += price;
                    }
                }
            }

            reader.Close();

            string timeString = textBoxTime.Text.Trim();
            int time = 0;

            if (timeString.EndsWith(" Day") && int.TryParse(timeString.Substring(0, timeString.IndexOf(" ")), out time))
            {
                totalPrice += time * 500000;
            }

            textboxTotalPrice.Text = "total: = " + totalPrice.ToString() + " vnđ";
        }
        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (comboBoxRoomID.SelectedItem != null)
            {
                string selectedRoomID = comboBoxRoomID.SelectedItem.ToString();
                PayAndUpdateRoomStatus(selectedRoomID);
            }
        }
        private void PayAndUpdateRoomStatus(string roomID)
        {
            try
            {
                mydb.openConnection();

                // Xóa dữ liệu khách hàng của roomID
                string deleteQuery = "DELETE FROM Customer WHERE roomID = @RoomID";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, mydb.getConnection);
                deleteCommand.Parameters.AddWithValue("@RoomID", roomID);
                deleteCommand.ExecuteNonQuery();

                // Cập nhật trạng thái của phòng thành "empty"
                string updateQuery = "UPDATE Room SET Status = 'empty' WHERE IDroom = @RoomID";
                SqlCommand updateCommand = new SqlCommand(updateQuery, mydb.getConnection);
                updateCommand.Parameters.AddWithValue("@RoomID", roomID);
                updateCommand.ExecuteNonQuery();

                MessageBox.Show("Payment completed successfully.");

                // Sau khi thanh toán, làm mới dữ liệu và combobox
                LoadRoomIDs();

                mydb.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void SaveBillToFile()
        {
            // Lấy ngày giờ hiện tại để tạo tên tệp tin hóa đơn
            string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";

            try
            {
                // Tạo đường dẫn đến thư mục lưu trữ hóa đơn
                string folderPath = "F:\\Desktop";
                string filePath = Path.Combine(folderPath, fileName);

                // Ghi dữ liệu vào tệp tin
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Ghi dữ liệu từ ListBox Bill
                    foreach (var item in Bill.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }

                    // Ghi tổng tiền từ TextBox textboxTotalPrice
                    writer.WriteLine(textboxTotalPrice.Text);
                }

                MessageBox.Show("Bill saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            SaveBillToFile();
        }
    }
}
