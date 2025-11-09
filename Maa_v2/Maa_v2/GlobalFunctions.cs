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
        public static string ConnString = @"Server=(LocalDB)\MSSQLLocalDB;Database=donations;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=60;";
        public static string LiveAPIURL = @"https://vocindia.in/api/";
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
                    string sql = @"SELECT rp.can_save,rp.can_update,rp.can_delete,rp.can_view,rp.can_export,m.form_name,rp.module_id,	rp.role_id FROM role_permissions rp
                                    INNER JOIN modules m  ON rp.module_id = m.id

WHERE 
    rp.role_id = @roleId
    AND LOWER(REPLACE(REPLACE(REPLACE(REPLACE(LTRIM(RTRIM(m.form_name)), CHAR(13), ''), CHAR(10), ''), CHAR(9), ''), CHAR(160), ''))
        = LOWER(@formName)";

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
