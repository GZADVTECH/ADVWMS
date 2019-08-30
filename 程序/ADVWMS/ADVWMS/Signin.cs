using ADVWMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADVWMS
{
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.BackColor = Color.White;
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            //this.BackgroundImage = Resources.ADV;
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();//关闭所有应用窗体
        }

        private void CloseForm_MouseEnter(object sender, EventArgs e)
        {
            CloseForm.Image = Resources.onclose;
        }

        private void CloseForm_MouseLeave(object sender, EventArgs e)
        {
            CloseForm.Image = Resources.close;
        }
        /// <summary>
        /// 默认加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Signin_Load(object sender, EventArgs e)
        {
            CloseForm.Image = Resources.close;
        }
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }


        #region 美化操作
        private void Signin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) bLogin_Click(sender, e);
        }
        private void tUid_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if(tb.Text== "请输入账号" || tb.Text== "请输入密码")
            tb.Text = string.Empty;
            tb.ForeColor = SystemColors.WindowText;
        }
        private void tUid_Leave(object sender, EventArgs e)
        {
            if (tUid.Text.Trim() == string.Empty)
            {
                tUid.ForeColor = SystemColors.ScrollBar;
                tUid.Text = "请输入账号";
            }
        }
        private void tPwd_Leave(object sender, EventArgs e)
        {
            if (tPwd.Text.Trim() == string.Empty)
            {
                tPwd.ForeColor = SystemColors.ScrollBar;
                tPwd.Text = "请输入密码";
            }
        }
        private void bLogin_MouseEnter(object sender, EventArgs e)
        {
            bLogin.ForeColor = SystemColors.WindowText;
        }

        private void bLogin_MouseLeave(object sender, EventArgs e)
        {
            bLogin.ForeColor = Color.White;
        }
        private void bRegion_Leave(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            Font f = new Font("幼圆", 9);
            l.Font = f;
        }

        private void bRegion_MouseEnter(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            Font f = new Font("幼圆", 9, FontStyle.Bold);
            l.Font = f;
        }
        #endregion

    }
}
