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
    public partial class SalaryEmployeeForm : Form
    {
        MY_DB mydb = new MY_DB();
        EMPLOYEE employee = new EMPLOYEE();
        TIMESHEET timesheet = new TIMESHEET();

        string roleUser;
        string fnameUser;
        string lnameUser;
        public SalaryEmployeeForm()
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
            dataGridViewSalaryList.ReadOnly = true;
            dataGridViewSalaryList.DataSource = employee.getEmployees(command);
            dataGridViewSalaryList.AllowUserToAddRows = false;        }

        private void SalaryEmployeeForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();

            SqlCommand command = new SqlCommand("SELECT day AS Day, totalWorkTime AS [Total Work Time], totalShortageTime AS [Total Shortage Time], totalSalary AS [Total Salary], totalPenalty AS [Total Penalty] FROM Salary WHERE ID = '" + Global.GlobalUserID + "' ORDER BY CAST(REPLACE([day], 'Day ', '') AS INT)");
            fillGrid(command);

            // Kiểm tra có bất kỳ dữ liệu nào trong DataGridView hay không
            if (dataGridViewSalaryList.RowCount == 0)
            {
                MessageBox.Show("No Salary Data Available!", "Show Salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblTotalSalary.Text = "Total Salary: ";
                lblTotalPenalty.Text = "Total Penalty: ";

                return;
            }
            else
            {
                double totalSalary = Convert.ToDouble(timesheet.totalSalary(Global.GlobalUserID));

                double totalPenalty = Convert.ToDouble(timesheet.totalPenalty(Global.GlobalUserID));

                lblTotalSalary.Text = "Total Salary: " + totalSalary;
                lblTotalPenalty.Text = "Total Penalty: " + totalPenalty;
            }
            

        }
    }
}
