namespace Ortoped_Store
{
    partial class ConectionForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btCancel = new System.Windows.Forms.Button();
            this.btConect = new System.Windows.Forms.Button();
            this.btCheck = new System.Windows.Forms.Button();
            this.cbInitialCatalog = new System.Windows.Forms.ComboBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.statusConect = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblServers = new System.Windows.Forms.Label();
            this.cbDataSource = new System.Windows.Forms.ComboBox();
            this.statusConect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.BorderSize = 4;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.Location = new System.Drawing.Point(455, 394);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(196, 66);
            this.btCancel.TabIndex = 23;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btConect
            // 
            this.btConect.Enabled = false;
            this.btConect.FlatAppearance.BorderSize = 4;
            this.btConect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConect.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btConect.Location = new System.Drawing.Point(235, 394);
            this.btConect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btConect.Name = "btConect";
            this.btConect.Size = new System.Drawing.Size(196, 66);
            this.btConect.TabIndex = 22;
            this.btConect.Text = "Подключить";
            this.btConect.UseVisualStyleBackColor = true;
            this.btConect.Click += new System.EventHandler(this.btConect_Click);
            // 
            // btCheck
            // 
            this.btCheck.Enabled = false;
            this.btCheck.FlatAppearance.BorderSize = 4;
            this.btCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheck.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCheck.Location = new System.Drawing.Point(13, 394);
            this.btCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(196, 66);
            this.btCheck.TabIndex = 21;
            this.btCheck.Text = "Проверка";
            this.btCheck.UseVisualStyleBackColor = true;
            this.btCheck.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // cbInitialCatalog
            // 
            this.cbInitialCatalog.Enabled = false;
            this.cbInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbInitialCatalog.FormattingEnabled = true;
            this.cbInitialCatalog.Location = new System.Drawing.Point(18, 301);
            this.cbInitialCatalog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbInitialCatalog.Name = "cbInitialCatalog";
            this.cbInitialCatalog.Size = new System.Drawing.Size(633, 37);
            this.cbInitialCatalog.TabIndex = 20;
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDataSource.Location = new System.Drawing.Point(13, 262);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(270, 25);
            this.lblDataSource.TabIndex = 19;
            this.lblDataSource.Text = "Список источников данных:";
            // 
            // tbPassword
            // 
            this.tbPassword.Enabled = false;
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPassword.Location = new System.Drawing.Point(13, 205);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(638, 35);
            this.tbPassword.TabIndex = 18;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPassword.Location = new System.Drawing.Point(8, 175);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(223, 25);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Пароль пользователя:";
            // 
            // tbUserID
            // 
            this.tbUserID.Enabled = false;
            this.tbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUserID.Location = new System.Drawing.Point(13, 121);
            this.tbUserID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(638, 35);
            this.tbUserID.TabIndex = 16;
            // 
            // statusConect
            // 
            this.statusConect.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusConect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusConect.Location = new System.Drawing.Point(0, 475);
            this.statusConect.Name = "statusConect";
            this.statusConect.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusConect.Size = new System.Drawing.Size(664, 22);
            this.statusConect.TabIndex = 15;
            this.statusConect.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(19, 25);
            this.tsslStatus.Text = "-";
            this.tsslStatus.Visible = false;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUsers.Location = new System.Drawing.Point(8, 91);
            this.lblUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(231, 25);
            this.lblUsers.TabIndex = 14;
            this.lblUsers.Text = "Пользователь сервера:";
            // 
            // lblServers
            // 
            this.lblServers.AutoSize = true;
            this.lblServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblServers.Location = new System.Drawing.Point(8, 7);
            this.lblServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServers.Name = "lblServers";
            this.lblServers.Size = new System.Drawing.Size(174, 25);
            this.lblServers.TabIndex = 13;
            this.lblServers.Text = "Список серверов:";
            // 
            // cbDataSource
            // 
            this.cbDataSource.Enabled = false;
            this.cbDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDataSource.FormattingEnabled = true;
            this.cbDataSource.Location = new System.Drawing.Point(13, 37);
            this.cbDataSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDataSource.Name = "cbDataSource";
            this.cbDataSource.Size = new System.Drawing.Size(638, 37);
            this.cbDataSource.TabIndex = 12;
            // 
            // ConectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 497);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btConect);
            this.Controls.Add(this.btCheck);
            this.Controls.Add(this.cbInitialCatalog);
            this.Controls.Add(this.lblDataSource);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbUserID);
            this.Controls.Add(this.statusConect);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lblServers);
            this.Controls.Add(this.cbDataSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка подлючения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConectionForm_FormClosing);
            this.Load += new System.EventHandler(this.ConectionForm_Load);
            this.statusConect.ResumeLayout(false);
            this.statusConect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btConect;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.ComboBox cbInitialCatalog;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.StatusStrip statusConect;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblServers;
        private System.Windows.Forms.ComboBox cbDataSource;
    }
}

