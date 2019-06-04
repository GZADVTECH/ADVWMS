using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SQLHelper;
using Basics;
/// <summary>
/// 调用SQLHelper类和Basics基础组件类
/// </summary>
namespace Signin
{
    /// <summary>
    /// 登录类
    /// </summary>
    public class Login
    {
        #region 加密类
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="accountnumber">账号</param>
        /// <param name="password">密码</param>
        /// <param name="level">权限等级</param>
        /// <param name="position">职位</param>
        /// <param name="department">部门</param>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        private static bool Register(string accountnumber, string password, string level, string position, string department, string name)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@l_accountnumber",accountnumber),
                new SqlParameter("@l_password",MD5Encrypt.MD5Encrypt32(password)),
                new SqlParameter("@l_level",level),
                new SqlParameter("@l_position",position),
                new SqlParameter("@l_department",department),
                new SqlParameter ("@u_name",name)
            };
            int state = SQLOperation.Execute("SQL", "PRO_LOIN_REGISTER", CommandType.StoredProcedure, param);
            if (state > 0) return true;
            else return false;
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="uid">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns>返回l_id,l_level,l_position,l_department,l_state，不正确或不存在返回null</returns>
        private static DataTable Verification(string uid, string pwd)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@l_accountnumber",uid),
                new SqlParameter("@l_password",MD5Encrypt.MD5Encrypt32(pwd))
        };
            DataTable dt = SQLOperation.QueryDataTable("SQL", "PRO_LOGIN_VERIFICATION", CommandType.StoredProcedure, param);
            if (dt.Rows.Count > 0)
                return dt;
            else
                return null;
        }
        /// <summary>
        /// 登录记录登记
        /// </summary>
        /// <param name="uid">登录账号</param>
        /// <param name="ipaddress">登录IP地址</param>
        /// <returns>成功返回true，失败返回false</returns>
        private static bool LoginRecord(string uid, string ipaddress)
        {
            //SqlParameter[] param =
            //{
            //    new SqlParameter("@lr_uid",uid),
            //    new SqlParameter("@lr_ipaddress",ipaddress)
            //};
            bool state = Basic.Change("T_LOGIN", "lr_uid", uid, "lr_ipaddress", ipaddress);
            return state;
        }
        /// <summary>
        /// 简易忘记密码
        /// </summary>
        /// <param name="uid">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns>提交忘记密码反馈给管理员，成功返回true，错误返回false</returns>
        private static bool ForgetPassword(string uid, string pwd)
        {
            //SqlParameter[] param =
            //{
            //    new SqlParameter("@table","T_LOGIN"),
            //    new SqlParameter("@field","l_password"),
            //    new SqlParameter("@fieldvalue",pwd),
            //    new SqlParameter("@condition","l_accountnumber"),
            //    new SqlParameter("@conditionvalue",uid)
            //};
            //int state = SQLOperation.Execute("SQL", "PRO_UPDATE", CommandType.StoredProcedure, param);
            bool state = Basic.Change("T_LOGIN", "l_password", pwd, "l_accountnumber", uid);
            return state;
        }
        /// <summary>
        /// 查询登陆表所有信息，返回DataSet类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectLoginToDataSet()
        {
            try
            {
                DataSet ds = Basic.SelectDataSet("T_USER", "l_id,l_accountnumber,l_level,l_position,l_department,l_state", "");
                if (ds == null) return null;
                else return ds;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询登陆表所有信息，返回DataTable类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectLoginToDataTable()
        {
            try
            {
                DataTable dt = Basic.SelectDataTable("T_USER", "l_id,l_accountnumber,l_level,l_position,l_department,l_state", "");
                if (dt == null) return null;
                else return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 开放类
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="accountnumber">账号</param>
        /// <param name="password">密码</param>
        /// <param name="level">权限等级</param>
        /// <param name="position">职位</param>
        /// <param name="department">部门</param>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        public static bool DoRegister(string accountnumber, string password, string level, string position, string department, string name)
        {
            return Register(accountnumber, password, level, position, department, name);
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="uid">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns>返回l_id,l_level,l_position,l_department,l_state，不正确或不存在返回null</returns>
        public static DataTable DoVerification(string uid, string pwd)
        {
            return Verification(uid, pwd);
        }
        /// <summary>
        /// 登录记录登记
        /// </summary>
        /// <param name="uid">登录账号</param>
        /// <param name="ipaddress">登录IP地址</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static bool DoLoginRecord(string uid, string ipaddress)
        {
            return LoginRecord(uid, ipaddress);
        }
        /// <summary>
        /// 简易忘记密码
        /// </summary>
        /// <param name="uid">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns>提交忘记密码反馈给管理员，成功返回true，错误返回false</returns>
        public static bool DoForgetPassword(string uid, string pwd)
        {
            return ForgetPassword(uid, pwd);
        }
        /// <summary>
        /// 查询登陆表所有信息，返回DataSet类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectLoginToDataSet()
        {
            return SelectLoginToDataSet();
        }
        /// <summary>
        /// 查询登陆表所有信息，返回DataTable类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectLoginToDataTable()
        {
            return SelectLoginToDataTable();
        }
        #endregion
    }
}
