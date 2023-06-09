using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _20142178_20110370_Nhom15_QLHotel
{
    public partial class EnterPINCodeForm : Form
    {
        public EnterPINCodeForm()
        {
            InitializeComponent();
        }
        USER user = new USER();
        string pincode;
        string idUser;
        string roleUser;
        string username;
        string password;
        string emailuser;
        public EnterPINCodeForm(string id, string role, string pin, string uname, string pass, string email)
        {
            pincode = pin;
            username = uname;
            password = pass;
            emailuser = email;
            idUser = id;
            roleUser = role;
            InitializeComponent();
        }

        private void btnEnterPINCode_Click(object sender, EventArgs e)
        {
            if (textBoxPINCode.Text == pincode)
            {
                user.insertTempUser(idUser, roleUser, username, password, emailuser);
                MessageBox.Show("sign Up Successfully! , Please Wait For Admin To Accept", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

                LoginForm login = new LoginForm();
                login.Show(this);
            }
            else
            {
                MessageBox.Show("PIN Code Not Correct!", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPINCode.Text = "";
            }
        }
    }
}
