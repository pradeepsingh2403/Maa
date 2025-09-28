using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maa
{
    public static class GlobalFunctions
    {
        // SQL Server connection string example
        public static string ConnString = "Server=PRADEEPLP-DEVEL\\PRADEEP;Database=donations;User Id=sa;Password=Cashpor@123;Trusted_Connection=False;";
        public static int userId = 0;
        public static string userName = string.Empty;
        public static int role = 1;

        public static RolePermission GetRolePermission(int roleId, string formName)
        {
            RolePermission permission = new RolePermission(); // Custom class to store permissions

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"
                                    SELECT rp.can_save, rp.can_update, rp.can_delete, rp.can_view, rp.can_export
                                    FROM role_permissions rp
                                    INNER JOIN modules m ON rp.module_id = m.id
                                    WHERE rp.role_id = @roleId AND m.form_name = @formName";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@roleId", roleId);
                        cmd.Parameters.AddWithValue("@formName", formName);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                permission.CanSave = Convert.ToBoolean(reader["can_save"]);
                                permission.CanUpdate = Convert.ToBoolean(reader["can_update"]);
                                permission.CanDelete = Convert.ToBoolean(reader["can_delete"]);
                                permission.CanView = Convert.ToBoolean(reader["can_view"]);
                                permission.CanExport = Convert.ToBoolean(reader["can_export"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching permissions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return permission;
        }

    }
}
