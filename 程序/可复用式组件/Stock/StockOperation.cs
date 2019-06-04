using Basics;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    /// <summary>
    /// 库存类
    /// </summary>
    public class StockOperation
    {
        #region 加密类
        /// <summary>
        /// 添加库存信息
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="number">数量</param>
        /// <param name="company">单位</param>
        /// <returns></returns>
        private static bool InsertStock(string id, string number, string company)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@s_id",id),
                new SqlParameter("@s_number",number),
                new SqlParameter("@s_company",company)
            };
            int state = SQLOperation.Execute("SQL", "PRO_STOCK_INSERT", System.Data.CommandType.StoredProcedure, param);
            if (state > 0) return true; else return false;
        }
        /// <summary>
        /// 查询所有的库存信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectStockToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_STOCK", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有的库存信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectStockToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_STOCK", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号查询所有的库存信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectStockToDataSet(int id)
        {
            DataSet ds = Basic.SelectDataSet("T_STOCK", "*", "s_id='" + id.ToString() + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过货物编号查询所有的库存信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectStockToDataTable(int id)
        {
            DataTable dt = Basic.SelectDataTable("T_STOCK", "*", "s_id='" + id.ToString() + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号更改数量
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="number">数量</param>
        /// <returns></returns>
        private static bool UpdateStockOfNumberById(string id, string number)
        {
            bool state = Basic.Change("T_STOCK", "s_id", id, "s_number", number);
            return state;
        }
        /// <summary>
        /// 通过货物编号更改单位
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="number">单位</param>
        /// <returns></returns>
        private static bool UpdateStockOfCompanyById(string id, string company)
        {
            bool state = Basic.Change("T_STOCK", "s_id", id, "s_company", company);
            return state;
        }
        #endregion

        #region 公开类
        /// <summary>
        /// 添加库存信息
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="number">数量</param>
        /// <param name="company">单位</param>
        /// <returns></returns>
        public static bool DoInsertStock(string id, string number, string company)
        {
            return InsertStock(id, number, company);
        }
        /// <summary>
        /// 查询所有的库存信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectStockToDataSet()
        {
            return SelectStockToDataSet();
        }
        /// <summary>
        /// 查询所有的库存信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectStockToDataTable()
        {
            return SelectStockToDataTable();
        }
        /// <summary>
        /// 通过货物编号查询所有的库存信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectStockToDataSet(int id)
        {
            return SelectStockToDataSet(id);
        }
        /// <summary>
        /// 通过货物编号查询所有的库存信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectStockToDataTable(int id)
        {
            return SelectStockToDataTable(id);
        }
        /// <summary>
        /// 通过货物编号更改数量
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="number">数量</param>
        /// <returns></returns>
        public static bool DoUpdateStockOfNumberById(string id, string number)
        {
            return UpdateStockOfNumberById(id, number);
        }
        /// <summary>
        /// 通过货物编号更改单位
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="number">单位</param>
        /// <returns></returns>
        public static bool DoUpdateStockOfCompanyById(string id, string company)
        {
            return UpdateStockOfCompanyById(id, company);
        }
        #endregion
    }
}
