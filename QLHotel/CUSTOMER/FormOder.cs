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
    public partial class FormOder : Form
    {
        private string roomId;
        private MY_DB mydb = new MY_DB();
        public FormOder()
        {
            InitializeComponent();
        }
        public FormOder(string roomId)
        {
            InitializeComponent();
            this.roomId = roomId;

        }
        private void FormOder_Load(object sender, EventArgs e)
        {
            LoadRoomData();
            LoadTypes();
        }

        private void LoadTypes()
        {
            try
            {

                mydb.openConnection();

                string query = "SELECT DISTINCT Type FROM Foods";
                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string type = reader["Type"].ToString();
                    comboBoxType.Items.Add(type);
                }

                reader.Close();
                mydb.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadRoomData()
        {
            try
            {
                mydb.openConnection();

                string query = "SELECT IDroom, status, address, picture FROM Room WHERE IDroom = @roomId";

                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                command.Parameters.AddWithValue("@roomId", roomId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string status = reader["status"].ToString();
                    string address = reader["address"].ToString();

                    byte[] imageData = (byte[])reader["picture"];
                    Image roomImage = Image.FromStream(new MemoryStream(imageData));

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = roomImage;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = new Size(100, 100);

                    TextBox textBox = new TextBox();
                    textBox.BackColor = ColorTranslator.FromHtml("#05386B");
                    textBox.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    textBox.Font = new Font(textBox.Font.FontFamily, 14, FontStyle.Bold);
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Text = $"{roomId}\r\nStatus: {status}\r\nAddress: {address}";
                    textBox.Multiline = true;
                    textBox.Size = new Size(270, 100);

                    textBox.ReadOnly = true;

                    flowLayoutPanel1.Controls.Add(pictureBox);
                    flowLayoutPanel1.Controls.Add(textBox);

                    pictureBox.Click += new EventHandler(pictureBox_Click);
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
            // Handle the click event if needed
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBoxType.SelectedItem.ToString();
            LoadFoodDataByType(selectedType);
        }

        private void LoadFoodDataByType(string type)
        {
            try
            {
                mydb.openConnection();

                string query = "SELECT Name, Price FROM Foods WHERE Type = @type";
                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                command.Parameters.AddWithValue("@type", type);
                SqlDataReader reader = command.ExecuteReader();

                listBoxShow.Items.Clear(); // Xóa danh sách cũ

                while (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string price = reader["Price"].ToString() + " vnđ";
                    string foodInfo = $"{name} - {price}";
                    listBoxShow.Items.Add(foodInfo);
                }

                reader.Close();
                mydb.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listBoxShow.SelectedItem != null)
            {
                string selectedFood = listBoxShow.SelectedItem.ToString();
                listBoxOrder.Items.Add(selectedFood);
                listBoxShow.Items.Remove(selectedFood);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxOrder.SelectedItem != null)
            {
                string selectedFood = listBoxOrder.SelectedItem.ToString();
                listBoxShow.Items.Add(selectedFood);
                listBoxOrder.Items.Remove(selectedFood);
            }
        }

        private void listBoxShow_Click(object sender, EventArgs e)
        {
            buttonRemove.Enabled = false;
            buttonAdd.Enabled = true;
        }

        private void listBoxOrder_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            buttonRemove.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                mydb.openConnection();

                string selectedTime = comboBoxTime.SelectedItem.ToString();

                string insertQuery = "INSERT INTO Customer (roomID, Name, Phone, Food, Price, Time, RentalDate) VALUES (@roomID, @name, @phone, @food, @price, @time, @rentalDate)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, mydb.getConnection);
                insertCommand.Parameters.AddWithValue("@roomID", roomId);
                insertCommand.Parameters.AddWithValue("@name", textBoxName.Text);
                insertCommand.Parameters.AddWithValue("@phone", Convert.ToInt32(textBoxSdt.Text));
                insertCommand.Parameters.AddWithValue("@food", DBNull.Value);
                insertCommand.Parameters.AddWithValue("@price", DBNull.Value);
                insertCommand.Parameters.AddWithValue("@time", selectedTime);
                insertCommand.Parameters.AddWithValue("@rentalDate", DateTime.Now);

                SqlCommand updateCommand = new SqlCommand("UPDATE Room SET status = 'full' WHERE IDroom = @roomId", mydb.getConnection);
                updateCommand.Parameters.AddWithValue("@roomId", roomId);

                // Create a dictionary to store the count of each food item
                Dictionary<string, int> foodCount = new Dictionary<string, int>();

                foreach (string foodItem in listBoxOrder.Items)
                {
                    string[] foodInfo = foodItem.Split('-');
                    string food = foodInfo[0].Trim();
                    string price = foodInfo[1].Trim();

                    insertCommand.Parameters["@food"].Value = food;
                    insertCommand.Parameters["@price"].Value = price;

                    insertCommand.ExecuteNonQuery();

                    // Count the number of occurrences of each food item
                    if (foodCount.ContainsKey(food))
                    {
                        foodCount[food]++;
                    }
                    else
                    {
                        foodCount.Add(food, 1);
                    }
                }

                // Update the quantity of each food item in the Foods table
                foreach (KeyValuePair<string, int> entry in foodCount)
                {
                    string updateQuantityQuery = "UPDATE Foods SET Quantity = Quantity - @quantity WHERE Name = @name";
                    SqlCommand updateQuantityCommand = new SqlCommand(updateQuantityQuery, mydb.getConnection);
                    updateQuantityCommand.Parameters.AddWithValue("@quantity", entry.Value);
                    updateQuantityCommand.Parameters.AddWithValue("@name", entry.Key);
                    updateQuantityCommand.ExecuteNonQuery();
                }

                updateCommand.ExecuteNonQuery();

                mydb.closeConnection();

                MessageBox.Show("Data saved successfully. Room status updated to 'full'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            textBoxName.Enabled = false;
            textBoxSdt.Enabled = false;
        }
    }
}
