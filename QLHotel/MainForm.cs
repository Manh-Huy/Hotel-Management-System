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
    public partial class MainForm : Form
    {
        MY_DB mydb = new MY_DB();
        EMPLOYEE employee = new EMPLOYEE();
        string roleUser;
        string fnameUser;
        string lnameUser;
        public MainForm()
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

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            contextMenuStripEmployee.Show(btnEmployee, new Point(0, btnEmployee.Height));
        }

        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeF = new AddEmployeeForm();
            addEmployeeF.Show(this);
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeListForm employeeListF = new EmployeeListForm();
            employeeListF.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmployeeForm updateDeleteEmployeeF = new UpdateDeleteEmployeeForm();
            updateDeleteEmployeeF.Show(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
        }

        private void btnArrTimeSheet_Click(object sender, EventArgs e)
        {
            TimeSheetForm timeSheetF = new TimeSheetForm();
            timeSheetF.Show(this);
        }

        private void btnTimeSheet_Click(object sender, EventArgs e)
        {
            TimeSheetForEachEmployeeForm timeSheetForEachEmployeeF = new TimeSheetForEachEmployeeForm();
            timeSheetForEachEmployeeF.Show(this);
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            SalaryEmployeeForm salaryEmployeeF = new SalaryEmployeeForm();
            salaryEmployeeF.Show(this);
        }

        private void btnSalaryAllEmployee_Click(object sender, EventArgs e)
        {
            AllSalaryEmployeeForm allSalaryEmployeeF = new AllSalaryEmployeeForm();
            allSalaryEmployeeF.Show(this);
        }

        private void linkLabelEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditUserForm editUserF = new EditUserForm();
            editUserF.Show(this);
        }

        private void linkLabelRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getImageAndUsername();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            contextMenuStripUserManagement.Show(btnUserManagement, new Point(0, btnUserManagement.Height));
        }

        private void authenticationUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthenticationUserForm auUser = new AuthenticationUserForm();
            auUser.Show(this);
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserListForm userLF = new UserListForm();
            userLF.Show(this);
        }

        private void btnStatic_Click(object sender, EventArgs e)
        {
            FormStaticFoodAndDrink formStaticFoodAndDrink = new FormStaticFoodAndDrink();
            formStaticFoodAndDrink.Show(this);
        }
    }
}
