namespace ExcelImporter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSaveToDb;
        private System.Windows.Forms.Button btnLoadTable;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Label lblExcel;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label lblDbInfo;
        private System.Windows.Forms.Panel panelStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.btnLoadTable = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.lblExcel = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.lblDbInfo = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.Location = new System.Drawing.Point(450, 60);
            this.cmbTables.Size = new System.Drawing.Size(200, 32);
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.Location = new System.Drawing.Point(12, 60);
            this.btnLoadTable.Size = new System.Drawing.Size(130, 36);
            this.btnLoadTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoadTable.Text = "Carregar Tabela";
            this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(120, 60);
            this.btnExportExcel.Size = new System.Drawing.Size(150, 36);
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportExcel.Text = "Exportar p/ Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(230, 60);
            this.btnImportExcel.Size = new System.Drawing.Size(150, 36);
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImportExcel.Text = "Importar do Excel";
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Location = new System.Drawing.Point(340, 60);
            this.btnSaveToDb.Size = new System.Drawing.Size(150, 36);
            this.btnSaveToDb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveToDb.Text = "Salvar no Banco";
            this.btnSaveToDb.Click += new System.EventHandler(this.btnSaveToDb_Click);
            // 
            // lblExcel
            // 
            this.lblExcel.Location = new System.Drawing.Point(12, 58);
            this.lblExcel.Size = new System.Drawing.Size(110, 20);
            this.lblExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExcel.Text = "Arquivo Excel:";
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(130, 55);
            this.txtExcelPath.Size = new System.Drawing.Size(700, 27);
            this.txtExcelPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtExcelPath.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Size = new System.Drawing.Size(820, 400);
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(950, 510);
            // lblDbInfo
            // 
            // panelStatus
            // 
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelStatus.Location = new System.Drawing.Point(0, 0);
            this.panelStatus.Size = new System.Drawing.Size(950, 38);
            this.panelStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelStatus.Controls.Add(this.lblDbInfo);

            // lblDbInfo
            // 
            this.lblDbInfo.Location = new System.Drawing.Point(10, 6);
            this.lblDbInfo.Size = new System.Drawing.Size(930, 28);
            this.lblDbInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDbInfo.Text = "Banco: ---";

            this.Controls.Add(this.panelStatus);

            // Botões centralizados em linha
            int btnCount = 6;
            int btnWidth = 140;
            int btnHeight = 38;
            int btnSpacing = 18;
            int totalWidth = btnCount * btnWidth + (btnCount - 1) * btnSpacing;
            int btnTop = 50;
            int btnStartX = (950 - totalWidth) / 2;
            // btnLoadTable
            this.btnLoadTable.Location = new System.Drawing.Point(btnStartX, btnTop);
            this.btnLoadTable.Size = new System.Drawing.Size(btnWidth, btnHeight);
            // btnExportExcel
            this.btnExportExcel.Location = new System.Drawing.Point(btnStartX + (btnWidth + btnSpacing) * 1, btnTop);
            this.btnExportExcel.Size = new System.Drawing.Size(btnWidth, btnHeight);
            // btnExportAllTables
            this.btnExportAllTables = new System.Windows.Forms.Button();
            this.btnExportAllTables.Location = new System.Drawing.Point(btnStartX + (btnWidth + btnSpacing) * 2, btnTop);
            this.btnExportAllTables.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnExportAllTables.Text = "Exportar Todas";
            this.btnExportAllTables.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportAllTables.UseVisualStyleBackColor = true;
            this.btnExportAllTables.Click += new System.EventHandler(this.btnExportAllTables_Click);
            // btnImportExcel
            this.btnImportExcel.Location = new System.Drawing.Point(btnStartX + (btnWidth + btnSpacing) * 3, btnTop);
            this.btnImportExcel.Size = new System.Drawing.Size(btnWidth, btnHeight);
            // btnSaveToDb
            this.btnSaveToDb.Location = new System.Drawing.Point(btnStartX + (btnWidth + btnSpacing) * 4, btnTop);
            this.btnSaveToDb.Size = new System.Drawing.Size(btnWidth, btnHeight);
            // btnConfig
            this.btnConfig.Location = new System.Drawing.Point(btnStartX + (btnWidth + btnSpacing) * 5, btnTop);
            this.btnConfig.Size = new System.Drawing.Size(btnWidth, btnHeight);
            // Ajuste de altura dos botões
            this.btnLoadTable.Font = this.btnExportExcel.Font = this.btnImportExcel.Font = this.btnSaveToDb.Font = this.btnConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Controls.Add(this.btnExportAllTables);
            // Ajuste de altura dos botões
            this.btnLoadTable.Font = this.btnExportExcel.Font = this.btnImportExcel.Font = this.btnSaveToDb.Font = this.btnConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // ComboBox de tabelas centralizada abaixo dos botões
            this.cmbTables.Location = new System.Drawing.Point((950-300)/2, btnTop+btnHeight+15);
            this.cmbTables.Size = new System.Drawing.Size(300, 32);

            // Barra de arquivo (lblExcel + txtExcelPath) centralizada abaixo da ComboBox
            int fileBarY = btnTop+btnHeight+15+32+10;
            this.lblExcel.Location = new System.Drawing.Point((950-120-700)/2, fileBarY+3);
            this.lblExcel.Size = new System.Drawing.Size(110, 27);
            this.lblExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExcel.Text = "Arquivo Excel:";
            this.txtExcelPath.Location = new System.Drawing.Point((950-120-700)/2+120, fileBarY);
            this.txtExcelPath.Size = new System.Drawing.Size(700, 27);
            this.txtExcelPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtExcelPath.ReadOnly = true;

            // DataGridView ocupa o restante da área
            this.dataGridView1.Location = new System.Drawing.Point(12, fileBarY+37);
            this.dataGridView1.Size = new System.Drawing.Size(926, 340);

            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.btnLoadTable);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnSaveToDb);
            this.Controls.Add(this.lblExcel);
            this.Controls.Add(this.txtExcelPath);
            // btnConfig
            // 
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnConfig.Location = new System.Drawing.Point(840, 60);
            this.btnConfig.Size = new System.Drawing.Size(90, 36);
            this.btnConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);

            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.dataGridView1);
            this.Text = "Importador/Exportador Excel <-> MySQL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
