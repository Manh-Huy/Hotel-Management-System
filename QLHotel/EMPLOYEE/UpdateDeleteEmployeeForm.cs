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
    public partial class UpdateDeleteEmployeeForm : Form
    {
        MY_DB mydb = new MY_DB();
        EMPLOYEE employee = new EMPLOYEE();
        USER user = new USER();
        string roleUser;
        string fnameUser;
        string lnameUser;
        public UpdateDeleteEmployeeForm()
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

        private void UpdateDeleteEmployeeForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();

            if (textBoxID.Text == "")
            {
                comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                comboBoxRole.DropDownStyle = ComboBoxStyle.DropDown;
            }
            if (roleUser == "Admin")
            {
                comboBoxRole.Items.Add("Manager");
                comboBoxRole.Items.Add("Receptionist");
                comboBoxRole.Items.Add("Labor");
            }
            else if (roleUser == "Manager")
            {
                comboBoxRole.Items.Add("Receptionist");
                comboBoxRole.Items.Add("Labor");
            }
            else if (roleUser == "Receptionist")
            {
                comboBoxRole.Items.Add("Labor");
            }
        }
        // chuc nang kiem tra du lieu input
        bool verif()
        {
            if ((textBoxFirstName.Text.Trim() == "")
                || (textBoxLastName.Text.Trim() == "")
                || (textBoxID.Text.Trim() == "")
                || (comboBoxRole.Text.Trim() == "")
                || (textBoxAddress.Text.Trim() == "")
                || (textBoxPhone.Text.Trim() == "")
                || (textBoxHomeTown.Text.Trim() == "")
                || (textBoxEmail.Text.Trim() == "")
                || (pictureBoxImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg;*.png;.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string userID = textBoxID.Text;
            string fname = textBoxFirstName.Text;
            string lname = textBoxLastName.Text;
            string role = comboBoxRole.Text;
            DateTime bdate = dateTimePickerBirthDate.Value;
            string gender = "Male";
            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }
            MemoryStream picture = new MemoryStream();
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            string hometown = textBoxHomeTown.Text;

            int born_year = dateTimePickerBirthDate.Value.Year;
            int this_year = DateTime.Now.Year;

            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Employee Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (verif())
            {
                try
                {
                    pictureBoxImage.Image.Save(picture, pictureBoxImage.Image.RawFormat);
                    if (employee.updateEmployee(userID, fname, lname, role, bdate, gender, phone, email, address, hometown, picture))
                    {
                        MessageBox.Show("New Employee Added", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Số lỗi cho lỗi ràng buộc khóa chính
                    {
                        MessageBox.Show("ID Employee Already Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;

            if (employee.deleteEmployee(id) && user.deleteUser(id))
            {
                MessageBox.Show("Delete Employee Successfully!", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxID.Text = "";
                textBoxFirstName.Text = "";
                textBoxLastName.Text = "";
                comboBoxRole.Text = "";
                dateTimePickerBirthDate.Value = DateTime.Now;
                radioButtonMale.Checked = true;
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                textBoxAddress.Text = "";
                textBoxHomeTown.Text = "";
                pictureBoxImage.Image = null;
            }
            else
            {
                MessageBox.Show("ID Do Not Exist!", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string ID = textBoxID.Text;

            string query = "";

            if (roleUser == "Admin")
            {
                query = "SELECT ID, fname, lname, role, bdate, gender, phone,  email, address, hometown, picture FROM Employee WHERE ID = '" + ID + "'";
            }
            else if (roleUser == "Manager")
            {
                query = "SELECT ID, fname, lname, role, bdate, gender, phone,  email, address, hometown, picture FROM Employee WHERE role <> 'Admin' AND role <> 'Manager' AND ID = '" + ID + "'";
            }
            else if (roleUser == "Receptionist")
            {
                query = "SELECT ID, fname, lname, role, bdate, gender, phone,  email, address, hometown, picture FROM Employee WHERE role = 'Labor' AND ID = '" + ID + "'";
            }
            SqlCommand command = new SqlCommand(query);

            DataTable table = employee.getEmployees(command);

            if (table.Rows.Count > 0)
            {
                textBoxFirstName.Text = table.Rows[0]["fname"].ToString();
                textBoxLastName.Text = table.Rows[0]["lname"].ToString();
                comboBoxRole.Text = table.Rows[0]["role"].ToString();
                dateTimePickerBirthDate.Value = (DateTime)table.Rows[0]["bdate"];

                // gender
                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    radioButtonFemale.Checked = true;
                }
                else
                {
                    radioButtonMale.Checked = true;
                }

                textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                textBoxAddress.Text = table.Rows[0]["address"].ToString();
                textBoxHomeTown.Text = table.Rows[0]["hometown"].ToString();
                textBoxEmail.Text = table.Rows[0]["email"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxImage.Image = Image.FromStream(picture);
            }

            else
            {
                MessageBox.Show("Not Found", "Find Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
