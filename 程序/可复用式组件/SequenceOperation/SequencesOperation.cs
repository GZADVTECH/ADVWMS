using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SQLHelper;
using Basics;

namespace SequenceOperation
{
    /// <summary>
    /// 序列号操作记录表
    /// </summary>
    public class SequencesOperation
    {
        #region 加密类
        /// <summary>
        /// 添加序列号操作记录信息
        /// </summary>
        /// <param name="sequence">序列号</param>
        /// <param name="content">操作内容</param>
        /// <returns></returns>
        private static bool InsertSequenceOperation(string sequence, string content)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@seo_sequence",sequence),
                new SqlParameter("@seo_operationcontent",content)
            };
            int state = SQLOperation.Execute("SQL", "PRO_SEQUENCEOPERATION_INSERT", CommandType.StoredProcedure, param);
            if (state > 0) return true; else return false;
        }
        /// <summary>
        /// 查询所有的序列号操作记录信息
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectSequenceOperationToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_SEQUENCEOPERATION", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有的序列号操作记录信息
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSequenceOperationToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_SEQUENCEOPERATION", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过序列号查询所有序列号操作记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectSequenceOperationToDataSet(string sequence)
        {
            DataSet ds = Basic.SelectDataSet("T_SEQUENCEOPERATION", "*", "seo_sequence='" + sequence.ToString() + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过序列号查询所有序列号操作记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSequenceOperationToDataTable(string sequence)
        {
            DataTable dt = Basic.SelectDataTable("T_SEQUENCEOPERATION", "*", "seo_sequence='" + sequence.ToString() + "'");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过时间查询所有序列号操作记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectSequenceOperationToDataSet(DateTime time)
        {
            DataSet ds = Basic.SelectDataSet("T_SEQUENCEOPERATION", "*", "seo_time like '" + time.ToString("d") + "'");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过时间查询所有序列号操作记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSequenceOperationToDataTable(DateTime time)
        {
            DataTable dt = Basic.SelectDataTable("T_SEQUENCEOPERATION", "*", "seo_time like '" + time.ToString("d") + "'");
            if (dt == null) return null; else return dt;
        }
        #endregion

        #region 公开类
        /// <summary>
        /// 添加序列号操作记录信息
        /// </summary>
        /// <param name="sequence">序列号</param>
        /// <param name="content">操作内容</param>
        /// <returns></returns>
        public static bool DoInsertSequenceOperation(string sequence, string content)
        {
            return InsertSequenceOperation(sequence, content);
        }
        /// <summary>
        /// 查询所有的序列号操作记录信息
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectSequenceOperationToDataSet()
        {
            return SelectSequenceOperationToDataSet();
        }
        /// <summary>
        /// 查询所有的序列号操作记录信息
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectSequenceOperationToDataTable()
        {
            return SelectSequenceOperationToDataTable();
        }
        /// <summary>
        /// 通过序列号查询所有序列号操作记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectSequenceOperationToDataSet(string sequence)
        {
            return SelectSequenceOperationToDataSet(sequence);
        }
        /// <summary>
        /// 通过序列号查询所有序列号操作记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectSequenceOperationToDataTable(string sequence)
        {
            return SelectSequenceOperationToDataTable(sequence);
        }
        /// <summary>
        /// 通过时间查询所有序列号操作记录信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectSequenceOperationToDataSet(DateTime time)
        {
            return SelectSequenceOperationToDataSet(time);
        }
        /// <summary>
        /// 通过时间查询所有序列号操作记录信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectSequenceOperationToDataTable(DateTime time)
        {
            return SelectSequenceOperationToDataTable(time);
        }
        #endregion
    }
}
