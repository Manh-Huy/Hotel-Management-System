using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20142178_20110370_Nhom15_QLHotel
{
    public partial class TimeSheetForEachEmployeeForm : Form
    {
        static public bool isSeeOtherTimeSheet = false;

        string fullNameOther;
        string IDOther;
        string roleOther;

        public TimeSheetForEachEmployeeForm()
        {
            isSeeOtherTimeSheet = false;
            InitializeComponent();
        }
        public TimeSheetForEachEmployeeForm(string fullName,string ID, string role)
        {
            InitializeComponent();
            fullNameOther = fullName;
            IDOther = ID;
            roleOther = role;
        }

        MY_DB mydb = new MY_DB();
        EMPLOYEE employee = new EMPLOYEE();
        TIMESHEET timesheet = new TIMESHEET();

        string roleUser;
        string fnameUser;
        string lnameUser;
        public void getImageAndUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT Log_in.username, Log_in.password, Employee.* FROM Log_in INNER JOIN Employee ON Log_in.ID = Employee.ID WHERE Employee.ID = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = Global.GlobalUserID;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                fnameUser = table.Rows[0]["fname"].ToString();
                lnameUser = table.Rows[0]["lname"].ToString();
                roleUser = table.Rows[0]["role"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxUser.Image = Image.FromStream(picture);

                lblWelcomeEmployee.Text = "Welcome Back (" + table.Rows[0]["username"].ToString() + ")";

                lblRoleUser.Text = "Role: " + roleUser;
            }
        }
        public void fillGrid(SqlCommand command)
        {
            dataGridViewTimesheetEmployeeList.ReadOnly = true;
            dataGridViewTimesheetEmployeeList.DataSource = employee.getEmployees(command);
            dataGridViewTimesheetEmployeeList.AllowUserToAddRows = false;
            dataGridViewTimesheetEmployeeList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void fillGridForSalary(SqlCommand command)
        {
            dataGridViewSalaryList.ReadOnly = true;
            dataGridViewSalaryList.DataSource = employee.getEmployees(command);
            dataGridViewSalaryList.AllowUserToAddRows = false;
        }
        private void TimeSheetForEachEmployeeForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();

            if (isSeeOtherTimeSheet == false)
            {
                textBoxFullName.Text = fnameUser + " " + lnameUser;
                textBoxRole.Text = roleUser;

                SqlCommand command = new SqlCommand("SELECT day As Day, [7h-15h], [15h-19h], [19h-3h], [3h-7h] FROM TimeSheet WHERE ID = '" + Global.GlobalUserID + "' ORDER BY CAST(REPLACE([day], 'Day ', '') AS INT)");
                fillGrid(command);
            }
            else if (isSeeOtherTimeSheet == true)
            {
                textBoxFullName.Text = fullNameOther;
                textBoxRole.Text = roleOther;

                SqlCommand command = new SqlCommand("SELECT day As Day, [7h-15h], [15h-19h], [19h-3h], [3h-7h] FROM TimeSheet WHERE ID = '" + IDOther + "' ORDER BY CAST(REPLACE([day], 'Day ', '') AS INT)");
                fillGrid(command);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô được chọn trong DataGridView hay không
            if (dataGridViewTimesheetEmployeeList.SelectedCells.Count > 0)
            {
                // Lấy chỉ số của ô được chọn
                int selectedRowIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].RowIndex;
                int selectedColumnIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].ColumnIndex;

                // Kiểm tra xem ô được chọn có giá trị null hay không
                if (dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value != null)
                {
                    string cellValue = dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value.ToString();

                    if (cellValue.Contains("Day"))
                    {
                        MessageBox.Show("Choose Wrong Position", "Check In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!cellValue.Contains("Start: "))
                    {
                        dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value = "Start: " + DateTime.Now.ToString();

                        MessageBox.Show("Checked In Successfully", "Check In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Already Checked In", "Check In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
       
        private void dataGridViewTimesheetEmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem ô đã được chọn có dữ liệu hay không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !string.IsNullOrEmpty(dataGridViewTimesheetEmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
            {
                // Bật Button để cho phép cập nhật giá trị
                btnCheckIn.Enabled = true;
                btnCheckIn.BackColor = Color.Green;

                btnCheckOut.Enabled = true;
                btnCheckOut.BackColor = Color.DarkBlue;
            }
            else
            {
                // Tắt Button nếu ô không có dữ liệu
                btnCheckIn.Enabled = false;
                btnCheckIn.BackColor = Color.Gray;

                btnCheckOut.Enabled = false;
                btnCheckOut.BackColor = Color.Gray;
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô được chọn trong DataGridView hay không
            if (dataGridViewTimesheetEmployeeList.SelectedCells.Count > 0)
            {
                // Lấy chỉ số của ô được chọn
                int selectedRowIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].RowIndex;
                int selectedColumnIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].ColumnIndex;

                // Kiểm tra xem ô được chọn có giá trị null hay không
                if (dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value != null)
                {
                    string cellValue = dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value.ToString();

                    if (cellValue.Contains("Day"))
                    {
                        MessageBox.Show("Choose Wrong Position", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!cellValue.Contains("End: "))
                    {
                        dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value += "\n\nEnd: " + DateTime.Now.ToString();

                        MessageBox.Show("Checked Out Successfully", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Already Checked Out", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string roleID = Global.GlobalUserID;
            int count = 0;

            if (dataGridViewTimesheetEmployeeList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewTimesheetEmployeeList.Rows)
                {
                    // Lấy dữ liệu từ các ô trong hàng
                    string day = row.Cells["Day"].Value?.ToString();
                    string shiftOne = row.Cells["7h-15h"].Value?.ToString();
                    string shiftTwo = row.Cells["15h-19h"].Value?.ToString();
                    string shiftThree = row.Cells["19h-3h"].Value?.ToString();
                    string shiftFour = row.Cells["3h-7h"].Value?.ToString();

                    if (timesheet.updateTimeSheet(roleID, day, shiftOne, shiftTwo, shiftThree, shiftFour))
                    {
                        count++;
                    }
                    else
                    {
                        MessageBox.Show("Save Data UnSuccessfully", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Sau khi cập nhật thành công, thông báo hoặc thực hiện các hành động khác

                if (count > 0)
                {
                    MessageBox.Show("Save Data Successfully", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnSelectToCalculate_Click(object sender, EventArgs e)
        {
            string inputString = "";
            // Kiểm tra xem có ô được chọn trong DataGridView hay không
            if (dataGridViewTimesheetEmployeeList.SelectedCells.Count > 0)
            {
                // Lấy chỉ số của ô được chọn
                int selectedRowIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].RowIndex;
                int selectedColumnIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].ColumnIndex;

                // Kiểm tra xem ô được chọn có giá trị null hay không
                if (dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value != null)
                {
                    // Cập nhật giá trị mới cho ô được chọn
                    inputString = dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value.ToString();
                }
            }

            string startTime = "";
            string endTime = "";
            //string inputString = "Start: 5/18/2023 1:24:52 PMEnd: 5/18/2023 4:24:54 PM";
            string[] parts = inputString.Split(new string[] { "Start:", "End:" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 2)
            {
                startTime = parts[0].Trim();  // Sử dụng Trim() để loại bỏ khoảng trắng dư thừa
                endTime = parts[1].Trim();
                textBoxStart.Text = startTime;
                textBoxEnd.Text = endTime;
            }
            else
            {
                // Xử lý khi không đủ số lượng phần tử trong mảng parts
                textBoxStart.Text = "Invalid input";
                textBoxEnd.Text = "Invalid input";
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string startTime = textBoxStart.Text;
            string endTime = textBoxEnd.Text;

            DateTime startDateTime = DateTime.Parse(startTime);
            DateTime endDateTime = DateTime.Parse(endTime);

            TimeSpan duration = endDateTime - startDateTime;

            string formattedDuration = duration.ToString("h':'mm");

            // Kiểm tra xem có ô được chọn trong DataGridView hay không
            if (dataGridViewTimesheetEmployeeList.SelectedCells.Count > 0)
            {
                // Lấy chỉ số của ô được chọn
                int selectedRowIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].RowIndex;
                int selectedColumnIndex = dataGridViewTimesheetEmployeeList.SelectedCells[0].ColumnIndex;

                // Kiểm tra xem ô được chọn có giá trị null hay không
                if (dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value != null)
                {
                    // Cập nhật giá trị mới cho ô được chọn
                    dataGridViewTimesheetEmployeeList.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value = "Time Working: " + formattedDuration;
                }
            }
        }

        private void btnCalculateSalary_Click(object sender, EventArgs e)
        {
            if (dataGridViewTimesheetEmployeeList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select A Day To Calculate!", "Calculate Salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string day = (string)dataGridViewTimesheetEmployeeList.SelectedRows[0].Cells["Day"].Value;

            TimeSpan totalWorkTime = TimeSpan.Zero;
            float totalSalary = 0;
            TimeSpan totalShortageTime = TimeSpan.Zero;
            float totalPenalty = 0;

            foreach (DataGridViewRow row in dataGridViewTimesheetEmployeeList.SelectedRows)
            {
                TimeSpan rowWorkTime = TimeSpan.Zero;
                double rowExpectedWorkHours = 0;
                for (int i = 1; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().StartsWith("Time Working: "))
                    {
                        string timeString = row.Cells[i].Value.ToString().Substring(14); // Lấy chuỗi thời gian làm việc từ cell
                        TimeSpan workTime;
                        if (TimeSpan.TryParse(timeString, out workTime))
                        {
                            rowWorkTime += workTime;

                            // Tính số giờ làm việc dự kiến
                            if (i == 1) // Cột 7h-15h
                                rowExpectedWorkHours += 8;
                            else if (i == 2) // Cột 15h-19h
                                rowExpectedWorkHours += 4;
                            else if (i == 3) // Cột 19h-3h
                                rowExpectedWorkHours += 8;
                            else if (i == 4) // Cột 3h-7h
                                rowExpectedWorkHours += 4;
                        }
                    }
                }

                totalWorkTime += rowWorkTime;

                // Tính thời gian làm không đủ giờ
                if (rowWorkTime < TimeSpan.FromHours(rowExpectedWorkHours))
                {
                    TimeSpan shortageTime = TimeSpan.FromHours(rowExpectedWorkHours) - rowWorkTime;
                    
                    totalShortageTime += shortageTime;

                    if (roleOther == "Manager")
                    {
                        float penalty = (float)shortageTime.TotalHours * 160;
                        totalPenalty += penalty;
                    }
                    else if (roleOther == "Receptionist")
                    {
                        float penalty = (float)shortageTime.TotalHours * 120;
                        totalPenalty += penalty;
                    }
                    else if (roleOther == "Labor")
                    {
                        float penalty = (float)shortageTime.TotalHours * 80;
                        totalPenalty += penalty;
                    }
                }
            }

            if (roleOther == "Manager")
            {
                totalSalary = (float)totalWorkTime.TotalHours * 80;
            }
            else if (roleOther == "Receptionist")
            {
                totalSalary = (float)totalWorkTime.TotalHours * 60;
            }
            else if (roleOther == "Labor")
            {
                totalSalary = (float)totalWorkTime.TotalHours * 40;
            }

            string totalWorkTimeFormatted = string.Format("{0}:{1:D2}", (int)totalWorkTime.TotalHours, totalWorkTime.Minutes);
            //MessageBox.Show("Total Work Time: " + totalWorkTimeFormatted);
            //MessageBox.Show("Total Salary: " + totalSalary.ToString());

            string totalShortageTimeFormatted = string.Format("{0}:{1:D2}", (int)totalShortageTime.TotalHours, totalShortageTime.Minutes);
            //MessageBox.Show("Total Shortage Time: " + totalShortageTimeFormatted);
            //MessageBox.Show("Total Penalty: " + totalPenalty.ToString());

            if (timesheet.CheckAlreadyCalculateSalary(IDOther, day))
            {
                if (timesheet.insertSalary(IDOther, fullNameOther, day, totalWorkTimeFormatted, totalShortageTimeFormatted, totalSalary, totalPenalty))
                {
                    MessageBox.Show("Calculate Salary Successfully", "Calculate Salary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Calculate Salary UnSuccessfully", "Calculate salary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This Day Already Calculate", "Calculate salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SqlCommand command = new SqlCommand("SELECT day AS Day, totalWorkTime AS [Total Work Time], totalShortageTime AS [Total Shortage Time], totalSalary AS [Total Salary], totalPenalty AS [Total Penalty] FROM Salary WHERE ID = '" + IDOther + "' ORDER BY CAST(REPLACE([day], 'Day ', '') AS INT)");
            fillGridForSalary(command);
        }

        private void btnDeleteCalculate_Click(object sender, EventArgs e)
        {
            if (dataGridViewSalaryList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select A Day To Delete!", "Delete Calculate Salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string day = (string)dataGridViewSalaryList.SelectedRows[0].Cells["Day"].Value;

            if (timesheet.deleteSalary(IDOther, day))
            {
                MessageBox.Show("Delete Successfully", "Delete Calculate Salary", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete UnSuccessfully", "Delete Calculate Salary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SqlCommand command = new SqlCommand("SELECT day AS Day, totalWorkTime AS [Total Work Time], totalShortageTime AS [Total Shortage Time], totalSalary AS [Total Salary], totalPenalty AS [Total Penalty] FROM Salary WHERE ID = '" + IDOther + "' ORDER BY CAST(REPLACE([day], 'Day ', '') AS INT)");
            fillGridForSalary(command);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT day AS Day, totalWorkTime AS [Total Work Time], totalShortageTime AS [Total Shortage Time], totalSalary AS [Total Salary], totalPenalty AS [Total Penalty] FROM Salary WHERE ID = '" + IDOther + "' ORDER BY CAST(REPLACE([day], 'Day ', '') AS INT)");
            fillGridForSalary(command);
        }
    }
}
