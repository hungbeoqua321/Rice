namespace Rice
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.TenDangNhap = new System.Windows.Forms.TextBox();
            this.MatKhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Submit_Login = new System.Windows.Forms.Button();
            this.Not_Blank_TenDangNhap = new System.Windows.Forms.Label();
            this.Not_Blank_MatKhau = new System.Windows.Forms.Label();
            this.Check_Text = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(142, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP";
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TenDangNhap.Location = new System.Drawing.Point(224, 266);
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Size = new System.Drawing.Size(267, 36);
            this.TenDangNhap.TabIndex = 1;
            // 
            // MatKhau
            // 
            this.MatKhau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.MatKhau.Location = new System.Drawing.Point(224, 373);
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Size = new System.Drawing.Size(267, 36);
            this.MatKhau.TabIndex = 2;
            this.MatKhau.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(43, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên đăng nhập :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(43, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu :";
            // 
            // Submit_Login
            // 
            this.Submit_Login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Submit_Login.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Submit_Login.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Submit_Login.ForeColor = System.Drawing.Color.Khaki;
            this.Submit_Login.Location = new System.Drawing.Point(206, 482);
            this.Submit_Login.Name = "Submit_Login";
            this.Submit_Login.Size = new System.Drawing.Size(228, 70);
            this.Submit_Login.TabIndex = 5;
            this.Submit_Login.Text = "Đăng nhập";
            this.Submit_Login.UseVisualStyleBackColor = false;
            this.Submit_Login.Click += new System.EventHandler(this.Submit_Login_Click);
            // 
            // Not_Blank_TenDangNhap
            // 
            this.Not_Blank_TenDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Not_Blank_TenDangNhap.AutoSize = true;
            this.Not_Blank_TenDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.Not_Blank_TenDangNhap.ForeColor = System.Drawing.Color.Red;
            this.Not_Blank_TenDangNhap.Location = new System.Drawing.Point(222, 314);
            this.Not_Blank_TenDangNhap.Name = "Not_Blank_TenDangNhap";
            this.Not_Blank_TenDangNhap.Size = new System.Drawing.Size(133, 16);
            this.Not_Blank_TenDangNhap.TabIndex = 7;
            this.Not_Blank_TenDangNhap.Text = "Không được để trống!";
            this.Not_Blank_TenDangNhap.Visible = false;
            // 
            // Not_Blank_MatKhau
            // 
            this.Not_Blank_MatKhau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Not_Blank_MatKhau.AutoSize = true;
            this.Not_Blank_MatKhau.BackColor = System.Drawing.Color.Transparent;
            this.Not_Blank_MatKhau.ForeColor = System.Drawing.Color.Red;
            this.Not_Blank_MatKhau.Location = new System.Drawing.Point(222, 421);
            this.Not_Blank_MatKhau.Name = "Not_Blank_MatKhau";
            this.Not_Blank_MatKhau.Size = new System.Drawing.Size(133, 16);
            this.Not_Blank_MatKhau.TabIndex = 8;
            this.Not_Blank_MatKhau.Text = "Không được để trống!";
            this.Not_Blank_MatKhau.Visible = false;
            // 
            // Check_Text
            // 
            this.Check_Text.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Check_Text.AutoSize = true;
            this.Check_Text.BackColor = System.Drawing.Color.Transparent;
            this.Check_Text.ForeColor = System.Drawing.Color.Red;
            this.Check_Text.Location = new System.Drawing.Point(212, 569);
            this.Check_Text.Name = "Check_Text";
            this.Check_Text.Size = new System.Drawing.Size(181, 16);
            this.Check_Text.TabIndex = 9;
            this.Check_Text.Text = "Tài khoản hoặc mật khẩu sai!";
            this.Check_Text.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(616, 729);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.Check_Text);
            this.panel1.Controls.Add(this.Not_Blank_MatKhau);
            this.panel1.Controls.Add(this.Not_Blank_TenDangNhap);
            this.panel1.Controls.Add(this.Submit_Login);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MatKhau);
            this.panel1.Controls.Add(this.TenDangNhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(615, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 729);
            this.panel1.TabIndex = 11;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1177, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quán cơm nhà làm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TenDangNhap;
        private System.Windows.Forms.TextBox MatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Submit_Login;
        private System.Windows.Forms.Label Not_Blank_TenDangNhap;
        private System.Windows.Forms.Label Not_Blank_MatKhau;
        private System.Windows.Forms.Label Check_Text;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
    }
}