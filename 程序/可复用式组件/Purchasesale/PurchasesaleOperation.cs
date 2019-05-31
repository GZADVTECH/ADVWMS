using Basics;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasesale
{
    /// <summary>
    /// 采销货物类
    /// </summary>
    public class PurchasesaleOperation
    {
        /// <summary>
        /// 添加采购信息
        /// </summary>
        /// <param name="id">采购订单号</param>
        /// <param name="gid">货物编号</param>
        /// <param name="number">采购数量</param>
        /// <param name="price">价格</param>
        /// <param name="tax">税率</param>
        /// <param name="time">发货时间</param>
        /// <returns></returns>
        public static bool InsertPurchasesale(string id,string gid,int number,double price,double tax,DateTime time)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@ps_id",id),
                new SqlParameter("@ps_gid",gid),
                new SqlParameter("@ps_number",number),
                new SqlParameter("@ps_price",price.ToString()),
                new SqlParameter("@ps_tax",tax.ToString()),
                new SqlParameter("@ps_taxprice",(price*(1+tax)).ToString()),
                new SqlParameter("@ps_time",time.ToString("yyyy/MM/dd"))
            };
            int states = SQLOperation.Execute("SQL", "PRO_PURCHASESALE_INSERT", CommandType.StoredProcedure, param);
            if (states > 0) return true; else return false;
        }
        /// <summary>
        /// 查询采销货物信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectPurchasesaleToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_PURCHASESALE", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有采销货物信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectPurchasesaleToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_PURCHASESALE", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号查询采销货物信息，返回DataSet数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        public static DataSet SelectPurchasesaleToDataSet(int id)
        {
            DataSet ds = Basic.SelectDataSet("T_PURCHASESALE", "*", "ps_gid='" + id.ToString() + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过货物编号查询采销货物信息，返回DataTable数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        public static DataTable SelectPurchasesaleToDataTable(int id)
        {
            DataTable dt = Basic.SelectDataTable("T_PURCHASESALE", "*", "ps_gid='" + id.ToString() + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过采销订单号查询采销货物信息，返回DataSet数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        public static DataSet SelectPurchasesaleToDataSet(string id)
        {
            DataSet ds = Basic.SelectDataSet("T_PURCHASESALE", "*", "ps_id='" + id + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过采销订单号查询采销货物信息，返回DataTable数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        public static DataTable SelectPurchasesaleToDataTable(string id)
        {
            DataTable dt = Basic.SelectDataTable("T_PURCHASESALE", "*", "ps_id='" + id + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过采销货物编号更改货物编号信息
        /// </summary>
        /// <param name="fieldvalue">货物编号</param>
        /// <param name="conditionvalue">采销货物编号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesaleOfGoodsById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALE", "ps_gid", fieldvalue, "ps_pid", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销货物编号更改货物数量信息
        /// </summary>
        /// <param name="fieldvalue">货物数量</param>
        /// <param name="conditionvalue">采销货物编号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesaleOfNumberById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALE", "ps_number", fieldvalue, "ps_pid", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销货物编号更改货物价格信息
        /// </summary>
        /// <param name="fieldvalue">价格</param>
        /// <param name="conditionvalue">采销货物编号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesaleOfPriceById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALE", "ps_price", fieldvalue, "ps_pid", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销货物编号更改货物税率信息
        /// </summary>
        /// <param name="fieldvalue">税率</param>
        /// <param name="conditionvalue">采销货物编号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesaleOfTaxById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALE", "ps_tax", fieldvalue, "ps_pid", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销货物编号更改货物税后价信息
        /// </summary>
        /// <param name="fieldvalue">税后价</param>
        /// <param name="conditionvalue">采销货物编号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesaleOfTaxPriceById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALE", "ps_taxprice", fieldvalue, "ps_pid", conditionvalue);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过采销货物编号更改发货时间信息
        /// </summary>
        /// <param name="fieldvalue">发货时间</param>
        /// <param name="conditionvalue">采销货物编号</param>
        /// <returns></returns>
        public static bool UpdatePurchasesaleOfTimeById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_PURCHASESALE", "ps_time", fieldvalue, "ps_pid", conditionvalue);
            if (state) return true; else return false;
        }
    }
}
