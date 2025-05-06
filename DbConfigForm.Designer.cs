namespace ExcelImporter
{
    partial class DbConfigForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblServer = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            this.lblServer.Text = "Servidor:";
            this.lblServer.Location = new System.Drawing.Point(12, 15);
            this.lblServer.Size = new System.Drawing.Size(80, 23);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(100, 12);
            this.txtServer.Size = new System.Drawing.Size(200, 23);
            // 
            // lblUser
            // 
            this.lblUser.Text = "Usuário:";
            this.lblUser.Location = new System.Drawing.Point(12, 50);
            this.lblUser.Size = new System.Drawing.Size(80, 23);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(100, 47);
            this.txtUser.Size = new System.Drawing.Size(200, 23);
            // 
            // lblPassword
            // 
            this.lblPassword.Text = "Senha:";
            this.lblPassword.Location = new System.Drawing.Point(12, 85);
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(100, 82);
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.PasswordChar = '*';
            // 
            // lblDatabase
            // 
            this.lblDatabase.Text = "Banco:";
            this.lblDatabase.Location = new System.Drawing.Point(12, 120);
            this.lblDatabase.Size = new System.Drawing.Size(80, 23);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(100, 117);
            this.txtDatabase.Size = new System.Drawing.Size(200, 23);
            // 
            // btnSave
            // 
            this.btnSave.Text = "Salvar";
            this.btnSave.Location = new System.Drawing.Point(100, 160);
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new System.Drawing.Point(210, 160);
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // DbConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(320, 210);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurar Banco de Dados";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
