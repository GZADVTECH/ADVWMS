using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADVWMS
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }
        public Home(string nameMsg="")
        {
            InitializeComponent();
            this.lName.Text = string.IsNullOrEmpty(nameMsg)?"你好，尊敬的访客。":"你好，"+nameMsg+"。";
        }
        #region 窗体美化
        private void pbCart_MouseEnter(object sender, EventArgs e)
        {
            pbCart.Image = Properties.Resources.thecart;
        }

        private void pbCart_MouseLeave(object sender, EventArgs e)
        {
            pbCart.Image = Properties.Resources.cart;
        }

        private void pbBasket_MouseEnter(object sender, EventArgs e)
        {
            pbBasket.Image = Properties.Resources.thebasket;
        }

        private void pbBasket_MouseLeave(object sender, EventArgs e)
        {
            pbBasket.Image = Properties.Resources.basket;
        }

        private void pbChart_MouseEnter(object sender, EventArgs e)
        {
            pbChart.Image = Properties.Resources.thechart;
        }

        private void pbChart_MouseLeave(object sender, EventArgs e)
        {
            pbChart.Image = Properties.Resources.chart;
        }

        private void pbBag_MouseEnter(object sender, EventArgs e)
        {
            pbBag.Image = Properties.Resources.thebag;
        }

        private void pbBag_MouseLeave(object sender, EventArgs e)
        {
            pbBag.Image = Properties.Resources.bag;
        }

        private void pbControls_MouseEnter(object sender, EventArgs e)
        {
            pbControls.Image = Properties.Resources.thecontrols;
        }

        private void pbControls_MouseLeave(object sender, EventArgs e)
        {
            pbControls.Image = Properties.Resources.controls;
        }

        private void pbSettings_MouseEnter(object sender, EventArgs e)
        {
            pbSettings.Image = Properties.Resources.thesettings;
        }

        private void pbSettings_MouseLeave(object sender, EventArgs e)
        {
            pbSettings.Image = Properties.Resources.settings;
        }
        #endregion
    }
}
