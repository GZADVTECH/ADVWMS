using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Low_Match_Edition
{
    public partial class MyBox : UserControl
    {
        public MyBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, false);
            Size = new Size(500, 60);
            Font = new Font("微软雅黑", 10);
        }
        /// <summary>
        /// 用户名。
        /// </summary>
        private string _username = "用户名";
        /// <summary>
        /// 消息日期时间。
        /// </summary>
        private DateTime _messagetime = DateTime.Now;
        /// <summary>
        /// 消息内容。
        /// </summary>
        private string _messagecontent = "消息内容";
        /// <summary>
        /// 每行消息数据的字节数。
        /// </summary>
        //private int _perlinebit = 68;
        /// <summary>
        /// 每行字符数。
        /// </summary>
        private int _perlinechar = 35;
        /// <summary>
        /// 消息内容的行高。
        /// </summary>
        private int _lineheight = 22;
        /// <summary>
        /// 背景图高。
        /// </summary>
        private int _iheight = 8;
        /// <summary>
        /// 背景图宽。
        /// </summary>
        private int _iwidth = 8;
        /// <summary>
        /// 消息类型。
        /// </summary>
        private MessageType _messagetype = MessageType.Receive;
        /// <summary>
        /// 获取或设置用户名。
        /// </summary>
        [Description("获取或设置用户名。")]
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                Invalidate(false);
            }
        }

        /// <summary>
        /// 获取或设置用户名。
        /// </summary>
        [Description("获取或设置信息时间。")]
        public DateTime MessageTime
        {
            get
            {
                return _messagetime;
            }
            set
            {
                _messagetime = value;
                Invalidate(false);
            }
        }

        /// <summary>
        /// 获取或设置消息内容。
        /// </summary>
        [Description("获取或设置消息内容。")]
        public string MessageContent
        {
            get
            {
                return _messagecontent;
            }
            set
            {
                _messagecontent = value;
                Invalidate(false);
            }
        }

        /// <summary>
        /// 获取或设置消息的类型。
        /// </summary>
        [Description("获取或设置消息的类型。")]
        public MessageType MType
        {
            get
            {
                return _messagetype;
            }
            set
            {
                _messagetype = value;
                Invalidate(false);
            }
        }
        /// <summary>
        /// 自定义绘制。
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Size = new Size(500, InitHeight());
            DrawBackColor(g);
            DrawBackGroundLine(g);
            DrawText(g);
            DrawLine(g);
            DrawMessageContent(g);
        }
        /// <summary>
        /// 绘制用户名和消息时间。
        /// </summary>
        private void DrawText(Graphics g)
        {
            Font f = new Font("微软雅黑", 10, FontStyle.Bold);
            g.DrawString(UserName + "  " + MessageTime.ToString("yyyy-MM-dd HH:mm:ss"), f, new SolidBrush(ForeColor), 8 + _iwidth, 2);
        }
        /// <summary>
        /// 绘制一条直线。
        /// </summary>
        private void DrawLine(Graphics g)
        {
            Color color = Color.Green;
            if (MType == MessageType.Receive)
                color = Color.Red;
            Pen p = new Pen(color);
            p.Width = 1;
            g.DrawLine(p, 4 + _iwidth, 22, Width - 8 - _iwidth, 22);
        }
        /// <summary>
        /// 绘制短信内容。
        /// </summary>
        private void DrawMessageContent(Graphics g)
        {
            int initheight = 22;
            int rowscount = MessageLineCount();
            string contents = MessageContent;
            string content = "";
            for (int i = 0; i < rowscount; i++)
            {
                if (contents.Length > _perlinechar)
                {
                    content = contents.Substring(0, _perlinechar);
                    contents = contents.Remove(0, _perlinechar);
                }
                else
                {
                    content = contents;
                }
                g.DrawString(content, Font, new SolidBrush(ForeColor), 4 + _iwidth, initheight + i * _lineheight);
            }
        }
        /// <summary>
        /// 绘制边框。
        /// </summary>
        private void DrawBackGroundLine(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            p.Width = 1;
            g.DrawArc(p, _iwidth, 0, _iwidth, _iheight, 180, 90);
            g.DrawLine(p, (int)(_iwidth * 1.5), 0, Width - (int)(_iwidth * 1.5), 0);
            g.DrawArc(p, Width - _iwidth * 2, 0, _iwidth, _iheight, 270, 90);
            if (MType == MessageType.Send)
            {
                g.DrawLine(p, Width - _iwidth, (int)(_iheight * 0.5), Width - _iwidth, (int)(_iheight * 1.5));
                g.DrawLine(p, Width - _iwidth, (int)(_iheight * 1.5), Width, _iheight * 2);
                g.DrawLine(p, Width - _iwidth, (int)(_iheight * 2.5), Width, _iheight * 2);
                g.DrawLine(p, Width - _iwidth, (int)(_iheight * 2.5), Width - _iwidth, Height - (int)(_iheight * 0.5));
            }
            else
            {
                g.DrawLine(p, Width - _iwidth, (int)(_iheight * 0.5), Width - _iwidth, Height - (int)(_iheight * 0.5));
            }
            g.DrawArc(p, Width - _iwidth * 2, Height - _iheight, _iwidth, _iheight, 0, 90);
            g.DrawLine(p, (int)(_iwidth * 1.5), Height, Width - (int)(_iwidth * 1.5), Height);
            g.DrawArc(p, _iwidth, Height - _iheight, _iwidth, _iheight, 90, 90);
            if (MType == MessageType.Receive)
            {
                g.DrawLine(p, _iwidth, (int)(_iheight * 0.5), _iwidth, (int)(_iheight * 1.5));
                g.DrawLine(p, 0, _iheight * 2, _iwidth, (int)(_iheight * 1.5));
                g.DrawLine(p, 0, _iheight * 2, _iwidth, (int)(_iheight * 2.5));
                g.DrawLine(p, _iwidth, (int)(_iheight * 2.5), _iwidth, Height - (int)(_iheight * 0.5));
            }
            else
            {
                g.DrawLine(p, _iwidth, (int)(_iheight * 0.5), _iwidth, Height - (int)(_iheight * 0.5));
            }
        }
        /// <summary>
        /// 绘制背景色。
        /// </summary>
        private void DrawBackColor(Graphics g)
        {
            Brush b = Brushes.YellowGreen;
            Point[] ps = new Point[3];
            if (MType == MessageType.Receive)
            {
                ps[0] = new Point(0, _iheight * 2);
                ps[1] = new Point(_iwidth, (int)(_iheight * 1.5));
                ps[2] = new Point(_iwidth, (int)(_iheight * 2.5));
            }
            else
            {
                b = Brushes.Goldenrod;
                ps[0] = new Point(Width - _iwidth, (int)(_iheight * 1.5));
                ps[1] = new Point(Width - _iwidth, (int)(_iheight * 2.5));
                ps[2] = new Point(Width, _iheight * 2);
            }
            g.FillEllipse(b, _iwidth, 0, _iwidth, _iheight);
            g.FillEllipse(b, Width - _iwidth * 2, 0, _iwidth, _iheight);
            g.FillEllipse(b, Width - _iwidth * 2, Height - _iheight, _iwidth, _iheight);
            g.FillEllipse(b, _iwidth, Height - _iheight, _iwidth, _iheight);
            g.FillRectangle(b, _iwidth, (int)(_iheight * 0.5), Width - _iwidth * 2, Height - _iheight);
            g.FillRectangle(b, (int)(_iwidth * 1.5), 0, Width - _iwidth * 3, (int)(_iheight * 0.5));
            g.FillRectangle(b, (int)(_iwidth * 1.5), Height - (int)(_iheight * 0.5), Width - _iwidth * 3, (int)(_iheight * 0.5));
            g.FillPolygon(b, ps);
        }
        /// <summary>
        /// 动态计算控件高度。
        /// </summary>
        /// <returns>控件高度。</returns>
        public int InitHeight()
        {
            int rowCount = MessageLineCount();
            int iRows = rowCount == 0 ? 1 : rowCount;
            return iRows * _lineheight + 22;
        }
        /// <summary>
        /// 获取消息行数。
        /// </summary>
        /// <returns>消息行数。</returns>
        private int MessageLineCount()
        {
            //int MessageBits = Encoding.Default.GetByteCount(MessageContent.Trim());
            //return (int)Math.Ceiling(MessageBits * 1.0 / _perlinebit);
            int MessageCharCount = MessageContent.Trim().Length;
            return (int)Math.Ceiling(MessageCharCount * 1.0 / _perlinechar);
        }
    }

    /// <summary>
    /// 消息类型。
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 发送消息。
        /// </summary>
        Send,
        /// <summary>
        /// 接收消息。
        /// </summary>
        Receive
    }
}