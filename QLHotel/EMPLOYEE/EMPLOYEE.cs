using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20142178_20110370_Nhom15_QLHotel
{
    internal class EMPLOYEE
    {
        MY_DB mydb = new MY_DB();
        public DataTable getEmployees(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool insertEmployee(string ID, string fname, string lname, string role, DateTime bdate, string gender, string phone, string email, string address, string hometown,  MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Employee (ID, fname, lname, role, bdate, gender, phone, email, address, hometown, picture)" + " VALUES(@ID, @fname, @lname, @role, @bdate, @gender, @phone, @email, @address, @hometown, @picture)", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
            command.Parameters.Add("@bdate", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@hometown", SqlDbType.NVarChar).Value = hometown;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

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
        public bool updateEmployee(string ID, string fname, string lname, string role, DateTime bdate, string gender, string phone, string email, string address, string hometown, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Employee SET ID = @ID, fname = @fname, lname = @lname, role = @role, bdate = @bdate, gender = @gender, phone = @phone, email = @email, address = @address, hometown = @hometown, picture = @picture WHERE ID = @ID", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
            command.Parameters.Add("@bdate", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@hometown", SqlDbType.NVarChar).Value = hometown;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

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
        public bool deleteEmployee(string ID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Employee WHERE ID = @ID", mydb.getConnection);

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
    }
}
