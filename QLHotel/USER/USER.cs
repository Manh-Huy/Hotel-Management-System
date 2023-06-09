using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20142178_20110370_Nhom15_QLHotel
{
    internal class USER
    {
        MY_DB mydb = new MY_DB();
        public DataTable getUsers(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteUser(string ID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Log_in WHERE ID = @ID", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))

            {
                mydb.closeConnection();
                return true;
            }

            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool CheckUserName(string role,string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Log_in where username = @uname AND role = @role", mydb.getConnection);
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;

            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                mydb.closeConnection();
                return false;
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }
        public bool CheckID(string ID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Log_in where ID = @ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;

            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                mydb.closeConnection();
                return false;
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }
        public bool insertTempUser(string Id, string role, string username, string password, string email)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Temp_Log_in (ID, role, username, password, email)" + " VALUES(@id, @role, @uname, @pass, @email)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = Id;
            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.NVarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))

            {
                mydb.closeConnection();
                return true;
            }

            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
