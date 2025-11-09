using Maa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maa_v2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ Check database connection and admin data
            if (IsDatabaseConnected())
            {
                if (HasAdminData())
                {
                    // If admin data exists, go to Login page
                    Application.Run(new frmLogin());
                }
                else
                {
                    // No admin data, go to Install page
                    Application.Run(new frmInstall());
                }
            }
            else
            {
                Application.Run(new frmInstall());
            }
        }

        private static bool IsDatabaseConnected()
        {
            try
            {
                using (var con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();
                    return true; // Connection successful
                }
            }
            catch (SqlException ex)
            {
                // Optional: Log exception
                Console.WriteLine("Database connection error: " + ex.Message);
                return false; // Connection failed
            }
            catch (Exception ex)
            {
                // Optional: Log any other exception
                Console.WriteLine("Unexpected error: " + ex.Message);
                return false; // Treat as failed connection
            }
        }


        private static bool HasAdminData()
        {
            try
            {
                using (var con = new SqlConnection(GlobalFunctions.ConnString))
                {
                    con.Open();
                    string sql = "SELECT TOP 2 * FROM admins"; // Get only top 2
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows; // True if at least one row exists
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }

}
