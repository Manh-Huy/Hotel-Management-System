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
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
        }
        bool isAddingItem = false;
        USER user = new USER();
        MY_DB mydb = new MY_DB();

        public void fillGrid(SqlCommand command)
        {
            dataGridViewUserList.ReadOnly = true;
            dataGridViewUserList.DataSource = user.getUsers(command);
            dataGridViewUserList.AllowUserToAddRows = false;
        }
        private void UserListForm_Load(object sender, EventArgs e)
        {
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            isAddingItem = true;
            comboBoxRole.Items.Add("All");
            comboBoxRole.Items.Add("Manager");
            comboBoxRole.Items.Add("Receptionist");
            comboBoxRole.Items.Add("Labor");
            comboBoxRole.Text = "All";
            isAddingItem = false;

            SqlCommand command = new SqlCommand("SELECT ID, role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Log_in");
            fillGrid(command);
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAddingItem)
            {
                return;
            }
            if (comboBoxRole.Text == "All")
            {
                SqlCommand command = new SqlCommand("SELECT ID, role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Log_in");
                fillGrid(command);
            }
            else if (comboBoxRole.Text == "Manager")
            {
                SqlCommand command = new SqlCommand("SELECT ID, role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Log_in WHERE role = 'Manager'");
                fillGrid(command);
            }
            else if (comboBoxRole.Text == "Receptionist")
            {
                SqlCommand command = new SqlCommand("SELECT ID, role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Log_in WHERE role = 'Receptionist'");
                fillGrid(command);
            }
            else if (comboBoxRole.Text == "Labor")
            {
                SqlCommand command = new SqlCommand("SELECT ID, role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Log_in WHERE role = 'Labor'");
                fillGrid(command);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select A User To Delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = ((string)dataGridViewUserList.SelectedRows[0].Cells["Role"].Value).Trim();
            if (role == "Admin")
            {
                MessageBox.Show("Can Not Delete Admin!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userId = dataGridViewUserList.SelectedRows[0].Cells["ID"].Value.ToString();

            MY_DB db = new MY_DB();
            SqlCommand deleteCommand = new SqlCommand("DELETE FROM Log_in WHERE ID = @id", db.getConnection);
            deleteCommand.Parameters.AddWithValue("@id", userId);

            db.openConnection();

            if (deleteCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Delete Successful!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete Unsuccessful!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            // Refresh lại datagridview
            SqlCommand command = new SqlCommand("SELECT ID, role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Log_in");
            fillGrid(command);
            comboBoxRole.Text = "All";
            db.closeConnection();
        }
    }
}
