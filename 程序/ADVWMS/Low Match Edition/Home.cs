using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace Low_Match_Edition
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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

        private void Home_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.tsbName.Text = "你好，" + (string.IsNullOrEmpty(UserInfo.Name) ? "尊敬的访客。" : UserInfo.Name + "。");
            this.tslDepartment.Text = "部门：" + (string.IsNullOrEmpty(UserInfo.Department) ? "无" : UserInfo.Department);
            this.tslLevel.Text = "级别：" + (string.IsNullOrEmpty(UserInfo.Level) ? "无" : UserInfo.Level);
            this.tslPosition.Text = "职位：" + (string.IsNullOrEmpty(UserInfo.Position) ? "无" : UserInfo.Position);
            this.tslDate.Text = "日期："+DateTime.Now.ToString("yyyy:MM:dd ddd");
            //read memorandum
            rtbMemorandum.Text=ServerUpDownDocuments.DownloadingFiles("Memorandum", UserInfo.AccountNumber);
            //read bulletin board
            rtbNotice.Text = ServerUpDownDocuments.DownloadingFiles("BulletinBoard");
            

        }

        private void lbMemorandum_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
            if (e.Index >= 0)
            {
                StringFormat sStringFormat = new StringFormat();
                sStringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, sStringFormat);
            }
            e.DrawFocusRectangle();
        }

        private void lbMemorandum_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = e.ItemHeight + 36;
        }
        /// <summary>
        /// save the data when leave rtbMemorandum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbMemorandum_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbMemorandum.Text)) return;
            ServerUpDownDocuments.UploadingFiles("Memorandum", UserInfo.AccountNumber, rtbMemorandum.Text);
        }

        private void rtbBulletinBoardMessage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbBulletinBoardMessage.Text)) return;
            bbbRelease_Click(sender, e);
        }

        private void bbbRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否发布？", "设置", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ServerUpDownDocuments.UploadingFiles("BulletinBoard", rtbBulletinBoardMessage.Text))
                    MessageBox.Show("发布成功！");
                else
                    MessageBox.Show("发布失败！");
            }
        }
    }
}
