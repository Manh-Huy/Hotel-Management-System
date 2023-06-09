using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20142178_20110370_Nhom15_QLHotel
{
    public partial class CheckTimeForm : Form
    {
        private MY_DB mydb = new MY_DB();
        private DataTable dataTable = new DataTable();

        public CheckTimeForm()
        {
            InitializeComponent();
        }

        private void CheckTimeForm_Load(object sender, EventArgs e)
        {
            // Hiển thị dữ liệu trong DataGridView
            DisplayRoomStatus();

        }

        private void DisplayRoomStatus()
        {
            // Kiểm tra nếu các cột chưa tồn tại trong DataTable
            if (!dataTable.Columns.Contains("roomID"))
            {
                dataTable.Columns.Add("roomID", typeof(string));
            }

            if (!dataTable.Columns.Contains("status"))
            {
                dataTable.Columns.Add("status", typeof(string));
            }

            if (!dataTable.Columns.Contains("RentalDate"))
            {
                dataTable.Columns.Add("RentalDate", typeof(DateTime));
            }

            if (!dataTable.Columns.Contains("TimeRemaining"))
            {
                dataTable.Columns.Add("TimeRemaining", typeof(string));
            }

            try
            {
                // Kết nối tới cơ sở dữ liệu và thực hiện truy vấn để lấy dữ liệu từ bảng "Customer"
                mydb.openConnection();

                string selectQuery = "SELECT roomID, RentalDate, Time FROM Customer";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, mydb.getConnection);
                dataTable.Clear(); // Xóa dữ liệu cũ trong DataTable trước khi điền dữ liệu mới
                adapter.Fill(dataTable);

                // Tạo danh sách để lưu trữ các mã roomID đã hiển thị
                List<string> displayedRoomIDs = new List<string>();
                List<DataRow> rowsToRemove = new List<DataRow>();

                // Tính toán thời gian còn lại dựa trên "Time" và "RentalDate" và cập nhật cột "status" và "TimeRemaining"
                foreach (DataRow row in dataTable.Rows)
                {
                    string roomID = row["roomID"].ToString();

                    // Kiểm tra xem mã roomID đã được hiển thị hay chưa
                    if (!displayedRoomIDs.Contains(roomID))
                    {
                        DateTime rentalDate = Convert.ToDateTime(row["RentalDate"]);
                        string timeString = row["Time"].ToString();
                        int time = int.Parse(timeString.Split(' ')[0]);

                        DateTime expiryDate = rentalDate.AddDays(time);
                        string status = (expiryDate >= DateTime.Now) ? "still" : "expired";

                        TimeSpan timeRemaining = expiryDate - DateTime.Now;
                        string timeRemainingString = string.Format("{0} days, {1} hours", timeRemaining.Days, timeRemaining.Hours);

                        row["status"] = status;
                        row["TimeRemaining"] = timeRemainingString;

                        displayedRoomIDs.Add(roomID);
                    }
                    else
                    {
                        // Nếu mã roomID đã được hiển thị, đánh dấu hàng để xóa sau khi hoàn thành vòng lặp
                        rowsToRemove.Add(row);
                    }
                }

                // Xóa các hàng đã được đánh dấu để xóa
                foreach (DataRow rowToRemove in rowsToRemove)
                {
                    dataTable.Rows.Remove(rowToRemove);
                }

                // Gán dữ liệu cho cột "roomID"
                foreach (DataRow row in dataTable.Rows)
                {
                    string roomID = row["roomID"].ToString();
                    row["roomID"] = roomID;
                }

                // Gán dữ liệu cho DataGridView
                dataGridView1.DataSource = dataTable;

                mydb.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGotoMainForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show(this);
        }

        private void btnReturnRoom_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show(this);
        }
    }
}
