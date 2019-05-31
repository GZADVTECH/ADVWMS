using Basics;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access
{
    /// <summary>
    /// 仓库货物进出类
    /// </summary>
    public class AccessOperation
    {
        /// <summary>
        /// 添加仓库货物出入信息
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="number">数量</param>
        /// <param name="ordernumber">订单号</param>
        /// <param name="warehouse">仓位</param>
        /// <param name="uid">操作员编号</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public static bool InsertAccess(string id,string number,string ordernumber,string warehouse,string uid,string remark)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@ac_id",id),
                new SqlParameter("@ac_number",number),
                new SqlParameter("@ac_ordernumber",ordernumber),
                new SqlParameter("@ac_warehouse",warehouse),
                new SqlParameter("@ac_uid",uid),
                new SqlParameter("@ac_remark",remark)
            };
            int states = SQLOperation.Execute("SQL", "PRO_ACCESS_INSERT", System.Data.CommandType.StoredProcedure, param);
            if (states > 0) return false; else return true;
        }
        /// <summary>
        /// 查询所有仓库货物出入信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAccessToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_ACCESS", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有仓库货物出入信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectAccessToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_ACCESS", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号查询仓库货物出入信息，返回DataSet数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        public static DataSet SelectGoodsToDataSet(int id)
        {
            DataSet ds = Basic.SelectDataSet("T_ACCESS", "*", "ac_id='" + id.ToString() + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过货物编号查询仓库货物出入信息，返回DataTable数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        public static DataTable SelectGoodsToDataTable(int id)
        {
            DataTable dt = Basic.SelectDataTable("T_ACCESS", "*", "ac_id='" + id.ToString() + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过采销订单号查询仓库货物出入信息，返回DataSet数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        public static DataSet SelectGoodsToDataSet(string name)
        {
            DataSet ds = Basic.SelectDataSet("T_ACCESS", "*", "ac_ordernumber='" + name + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过采销订单号查询仓库货物出入信息，返回DataTable数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        public static DataTable SelectGoodsToDataTable(string name)
        {
            DataTable dt = Basic.SelectDataTable("T_ACCESS", "*", "ac_ordernumber='" + name + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号和采销订单号更改货物编号
        /// </summary>
        /// <param name="after">新货物编号</param>
        /// <param name="before">旧货物编号</param>
        /// <param name="order">采销订单号</param>
        /// <returns></returns>
        public static bool UpdateAccessOfId(string after,string before,string order)
        {
            bool state = Basic.FullChange("T_ACCESS", "ac_id='" + after + "'", "ac_id='" + before + "' and ac_ordernumber='" + order + "'");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过货物编号和采销订单号更改数量
        /// </summary>
        /// <param name="after">数量</param>
        /// <param name="before">旧货物编号</param>
        /// <param name="order">采销订单号</param>
        /// <returns></returns>
        public static bool UpdateAccessOfNumber(string after, string before, string order)
        {
            bool state = Basic.FullChange("T_ACCESS", "ac_number='" + after + "'", "ac_id='" + before + "' and ac_ordernumber='" + order + "'");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过货物编号和采销订单号更改仓位
        /// </summary>
        /// <param name="after">仓位</param>
        /// <param name="before">旧货物编号</param>
        /// <param name="order">采销订单号</param>
        /// <returns></returns>
        public static bool UpdateAccessOfWarehouse(string after, string before, string order)
        {
            bool state = Basic.FullChange("T_ACCESS", "ac_warehouse='" + after + "'", "ac_id='" + before + "' and ac_ordernumber='" + order + "'");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过货物编号和采销订单号更改时间
        /// </summary>
        /// <param name="after">时间</param>
        /// <param name="before">旧货物编号</param>
        /// <param name="order">采销订单号</param>
        /// <returns></returns>
        public static bool UpdateAccessOfTime(string after, string before, string order)
        {
            bool state = Basic.FullChange("T_ACCESS", "ac_time='" + after + "'", "ac_id='" + before + "' and ac_ordernumber='" + order + "'");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过货物编号和采销订单号更改备注
        /// </summary>
        /// <param name="after">备注</param>
        /// <param name="before">旧货物编号</param>
        /// <param name="order">采销订单号</param>
        /// <returns></returns>
        public static bool UpdateAccessOfRemark(string after, string before, string order)
        {
            bool state = Basic.FullChange("T_ACCESS", "ac_remark='" + after + "'", "ac_id='" + before + "' and ac_ordernumber='" + order + "'");
            if (state) return true; else return false;
        }

    }
}
