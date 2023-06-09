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
    public partial class LoginForm : Form
    {
        MY_DB db = new MY_DB();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string password = textBoxPassWord.Text;

            if (radioButtonAdmin.Checked == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM Log_in WHERE role = 'Admin' AND username = @User AND password = @Pass", db.getConnection);

                command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

                adapter.SelectCommand = command;

                adapter.Fill(table);

                if ((table.Rows.Count > 0))
                {
                    string idUser = table.Rows[0][0].ToString();
                    Global.SetGlobalUserId(idUser);

                    MainForm mainF = new MainForm();

                    mainF.btnArrTimeSheet.Enabled = true;
                    mainF.btnArrTimeSheet.BackColor = Color.DarkOrange;

                    mainF.btnTimeSheet.Enabled = false;
                    mainF.btnTimeSheet.BackColor = Color.Gray;

                    mainF.btnSalary.Enabled = false;
                    mainF.btnSalary.BackColor = Color.Gray;

                    mainF.btnSalaryAllEmployee.Enabled = true;
                    mainF.btnSalaryAllEmployee.BackColor = Color.DarkOrange;

                    mainF.btnUserManagement.Enabled = true;
                    mainF.btnUserManagement.BackColor = Color.DarkOrange;

                    mainF.Show(this);
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButtonManage.Checked == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM Log_in WHERE role = 'Manager' AND username = @User AND password = @Pass", db.getConnection);

                command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

                adapter.SelectCommand = command;

                adapter.Fill(table);

                // xác nhận user đang chờ admin xác nhận
                SqlDataAdapter adapterTempUser = new SqlDataAdapter();

                DataTable tableTempUser = new DataTable();

                SqlCommand commandTempUser = new SqlCommand("SELECT * FROM Temp_Log_in WHERE role = 'Manager' AND username = @User AND password = @Pass", db.getConnection);

                commandTempUser.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUserName.Text;
                commandTempUser.Parameters.Add("Pass", SqlDbType.VarChar).Value = textBoxPassWord.Text;

                adapterTempUser.SelectCommand = commandTempUser;

                adapterTempUser.Fill(tableTempUser);

                if ((table.Rows.Count > 0))
                {
                    string idUser = table.Rows[0][0].ToString();
                    Global.SetGlobalUserId(idUser);

                    MainForm mainF = new MainForm();
                    mainF.Show(this);
                }
                else if ((tableTempUser.Rows.Count > 0))
                {
                    MessageBox.Show("Sorry, Please Wait For Admin To Accept", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButtonReceptionist.Checked == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM Log_in WHERE role = 'Receptionist' AND username = @User AND password = @Pass", db.getConnection);

                command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

                adapter.SelectCommand = command;

                adapter.Fill(table);

                // xác nhận user đang chờ admin xác nhận
                SqlDataAdapter adapterTempUser = new SqlDataAdapter();

                DataTable tableTempUser = new DataTable();

                SqlCommand commandTempUser = new SqlCommand("SELECT * FROM Temp_Log_in WHERE role = 'Receptionist' AND username = @User AND password = @Pass", db.getConnection);

                commandTempUser.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUserName.Text;
                commandTempUser.Parameters.Add("Pass", SqlDbType.VarChar).Value = textBoxPassWord.Text;

                adapterTempUser.SelectCommand = commandTempUser;

                adapterTempUser.Fill(tableTempUser);

                if ((table.Rows.Count > 0))
                {
                    string idUser = table.Rows[0][0].ToString();
                    Global.SetGlobalUserId(idUser);

                    //MainForm mainF = new MainForm();
                    //mainF.Show(this);

                    CheckTimeForm checkTimeForm = new CheckTimeForm();
                    checkTimeForm.Show(this);
                }
                else if ((tableTempUser.Rows.Count > 0))
                {
                    MessageBox.Show("Sorry, Please Wait For Admin To Accept", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButtonLabor.Checked == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM Log_in WHERE role = 'Labor' AND username = @User AND password = @Pass", db.getConnection);

                command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("Pass", SqlDbType.VarChar).Value = password;

                adapter.SelectCommand = command;

                adapter.Fill(table);

                // xác nhận user đang chờ admin xác nhận
                SqlDataAdapter adapterTempUser = new SqlDataAdapter();

                DataTable tableTempUser = new DataTable();

                SqlCommand commandTempUser = new SqlCommand("SELECT * FROM Temp_Log_in WHERE role = 'Labor' AND username = @User AND password = @Pass", db.getConnection);

                commandTempUser.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUserName.Text;
                commandTempUser.Parameters.Add("Pass", SqlDbType.VarChar).Value = textBoxPassWord.Text;

                adapterTempUser.SelectCommand = commandTempUser;

                adapterTempUser.Fill(tableTempUser);

                if ((table.Rows.Count > 0))
                {
                    string idUser = table.Rows[0][0].ToString();
                    Global.SetGlobalUserId(idUser);

                    MainForm mainF = new MainForm();
                    mainF.btnEmployee.Enabled = false;
                    mainF.btnEmployee.BackColor = Color.Gray;
                    mainF.Show(this);
                }
                else if ((tableTempUser.Rows.Count > 0))
                {
                    MessageBox.Show("Sorry, Please Wait For Admin To Accept", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            pictureBoxLogin.Image = Image.FromFile("../../images/login.jpg");
        }

        private void linkLabelNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (radioButtonAdmin.Checked == true)
            {
                MessageBox.Show("Can Not Register Role Admin", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (radioButtonLabor.Checked == true)
            {
                string role = "Labor";
                RegisterForm registerF = new RegisterForm(role);
                registerF.Show(this);
            }
            else if (radioButtonManage.Checked == true)
            {
                string role = "Manager";
                RegisterForm registerF = new RegisterForm(role);
                registerF.Show(this);
            }
            else if (radioButtonReceptionist.Checked == true)
            {
                string role = "Receptionist";
                RegisterForm registerF = new RegisterForm(role);
                registerF.Show(this);
            }
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            FormBookRoom formBookRoom = new FormBookRoom();
            formBookRoom.Show(this);
        }
    }
}
