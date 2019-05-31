using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basics;
using System.Data.SqlClient;
using System.Data;
namespace Report
{
    /// <summary>
    /// 报表模板类
    /// </summary>
    public class ReportOperation
    {
        /// <summary>
        /// 添加报表模板信息
        /// </summary>
        /// <param name="uid">添加人编号</param>
        /// <param name="name">报表模板名称</param>
        /// <param name="route">存放位置</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public static bool InsertReport(string uid, string name, string route, string remark)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@r_uid",uid),
                new SqlParameter("@r_name",name),
                new SqlParameter("@r_route",route),
                new SqlParameter("@r_remark",remark)
            };
            int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_REPORT_INSERT", CommandType.StoredProcedure, param);
            if (state > 0) return true; else return false; 
        }
        /// <summary>
        /// 添加报表模板信息
        /// </summary>
        /// <param name="uid">添加人编号</param>
        /// <param name="name">报表模板名称</param>
        /// <param name="route">存放位置</param>
        /// <returns></returns>
        public static bool InsertReport(string uid,string name,string route)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@r_uid",uid),
                new SqlParameter("@r_name",name),
                new SqlParameter("@r_route",route),
                new SqlParameter("@r_remark","")
            };
            int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_REPORT_INSERT", CommandType.StoredProcedure, param);
            if (state > 0) return true; else return false;
        }
        /// <summary>
        /// 通过报表ID修改报表名称
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="name">报表名称</param>
        /// <returns></returns>
        public static bool UpdateReportOfNameById(string id,string name)
        {
            bool state = Basic.Change("T_REPORT", "r_name", name, "r_id", id);
            return state;
        }
        /// <summary>
        /// 通过报表ID修改存放位置
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="route">存放位置</param>
        /// <returns></returns>
        public static bool UpdateReportOfRouteById(string id,string route)
        {
            bool state = Basic.Change("T_REPORT", "r_route", route, "r_id", id);
            return state;
        }
        /// <summary>
        /// 通过报表ID修改状态
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public static bool UpdateReportOfStateById(string id,string state)
        {
            bool states = Basic.Change("T_REPORT", "r_state", state, "r_id", id);
            return states;
        }
        /// <summary>
        /// 查询所有报表信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectReportToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_REPORT", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有报表信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectReportToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_REPORT", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过报表名称查询所有报表信息，返回DataSet数据类型
        /// </summary>
        /// <param name="name">报表名称</param>
        /// <returns></returns>
        public static DataSet SelectReportToDataSet(string name)
        {
            DataSet ds = Basic.SelectDataSet("T_REPORT", "*", "r_state=1 and r_name='"+ name+"'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过报表名称查询所有报表信息，返回DataTable数据类型
        /// </summary>
        /// <param name="name">报表名称</param>
        /// <returns></returns>
        public static DataTable SelectReportToDataTable(string name)
        {
            DataTable dt = Basic.SelectDataTable("T_REPORT", "*", "r_state=1 and r_name='" + name + "'");
            if (dt == null) return null; else return dt;
        }
    }
}
