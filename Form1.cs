using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExcelImporter
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Button btnExportAllTables;


        private DataTable? currentData = null;

        public Form1()
        {
            InitializeComponent();
            UpdateDbInfo();
            LoadTables();
            // Adiciona handler caso não esteja no designer
            if (btnConfig != null)
                btnConfig.Click += btnConfig_Click;
        }

        private void UpdateDbInfo()
        {
            try
            {
                var connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;
                if (!string.IsNullOrEmpty(connStr))
                {
                    var builder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder(connStr);
                    bool conectado = false;
                    using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                    {
                        try
                        {
                            conn.Open();
                            conectado = true;
                        }
                        catch
                        {
                            conectado = false;
                        }
                    }
                    lblDbInfo.Text = $"Banco: {builder.Database} (Servidor: {builder.Server})" + (conectado ? " - CONECTADO" : " - NÃO CONECTADO");
                    lblDbInfo.ForeColor = conectado ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                }
                else
                {
                    lblDbInfo.Text = "Banco: ---";
                    lblDbInfo.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch { lblDbInfo.Text = "Banco: ---"; lblDbInfo.ForeColor = System.Drawing.Color.Red; }
        }

        private void LoadTables()
        {
            try
            {
                var dt = DbHelper.GetTables();
                cmbTables.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string? tableName = row["TABLE_NAME"]?.ToString();
                    if (!string.IsNullOrEmpty(tableName))
                        cmbTables.Items.Add(tableName);
                }
                if (cmbTables.Items.Count > 0)
                    cmbTables.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tabelas: " + ex.Message);
            }
        }

        private void btnLoadTable_Click(object? sender, EventArgs e)
        {
            if (cmbTables.SelectedItem == null || string.IsNullOrWhiteSpace(cmbTables.SelectedItem.ToString()))
                return;
            string table = cmbTables.SelectedItem.ToString()!;
            try
            {
                currentData = DbHelper.GetTableData(table);
                dataGridView1.DataSource = currentData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            if (currentData == null)
            {
                MessageBox.Show("Carregue uma tabela primeiro!");
                return;
            }
            using var sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = $"{cmbTables.SelectedItem ?? "Tabela"}.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExcelHelper.WriteDataTableToExcel(currentData, sfd.FileName);
                MessageBox.Show("Exportação concluída!");
            }
        }

        private void btnImportExcel_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtExcelPath.Text = ofd.FileName;
                currentData = ExcelHelper.ReadExcelToDataTable(ofd.FileName);
                dataGridView1.DataSource = currentData;
            }
        }

        private void btnSaveToDb_Click(object? sender, EventArgs e)
        {
            if (currentData == null)
            {
                MessageBox.Show("Importe um arquivo Excel primeiro!");
                return;
            }
            if (cmbTables.SelectedItem == null || string.IsNullOrWhiteSpace(cmbTables.SelectedItem.ToString()))
            {
                MessageBox.Show("Selecione a tabela de destino!");
                return;
            }
            string table = cmbTables.SelectedItem.ToString()!;
            try
            {
                DbHelper.BulkInsert(table, currentData);
                MessageBox.Show("Importação concluída!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar: " + ex.Message);
            }
        }
        private void btnExportAllTables_Click(object? sender, EventArgs e)
        {
            try
            {
                var connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"]?.ConnectionString;
                if (string.IsNullOrEmpty(connStr))
                {
                    MessageBox.Show("Configuração do banco não encontrada.");
                    return;
                }
                var builder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder(connStr);
                string dbName = builder.Database;
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                {
                    conn.Open();
                    var tableCmd = new MySql.Data.MySqlClient.MySqlCommand($"SHOW TABLES", conn);
                    using (var reader = tableCmd.ExecuteReader())
                    {
                        var tableNames = new List<string>();
                        while (reader.Read())
                            tableNames.Add(reader.GetString(0));
                        reader.Close();
                        if (tableNames.Count == 0)
                        {
                            MessageBox.Show("Nenhuma tabela encontrada no banco.");
                            return;
                        }
                        using (var fbd = new FolderBrowserDialog())
                        {
                            fbd.Description = "Escolha a pasta onde será criada a pasta do banco com os arquivos Excel.";
                            if (fbd.ShowDialog() == DialogResult.OK)
                            {
                                string targetDir = System.IO.Path.Combine(fbd.SelectedPath, dbName);
                                System.IO.Directory.CreateDirectory(targetDir);
                                // Cria ProgressBar temporário
                                ProgressBar progressBar = new ProgressBar();
                                progressBar.Minimum = 0;
                                progressBar.Maximum = tableNames.Count;
                                progressBar.Value = 0;
                                progressBar.Width = 400;
                                progressBar.Style = ProgressBarStyle.Continuous;
                                Form progressForm = new Form();
                                progressForm.Text = "Exportando tabelas...";
                                progressForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                                progressForm.MaximizeBox = false;
                                progressForm.MinimizeBox = false;
                                progressForm.StartPosition = FormStartPosition.CenterScreen;
                                progressForm.ClientSize = new System.Drawing.Size(420, 90);
                                Label lbl = new Label();
                                lbl.Text = "Exportando 0/" + tableNames.Count;
                                lbl.AutoSize = true;
                                lbl.Location = new System.Drawing.Point(10, 10);
                                progressBar.Location = new System.Drawing.Point(10, 35);
                                progressForm.Controls.Add(lbl);
                                progressForm.Controls.Add(progressBar);
                                progressForm.Show();
                                progressForm.Refresh();
                                int count = 0;
                                foreach (var table in tableNames)
                                {
                                    var dt = DbHelper.GetTableData(table);
                                    string filePath = System.IO.Path.Combine(targetDir, table + ".xlsx");
                                    ExcelHelper.WriteDataTableToExcel(dt, filePath);
                                    count++;
                                    progressBar.Value = count;
                                    lbl.Text = $"Exportando {count}/{tableNames.Count}: {table}";
                                    progressForm.Refresh();
                                }
                                progressForm.Close();
                                MessageBox.Show($"Exportação concluída! {tableNames.Count} tabelas exportadas em {targetDir}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar todas as tabelas: " + ex.Message);
            }
        }

        private void btnConfig_Click(object? sender, EventArgs e)
        {
            using (var configForm = new DbConfigForm())
            {
                if (configForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateDbInfo();
                    LoadTables();
                }
                else
                {
                    UpdateDbInfo(); // Mesmo se cancelar, pode ter mudado config
                }
            }
        }
    }
}
