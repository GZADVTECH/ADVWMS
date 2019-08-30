namespace ADVWMS
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pbMise = new System.Windows.Forms.PictureBox();
            this.pbMinus = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.statusView = new System.Windows.Forms.StatusStrip();
            this.tslName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslState = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbMise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.statusView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMise
            // 
            this.pbMise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMise.BackColor = System.Drawing.Color.Transparent;
            this.pbMise.Image = global::ADVWMS.Properties.Resources.minimise;
            this.pbMise.Location = new System.Drawing.Point(1101, 12);
            this.pbMise.Name = "pbMise";
            this.pbMise.Size = new System.Drawing.Size(41, 43);
            this.pbMise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMise.TabIndex = 0;
            this.pbMise.TabStop = false;
            this.pbMise.Click += new System.EventHandler(this.pbMise_Click);
            // 
            // pbMinus
            // 
            this.pbMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinus.BackColor = System.Drawing.Color.Transparent;
            this.pbMinus.Image = global::ADVWMS.Properties.Resources.minus;
            this.pbMinus.Location = new System.Drawing.Point(1054, 12);
            this.pbMinus.Name = "pbMinus";
            this.pbMinus.Size = new System.Drawing.Size(41, 43);
            this.pbMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMinus.TabIndex = 0;
            this.pbMinus.TabStop = false;
            this.pbMinus.Click += new System.EventHandler(this.pbMinus_Click);
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Image = global::ADVWMS.Properties.Resources.close;
            this.pbClose.Location = new System.Drawing.Point(1147, 12);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(41, 43);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 0;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // statusView
            // 
            this.statusView.BackColor = System.Drawing.Color.Transparent;
            this.statusView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslName,
            this.tslPosition,
            this.tslLevel,
            this.tslState});
            this.statusView.Location = new System.Drawing.Point(0, 650);
            this.statusView.Name = "statusView";
            this.statusView.Size = new System.Drawing.Size(1200, 30);
            this.statusView.TabIndex = 4;
            this.statusView.Text = "statusStrip1";
            // 
            // tslName
            // 
            this.tslName.Font = new System.Drawing.Font("Bradley Hand ITC", 15F, System.Drawing.FontStyle.Bold);
            this.tslName.Name = "tslName";
            this.tslName.Size = new System.Drawing.Size(117, 25);
            this.tslName.Text = "姓名：XXX";
            // 
            // tslPosition
            // 
            this.tslPosition.Font = new System.Drawing.Font("Bradley Hand ITC", 15F, System.Drawing.FontStyle.Bold);
            this.tslPosition.Name = "tslPosition";
            this.tslPosition.Size = new System.Drawing.Size(131, 25);
            this.tslPosition.Text = "职位：XXXX";
            // 
            // tslLevel
            // 
            this.tslLevel.Font = new System.Drawing.Font("Bradley Hand ITC", 15F, System.Drawing.FontStyle.Bold);
            this.tslLevel.Name = "tslLevel";
            this.tslLevel.Size = new System.Drawing.Size(103, 25);
            this.tslLevel.Text = "等级：XX";
            // 
            // tslState
            // 
            this.tslState.Font = new System.Drawing.Font("Bradley Hand ITC", 15F, System.Drawing.FontStyle.Bold);
            this.tslState.Name = "tslState";
            this.tslState.Size = new System.Drawing.Size(117, 25);
            this.tslState.Text = "状态：XXX";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 680);
            this.Controls.Add(this.statusView);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.pbMinus);
            this.Controls.Add(this.pbMise);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.statusView.ResumeLayout(false);
            this.statusView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMise;
        private System.Windows.Forms.PictureBox pbMinus;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.StatusStrip statusView;
        private System.Windows.Forms.ToolStripStatusLabel tslName;
        private System.Windows.Forms.ToolStripStatusLabel tslPosition;
        private System.Windows.Forms.ToolStripStatusLabel tslLevel;
        private System.Windows.Forms.ToolStripStatusLabel tslState;
    }
}