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
    public partial class TimeSheetForm : Form
    {
        public TimeSheetForm()
        {
            InitializeComponent();
        }
        EMPLOYEE employee = new EMPLOYEE();
        MY_DB mydb = new MY_DB();

        bool isAddingItem = false;

        public bool insertDatabaseByQuery(string ID, string fullName, string day, string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@day", SqlDbType.NVarChar).Value = day;


            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))

            {
                mydb.closeConnection();
                return true;
            }

            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        private void TimeSheetForm_Load(object sender, EventArgs e)
        {
            // dataGridViewTimeSheet
            dataGridViewTimeSheet.Columns.Add("TimeSlot", "Time Slot");
            dataGridViewTimeSheet.Columns.Add("Employee", "Employee");
            dataGridViewTimeSheet.Columns["Employee"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTimeSheet.Columns.Insert(0, new DataGridViewTextBoxColumn() { HeaderText = "Days", Name = "Days" });

            // dataGridViewEmployeeList
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;

            isAddingItem = true;
            comboBoxRole.Items.Add("All");
            comboBoxRole.Items.Add("Manager");
            comboBoxRole.Items.Add("Receptionist");
            comboBoxRole.Items.Add("Labor");
            comboBoxRole.Text = "All";
            isAddingItem = false;

            SqlCommand command = new SqlCommand("SELECT ID, CONCAT (fname, ' ', lname) AS [Full Name] FROM Employee WHERE role <> 'Admin'");
            fillGrid("EmployeeList", command);

            // dataGridViewSelectEmloyee
            dataGridViewSelectEmloyee.Columns.Add("ID", "ID");
            dataGridViewSelectEmloyee.Columns.Add("FullName", "Full Name");
        }
        public void fillGrid(string position, SqlCommand command)
        {
            if (position == "EmployeeList")
            {
                dataGridViewEmployeeList.ReadOnly = true;
                dataGridViewEmployeeList.DataSource = employee.getEmployees(command);
                dataGridViewEmployeeList.AllowUserToAddRows = false;
            }
        }
        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAddingItem)
            {
                return;
            }

            if (comboBoxRole.Text == "Manager")
            {
                SqlCommand command = new SqlCommand("SELECT ID, CONCAT (fname, ' ', lname) AS [Full Name] FROM Employee WHERE role = 'Manager' AND role <> 'Admin'");
                fillGrid("EmployeeList", command);
            }
            else if (comboBoxRole.Text == "Receptionist")
            {
                SqlCommand command = new SqlCommand("SELECT ID, CONCAT (fname, ' ', lname) AS [Full Name] FROM Employee WHERE role = 'Receptionist' AND role <> 'Admin'");
                fillGrid("EmployeeList", command);
            }
            else if (comboBoxRole.Text == "Labor")
            {
                SqlCommand command = new SqlCommand("SELECT ID, CONCAT (fname, ' ', lname) AS [Full Name] FROM Employee WHERE role = 'Labor' AND role <> 'Admin'");
                fillGrid("EmployeeList", command);
            }
        }
        private void dataGridViewEmployeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = 0;
            string ID = dataGridViewEmployeeList.CurrentRow.Cells[0].Value.ToString();
            string fullName = dataGridViewEmployeeList.CurrentRow.Cells[1].Value.ToString();

            foreach (DataGridViewRow row in dataGridViewSelectEmloyee.Rows)
            {
                var cellValue = row.Cells[0].Value; // Lấy giá trị của ô trong cột đầu tiên

                if (cellValue != null && ID == cellValue.ToString())
                {
                    count++;
                    break;
                }
            }

            if (count > 0)
            {
                MessageBox.Show("You Have Been Choosed This Employee", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dataGridViewSelectEmloyee.Rows.Add(ID, fullName);
            }
        }
        private void dataGridViewSelectEmloyee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewSelectEmloyee.Rows[e.RowIndex];
                dataGridViewSelectEmloyee.Rows.Remove(selectedRow);
            }
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewEmployeeList.Rows)
            {
                string ID = row.Cells[0].Value.ToString();
                string fullName = row.Cells[1].Value.ToString();

                int count = 0;
                foreach (DataGridViewRow selectedRow in dataGridViewSelectEmloyee.Rows)
                {
                    var cellValue = selectedRow.Cells[0].Value;

                    if (cellValue != null && ID == cellValue.ToString())
                    {
                        count++;
                        break;
                    }
                }

                if (count > 0)
                {
                    MessageBox.Show("You Have Already Chosen This Employee", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dataGridViewSelectEmloyee.Rows.Add(ID, fullName);
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            dataGridViewSelectEmloyee.Rows.Clear();
        }
        private void btnArrange_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM TimeSheet", mydb.getConnection);

            mydb.openConnection();

            command.ExecuteNonQuery();

            mydb.closeConnection();

            SqlCommand commandSalary = new SqlCommand("DELETE FROM Salary", mydb.getConnection);

            mydb.openConnection();

            commandSalary.ExecuteNonQuery();

            mydb.closeConnection();

            // Xóa dữ liệu hiện có trong DataGridView
            dataGridViewTimeSheet.Rows.Clear();

            if (string.IsNullOrEmpty(comboBoxNumDays.Text) || !int.TryParse(comboBoxNumDays.Text, out _))
            {
                MessageBox.Show("Please Enter a Valid Number of Days", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int countManager = 0;
            int countReceptionist = 0;
            int countLabor = 0;

            foreach (DataGridViewRow row in dataGridViewSelectEmloyee.Rows)
            {
                if (row.Cells["ID"].Value != null)
                {
                    string value = row.Cells["ID"].Value.ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value.StartsWith("m"))
                        {
                            countManager++;
                        }
                        else if (value.StartsWith("r"))
                        {
                            countReceptionist++;
                        }
                        else if (value.StartsWith("l"))
                        {
                            countLabor++;
                        }
                    }
                }
            }

            if (countManager != 2)
            {
                MessageBox.Show("Number Of Managers Only Can Be 2", "Wrong Number Of Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (countReceptionist != 4)
            {
                MessageBox.Show("Number Of Receptionists Only Can Be 4", "Wrong Number Of Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (countLabor != 6)
            {
                MessageBox.Show("Number Of Labors Only Can Be 6", "Wrong Number Of Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int n = Int32.Parse(comboBoxNumDays.Text);

            // Tạo danh sách ngày và ca làm việc dựa trên mẫu đã cho
            List<string> days = new List<string> { "Day 1", "Day 2", "Day 3", "Day 4" }; // Thay đổi mẫu ngày làm việc tại đây

            List<string> timeSlots = new List<string> { "7h - 15h", "15h - 19h", "19h - 3h", "3h - 7h" };

            // Thêm dữ liệu vào DataGridView dựa trên mẫu
            for (int i = 1; i <= n; i++) // Hiển thị 30 ngày
            {
                foreach (var timeSlot in timeSlots)
                {
                    string day = "Day " + i.ToString();
                    string employee = GetEmployee(day, timeSlot);
                    //string position = GetPosition(day, timeSlot);

                    dataGridViewTimeSheet.Rows.Add(day, timeSlot, employee);
                }
            }
            dataGridViewTimeSheet.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        // Phương thức để xác định người làm và chức vụ dựa trên ngày và ca làm việc
        private string GetEmployee(string day, string timeSlot)
        {
            string IDmanager1 = "";
            string IDmanager2 = "";

            string IDreceptionist1 = "";
            string IDreceptionist2 = "";
            string IDreceptionist3 = "";
            string IDreceptionist4 = "";

            string IDlabor1 = "";
            string IDlabor2 = "";
            string IDlabor3 = "";
            string IDlabor4 = "";
            string IDlabor5 = "";
            string IDlabor6 = "";

            string manager1 = "";
            string manager2 = "";

            string receptionist1 = "";
            string receptionist2 = "";
            string receptionist3 = "";
            string receptionist4 = "";

            string labor1 = "";
            string labor2 = "";
            string labor3 = "";
            string labor4 = "";
            string labor5 = "";
            string labor6 = "";

            foreach (DataGridViewRow row in dataGridViewSelectEmloyee.Rows)
            {
                object idCellValue = row.Cells["ID"].Value;
                object fullNameCellValue = row.Cells["FullName"].Value;

                if (idCellValue != null && fullNameCellValue != null)
                {
                    string ID = row.Cells["ID"].Value.ToString();
                    string fullName = row.Cells["FullName"].Value.ToString();

                    if (ID.StartsWith("m"))
                    {
                        if (string.IsNullOrEmpty(manager1))
                        {
                            manager1 = fullName;
                            IDmanager1 = ID;
                        }
                        else if (string.IsNullOrEmpty(manager2))
                        {
                            manager2 = fullName;
                            IDmanager2 = ID;
                        }
                    }
                    else if (ID.StartsWith("l"))
                    {
                        if (string.IsNullOrEmpty(labor1))
                        {
                            labor1 = fullName;
                            IDlabor1 = ID;
                        }
                        else if (string.IsNullOrEmpty(labor2))
                        {
                            labor2 = fullName;
                            IDlabor2 = ID;
                        }
                        else if (string.IsNullOrEmpty(labor3))
                        {
                            labor3 = fullName;
                            IDlabor3 = ID;
                        }
                        else if (string.IsNullOrEmpty(labor4))
                        {
                            labor4 = fullName;
                            IDlabor4 = ID;
                        }
                        else if (string.IsNullOrEmpty(labor5))
                        {
                            labor5 = fullName;
                            IDlabor5 = ID;
                        }
                        else if (string.IsNullOrEmpty(labor6))
                        {
                            labor6 = fullName;
                            IDlabor6 = ID;
                        }
                    }
                    else if (ID.StartsWith("r"))
                    {
                        if (string.IsNullOrEmpty(receptionist1))
                        {
                            receptionist1 = fullName;
                            IDreceptionist1 = ID;
                        }
                        else if (string.IsNullOrEmpty(receptionist2))
                        {
                            receptionist2 = fullName;
                            IDreceptionist2 = ID;
                        }
                        else if (string.IsNullOrEmpty(receptionist3))
                        {
                            receptionist3 = fullName;
                            IDreceptionist3 = ID;
                        }
                        else if (string.IsNullOrEmpty(receptionist4))
                        {
                            receptionist4 = fullName;
                            IDreceptionist4 = ID;
                        }
                    }
                }
            }
            
            int dayNumber = int.Parse(day.Split(' ')[1]); // Trích xuất số ngày từ chuỗi "Day X"
            int cycleDay = (dayNumber - 1) % 12 + 1;
            if (cycleDay == 1)
            {
                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist1 + ", " + receptionist2 + "\nManager: " + manager1 + "\nLabor: " + labor1 + ", " + labor2 + ", " + labor3 + ", " + labor4;
                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist3 + ", " + receptionist4 + "\nManager: " + manager2 + "\nLabor: " + labor1 + ", " + labor2 + ", " + labor3 + ", " + labor4;
                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist1 + "\nLabor: " + labor5;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager2 + "\nLabor: " + labor6;
                }
            }
            else if (cycleDay == 2)
            {
                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist2 + ", " + receptionist3 + "\nManager: " + manager2 + "\nLabor: " + labor2 + ", " + labor3 + ", " + labor4 + ", " + labor5;

                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist4 + ", " + receptionist1 + "\nManager: " + manager1 + "\nLabor: " + labor2 + ", " + labor3 + ", " + labor4 + ", " + labor5;

                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist2 + "\nLabor: " + labor6;

                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager1 + "\nLabor: " + labor1;

                }
            }
            else if (cycleDay == 3)
            {
                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist3 + ", " + receptionist4 + "\nManager: " + manager1 + "\nLabor: " + labor3 + ", " + labor4 + ", " + labor5 + ", " + labor6;

                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist1 + ", " + receptionist2 + "\nManager: " + manager2 + "\nLabor: " + labor3 + ", " + labor4 + ", " + labor5 + ", " + labor6;

                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist3 + "\nLabor: " + labor1;

                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager2 + "\nLabor: " + labor2;

                }
            }
            else if (cycleDay == 4)
            {
                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist4 + ", " + receptionist1 + "\nManager: " + manager2 + "\nLabor: " + labor4 + ", " + labor5 + ", " + labor6 + ", " + labor1;

                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist2 + ", " + receptionist3 + "\nManager: " + manager1 + "\nLabor: " + labor4 + ", " + labor5 + ", " + labor6 + ", " + labor1;

                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist4 + "\nLabor: " + labor2;

                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager1 + "\nLabor: " + labor3;

                }
            }
            else if (cycleDay == 5)
            {
                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist1 + ", " + receptionist2 + "\nManager: " + manager1 + "\nLabor: " + labor5 + ", " + labor6 + ", " + labor1 + ", " + labor2;

                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist3 + ", " + receptionist4 + "\nManager: " + manager2 + "\nLabor: " + labor5 + ", " + labor6 + ", " + labor1 + ", " + labor2;
                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist1 + "\nLabor: " + labor3;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager2 + "\nLabor: " + labor4;
                }
            }
            else if (cycleDay == 6)
            {
                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist2 + ", " + receptionist3 + "\nManager: " + manager2 + "\nLabor: " + labor6 + ", " + labor1 + ", " + labor2 + ", " + labor3;
                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist4 + ", " + receptionist1 + "\nManager: " + manager1 + "\nLabor: " + labor6 + ", " + labor1 + ", " + labor2 + ", " + labor3;

                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist2 + "\nLabor: " + labor4;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager1 + "\nLabor: " + labor5;

                }
            }
            else if (cycleDay == 7)
            {
                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist3 + ", " + receptionist4 + "\nManager: " + manager1 + "\nLabor: " + labor1 + ", " + labor2 + ", " + labor3 + ", " + labor4;
                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist1 + ", " + receptionist2 + "\nManager: " + manager2 + "\nLabor: " + labor1 + ", " + labor2 + ", " + labor3 + ", " + labor4;
                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist3 + "\nLabor: " + labor5;

                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager2 + "\nLabor: " + labor6;
                }
            }
            else if (cycleDay == 8)
            {
                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist4 + ", " + receptionist1 + "\nManager: " + manager2 + "\nLabor: " + labor2 + ", " + labor3 + ", " + labor4 + ", " + labor5;

                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist2 + ", " + receptionist3 + "\nManager: " + manager1 + "\nLabor: " + labor2 + ", " + labor3 + ", " + labor4 + ", " + labor5;

                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist4 + "\nLabor: " + labor6;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager1 + "\nLabor: " + labor1;
                }
            }
            else if (cycleDay == 9)
            {
                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist1 + ", " + receptionist2 + "\nManager: " + manager1 + "\nLabor: " + labor3 + ", " + labor4 + ", " + labor5 + ", " + labor6;
                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist3 + ", " + receptionist4 + "\nManager: " + manager2 + "\nLabor: " + labor3 + ", " + labor4 + ", " + labor5 + ", " + labor6;
                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist1 + "\nLabor: " + labor1;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager2 + "\nLabor: " + labor2;
                }
            }
            else if (cycleDay == 10)
            {
                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist2 + ", " + receptionist3 + "\nManager: " + manager2 + "\nLabor: " + labor4 + ", " + labor5 + ", " + labor6 + ", " + labor1;
                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist4 + ", " + receptionist1 + "\nManager: " + manager1 + "\nLabor: " + labor4 + ", " + labor5 + ", " + labor6 + ", " + labor1;
                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist2 + "\nLabor: " + labor2;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager1 + "\nLabor: " + labor3;
                }
            }
            else if (cycleDay == 11)
            {
                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist3 + ", " + receptionist4 + "\nManager: " + manager1 + "\nLabor: " + labor5 + ", " + labor6 + ", " + labor1 + ", " + labor2;
                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist1 + ", " + receptionist2 + "\nManager: " + manager2 + "\nLabor: " + labor5 + ", " + labor6 + ", " + labor1 + ", " + labor2;
                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist3 + "\nLabor: " + labor3;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager2 + "\nLabor: " + labor4;
                }
            }
            else if (cycleDay == 12)
            {
                string queryReceptionist4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDreceptionist4, receptionist4, day, queryReceptionist4);

                string queryReceptionist1 = "INSERT INTO TimeSheet (ID, fullName, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @fullName, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist1, receptionist1, day, queryReceptionist1);

                string queryReceptionist2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist2, receptionist2, day, queryReceptionist2);

                string queryReceptionist3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDreceptionist3, receptionist3, day, queryReceptionist3);

                string queryManager2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', NULL, NULL, NULL)";
                insertDatabaseByQuery(IDmanager2, manager2, day, queryManager2);

                string queryManager1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, 'Working', NULL, 'Working')";
                insertDatabaseByQuery(IDmanager1, manager1, day, queryManager1);

                string queryLabor6 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor6, labor6, day, queryLabor6);

                string queryLabor1 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor1, labor1, day, queryLabor1);

                string queryLabor2 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor2, labor2, day, queryLabor2);

                string queryLabor3 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, 'Working', 'Working', NULL, NULL)";
                insertDatabaseByQuery(IDlabor3, labor3, day, queryLabor3);

                string queryLabor4 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, 'Working', NULL)";
                insertDatabaseByQuery(IDlabor4, labor4, day, queryLabor4);

                string queryLabor5 = "INSERT INTO TimeSheet (ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h])" + " VALUES(@ID, @day, NULL, NULL, NULL, 'Working')";
                insertDatabaseByQuery(IDlabor5, labor5, day, queryLabor5);

                if (timeSlot == "7h - 15h")
                {
                    return "Receptionist: " + receptionist4 + ", " + receptionist1 + "\nManager: " + manager2 + "\nLabor: " + labor6 + ", " + labor1 + ", " + labor2 + ", " + labor3;
                }
                else if (timeSlot == "15h - 19h")
                {
                    return "Receptionist: " + receptionist2 + ", " + receptionist3 + "\nManager: " + manager1 + "\nLabor: " + labor6 + ", " + labor1 + ", " + labor2 + ", " + labor3;
                }
                else if (timeSlot == "19h - 3h")
                {
                    return "Receptionist: " + receptionist4 + "\nLabor: " + labor4;
                }
                else if (timeSlot == "3h - 7h")
                {
                    return "Manager: " + manager1 + "\nLabor: " + labor5;
                }
            }
            return "";
        }
    }
}
