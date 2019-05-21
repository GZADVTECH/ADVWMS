using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basics;
/// <summary>
/// 关联Basic基础组件类
/// </summary>
namespace Event
{
    /// <summary>
    /// 待办事件操作类
    /// </summary>
    public class EventOperation
    {
        /// <summary>
        /// 插入待办事件信息
        /// </summary>
        /// <param name="content">待办事件内容</param>
        /// <param name="releaseid">发布者编号</param>
        /// <param name="handleid">执行者编号</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static bool InsertEvent(string content,string releaseid,string handleid)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@e_conent",content),
                new SqlParameter("@e_releaseid",releaseid),
                new SqlParameter("@e_handleid",handleid)
            };
            int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_EVENT_INSERT", System.Data.CommandType.StoredProcedure, param);
            if (state > 0) return true;else return false;
        }
        /// <summary>
        /// 通过ID查找待办事件更改待办内容
        /// </summary>
        /// <param name="fieldvalue">待办内容</param>
        /// <param name="conditionvalue">待办事件ID</param>
        /// <returns></returns>
        public static bool UpdateEventOfContentById(string fieldvalue,string conditionvalue)
        {
            //SqlParameter[] param =
            //{
            //    new SqlParameter("@table","T_EVENT"),
            //    new SqlParameter("@field","e_content"),
            //    new SqlParameter("@fieldvalue",fieldvalue),
            //    new SqlParameter("@condition","e_id"),
            //    new SqlParameter("@conditionvalue",conditionvalue)
            //};
            //int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_UPDATE", System.Data.CommandType.StoredProcedure, param);
            bool state= Basic.Change("T_EVENT", "e_content", fieldvalue, "e_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过ID查找待办事件更改办事员编号
        /// </summary>
        /// <param name="fieldvalue">办事员编号</param>
        /// <param name="conditionvalue">待办事件ID</param>
        /// <returns></returns>
        public static bool UpdateEventOfHandleById(string fieldvalue, string conditionvalue)
        {
            //SqlParameter[] param =
            //{
            //    new SqlParameter("@table","T_EVENT"),
            //    new SqlParameter("@field","e_handleid"),
            //    new SqlParameter("@fieldvalue",fieldvalue),
            //    new SqlParameter("@condition","e_id"),
            //    new SqlParameter("@conditionvalue",conditionvalue)
            //};
            //int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_UPDATE", System.Data.CommandType.StoredProcedure, param);
            bool state = Basic.Change("T_EVENT", "e_handleid", fieldvalue, "e_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过ID查找待办事件更改待办状态
        /// </summary>
        /// <param name="fieldvalue">待办状态</param>
        /// <param name="conditionvalue">待办事件ID</param>
        /// <returns></returns>
        public static bool UpdateEventOfStateById(string fieldvalue,string conditionvalue)
        {
            //SqlParameter[] param =
            //{
            //    new SqlParameter("@table","T_EVENT"),
            //    new SqlParameter("@field","e_state"),
            //    new SqlParameter("@fieldvalue",fieldvalue),
            //    new SqlParameter("@condition","e_id"),
            //    new SqlParameter("@conditionvalue",conditionvalue)
            //};
            //int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_UPDATE", System.Data.CommandType.StoredProcedure, param);
            bool state = Basic.Change("T_EVENT", "e_state", fieldvalue, "e_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 查询待办事件的所有详细信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectEventToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_EVENT", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询待办事件的所有详细信息，返回DateTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectEventToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_EVENT", "*", "");
            if (dt == null) return null; else return dt;
        }
    }
}
