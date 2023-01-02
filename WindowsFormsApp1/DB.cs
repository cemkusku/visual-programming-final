using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WindowsFormsApp1
{
    class DB
    {
        private static MySqlConnection sqlConnection;

        private DB() 
        {
        }
        public static MySqlConnection baglanti() 
        {
            if (sqlConnection == null)
            {
                sqlConnection = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=tasımacılık");
                sqlConnection.Open();
            }

            return sqlConnection;
        }
        public static void kapat() 
        {
            if (sqlConnection != null) 
            {
                sqlConnection.Close();
            }
        }
    }
}
