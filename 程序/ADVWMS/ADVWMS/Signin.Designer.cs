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
            this.bLogin = new System.Windows.Forms.Label();
            this.bRegion = new System.Windows.Forms.Label();
            this.bFormat = new System.Windows.Forms.Label();
            this.tUid = new System.Windows.Forms.TextBox();
            this.tPwd = new System.Windows.Forms.TextBox();
            this.CloseForm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CloseForm)).BeginInit();
            this.SuspendLayout();
            // 
            // bLogin
            // 
            this.bLogin.BackColor = System.Drawing.Color.Transparent;
            this.bLogin.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogin.ForeColor = System.Drawing.Color.White;
            this.bLogin.Location = new System.Drawing.Point(85, 350);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(194, 22);
            this.bLogin.TabIndex = 3;
            this.bLogin.Text = "L o g i n  i n";
            this.bLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            this.bLogin.MouseEnter += new System.EventHandler(this.bLogin_MouseEnter);
            this.bLogin.MouseLeave += new System.EventHandler(this.bLogin_MouseLeave);
            // 
            // bRegion
            // 
            this.bRegion.AutoSize = true;
            this.bRegion.BackColor = System.Drawing.Color.Transparent;
            this.bRegion.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRegion.ForeColor = System.Drawing.Color.Navy;
            this.bRegion.Location = new System.Drawing.Point(65, 375);
            this.bRegion.Name = "bRegion";
            this.bRegion.Size = new System.Drawing.Size(35, 12);
            this.bRegion.TabIndex = 4;
            this.bRegion.Text = "注册!";
            this.bRegion.MouseEnter += new System.EventHandler(this.bRegion_MouseEnter);
            this.bRegion.MouseLeave += new System.EventHandler(this.bRegion_Leave);
            // 
            // bFormat
            // 
            this.bFormat.AutoSize = true;
            this.bFormat.BackColor = System.Drawing.Color.Transparent;
            this.bFormat.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bFormat.ForeColor = System.Drawing.Color.Navy;
            this.bFormat.Location = new System.Drawing.Point(263, 375);
            this.bFormat.Name = "bFormat";
            this.bFormat.Size = new System.Drawing.Size(41, 12);
            this.bFormat.TabIndex = 5;
            this.bFormat.Text = "忘记？";
            this.bFormat.MouseEnter += new System.EventHandler(this.bRegion_MouseEnter);
            this.bFormat.MouseLeave += new System.EventHandler(this.bRegion_Leave);
            // 
            // tUid
            // 
            this.tUid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tUid.Font = new System.Drawing.Font("Bradley Hand ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUid.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tUid.Location = new System.Drawing.Point(106, 157);
            this.tUid.MaxLength = 20;
            this.tUid.Name = "tUid";
            this.tUid.Size = new System.Drawing.Size(188, 25);
            this.tUid.TabIndex = 1;
            this.tUid.Text = "请输入账号";
            this.tUid.Enter += new System.EventHandler(this.tUid_Enter);
            this.tUid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Signin_KeyPress);
            this.tUid.Leave += new System.EventHandler(this.tUid_Leave);
            // 
            // tPwd
            // 
            this.tPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tPwd.Font = new System.Drawing.Font("Bradley Hand ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPwd.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tPwd.Location = new System.Drawing.Point(106, 210);
            this.tPwd.MaxLength = 20;
            this.tPwd.Name = "tPwd";
            this.tPwd.Size = new System.Drawing.Size(188, 25);
            this.tPwd.TabIndex = 2;
            this.tPwd.Text = "请输入密码";
            this.tPwd.Enter += new System.EventHandler(this.tUid_Enter);
            this.tPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Signin_KeyPress);
            this.tPwd.Leave += new System.EventHandler(this.tPwd_Leave);
            // 
            // CloseForm
            // 
            this.CloseForm.BackColor = System.Drawing.Color.Transparent;
            this.CloseForm.Location = new System.Drawing.Point(312, 12);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 27);
            this.CloseForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CloseForm.TabIndex = 0;
            this.CloseForm.TabStop = false;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            this.CloseForm.MouseEnter += new System.EventHandler(this.CloseForm_MouseEnter);
            this.CloseForm.MouseLeave += new System.EventHandler(this.CloseForm_MouseLeave);
            // 
            // Signin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ADVWMS.Properties.Resources.Main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(354, 403);
            this.Controls.Add(this.tPwd);
            this.Controls.Add(this.tUid);
            this.Controls.Add(this.bFormat);
            this.Controls.Add(this.bRegion);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.CloseForm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Signin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADV-WMS";
            this.Load += new System.EventHandler(this.Signin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Signin_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.CloseForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CloseForm;
        private System.Windows.Forms.Label bLogin;
        private System.Windows.Forms.Label bRegion;
        private System.Windows.Forms.Label bFormat;
        private System.Windows.Forms.TextBox tUid;
        private System.Windows.Forms.TextBox tPwd;
    }
}

