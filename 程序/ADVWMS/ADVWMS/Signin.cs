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
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
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
            ADVForm.Image = Resources.ADV;
            CloseForm.Image = Resources.close;
        }
    }
}
