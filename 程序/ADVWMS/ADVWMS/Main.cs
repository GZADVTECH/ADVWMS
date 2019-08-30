using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ADVWMS
{
    public partial class Main : Form
    {
        Thread thread;
        private short time = 0;
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.tslLevel.Text = "级别：" + (string.IsNullOrEmpty(UserInfo.Level) ? "无" : UserInfo.Level);
            this.tslName.Text = "姓名：" + (string.IsNullOrEmpty(UserInfo.Name) ? "访客" : UserInfo.Name);
            this.tslPosition.Text = "职位：" + (string.IsNullOrEmpty(UserInfo.Position) ? "无" : UserInfo.Position);
            this.tslState.Text = "状态：" + ((UserInfo.State == false) ? "无效" : "有效");
        }
        /// <summary>
        /// 用户信息类
        /// </summary>
        private class UserInfo
        {
            /// <summary>
            /// 用户账号
            /// </summary>
            public static string AccountNumber { get; set; }
            /// <summary>
            /// 用户级别
            /// </summary>
            public static string Level { get; set; }
            /// <summary>
            /// 用户职位
            /// </summary>
            public static string Position { get; set; }
            /// <summary>
            /// 用户部门
            /// </summary>
            public static string Department { get; set; }
            /// <summary>
            /// 用户状态
            /// </summary>
            public static bool State { get; set; }
            /// <summary>
            /// 用户姓名
            /// </summary>
            public static string Name { get; set; }
        }
        
        #region 美化修饰
        private void pbMinus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        private void pbClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出ADV-WMS系统？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Application.Exit();
        }
        private void pbMise_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                pbMise.Image = Properties.Resources.maximise;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                pbMise.Image = Properties.Resources.minimise;
            }
            //pMain.Controls["home"].Size = pMain.Size;
        }
        #endregion
        
        private void pbCart_Click(object sender, EventArgs e)
        {
        }
        
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
