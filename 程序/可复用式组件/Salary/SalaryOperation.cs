using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Salary
{
    /// <summary>
    /// 薪资操作类
    /// </summary>
    public class SalaryOperation
    {
        /// <summary>
        /// 插入薪资信息
        /// </summary>
        /// <param name="datas">数据集</param>
        /// <returns></returns>
        public static bool InsertSalary(Dictionary<string, string> datas)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@s_basicwage",datas["basicwage"]),
                new SqlParameter("@s_formal",datas["formal"]),
                new SqlParameter("@s_position",datas["position"]),
                new SqlParameter("@s_ability",datas["ability"]),
                new SqlParameter("@s_traffic",datas["traffic"]),
                new SqlParameter("@s_festival",datas["festival"]),
                new SqlParameter("@s_full",datas["full"]),
                new SqlParameter("@s_bonus",datas["bonus"]),
                new SqlParameter("@s_housing",datas["housing"]),
                new SqlParameter("@s_insurance",datas["insurance"]),
                new SqlParameter("@s_bill",datas["bill"]),
                new SqlParameter("@s_attendance",datas["attendance"]),
                new SqlParameter("@s_hygiene",datas["hygiene"]),
                new SqlParameter("@s_meals",datas["meals"]),
                new SqlParameter("@s_utilites",datas["utilites"]),
                new SqlParameter("@s_tax",datas["tax"]),
                new SqlParameter("@s_operation",datas["operation"]),
                new SqlParameter("@s_state",datas["state"]),
                new SqlParameter("@s_remark",datas["remark"])
            };
            int state = SQLHelper.SQLOperation.Execute("SQL", "PRO_SALARY_INSERT", System.Data.CommandType.StoredProcedure, param);
            if (state > 0) return true; else return false;
        }

        public static bool UpdateSalaryOfBasicwageById(string basicwage)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@table","T_SALARY"),
                new SqlParameter("@field","s_basicwage"),
                new SqlParameter("@fieldvalue",""),
                new SqlParameter("@condition",""),
                new SqlParameter("conditionvalue","")
            };
        }
    }
}
