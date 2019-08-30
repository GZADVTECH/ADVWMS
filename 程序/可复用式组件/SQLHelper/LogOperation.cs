using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SQLHelper
{
    /// <summary>
    /// 日志记录类
    /// </summary>
    /// <remarks>当调用Write方法时</remarks>
    public class LogOperation
    {
        public static void Write(string msgText)
        {
            Write(DateTime.Now, MsgType.Information, "", msgText);
        }

        public static void Write(string msgText,MsgType msgType,string msglocation)
        {
            Write(DateTime.Now, msgType, msglocation, msgText);
        }
        /// <summary>
        /// 写日志基础方法
        /// </summary>
        /// <param name="msgDateTime"></param>
        /// <param name="msgType"></param>
        /// <param name="msglocation"></param>
        /// <param name="msgText"></param>
        private static void Write(DateTime msgDateTime,MsgType msgType,string msglocation,string msgText)
        {
            QueueManager qm = new QueueManager();
            qm.WriteToQueue(msgDateTime, msgType, msglocation, msgText);
        }
        #region QueueManager
        /// <summary>
        /// 企业应用框架的日志类
        /// </summary>
        private class QueueManager : IDisposable
        {
            /// <summary>
            /// 日志对象的缓存队列
            /// </summary>
            private static Queue<Msg> _msgQueue;
            /// <summary>
            /// 日志文件保存的路径
            /// </summary>
            private static readonly string Path = BasePath + @"\\AppLogs\";
            /// <summary>
            /// Web和WinForm通用的取当前根目录的方法
            /// </summary>
            private static string BasePath
            {
                get
                {
                    if (System.Web.HttpContext.Current != null) return System.Web.HttpContext.Current.Server.MapPath("~/").TrimEnd(new char[] { '\\' });
                    else//当空间在定时器的出发程序中使用时就为空
                    {
                        return AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new char[] { '\\' });
                    }
                }
            }
            /// <summary>
            /// 日志写入文件线程的控制标记，true为正在写入
            /// </summary>
            private static bool _state = false;
            /// <summary>
            /// 日志文件生命周期的时间标记
            /// </summary>
            private static DateTime _timeSign;
            /// <summary>
            /// 日志文件写入流对象
            /// </summary>
            private static StreamWriter _writer;
            private delegate void WorkDelegate();
            private static WorkDelegate _workDg;
            /// <summary>
            /// 初始化
            /// </summary>
            public QueueManager()
            {
                if (_msgQueue == null)
                {
                    if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
                    _msgQueue = new Queue<Msg>();
                    _workDg = new WorkDelegate(Work);
                }
            }
            /// <summary>
            /// 写入新日志，根据指定的日志对象Msg
            /// </summary>
            /// <param name="msg"></param>
            private void WriteToQueue(Msg msg)
            {
                if (msg != null)
                {
                    lock (_msgQueue)
                    {
                        _msgQueue.Enqueue(msg);
                    }
                }
                if (_msgQueue.Count > 0 && !_state)
                {
                    _state = true;
                    _workDg.BeginInvoke(null, null);
                }
            }
            /// <summary>
            /// 日志写入文件线程执行的方法
            /// </summary>
            private void Work()
            {
                //判断队列中是否存在待写入的日志
                while (_msgQueue.Count > 0)
                {
                    Msg msg = null;
                    lock (_msgQueue)
                    {
                        msg = _msgQueue.Dequeue();
                    }
                    if (msg != null)
                    {
                        WriteToFile(msg);
                    }
                }
                _state = false;
                FileClose();
            }
            /// <summary>
            /// 通过判断文件的到期时间标记将决定是否创建新文件
            /// </summary>
            /// <returns></returns>
            private static string GetFilename()
            {
                DateTime now = DateTime.Now;
                string format = "yyyy-MM-dd'.log'";
                _timeSign = new DateTime(now.Year, now.Month, now.Day);
                _timeSign = _timeSign.AddDays(1);
                return now.ToString(format);
            }
            /// <summary>
            /// 写入日志文本到文件的方法
            /// </summary>
            /// <param name="msg"></param>
            private void WriteToFile(Msg msg)
            {
                try
                {
                    if (_writer == null)
                    {
                        FileOpen();
                    }
                    //判断文件到期标志，如果当前文件到期则关闭文件创建新的日志文件
                    if (DateTime.Now >= _timeSign)
                    {
                        FileClose();
                        FileOpen();
                    }
                    if (_writer != null)
                    {
                        _writer.WriteLine(string.Format("{0}", msg.DateTime) + "\t" + msg.Type + "\t" + msg.location + "t" + msg.Text);
                        _writer.Flush();
                    }
                }
                catch (Exception e)
                {
                    Console.Out.Write(e);
                }
            }
            //打开文件准备写入
            private void FileOpen()
            {
                _writer = new StreamWriter(Path + GetFilename(), true, Encoding.UTF8);
            }
            //关闭打开的日志文件
            private void FileClose()
            {
                if (_writer != null)
                {
                    _writer.Flush();
                    _writer.Close();
                    _writer.Dispose();
                    _writer = null;
                }
            }
            /// <summary>
            /// 写入新日志，根据指定的日志名字，日志内容和信息类型写入新日志
            /// </summary>
            /// <param name="msgDateTime"></param>
            /// <param name="msgType"></param>
            /// <param name="msglocation"></param>
            /// <param name="msgText"></param>
            public void WriteToQueue(DateTime msgDateTime, MsgType msgType, string msglocation, string msgText)
            {
                WriteToQueue(new Msg(msgDateTime, msgType, msglocation, msgText));
            }

            #region IDisposable成员
            /// <summary>
            /// 销毁日志对象
            /// </summary>
            public void Dispose()
            {
                _state = false;
            }
        }
        #endregion
        #endregion
        #region Msg
        /// <summary>
        /// 表示一个日志记录的对象
        /// </summary>
        private class Msg
        {
            /// <summary>
            /// 获取或设置日志记录的时间
            /// </summary>
            public DateTime DateTime { get;private set; }

            public string location { get; private set; }
            /// <summary>
            /// 获取或设置日志记录的消息类型
            /// </summary>
            public MsgType Type { get; private set; }
            /// <summary>
            /// 获取或设置日志记录的文本内容
            /// </summary>
            public string Text { get; private set; }
            /// <summary>
            /// 创建新的日志记录实例
            /// </summary>
            /// <param name="msgDateTime"></param>
            /// <param name="msgType"></param>
            /// <param name="msglocation"></param>
            /// <param name="msgText"></param>
            public Msg(DateTime msgDateTime,MsgType msgType,string msglocation,string msgText)
            {
                DateTime = msgDateTime;
                Type = msgType;
                location = msglocation;
                Text = msgText;
            }
        }
        #endregion

        #region msgType
        /// <summary>
        /// 日志消息类型的枚举
        /// </summary>
        public enum MsgType
        {
            /// <summary>
            /// 普通信息类型的日志记录
            /// </summary>
            Information,
            /// <summary>
            /// 警告信息类型的日志记录
            /// </summary>
            Warning,
            /// <summary>
            /// 错误信息类型的日志记录
            /// </summary>
            Error,
            /// <summary>
            /// 成功信息类型的日志记录
            /// </summary>
            Success,
            /// <summary>
            /// 致命类型的日志记录
            /// </summary>
            Fatal
        }
        #endregion
    }
}
