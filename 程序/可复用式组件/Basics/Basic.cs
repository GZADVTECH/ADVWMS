using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Basics
{/// <summary>
/// 基本组件
/// </summary>
    public class Basic
    {
     /// <summary>
     /// 通用式修改数据
     /// </summary>
     /// <param name="table">数据表名</param>
     /// <param name="field">被修改字段名称</param>
     /// <param name="fieldvalue">被修改字段值</param>
     /// <param name="condition">条件字段名称</param>
     /// <param name="conditionvalue">条件字段值</param>
     /// <returns>成功返回true，失败返回false</returns>
        public static bool Change(string table,string field,string fieldvalue,string condition,string conditionvalue)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@table",table),
                new SqlParameter("@field",field),
                new SqlParameter("@fieldvalue",fieldvalue),
                new SqlParameter("@condition",condition),
                new SqlParameter("@conditionvalue",conditionvalue)
            };
            int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_UPDATE", CommandType.StoredProcedure, param);
            if (state > 0) return true;
            else return false;
        }
        /// <summary>
        /// 通用式查询数据
        /// </summary>
        /// <param name="table">查询数据表名称</param>
        /// <param name="fieldvalue">查询字段内容</param>
        /// <param name="conditionvalue">条件字段内容</param>
        /// <returns>如果存在数据返回DataSet，如果不存在返回null</returns>
        public static DataTable SelectDataTable(string table,string fieldvalue,string conditionvalue)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@table",table),
                new SqlParameter("@fieldvalue",fieldvalue),
                new SqlParameter("@conditionvalue",conditionvalue)
            };
            DataTable dt = SQLHelper.SQLOperation.QueryDataTable("SQL", "PRO_SELECT", CommandType.StoredProcedure, param);
            if (dt.Rows.Count != 0) return dt;
            else return null;
        }
        /// <summary>
        /// 通用式查询数据
        /// </summary>
        /// <param name="table">查询数据表名称</param>
        /// <param name="fieldvalue">查询字段内容</param>
        /// <param name="conditionvalue">条件字段内容</param>
        /// <returns>如果存在数据返回DataSet，如果不存在返回null</returns>
        public static DataSet SelectDataSet(string table, string fieldvalue, string conditionvalue)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@table",table),
                new SqlParameter("@fieldvalue",fieldvalue),
                new SqlParameter("@conditionvalue",conditionvalue)
            };
            DataSet ds = SQLHelper.SQLOperation.QueryDataSet("SQL", "PRO_SELECT", CommandType.StoredProcedure, param);
            if (ds.Tables[0].Rows.Count != 0) return ds;
            else return null;
        }

        
    }
}
