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
    public partial class EmployeeListForm : Form
    {
        MY_DB mydb = new MY_DB();
        EMPLOYEE employee = new EMPLOYEE();

        string roleUser;
        string fnameUser;
        string lnameUser;

        bool isAddingItem = false;

        public EmployeeListForm()
        {
            InitializeComponent();
        }
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
            dataGridViewEmployeeList.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewEmployeeList.RowTemplate.Height = 80;
            dataGridViewEmployeeList.DataSource = employee.getEmployees(command);
            picCol = (DataGridViewImageColumn)dataGridViewEmployeeList.Columns[9];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewEmployeeList.AllowUserToAddRows = false;

        }

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();

            comboBoxSelectRole.DropDownStyle = ComboBoxStyle.DropDownList;

            if (roleUser == "Admin")
            {
                isAddingItem = true;
                comboBoxSelectRole.Items.Add("All");
                comboBoxSelectRole.Items.Add("Manager");
                comboBoxSelectRole.Items.Add("Receptionist");
                comboBoxSelectRole.Items.Add("Labor");
                comboBoxSelectRole.Text = "All";
                isAddingItem = false;

                SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee");
                fillGrid(command);
            }
            else if (roleUser == "Manager")
            {
                isAddingItem = true;
                comboBoxSelectRole.Items.Add("All");
                comboBoxSelectRole.Items.Add("Receptionist");
                comboBoxSelectRole.Items.Add("Labor");
                comboBoxSelectRole.Text = "All";
                isAddingItem = false;

                SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee WHERE role <> 'Manager' AND role <> 'Admin'");
                fillGrid(command);
            }
            else if (roleUser == "Receptionist")
            {
                isAddingItem = true;
                comboBoxSelectRole.Items.Add("All");
                comboBoxSelectRole.Items.Add("Labor");
                comboBoxSelectRole.Text = "All";
                isAddingItem = false;

                SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee WHERE role = 'Labor'");
                fillGrid(command);
            }
        }

        private void comboBoxSelectRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAddingItem)
            {
                return;
            }
            if (comboBoxSelectRole.Text == "All")
            {
                if (roleUser == "Admin")
                {
                    SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee");
                    fillGrid(command);
                }
                else if (roleUser == "Manager")
                {
                    SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee WHERE role <> 'Manager' AND role <> 'Admin'");
                    fillGrid(command);
                }
                else if (roleUser == "Receptionist")
                {
                    SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee WHERE role = 'Labor'");
                    fillGrid(command);
                }
            }
            else if (comboBoxSelectRole.Text == "Manager")
            {
                SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee WHERE role = 'Manager'");
                fillGrid(command);
            }
            else if (comboBoxSelectRole.Text == "Receptionist")
            {
                SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee WHERE role = 'Receptionist'");
                fillGrid(command);
            }
            else if (comboBoxSelectRole.Text == "Labor")
            {
                SqlCommand command = new SqlCommand("SELECT ID, fname AS [First Name], lname AS [Last Name], bdate AS [BirthDate], gender AS [Gender], phone AS [Phone], email AS [Email], address AS [Address], hometown AS [Hometown], picture AS [Picture] FROM Employee WHERE role = 'Labor'");
                fillGrid(command);
            }
        }

        private void dataGridViewEmployeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDeleteEmployeeForm updateDeleteEmployeeF = new UpdateDeleteEmployeeForm();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT role FROM Employee WHERE ID = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = dataGridViewEmployeeList.CurrentRow.Cells[0].Value.ToString();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                updateDeleteEmployeeF.comboBoxRole.Text = table.Rows[0]["role"].ToString();
            }

            updateDeleteEmployeeF.textBoxID.Text = dataGridViewEmployeeList.CurrentRow.Cells[0].Value.ToString();
            updateDeleteEmployeeF.textBoxFirstName.Text = dataGridViewEmployeeList.CurrentRow.Cells[1].Value.ToString();
            updateDeleteEmployeeF.textBoxLastName.Text = dataGridViewEmployeeList.CurrentRow.Cells[2].Value.ToString();

            updateDeleteEmployeeF.dateTimePickerBirthDate.Value = (DateTime)dataGridViewEmployeeList.CurrentRow.Cells[3].Value;
            if ((dataGridViewEmployeeList.CurrentRow.Cells[4].Value.ToString().Trim() == "Female"))
            {
                updateDeleteEmployeeF.radioButtonFemale.Checked = true;
            }
            else
            {
                updateDeleteEmployeeF.radioButtonMale.Checked = true;
            }

            updateDeleteEmployeeF.textBoxPhone.Text = dataGridViewEmployeeList.CurrentRow.Cells[5].Value.ToString();
            updateDeleteEmployeeF.textBoxEmail.Text = dataGridViewEmployeeList.CurrentRow.Cells[6].Value.ToString();
            updateDeleteEmployeeF.textBoxAddress.Text = dataGridViewEmployeeList.CurrentRow.Cells[7].Value.ToString();
            updateDeleteEmployeeF.textBoxHomeTown.Text = dataGridViewEmployeeList.CurrentRow.Cells[8].Value.ToString();
            // code xử lý hình ảnh up lên
            byte[] pic;
            pic = (byte[])dataGridViewEmployeeList.CurrentRow.Cells[9].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteEmployeeF.pictureBoxImage.Image = Image.FromStream(picture);

            this.Show();
            updateDeleteEmployeeF.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowTimeSheet_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployeeList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Employee!", "Select Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string firstName = (string)dataGridViewEmployeeList.SelectedRows[0].Cells["First Name"].Value;
            
            string lastName = (string)dataGridViewEmployeeList.SelectedRows[0].Cells["Last Name"].Value;

            string ID = (string)dataGridViewEmployeeList.SelectedRows[0].Cells["ID"].Value;

            string fullName = firstName + " " + lastName;

            string role = "";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT role FROM Employee WHERE ID = '" + ID + "'", mydb.getConnection);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                role = table.Rows[0]["role"].ToString();
            }

            TimeSheetForEachEmployeeForm.isSeeOtherTimeSheet = true;

            TimeSheetForEachEmployeeForm timeSheetForEachEmployeeF = new TimeSheetForEachEmployeeForm(fullName, ID, role);

            if (roleUser == "Admin")
            {
                timeSheetForEachEmployeeF.panelCalculateSalary.Enabled = true;

                timeSheetForEachEmployeeF.btnSave.Enabled = false;
                timeSheetForEachEmployeeF.btnSave.BackColor = Color.Gray;

                timeSheetForEachEmployeeF.btnCheckIn.Enabled = false;
                timeSheetForEachEmployeeF.btnCheckIn.BackColor = Color.Gray;

                timeSheetForEachEmployeeF.btnCheckOut.Enabled = false;
                timeSheetForEachEmployeeF.btnCheckOut.BackColor = Color.Gray;
            }

            timeSheetForEachEmployeeF.Show(this);
        }
    }
}
