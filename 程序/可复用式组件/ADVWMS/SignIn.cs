using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Signin;
using System.Data;
using SQLHelper;
using System.Net;

namespace ADVWMS
{
    /// <summary>
    /// 管理系统之登录模块
    /// </summary>
    public class SignIn
    {
        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static string Login(string uid,string pwd)
        {
            if (string.IsNullOrEmpty(uid.Trim())) return "账号不允许为空";//验证账号是否为空
            if (string.IsNullOrEmpty(pwd.Trim())) return "密码不允许为空";//验证密码是否为空
            if (!Regex.IsMatch(pwd, "^[a-zA-Z0-9]{8,}$")) return "密码必须八位以上并且由大写字母、小写字母和数字组成...";

            try
            {
                DataTable dt=Signin.Login.DoVerification(uid, pwd);
                if (dt.Rows.Count > 0)
                {
                LogOperation.Write("登录成功。", LogOperation.MsgType.Success, GetLocalIP());//写入日志
                    return "0x00";
                }
            }
            catch 
            {
                LogOperation.Write("登录失败，校验账号密码过程发生错误。", LogOperation.MsgType.Error, GetLocalIP());//写入日志
            }
            return "0x01";
        }
        /// <summary>
        /// 获取用户IP地址
        /// </summary>
        /// <returns></returns>
        private static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName();//得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出Ipv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP地址
                    //AddressFamuly.InterNetworkV6表示此地址为Ipv6类型
                    if (IpEntry.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                } 
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
