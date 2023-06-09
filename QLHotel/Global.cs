using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20142178_20110370_Nhom15_QLHotel
{
    public static class Global
    {
        private static string globalUserID;
        public static string GlobalUserID { get => globalUserID; set => globalUserID = value; }

        public static void SetGlobalUserId(string userID)
        {
            GlobalUserID = userID;
        }
    }
}
