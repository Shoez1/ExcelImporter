using System;
using System.Windows.Forms;

namespace ExcelImporter
{
    public partial class DbConfigForm : Form
    {
        public DbConfigForm()
        {
            InitializeComponent();
            LoadConfig();
            btnSave.Click += btnSave_Click;
        }

        private void LoadConfig()
        {
            try
            {
                var connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;
                if (!string.IsNullOrEmpty(connStr))
                {
                    var builder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder(connStr);
                    txtServer.Text = builder.Server;
                    txtUser.Text = builder.UserID;
                    txtPassword.Text = builder.Password;
                    txtDatabase.Text = builder.Database;
                }
            }
            catch { }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            var builder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
            builder.Server = txtServer.Text.Trim();
            builder.UserID = txtUser.Text.Trim();
            builder.Password = txtPassword.Text.Trim();
            builder.Database = txtDatabase.Text.Trim();

            // Salvar no App.config
            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            var section = (System.Configuration.ConnectionStringsSection)config.GetSection("connectionStrings");
            section.ConnectionStrings["MySqlConn"].ConnectionString = builder.ConnectionString;
            config.Save();
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
            MessageBox.Show("Configuração salva com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
