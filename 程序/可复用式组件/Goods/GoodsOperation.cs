using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Basics;
using SQLHelper;

namespace Goods
{
    /// <summary>
    /// 货物信息类
    /// </summary>
    public class GoodsOperation
    {
        #region 加密类
        /// <summary>
        /// 添加货物信息
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <param name="model">规格型号</param>
        /// <param name="pncode">货物PN号</param>
        /// <param name="state">货物状态</param>
        /// <param name="remark">货物备注</param>
        /// <returns></returns>
        private static bool InsertGoods(string name, string model, string pncode, string state, string remark)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@g_name",name),
                new SqlParameter("@g_model",model),
                new SqlParameter("@g_pncode",pncode),
                new SqlParameter("@g_state",state),
                new SqlParameter("@remark",remark)
            };
            int states = SQLOperation.Execute("SQL", "PRO_GOODS_INSERT", CommandType.StoredProcedure, param);
            if (states > 0) return true; else return false;
        }
        /// <summary>
        /// 查询所有货物信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectGoodsToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_GOODS", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有货物信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectGoodsToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_GOODS", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号查询货物信息，返回DataSet数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        private static DataSet SelectGoodsToDataSet(int id)
        {
            DataSet ds = Basic.SelectDataSet("T_GOODS", "*", "g_id='" + id.ToString() + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过货物编号查询货物信息，返回DataTable数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        private static DataTable SelectGoodsToDataTable(int id)
        {
            DataTable dt = Basic.SelectDataTable("T_GOODS", "*", "g_id='" + id.ToString() + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物名称查询货物信息，返回DataSet数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        private static DataSet SelectGoodsToDataSet(string name)
        {
            DataSet ds = Basic.SelectDataSet("T_GOODS", "*", "g_name='" + name + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过货物名称查询货物信息，返回DataTable数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        private static DataTable SelectGoodsToDataTable(string name)
        {
            DataTable dt = Basic.SelectDataTable("T_GOODS", "*", "g_name='" + name + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号更改货物名称
        /// </summary>
        /// <param name="fieldvalue">货物名称</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        private static bool UpdateGoodsOfNameById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_GOODS", "g_name", fieldvalue, "g_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过货物编号更改规格型号
        /// </summary>
        /// <param name="fieldvalue">规格型号</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        private static bool UpdateGoodsOfModelById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_GOODS", "g_model", fieldvalue, "g_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过货物编号更改货物PN号
        /// </summary>
        /// <param name="fieldvalue">货物PN号</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        private static bool UpdateGoodsOfPNCodeById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_GOODS", "g_pncode", fieldvalue, "g_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过货物编号更改状态
        /// </summary>
        /// <param name="fieldvalue">状态</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        private static bool UpdateGoodsOfStateById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_GOODS", "g_state", fieldvalue, "g_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过货物编号更改货物PN号
        /// </summary>
        /// <param name="fieldvalue">货物PN号</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        private static bool UpdateGoodsOfRemarkById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_GOODS", "g_remark", fieldvalue, "g_id", conditionvalue);
            return state;
        }
        #endregion

        #region 公开类
        /// <summary>
        /// 添加货物信息
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <param name="model">规格型号</param>
        /// <param name="pncode">货物PN号</param>
        /// <param name="state">货物状态</param>
        /// <param name="remark">货物备注</param>
        /// <returns></returns>
        public static bool DoInsertGoods(string name, string model, string pncode, string state, string remark)
        {
            return InsertGoods(name, model, pncode,  state, remark);
        }
        /// <summary>
        /// 查询所有货物信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectGoodsToDataSet()
        {
            return SelectGoodsToDataSet();
        }
        /// <summary>
        /// 查询所有货物信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectGoodsToDataTable()
        {
            return SelectGoodsToDataTable();
        }
        /// <summary>
        /// 通过货物编号查询货物信息，返回DataSet数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        public static DataSet DoSelectGoodsToDataSet(int id)
        {
            return SelectGoodsToDataSet(id);
        }
        /// <summary>
        /// 通过货物编号查询货物信息，返回DataTable数据类型
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <returns></returns>
        public static DataTable DoSelectGoodsToDataTable(int id)
        {
            return SelectGoodsToDataTable(id);
        }
        /// <summary>
        /// 通过货物名称查询货物信息，返回DataSet数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        public static DataSet DoSelectGoodsToDataSet(string name)
        {
            return SelectGoodsToDataSet(name);
        }
        /// <summary>
        /// 通过货物名称查询货物信息，返回DataTable数据类型
        /// </summary>
        /// <param name="name">货物名称</param>
        /// <returns></returns>
        public static DataTable DoSelectGoodsToDataTable(string name)
        {
            return SelectGoodsToDataTable(name);
        }
        /// <summary>
        /// 通过货物编号更改货物名称
        /// </summary>
        /// <param name="fieldvalue">货物名称</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        public static bool DoUpdateGoodsOfNameById(string fieldvalue, string conditionvalue)
        {
            return UpdateGoodsOfNameById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过货物编号更改规格型号
        /// </summary>
        /// <param name="fieldvalue">规格型号</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        public static bool DoUpdateGoodsOfModelById(string fieldvalue, string conditionvalue)
        {
            return UpdateGoodsOfModelById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过货物编号更改货物PN号
        /// </summary>
        /// <param name="fieldvalue">货物PN号</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        public static bool DoUpdateGoodsOfPNCodeById(string fieldvalue, string conditionvalue)
        {
            return UpdateGoodsOfPNCodeById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过货物编号更改状态
        /// </summary>
        /// <param name="fieldvalue">状态</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        public static bool DoUpdateGoodsOfStateById(string fieldvalue, string conditionvalue)
        {
            return UpdateGoodsOfStateById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过货物编号更改货物PN号
        /// </summary>
        /// <param name="fieldvalue">货物PN号</param>
        /// <param name="conditionvalue">货物编号</param>
        /// <returns></returns>
        public static bool DoUpdateGoodsOfRemarkById(string fieldvalue, string conditionvalue)
        {
            return UpdateGoodsOfRemarkById(fieldvalue, conditionvalue);
        }
        #endregion
    }
}
