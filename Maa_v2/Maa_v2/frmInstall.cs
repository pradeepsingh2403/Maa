using Maa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maa_v2
{
    public partial class frmInstall : Form
    {
        public frmInstall()
        {
            InitializeComponent();
            // Center the button horizontally
            btnInstal.Left = (this.ClientSize.Width - btnInstal.Width) / 2;

            // Center the button vertically
            btnInstal.Top = (this.ClientSize.Height - btnInstal.Height) / 2;
            this.StartPosition = FormStartPosition.CenterScreen;
        }



        private void btnInstal_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseName = "donations";
                string masterConnStr = @"Server=(LocalDB)\MSSQLLocalDB;Database=master;Integrated Security=True;";
                string databaseConnStr = $@"Server=(LocalDB)\MSSQLLocalDB;Database={databaseName};Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=60;";

                // 1. Check if database exists, create if not
                using (var conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        $"IF DB_ID('{databaseName}') IS NULL CREATE DATABASE [{databaseName}]", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }


                string[] commands = sqlScript.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                using (var conn = new SqlConnection(databaseConnStr))
                {
                    conn.Open();
                    foreach (string command in commands)
                    {
                        if (!string.IsNullOrWhiteSpace(command))
                        {
                            using (var cmd = new SqlCommand(command, conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }


                MessageBox.Show("Database installed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Move to Login Form
                this.Hide(); // Hide the installation form
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error installing database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string sqlScript = @"USE master;
IF DB_ID('donations') IS NULL
BEGIN
    CREATE DATABASE [donations];
END
GO

USE [donations1];
GO
CREATE TABLE dbo.admin_role(
    id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    admin_id BIGINT NOT NULL,
    role_id BIGINT NOT NULL
);
GO
CREATE TABLE dbo.admins(
    id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    image NVARCHAR(MAX) NULL,
    email NVARCHAR(255) NOT NULL,
    phone BIGINT NULL,
    password NVARCHAR(255) NULL,
    status BIT NOT NULL DEFAULT 1,
    role_id BIGINT NULL,
    remember_token NVARCHAR(100) NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE()
);
GO
CREATE TABLE dbo.donations(
    id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    payment_mode NVARCHAR(10) NOT NULL,
    payment_mode_details NVARCHAR(255) NULL,
    receipt_number NVARCHAR(255) NOT NULL,
    admin_id BIGINT NOT NULL,
    ritual_performing_date DATE NULL,
    ritual_performing_date2 DATE NULL,
    donor_name NVARCHAR(255) NOT NULL,
    in_favour NVARCHAR(255) NULL,
    mobile_number NVARCHAR(255) NOT NULL,
    whatsapp_number NVARCHAR(255) NULL,
    alternate_number NVARCHAR(255) NULL,
    area NVARCHAR(255) NULL,
    city NVARCHAR(255) NULL,
    gotra NVARCHAR(255) NULL,
    id_type NVARCHAR(255) NOT NULL,
    id_number NVARCHAR(255) NULL,
    scheme_name NVARCHAR(255) NULL,
    donation_amount DECIMAL(10,2) NOT NULL,
    full_address NVARCHAR(MAX) NULL,
    donation_date DATE NULL,
    tithi NVARCHAR(255) NULL,
    spl_date NVARCHAR(MAX) NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE(),
    IsDataSync BIT NULL DEFAULT 0
);
GO

CREATE TABLE dbo.modules(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    module_name NVARCHAR(100) NOT NULL,
    form_name NVARCHAR(100) NOT NULL,
    status INT NOT NULL,
    created_at DATE NOT NULL,
    updated_at DATE NOT NULL
);
GO

CREATE TABLE dbo.permission_role(
    id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    role_id BIGINT NOT NULL,
    permission_id BIGINT NOT NULL
);
GO

CREATE TABLE dbo.permissions(
    id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(191) NOT NULL,
    slug NVARCHAR(191) NOT NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE()
);
GO

CREATE TABLE dbo.role_permissions(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    role_id INT NOT NULL,
    module_id INT NOT NULL,
    can_save BIT NULL,
    can_update BIT NULL,
    can_delete BIT NULL,
    can_view BIT NULL,
    can_export BIT NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);
GO

CREATE TABLE dbo.roles(
    id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(121) NOT NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE()
);
GO

CREATE TABLE dbo.schemes(
    id BIGINT NOT NULL PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    status TINYINT NOT NULL DEFAULT 1,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);
GO
CREATE TABLE dbo.status(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    status NVARCHAR(50) NULL
);
GO
ALTER TABLE dbo.admin_role ADD CONSTRAINT FK_admin_role_admin FOREIGN KEY(admin_id) REFERENCES dbo.admins(id);
ALTER TABLE dbo.admin_role ADD CONSTRAINT FK_admin_role_role FOREIGN KEY(role_id) REFERENCES dbo.roles(id);
ALTER TABLE dbo.donations ADD CONSTRAINT FK_donations_admin FOREIGN KEY(admin_id) REFERENCES dbo.admins(id);
ALTER TABLE dbo.permission_role ADD CONSTRAINT FK_permission_role_permission FOREIGN KEY(permission_id) REFERENCES dbo.permissions(id);
ALTER TABLE dbo.permission_role ADD CONSTRAINT FK_permission_role_role FOREIGN KEY(role_id) REFERENCES dbo.roles(id);
GO
ALTER TABLE dbo.donations ADD CONSTRAINT CK_donations_payment_mode CHECK (payment_mode IN ('Cheque','Online','Cash'));
GO
INSERT INTO [dbo].[admins]
           ([name],[image],[email],[phone],[password],[status],[role_id],[remember_token],[created_at],[updated_at])
     VALUES
           ('SAMCT','photo.jpg','admin@gmail.com','98851110722','123456',1,1,null,GETDATE(),GETDATE())
GO
INSERT INTO [dbo].[roles]([name],[created_at],[updated_at])
     VALUES('admin',GETDATE(),GETDATE()),('Editor',GETDATE(),GETDATE()),('user',GETDATE(),GETDATE())
GO
INSERT INTO [dbo].[modules]
           ([module_name], [form_name], [status], [created_at], [updated_at])
VALUES
           ('dashboard', 'frmDashboard', 1, '2025-10-23', '2025-10-23'),
           ('Add Role', 'frmRole', 1, '2025-10-23', '2025-10-23'),
           ('Add Users', 'frmUsers', 1, '2025-10-23', '2025-10-23'),
           ('Role Permission', 'frmRolePermission', 1, '2025-10-23', '2025-10-23'),
           ('Add Scheme', 'frmAddScheme', 1, '2025-10-23', '2025-10-23'),
           ('Add Donation', 'frmAddDonationForm', 1, '2025-10-23', '2025-10-23'),
           ('Donation List', 'frmDonationList', 1, '2025-10-23', '2025-10-23');
GO
INSERT INTO [dbo].[role_permissions]
           ([role_id], [module_id], [can_save], [can_update], [can_delete], [can_view], [can_export], [created_at], [updated_at])
VALUES
           (1, 1, 1, 1, 1, 0, 0, '1900-01-01 09:56:00.100', '1900-01-01 09:56:00.100'),
           (1, 2, 1, 1, 1, 1, 1, '1900-01-01 09:56:00.100', '1900-01-01 09:56:00.100'),
           (1, 3, 1, 0, 1, 1, 1, '1900-01-01 09:56:00.100', '1900-01-01 09:56:00.100'),
           (1, 4, 1, 1, 1, 1, 1, '1900-01-01 09:56:00.100', '1900-01-01 09:56:00.100'),
           (1, 5, 0, 0, 0, 0, 0, '1900-01-01 09:56:00.100', '1900-01-01 09:56:00.100'),
           (1, 6, 1, 1, 1, 1, 1, '1900-01-01 09:56:00.100', '1900-01-01 09:56:00.100'),
           (1, 7, 0, 0, 0, 0, 0, '1900-01-01 09:56:00.100', '1900-01-01 09:56:00.100');
GO
INSERT INTO [dbo].[status]([status])
     VALUES('Non-Active'),('Active')
GO

";

    }
}
