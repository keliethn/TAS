namespace TAS
{
    partial class Startup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            this.salesman_username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.InternetStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StationStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GameInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlaceInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GameDateTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.usr_lbl = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SalesmenListBinding = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesmenListBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // salesman_username
            // 
            this.salesman_username.AutoSize = true;
            this.salesman_username.Location = new System.Drawing.Point(0, 0);
            this.salesman_username.Name = "salesman_username";
            this.salesman_username.Size = new System.Drawing.Size(0, 17);
            this.salesman_username.TabIndex = 0;
            this.salesman_username.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione usuario";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InternetStatusLabel,
            this.StationStatusLabel,
            this.GameInfoLabel,
            this.PlaceInfoLabel,
            this.GameDateTimeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // InternetStatusLabel
            // 
            this.InternetStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternetStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.InternetStatusLabel.Name = "InternetStatusLabel";
            this.InternetStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // StationStatusLabel
            // 
            this.StationStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StationStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StationStatusLabel.Name = "StationStatusLabel";
            this.StationStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameInfoLabel.ForeColor = System.Drawing.Color.Blue;
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // PlaceInfoLabel
            // 
            this.PlaceInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaceInfoLabel.Name = "PlaceInfoLabel";
            this.PlaceInfoLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // GameDateTimeLabel
            // 
            this.GameDateTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameDateTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.GameDateTimeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GameDateTimeLabel.Name = "GameDateTimeLabel";
            this.GameDateTimeLabel.Size = new System.Drawing.Size(0, 17);
            this.GameDateTimeLabel.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.usr_lbl);
            this.loginPanel.Controls.Add(this.button11);
            this.loginPanel.Controls.Add(this.button10);
            this.loginPanel.Controls.Add(this.txt_pwd);
            this.loginPanel.Controls.Add(this.btn_clear);
            this.loginPanel.Controls.Add(this.button0);
            this.loginPanel.Controls.Add(this.button9);
            this.loginPanel.Controls.Add(this.button8);
            this.loginPanel.Controls.Add(this.salesman_username);
            this.loginPanel.Controls.Add(this.button7);
            this.loginPanel.Controls.Add(this.button6);
            this.loginPanel.Controls.Add(this.button5);
            this.loginPanel.Controls.Add(this.button4);
            this.loginPanel.Controls.Add(this.button3);
            this.loginPanel.Controls.Add(this.button2);
            this.loginPanel.Controls.Add(this.button1);
            this.loginPanel.Location = new System.Drawing.Point(565, 25);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(381, 457);
            this.loginPanel.TabIndex = 7;
            // 
            // usr_lbl
            // 
            this.usr_lbl.AutoSize = true;
            this.usr_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_lbl.Location = new System.Drawing.Point(9, 14);
            this.usr_lbl.Name = "usr_lbl";
            this.usr_lbl.Size = new System.Drawing.Size(0, 25);
            this.usr_lbl.TabIndex = 13;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(197, 364);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(85, 85);
            this.button11.TabIndex = 12;
            this.button11.Text = "<--";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button10.Location = new System.Drawing.Point(288, 273);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(85, 176);
            this.button10.TabIndex = 11;
            this.button10.Text = "ENTRAR";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // txt_pwd
            // 
            this.txt_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pwd.Location = new System.Drawing.Point(7, 45);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(366, 38);
            this.txt_pwd.TabIndex = 8;
            this.txt_pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_clear.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(288, 90);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(85, 177);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "C";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button0.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button0.Location = new System.Drawing.Point(9, 364);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(178, 85);
            this.button0.TabIndex = 9;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button9.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(197, 273);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(85, 85);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button8.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(102, 273);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(85, 85);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button7.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(9, 273);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 85);
            this.button7.TabIndex = 6;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button6.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(197, 182);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 85);
            this.button6.TabIndex = 5;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button5.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(102, 182);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 85);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(9, 182);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 85);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(197, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 85);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(102, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 85);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(9, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 149);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Red;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(15, 397);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(178, 85);
            this.button12.TabIndex = 10;
            this.button12.Text = "CERRAR";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Orange;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(362, 397);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(197, 85);
            this.button13.TabIndex = 11;
            this.button13.Text = "CONFIGURACION MANUAL";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(569, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Usuario selecionado:";
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(958, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup";
            this.Load += new System.EventHandler(this.Startup_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesmenListBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label salesman_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StationStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel GameInfoLabel;
        private System.Windows.Forms.ToolStripStatusLabel PlaceInfoLabel;
        private System.Windows.Forms.ToolStripStatusLabel GameDateTimeLabel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.ToolStripStatusLabel InternetStatusLabel;
        private System.Windows.Forms.BindingSource SalesmenListBinding;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label usr_lbl;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label1;
    }
}