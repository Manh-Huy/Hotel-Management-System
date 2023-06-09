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
    public partial class AllSalaryEmployeeForm : Form
    {
        public AllSalaryEmployeeForm()
        {
            InitializeComponent();
        }
        TIMESHEET timesheet = new TIMESHEET();
        EMPLOYEE employee = new EMPLOYEE();
        MY_DB mydb = new MY_DB();
        bool isAddingItem = false;


        private void AllSalaryEmployeeForm_Load(object sender, EventArgs e)
        {
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
        }
        public void fillGrid(string position, SqlCommand command)
        {
            if (position == "EmployeeList")
            {
                dataGridViewEmployeeList.ReadOnly = true;
                dataGridViewEmployeeList.DataSource = employee.getEmployees(command);
                dataGridViewEmployeeList.AllowUserToAddRows = false;
            }
            else if (position == "SalaryList")
            {
                dataGridViewSalaryList.ReadOnly = true;
                dataGridViewSalaryList.DataSource = employee.getEmployees(command);
                dataGridViewSalaryList.AllowUserToAddRows = false;
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployeeList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select An Employee!", "Show Salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ID = (string)dataGridViewEmployeeList.SelectedRows[0].Cells["ID"].Value;

            SqlCommand command = new SqlCommand("SELECT day AS Day, totalWorkTime AS [Total Work Time], totalShortageTime AS [Total Shortage Time], totalSalary AS [Total Salary], totalPenalty AS [Total Penalty] FROM Salary WHERE ID = '" + ID + "' ORDER BY CAST(REPLACE([day], 'Day ', '') AS INT)");
            fillGrid("SalaryList", command);

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
                double totalSalary = Convert.ToDouble(timesheet.totalSalary(ID));

                double totalPenalty = Convert.ToDouble(timesheet.totalPenalty(ID));

                lblTotalSalary.Text = "Total Salary: " + totalSalary;
                lblTotalPenalty.Text = "Total Penalty: " + totalPenalty;
            }
        }
    }
}
