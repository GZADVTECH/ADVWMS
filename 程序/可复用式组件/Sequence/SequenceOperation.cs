using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basics;
using SQLHelper;

namespace Sequence
{
    /// <summary>
    /// 序列号信息类
    /// </summary>
    public class SequenceOperation
    {
        #region 加密类
        /// <summary>
        /// 添加序列号信息
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="sequence">序列号</param>
        /// <returns></returns>
        private static bool InsertSequence(string id, string sequence)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@se_gid",id),
                new SqlParameter("@se_sequence",sequence),
                new SqlParameter("@se_state","在库")
            };
            int states = SQLOperation.Execute("SQL", "PRO_SEQUENCE_INSERT", CommandType.StoredProcedure, param);
            if (states > 0) return true; else return false;
        }
        /// <summary>
        /// 查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectSequenceToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_SEQUENCE", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSequenceToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_SEQUENCE", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过货物编号查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectSequenceToDataSet(int id)
        {
            DataSet ds = Basic.SelectDataSet("T_SEQUENCE", "*", "se_gid='" + id.ToString() + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过货物编号查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSequenceToDataTable(int id)
        {
            DataTable dt = Basic.SelectDataTable("T_SEQUENCE", "*", "se_gid='" + id.ToString() + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过序列号查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectSequenceToDataSet(string sequence)
        {
            DataSet ds = Basic.SelectDataSet("T_SEQUENCE", "*", "se_sequence='" + sequence.ToString() + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过序列号查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSequenceToDataTable(string sequence)
        {
            DataTable dt = Basic.SelectDataTable("T_SEQUENCE", "*", "se_sequence='" + sequence.ToString() + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过时间查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectSequenceToDataSet(DateTime time)
        {
            DataSet ds = Basic.SelectDataSet("T_SEQUENCE", "*", "se_time like '" + time.ToString("d") + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过时间查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSequenceToDataTable(DateTime time)
        {
            DataTable dt = Basic.SelectDataTable("T_SEQUENCE", "*", "se_time like '" + time.ToString("d") + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过序列编号更改序列号信息
        /// </summary>
        /// <param name="id">序列编号</param>
        /// <param name="sequence">序列号信息</param>
        /// <returns></returns>
        private static bool UpdateSequenceOfSequenceById(string id, string sequence)
        {
            bool states = Basic.Change("T_SEQUENCE", "se_sequence", sequence, "se_id", id);
            return states;
        }
        /// <summary>
        /// 通过序列编号更改状态信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private static bool UpdateSequenceOfStateById(string id, string state)
        {
            bool states = Basic.Change("T_SEQUENCE", "se_state", state, "se_id", id);
            return states;
        }
        #endregion

        #region 开放类
        /// <summary>
        /// 添加序列号信息
        /// </summary>
        /// <param name="id">货物编号</param>
        /// <param name="sequence">序列号</param>
        /// <returns></returns>
        public static bool DoInsertSequence(string id, string sequence)
        {
            return InsertSequence(id, sequence);
        }
        /// <summary>
        /// 查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectSequenceToDataSet()
        {
            return SelectSequenceToDataSet();
        }
        /// <summary>
        /// 查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectSequenceToDataTable()
        {
            return SelectSequenceToDataTable();
        }
        /// <summary>
        /// 通过货物编号查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectSequenceToDataSet(int id)
        {
            return SelectSequenceToDataSet(id);
        }
        /// <summary>
        /// 通过货物编号查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectSequenceToDataTable(int id)
        {
            return SelectSequenceToDataTable(id);
        }
        /// <summary>
        /// 通过序列号查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectSequenceToDataSet(string sequence)
        {
            return SelectSequenceToDataSet(sequence);
        }
        /// <summary>
        /// 通过序列号查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectSequenceToDataTable(string sequence)
        {
            return SelectSequenceToDataTable(sequence);
        }
        /// <summary>
        /// 通过时间查询所有序列号记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectSequenceToDataSet(DateTime time)
        {
            return SelectSequenceToDataSet(time);
        }
        /// <summary>
        /// 通过时间查询所有序列号记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectSequenceToDataTable(DateTime time)
        {
            return SelectSequenceToDataTable(time);
        }
        /// <summary>
        /// 通过序列编号更改序列号信息
        /// </summary>
        /// <param name="id">序列编号</param>
        /// <param name="sequence">序列号信息</param>
        /// <returns></returns>
        public static bool DoUpdateSequenceOfSequenceById(string id, string sequence)
        {
            return UpdateSequenceOfSequenceById(id, sequence);
        }
        /// <summary>
        /// 通过序列编号更改状态信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool DoUpdateSequenceOfStateById(string id, string state)
        {
            return UpdateSequenceOfStateById(id, state);
        }
        #endregion
    }
}
