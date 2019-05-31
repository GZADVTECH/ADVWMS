using Basics;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasesalemessage
{
    /// <summary>
    /// 采销信息表
    /// </summary>
    public class PurchasesalemessageOperation
    {
        /// <summary>
        /// 添加采销信息
        /// </summary>
        /// <param name="id">采销订单号</param>
        /// <param name="insidenumber">内部订单号</param>
        /// <param name="customer">客供编号</param>
        /// <param name="uid">跟单员编号</param>
        /// <param name="estimatetime">预期货期</param>
        /// <param name="state">状态</param>
        /// <param name="operation">操作员编号</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool InsertPurchasesalemessage(string id,string insidenumber,string customer,string uid,string estimatetime,string state,string operation,string type)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@psm_id",id),
                new SqlParameter("@psm_insidenumber",insidenumber),
                new SqlParameter("@psm_customer",customer),
                new SqlParameter("@psm_uid",uid),
                new SqlParameter("@psm_estimatetime",estimatetime),
                new SqlParameter("@psm_state",state),
                new SqlParameter("@psm_operation",operation),
                new SqlParameter("@psm_type",type)
            };
            int states = SQLOperation.Execute("SQL", "PRO_PURCHASESALEMESSAGE_INSERT", System.Data.CommandType.StoredProcedure, param);
            if (states > 0) return true; else return false;
        }
        /// <summary>
        /// 查询所有采销信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectPurchasesalemessageToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_PURCHASESALEMESSAGE", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有采销信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectPurchasesalemessageToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_PURCHASESALEMESSAGE", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过采销订单号/内部订单号查询采销信息，返回DataSet数据类型
        /// </summary>
        /// <param name="id">采销订单号/内部订单号</param>
        /// <returns></returns>
        public static DataSet SelectPurchasesalemessageToDataSet(string id)
        {
            DataSet ds = Basic.SelectDataSet("T_PURCHASESALEMESSAGE", "*", "psm_id='" + id + "' or psm_insidenumber= '" + id + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过采销订单号/内部订单号查询采销信息，返回DataTable数据类型
        /// </summary>
        /// <param name="id">采销订单号/内部订单号</param>
        /// <returns></returns>
        public static DataTable SelectPurchasesalemessageToDataTable(string id)
        {
            DataTable dt = Basic.SelectDataTable("T_PURCHASESALEMESSAGE", "*", "psm_id='" + id + "' or psm_insidenumber= '" + id + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过采销订单号更改内部订单号
        /// </summary>
        /// <param name="fieldvalue">内部订单号</param>
        /// <param name="conditionvalue">采销订单号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesalemessageOfInsidenumberById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALEMESSAGE", "psm_insidenumber", fieldvalue, "psm_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销订单号更改客供编号
        /// </summary>
        /// <param name="fieldvalue">客供编号</param>
        /// <param name="conditionvalue">采销订单号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesalemessageOfCustomerById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALEMESSAGE", "psm_customer", fieldvalue, "psm_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销订单号更改跟单员编号
        /// </summary>
        /// <param name="fieldvalue">跟单员编号</param>
        /// <param name="conditionvalue">采销订单号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesalemessageOfUidById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALEMESSAGE", "psm_uid", fieldvalue, "psm_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销订单号更改预期货期
        /// </summary>
        /// <param name="fieldvalue">预期货期</param>
        /// <param name="conditionvalue">采销订单号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesalemessageOfEstimatetimeById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALEMESSAGE", "psm_estimatetime", fieldvalue, "psm_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销订单号更改状态
        /// </summary>
        /// <param name="fieldvalue">状态</param>
        /// <param name="conditionvalue">采销订单号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesalemessageOfStateById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALEMESSAGE", "psm_state", fieldvalue, "psm_id", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销订单号更改类型
        /// </summary>
        /// <param name="fieldvalue">类型</param>
        /// <param name="conditionvalue">采销订单号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesalemessageOfTypeById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALEMESSAGE", "psm_type", fieldvalue, "psm_id", conditionvalue);
            if (state) return true; else return false;
        }
    }
}
