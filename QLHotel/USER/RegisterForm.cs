using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace _20142178_20110370_Nhom15_QLHotel
{
    public partial class RegisterForm : Form
    {
        string roleUser;
        public RegisterForm()
        {
            InitializeComponent();
        }
        public RegisterForm(string role)
        {
            roleUser = role;
            InitializeComponent();
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            pictureBoxLogin.Image = Image.FromFile("../../images/register.jpg");
            btnSignUp.Enabled = false;
            btnSignUp.BackColor = Color.Gray;
        }
        // chuc nang kiem tra du lieu input
        bool verif()
        {
            if ((textBoxUserName.Text.Trim() == "")
                || (textBoxPassWord.Text.Trim() == "")
                || (textBoxConfirmPW.Text.Trim() == "")
                || (textBoxEmail.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // chuc nang kiem tra format email
        private bool IsValidEmail(string email)
        {
            // Kiểm tra định dạng email bằng biểu thức chính quy
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (verif() == false)
            {
                MessageBox.Show("Empty Fields", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                USER user = new USER();
                string Id = textBoxID.Text;
                string uname = textBoxUserName.Text;
                string pass = textBoxPassWord.Text;
                string email = textBoxEmail.Text;

                if (user.CheckID(Id) == false)
                {
                    MessageBox.Show("This ID Already Has An Account", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (user.CheckUserName(roleUser, uname))
                {
                    if (textBoxPassWord.Text != textBoxConfirmPW.Text)
                    {
                        MessageBox.Show("Password does not match!!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (IsValidEmail(email))
                    {
                        string pin = RANDOM_PIN_GENERATOR.GenerateRandomPIN(6); // Tạo ra mã PIN ngẫu nhiên gồm 6 chữ số
                        string subject = "Mã xác nhận đăng ký";
                        string body = $"Mã xác nhận của bạn là {pin}";

                        // Thông tin tài khoản email gửi
                        string fromEmail = "test24072002@gmail.com";
                        string fromPassword = "kcsxsxfgaojfhuzp";

                        MailMessage message = new MailMessage(fromEmail, email, subject, body);
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.EnableSsl = true;
                        //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);

                        // Gửi email
                        try
                        {
                            smtp.Send(message);
                            MessageBox.Show("Code Successfully Send", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MessageBox.Show("Enter PIN from email", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            EnterPINCodeForm enterPin = new EnterPINCodeForm(Id, roleUser, pin, uname, pass, email);
                            enterPin.ShowDialog(this);
                        }
                        catch
                        {
                            MessageBox.Show("Code Unsuccessfully Send", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Email Not Correct!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("UserName Existed!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text == "")
            {
                MessageBox.Show("Please Enter ID User", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MY_DB mydb = new MY_DB();
            USER user = new USER();
            string Id = textBoxID.Text;


            SqlCommand command = new SqlCommand("SELECT email FROM Employee WHERE ID = @Id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            mydb.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                MessageBox.Show("ID Does Not Exist!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mydb.closeConnection();
                return;
            }
            else
            {
                while (reader.Read())
                {
                    textBoxEmail.Text = reader.GetString(0);
                    textBoxID.ReadOnly = true;
                    textBoxEmail.ReadOnly = true;
                    btnSignUp.Enabled = true;
                    btnSignUp.BackColor = Color.Green;
                }
            }
            mydb.closeConnection();
        }
    }
}
