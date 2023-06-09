using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20142178_20110370_Nhom15_QLHotel
{
    internal class MY_DB
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FEQAJ4I\SQLEXPRESS;Initial Catalog=QLHotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

        // get the connection
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        // open the connection
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }

        }

        // close the connection
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }

        }
    }
}
