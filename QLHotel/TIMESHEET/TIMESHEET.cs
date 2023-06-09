using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace _20142178_20110370_Nhom15_QLHotel
{
    internal class TIMESHEET
    {
        MY_DB mydb = new MY_DB();
        public bool updateTimeSheet(string ID, string day, string shiftOne, string shiftTwo, string shiftThree, string shiftFour)
        {
            SqlCommand command = new SqlCommand("UPDATE TimeSheet SET [7h-15h] = @shiftOne, [15h-19h] = @shiftTwo, [19h-3h] = @shiftThree, [3h-7h] = @shiftFour WHERE ID = @ID AND day = @day", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@day", SqlDbType.NVarChar).Value = day;
            command.Parameters.Add("@shiftOne", SqlDbType.NVarChar).Value = shiftOne;
            command.Parameters.Add("@shiftTwo", SqlDbType.NVarChar).Value = shiftTwo;
            command.Parameters.Add("@shiftThree", SqlDbType.NVarChar).Value = shiftThree;
            command.Parameters.Add("@shiftFour", SqlDbType.NVarChar).Value = shiftFour;


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
        public bool insertSalary(string ID, string fullName, string day, string totalWorkTime, string totalShortageTime, float totalSalary, float totalPenalty)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Salary (ID, fullName, day, totalWorkTime, totalShortageTime, totalSalary, totalPenalty)" + " VALUES(@ID, @fullName, @day, @totalWorkTime, @totalShortageTime, @totalSalary, @totalPenalty)", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@day", SqlDbType.NVarChar).Value = day;
            command.Parameters.Add("@totalWorkTime", SqlDbType.NVarChar).Value = totalWorkTime;
            command.Parameters.Add("@totalShortageTime", SqlDbType.NVarChar).Value = totalShortageTime;
            command.Parameters.Add("@totalSalary", SqlDbType.Float).Value = totalSalary;
            command.Parameters.Add("@totalPenalty", SqlDbType.Float).Value = totalPenalty;
            
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

        public bool CheckAlreadyCalculateSalary(string ID, string day)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Salary WHERE ID = @ID AND day = @day ", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@day", SqlDbType.NVarChar).Value = day;
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
        public bool deleteSalary(string ID, string day)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Salary WHERE ID = @ID and day = @day", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@day", SqlDbType.NVarChar).Value = day;

            mydb.openConnection();

            if (command.ExecuteNonQuery() >= 1)
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
        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = command.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }
        public string totalSalary(string ID)
        {
            return execCount("SELECT SUM(totalSalary) FROM Salary WHERE ID = '" + ID + "'");
        }
        public string totalPenalty(string ID)
        {
            return execCount("SELECT SUM(totalPenalty) FROM Salary WHERE ID = '" + ID + "'");
        }
    }
}
