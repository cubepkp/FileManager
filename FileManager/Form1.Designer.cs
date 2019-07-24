namespace FileManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disconnectButton1 = new System.Windows.Forms.Button();
            this.connectButton1 = new System.Windows.Forms.Button();
            this.userPasswordTB1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userNameTB1 = new System.Windows.Forms.TextBox();
            this.serverAdressTB1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.disconnectButton2 = new System.Windows.Forms.Button();
            this.connectButton2 = new System.Windows.Forms.Button();
            this.userPasswordTB2 = new System.Windows.Forms.TextBox();
            this.isServer = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userNameTB2 = new System.Windows.Forms.TextBox();
            this.serverAdressTB2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.driversCB = new System.Windows.Forms.ComboBox();
            this.fileWindow1 = new System.Windows.Forms.ListBox();
            this.fileWindow2 = new System.Windows.Forms.ListBox();
            this.renameButton1 = new System.Windows.Forms.Button();
            this.deleteButton1 = new System.Windows.Forms.Button();
            this.pasteButton1 = new System.Windows.Forms.Button();
            this.copyButton1 = new System.Windows.Forms.Button();
            this.pasteButton2 = new System.Windows.Forms.Button();
            this.copyButton2 = new System.Windows.Forms.Button();
            this.deleteButton2 = new System.Windows.Forms.Button();
            this.renameButton2 = new System.Windows.Forms.Button();
            this.sourceTB1 = new System.Windows.Forms.TextBox();
            this.sourceTB2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.disconnectButton1);
            this.groupBox1.Controls.Add(this.connectButton1);
            this.groupBox1.Controls.Add(this.userPasswordTB1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.userNameTB1);
            this.groupBox1.Controls.Add(this.serverAdressTB1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serwer FTP 1";
            // 
            // disconnectButton1
            // 
            this.disconnectButton1.Enabled = false;
            this.disconnectButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.disconnectButton1.Location = new System.Drawing.Point(373, 26);
            this.disconnectButton1.Name = "disconnectButton1";
            this.disconnectButton1.Size = new System.Drawing.Size(91, 24);
            this.disconnectButton1.TabIndex = 7;
            this.disconnectButton1.Text = "Rozłącz";
            this.disconnectButton1.UseVisualStyleBackColor = true;
            this.disconnectButton1.Click += new System.EventHandler(this.disconnectButton1_Click);
            // 
            // connectButton1
            // 
            this.connectButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectButton1.Location = new System.Drawing.Point(269, 26);
            this.connectButton1.Name = "connectButton1";
            this.connectButton1.Size = new System.Drawing.Size(91, 24);
            this.connectButton1.TabIndex = 6;
            this.connectButton1.Text = "Połącz";
            this.connectButton1.UseVisualStyleBackColor = true;
            this.connectButton1.Click += new System.EventHandler(this.connectButton1_Click);
            // 
            // userPasswordTB1
            // 
            this.userPasswordTB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userPasswordTB1.Location = new System.Drawing.Point(319, 62);
            this.userPasswordTB1.Name = "userPasswordTB1";
            this.userPasswordTB1.PasswordChar = '*';
            this.userPasswordTB1.Size = new System.Drawing.Size(145, 24);
            this.userPasswordTB1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(266, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hasło:";
            // 
            // userNameTB1
            // 
            this.userNameTB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameTB1.Location = new System.Drawing.Point(110, 62);
            this.userNameTB1.Name = "userNameTB1";
            this.userNameTB1.Size = new System.Drawing.Size(145, 24);
            this.userNameTB1.TabIndex = 3;
            // 
            // serverAdressTB1
            // 
            this.serverAdressTB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serverAdressTB1.Location = new System.Drawing.Point(110, 26);
            this.serverAdressTB1.Name = "serverAdressTB1";
            this.serverAdressTB1.Size = new System.Drawing.Size(145, 24);
            this.serverAdressTB1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Użytkownik:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adres serwera";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.disconnectButton2);
            this.groupBox2.Controls.Add(this.connectButton2);
            this.groupBox2.Controls.Add(this.userPasswordTB2);
            this.groupBox2.Controls.Add(this.isServer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.userNameTB2);
            this.groupBox2.Controls.Add(this.serverAdressTB2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(526, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serwer FTP 2";
            // 
            // disconnectButton2
            // 
            this.disconnectButton2.Enabled = false;
            this.disconnectButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.disconnectButton2.Location = new System.Drawing.Point(373, 25);
            this.disconnectButton2.Name = "disconnectButton2";
            this.disconnectButton2.Size = new System.Drawing.Size(91, 24);
            this.disconnectButton2.TabIndex = 15;
            this.disconnectButton2.Text = "Rozłącz";
            this.disconnectButton2.UseVisualStyleBackColor = true;
            this.disconnectButton2.Click += new System.EventHandler(this.disconnectButton2_Click);
            // 
            // connectButton2
            // 
            this.connectButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectButton2.Location = new System.Drawing.Point(269, 25);
            this.connectButton2.Name = "connectButton2";
            this.connectButton2.Size = new System.Drawing.Size(91, 24);
            this.connectButton2.TabIndex = 14;
            this.connectButton2.Text = "Połącz";
            this.connectButton2.UseVisualStyleBackColor = true;
            this.connectButton2.Click += new System.EventHandler(this.connectButton2_Click);
            // 
            // userPasswordTB2
            // 
            this.userPasswordTB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userPasswordTB2.Location = new System.Drawing.Point(319, 61);
            this.userPasswordTB2.Name = "userPasswordTB2";
            this.userPasswordTB2.PasswordChar = '*';
            this.userPasswordTB2.Size = new System.Drawing.Size(145, 24);
            this.userPasswordTB2.TabIndex = 13;
            // 
            // isServer
            // 
            this.isServer.AutoSize = true;
            this.isServer.Location = new System.Drawing.Point(78, 0);
            this.isServer.Name = "isServer";
            this.isServer.Size = new System.Drawing.Size(15, 14);
            this.isServer.TabIndex = 16;
            this.isServer.UseVisualStyleBackColor = true;
            this.isServer.CheckedChanged += new System.EventHandler(this.isServer_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(266, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hasło:";
            // 
            // userNameTB2
            // 
            this.userNameTB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameTB2.Location = new System.Drawing.Point(110, 61);
            this.userNameTB2.Name = "userNameTB2";
            this.userNameTB2.Size = new System.Drawing.Size(145, 24);
            this.userNameTB2.TabIndex = 11;
            // 
            // serverAdressTB2
            // 
            this.serverAdressTB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serverAdressTB2.Location = new System.Drawing.Point(110, 25);
            this.serverAdressTB2.Name = "serverAdressTB2";
            this.serverAdressTB2.Size = new System.Drawing.Size(145, 24);
            this.serverAdressTB2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Użytkownik:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Adres serwera";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.driversCB);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 110);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serwer FTP 2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(80, 1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.isServer_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(7, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Dysk lokalny";
            // 
            // driversCB
            // 
            this.driversCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driversCB.FormattingEnabled = true;
            this.driversCB.Location = new System.Drawing.Point(105, 22);
            this.driversCB.Name = "driversCB";
            this.driversCB.Size = new System.Drawing.Size(222, 26);
            this.driversCB.TabIndex = 17;
            this.driversCB.SelectionChangeCommitted += new System.EventHandler(this.driversCB_SelectionChangeCommitted);
            // 
            // fileWindow1
            // 
            this.fileWindow1.Font = new System.Drawing.Font("Meiryo UI", 11F);
            this.fileWindow1.FormattingEnabled = true;
            this.fileWindow1.ItemHeight = 19;
            this.fileWindow1.Location = new System.Drawing.Point(12, 163);
            this.fileWindow1.Name = "fileWindow1";
            this.fileWindow1.Size = new System.Drawing.Size(470, 327);
            this.fileWindow1.TabIndex = 2;
            this.fileWindow1.DoubleClick += new System.EventHandler(this.fileWindow1_DoubleClick);
            // 
            // fileWindow2
            // 
            this.fileWindow2.Font = new System.Drawing.Font("Meiryo UI", 11F);
            this.fileWindow2.FormattingEnabled = true;
            this.fileWindow2.ItemHeight = 19;
            this.fileWindow2.Location = new System.Drawing.Point(520, 163);
            this.fileWindow2.Name = "fileWindow2";
            this.fileWindow2.Size = new System.Drawing.Size(470, 327);
            this.fileWindow2.TabIndex = 3;
            this.fileWindow2.DoubleClick += new System.EventHandler(this.fileWindow2_DoubleClick);
            // 
            // renameButton1
            // 
            this.renameButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.renameButton1.Location = new System.Drawing.Point(249, 525);
            this.renameButton1.Name = "renameButton1";
            this.renameButton1.Size = new System.Drawing.Size(102, 24);
            this.renameButton1.TabIndex = 9;
            this.renameButton1.Text = "Zmień nazwę";
            this.renameButton1.UseVisualStyleBackColor = true;
            this.renameButton1.Click += new System.EventHandler(this.renameButton1_Click);
            // 
            // deleteButton1
            // 
            this.deleteButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteButton1.Location = new System.Drawing.Point(357, 525);
            this.deleteButton1.Name = "deleteButton1";
            this.deleteButton1.Size = new System.Drawing.Size(102, 24);
            this.deleteButton1.TabIndex = 10;
            this.deleteButton1.Text = "Usuń";
            this.deleteButton1.UseVisualStyleBackColor = true;
            this.deleteButton1.Click += new System.EventHandler(this.deleteButton1_Click);
            // 
            // pasteButton1
            // 
            this.pasteButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pasteButton1.Location = new System.Drawing.Point(143, 525);
            this.pasteButton1.Name = "pasteButton1";
            this.pasteButton1.Size = new System.Drawing.Size(102, 24);
            this.pasteButton1.TabIndex = 12;
            this.pasteButton1.Text = "Wklej";
            this.pasteButton1.UseVisualStyleBackColor = true;
            this.pasteButton1.Click += new System.EventHandler(this.pasteButton1_Click);
            // 
            // copyButton1
            // 
            this.copyButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.copyButton1.Location = new System.Drawing.Point(35, 525);
            this.copyButton1.Name = "copyButton1";
            this.copyButton1.Size = new System.Drawing.Size(102, 24);
            this.copyButton1.TabIndex = 11;
            this.copyButton1.Text = "Kopiuj";
            this.copyButton1.UseVisualStyleBackColor = true;
            this.copyButton1.Click += new System.EventHandler(this.copyButton1_Click);
            // 
            // pasteButton2
            // 
            this.pasteButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pasteButton2.Location = new System.Drawing.Point(651, 525);
            this.pasteButton2.Name = "pasteButton2";
            this.pasteButton2.Size = new System.Drawing.Size(102, 24);
            this.pasteButton2.TabIndex = 16;
            this.pasteButton2.Text = "Wklej";
            this.pasteButton2.UseVisualStyleBackColor = true;
            this.pasteButton2.Click += new System.EventHandler(this.pasteButton2_Click);
            // 
            // copyButton2
            // 
            this.copyButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.copyButton2.Location = new System.Drawing.Point(543, 525);
            this.copyButton2.Name = "copyButton2";
            this.copyButton2.Size = new System.Drawing.Size(102, 24);
            this.copyButton2.TabIndex = 15;
            this.copyButton2.Text = "Kopiuj";
            this.copyButton2.UseVisualStyleBackColor = true;
            this.copyButton2.Click += new System.EventHandler(this.copyButton2_Click);
            // 
            // deleteButton2
            // 
            this.deleteButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteButton2.Location = new System.Drawing.Point(865, 525);
            this.deleteButton2.Name = "deleteButton2";
            this.deleteButton2.Size = new System.Drawing.Size(102, 24);
            this.deleteButton2.TabIndex = 14;
            this.deleteButton2.Text = "Usuń";
            this.deleteButton2.UseVisualStyleBackColor = true;
            this.deleteButton2.Click += new System.EventHandler(this.deleteButton2_Click);
            // 
            // renameButton2
            // 
            this.renameButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.renameButton2.Location = new System.Drawing.Point(757, 525);
            this.renameButton2.Name = "renameButton2";
            this.renameButton2.Size = new System.Drawing.Size(102, 24);
            this.renameButton2.TabIndex = 13;
            this.renameButton2.Text = "Zmień nazwę";
            this.renameButton2.UseVisualStyleBackColor = true;
            this.renameButton2.Click += new System.EventHandler(this.renameButton2_Click);
            // 
            // sourceTB1
            // 
            this.sourceTB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sourceTB1.Location = new System.Drawing.Point(12, 128);
            this.sourceTB1.Name = "sourceTB1";
            this.sourceTB1.ReadOnly = true;
            this.sourceTB1.Size = new System.Drawing.Size(470, 24);
            this.sourceTB1.TabIndex = 17;
            // 
            // sourceTB2
            // 
            this.sourceTB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sourceTB2.Location = new System.Drawing.Point(520, 128);
            this.sourceTB2.Name = "sourceTB2";
            this.sourceTB2.ReadOnly = true;
            this.sourceTB2.Size = new System.Drawing.Size(470, 24);
            this.sourceTB2.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.sourceTB2);
            this.Controls.Add(this.sourceTB1);
            this.Controls.Add(this.pasteButton2);
            this.Controls.Add(this.copyButton2);
            this.Controls.Add(this.deleteButton2);
            this.Controls.Add(this.renameButton2);
            this.Controls.Add(this.pasteButton1);
            this.Controls.Add(this.copyButton1);
            this.Controls.Add(this.deleteButton1);
            this.Controls.Add(this.renameButton1);
            this.Controls.Add(this.fileWindow2);
            this.Controls.Add(this.fileWindow1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FTP File Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button disconnectButton1;
        private System.Windows.Forms.Button connectButton1;
        private System.Windows.Forms.TextBox userPasswordTB1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userNameTB1;
        private System.Windows.Forms.TextBox serverAdressTB1;
        private System.Windows.Forms.Button disconnectButton2;
        private System.Windows.Forms.Button connectButton2;
        private System.Windows.Forms.TextBox userPasswordTB2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userNameTB2;
        private System.Windows.Forms.TextBox serverAdressTB2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox fileWindow1;
        private System.Windows.Forms.ListBox fileWindow2;
        private System.Windows.Forms.Button renameButton1;
        private System.Windows.Forms.Button deleteButton1;
        private System.Windows.Forms.Button pasteButton1;
        private System.Windows.Forms.Button copyButton1;
        private System.Windows.Forms.Button pasteButton2;
        private System.Windows.Forms.Button copyButton2;
        private System.Windows.Forms.Button deleteButton2;
        private System.Windows.Forms.Button renameButton2;
        private System.Windows.Forms.TextBox sourceTB1;
        private System.Windows.Forms.TextBox sourceTB2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox isServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox driversCB;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

