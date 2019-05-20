namespace ADVWMS
{
    partial class Signin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signin));
            this.CloseForm = new System.Windows.Forms.PictureBox();
            this.lAppName = new System.Windows.Forms.Label();
            this.ADVForm = new System.Windows.Forms.PictureBox();
            this.llForget = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lUid = new System.Windows.Forms.Label();
            this.lPwd = new System.Windows.Forms.Label();
            this.bLogin = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.CloseForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ADVForm)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseForm
            // 
            this.CloseForm.Location = new System.Drawing.Point(245, 2);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(16, 16);
            this.CloseForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CloseForm.TabIndex = 0;
            this.CloseForm.TabStop = false;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            this.CloseForm.MouseEnter += new System.EventHandler(this.CloseForm_MouseEnter);
            this.CloseForm.MouseLeave += new System.EventHandler(this.CloseForm_MouseLeave);
            // 
            // lAppName
            // 
            this.lAppName.AutoSize = true;
            this.lAppName.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.lAppName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lAppName.Location = new System.Drawing.Point(24, 5);
            this.lAppName.Name = "lAppName";
            this.lAppName.Size = new System.Drawing.Size(157, 14);
            this.lAppName.TabIndex = 1;
            this.lAppName.Text = "广州希创旺思管理系统";
            // 
            // ADVForm
            // 
            this.ADVForm.BackColor = System.Drawing.Color.Transparent;
            this.ADVForm.Location = new System.Drawing.Point(1, 2);
            this.ADVForm.Name = "ADVForm";
            this.ADVForm.Size = new System.Drawing.Size(20, 17);
            this.ADVForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ADVForm.TabIndex = 2;
            this.ADVForm.TabStop = false;
            // 
            // llForget
            // 
            this.llForget.AutoSize = true;
            this.llForget.Location = new System.Drawing.Point(187, 211);
            this.llForget.Name = "llForget";
            this.llForget.Size = new System.Drawing.Size(65, 12);
            this.llForget.TabIndex = 3;
            this.llForget.TabStop = true;
            this.llForget.Text = "忘记密码？";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 21);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(136, 21);
            this.textBox2.TabIndex = 4;
            // 
            // lUid
            // 
            this.lUid.AutoSize = true;
            this.lUid.Location = new System.Drawing.Point(39, 70);
            this.lUid.Name = "lUid";
            this.lUid.Size = new System.Drawing.Size(41, 12);
            this.lUid.TabIndex = 5;
            this.lUid.Text = "账号：";
            // 
            // lPwd
            // 
            this.lPwd.AutoSize = true;
            this.lPwd.Location = new System.Drawing.Point(39, 107);
            this.lPwd.Name = "lPwd";
            this.lPwd.Size = new System.Drawing.Size(41, 12);
            this.lPwd.TabIndex = 5;
            this.lPwd.Text = "密码：";
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(97, 146);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 6;
            this.bLogin.Text = "登录";
            this.bLogin.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(13, 210);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 12);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            // 
            // Signin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(264, 232);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.lPwd);
            this.Controls.Add(this.lUid);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.llForget);
            this.Controls.Add(this.ADVForm);
            this.Controls.Add(this.lAppName);
            this.Controls.Add(this.CloseForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Signin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADV-WMS";
            this.Load += new System.EventHandler(this.Signin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CloseForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ADVForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CloseForm;
        private System.Windows.Forms.Label lAppName;
        private System.Windows.Forms.PictureBox ADVForm;
        private System.Windows.Forms.LinkLabel llForget;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lUid;
        private System.Windows.Forms.Label lPwd;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

