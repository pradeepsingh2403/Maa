using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maa
{
    public static class GlobalFunctions
    {
        public static string ConnString = "Server=localhost;Port=3306;Database=donation;Uid=root;Pwd=;SslMode=none;";
        public static int roleId = 1; // This should be set when the user logs in
        public static string currentUser = "";
        public static RolePermission GetRolePermission(int roleId, string formName)
        {
            RolePermission permission = new RolePermission(); // Custom class to store permissions

            try
            {
                string connStr = GlobalFunctions.ConnString;
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = @"SELECT can_save, can_update, can_delete, can_view, can_export 
                           FROM role_permissions rp
                           INNER JOIN modules m ON rp.module_id = m.id
                           WHERE rp.role_id = @roleId AND m.form_name = @formName";

                    using (var cmd = new MySqlCommand(sql, con))
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
