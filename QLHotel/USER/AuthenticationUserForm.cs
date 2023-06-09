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
    public partial class AuthenticationUserForm : Form
    {
        public AuthenticationUserForm()
        {
            InitializeComponent();
        }
        USER user = new USER();

        string stringcon = @"Data Source=DESKTOP-FEQAJ4I\SQLEXPRESS;Initial Catalog=QLHotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
        private void AuthenticationUserForm_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT id AS [ID], role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Temp_Log_in"));

        }
        // Nạp data
        public void fillGrid(SqlCommand command)
        {
            dataGridViewTemp_UserList.ReadOnly = true;
            dataGridViewTemp_UserList.DataSource = user.getUsers(command);
        }

        private void ButtonApprove_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng được chọn hay không
            if (dataGridViewTemp_UserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select At Least One User To Approve!", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy danh sách các ID của hàng được chọn
            List<string> selectedIds = new List<string>();
            foreach (DataGridViewRow row in dataGridViewTemp_UserList.SelectedRows)
            {
                string id = row.Cells["id"].Value.ToString();
                selectedIds.Add(id);
            }

            // Thực hiện thêm thông tin user vào bảng chính và xóa khỏi bảng tạm thời
            using (SqlConnection connection = new SqlConnection(stringcon))
            {
                connection.Open();

                int successCount = 0;

                foreach (string userId in selectedIds)
                {
                    // Thêm thông tin user vào bảng chính
                    SqlCommand selectCommand = new SqlCommand("SELECT * FROM Temp_Log_in WHERE ID = @id", connection);
                    selectCommand.Parameters.AddWithValue("@id", userId);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Thêm thông tin user vào bảng chính
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO Log_in (ID, role, username, password, email) VALUES (@Id, @role, @username, @password, @email)", connection);
                        insertCommand.Parameters.AddWithValue("@Id", reader["ID"].ToString());
                        insertCommand.Parameters.AddWithValue("@role", reader["role"].ToString());
                        insertCommand.Parameters.AddWithValue("@username", reader["username"].ToString());
                        insertCommand.Parameters.AddWithValue("@password", reader["password"].ToString());
                        insertCommand.Parameters.AddWithValue("@email", reader["email"].ToString());

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            successCount++;
                        }
                    }
                    reader.Close();

                    // Xóa thông tin user khỏi bảng tạm thời
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM Temp_Log_in WHERE ID = @id", connection);
                    deleteCommand.Parameters.AddWithValue("@id", userId);

                    int rowsDeleted = deleteCommand.ExecuteNonQuery();

                    if (rowsDeleted == 0)
                    {
                        MessageBox.Show("An Error Occurred While Deleting The User From The Temporary Table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (successCount > 0)
                {
                    MessageBox.Show(successCount + " User(s) Have Been Added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An Error Occurred While Adding Users.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Refresh lại datagridview
            SqlCommand command = new SqlCommand("SELECT id AS [ID], role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Temp_Log_in");
            dataGridViewTemp_UserList.ReadOnly = true;
            dataGridViewTemp_UserList.DataSource = user.getUsers(command);
        }

        private void ButtonApproveAll_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable table = new DataTable();

            //SqlCommand selectCommand = new SqlCommand("SELECT * FROM Temp_Log_in", db.getConnection);

            //db.openConnection();
            //adapter.SelectCommand = selectCommand;

            //adapter.Fill(table);

            db.openConnection();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Temp_Log_in");

            DataTable table = user.getUsers(selectCommand);
            string Id;
            string role;
            string username;
            string password;
            string email;

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Id = table.Rows[i].Field<string>("Id").ToString();
                    role = table.Rows[i].Field<string>("role").ToString();
                    username = table.Rows[i].Field<string>("username");
                    password = table.Rows[i].Field<string>("password");
                    email = table.Rows[i].Field<string>("email");

                    SqlCommand InsertCommand = new SqlCommand("INSERT INTO Log_in (ID, role, username, password, email) VALUES (@Id, @role, @username, @password, @email)", db.getConnection);

                    InsertCommand.Parameters.AddWithValue("@Id", Id);
                    InsertCommand.Parameters.AddWithValue("@role", role);
                    InsertCommand.Parameters.AddWithValue("@username", username);
                    InsertCommand.Parameters.AddWithValue("@password", password);
                    InsertCommand.Parameters.AddWithValue("@email", email);

                    InsertCommand.ExecuteNonQuery();

                }

                MessageBox.Show("Approve All Users Successful!", "Approved All", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Any User To Approve!", "Approved All", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SqlCommand deleteCommand = new SqlCommand("DELETE FROM Temp_Log_in", db.getConnection);
            deleteCommand.ExecuteNonQuery();

            // Refresh lại datagridview
            SqlCommand command = new SqlCommand("SELECT id AS [ID], role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Temp_Log_in");
            dataGridViewTemp_UserList.ReadOnly = true;
            dataGridViewTemp_UserList.DataSource = user.getUsers(command);

            db.closeConnection();
        }

        private void ButtonReject_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có user được chọn hay không
            if (dataGridViewTemp_UserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select At Least One User To Reject!", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lặp qua từng hàng được chọn và xóa user
            foreach (DataGridViewRow row in dataGridViewTemp_UserList.SelectedRows)
            {
                string userId = row.Cells["id"].Value.ToString();

                // Xóa thông tin user khỏi bảng tạm thời
                using (SqlConnection connection = new SqlConnection(stringcon))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("DELETE FROM Temp_Log_in WHERE ID = @id", connection);

                    sqlCommand.Parameters.AddWithValue("@id", userId);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("An Error Occurred While Rejecting The User With ID " + userId + ".", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Hiển thị thông báo khi xóa hoàn tất
            MessageBox.Show("Selected Users Have Been Rejected!", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh lại datagridview
            SqlCommand command = new SqlCommand("SELECT id AS [ID], role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Temp_Log_in");
            dataGridViewTemp_UserList.ReadOnly = true;
            dataGridViewTemp_UserList.DataSource = user.getUsers(command);
        }

        private void ButtonRejectAll_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            SqlCommand deleteCommand = new SqlCommand("DELETE FROM Temp_Log_in", db.getConnection);

            db.openConnection();

            if (deleteCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("All Users has been rejected!", "Rejected All", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Any User To Reject!", "Rejected All", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (deleteCommand.ExecuteNonQuery() == -1)
            {
                MessageBox.Show("An Error Occurred While Rejecting All User!", "Rejected All", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Refresh lại datagridview
            SqlCommand command = new SqlCommand("SELECT id AS [ID], role AS [Role], username AS [User Name], password AS [Password], email AS [Email] FROM Temp_Log_in");
            dataGridViewTemp_UserList.ReadOnly = true;
            dataGridViewTemp_UserList.DataSource = user.getUsers(command);

            db.closeConnection();
        }
    }
}
