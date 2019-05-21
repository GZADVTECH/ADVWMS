using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Basics;

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
        /// <summary>
        /// 查询薪资信息，返回DataSet数据类型
        /// </summary>
        /// <param name="time">查询时间</param>
        /// <returns></returns>
        public static DataSet SelectSalaryToDataSet(DateTime time)
        {
            try
            {
                DataSet ds = Basic.SelectDataSet("T_SALARY", "*", "Convert(varchar,s_time,111)="+time == null ? "" : time.ToString("yyyy/MM/dd"));
                if (ds == null) return null;
                else return ds;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询薪资信息，返回DataTable数据类型
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DataTable SelectSalaryToDataTable(DateTime time)
        {
            try
            {
                DataTable dt = Basic.SelectDataTable("T_SALARY", "*", "Convert(varchar,s_time,111)=" + time == null ? "" : time.ToString("yyyy/MM/dd"));
                if (dt == null) return null;
                else return dt;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 通过薪资ID更改基本工资信息
        /// </summary>
        /// <param name="basicwage">基本工资</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfBasicwageById(string basicwage, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_basicwage", basicwage, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改转正津贴信息
        /// </summary>
        /// <param name="formal">转正津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfFormalById(string formal, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_formal", formal, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改职位津贴信息
        /// </summary>
        /// <param name="position">职位津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfPositionById(string position, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_position", position, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改能力津贴信息
        /// </summary>
        /// <param name="ability">能力津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfAbilityById(string ability, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_ability", ability, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改交通津贴信息
        /// </summary>
        /// <param name="traffic">交通津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfTrafficById(string traffic, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_traffic", traffic, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改过节津贴信息
        /// </summary>
        /// <param name="festival">过节津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfFestivalById(string festival, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_festival", festival, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改全勤奖信息
        /// </summary>
        /// <param name="full">全勤奖</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfFullById(string full, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_full", full, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改奖金信息
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfBonusById(string bonus, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_bonus", bonus, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改住房公积金信息
        /// </summary>
        /// <param name="housing">住房公积金</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfHousingById(string housing,string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_housing", housing, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改社会保险信息
        /// </summary>
        /// <param name="insurance">社会保险</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfInsuranceById(string insurance,string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_insurance", insurance, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改话费信息
        /// </summary>
        /// <param name="bill">话费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfBillById(string bill, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_bill", bill, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改考勤信息
        /// </summary>
        /// <param name="attendance">考勤</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfAttendanceById(string attendance, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_attendance", attendance, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改卫生费信息
        /// </summary>
        /// <param name="hygiene">卫生费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfHygieneById(string hygiene, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_hygiene", hygiene, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改餐费信息
        /// </summary>
        /// <param name="meals">餐费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfMealsById(string meals, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_meals", meals, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改水电费信息
        /// </summary>
        /// <param name="utilites">水电费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfUtilitesById(string utilites, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_utilites", utilites, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改个人所得税信息
        /// </summary>
        /// <param name="tax">个人所得税</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfTaxById(string tax, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_tax", tax, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改状态信息
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public static bool UpdateSalaryOfStateById(string state, string sid)
        {
            bool states = Basic.Change("T_SALARY", "s_state", state, "s_id", sid);
            if (states) return true; else return false;
        }
        /// <summary>
        /// 通过薪资ID更改备注信息
        /// </summary>
        /// <param name="remark">备注</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfRemarkById(string remark, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_remark", remark, "s_id", sid);
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改基本工资信息
        /// </summary>
        /// <param name="basicwage">基本工资</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfBasicwageByUidAndTime(string basicwage, string uid,string time)
        {
            bool state = Basic.FullChange("T_SALARY", basicwage, "s_uid="+uid+" and Convert(varchar,"+time+",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改转正津贴信息
        /// </summary>
        /// <param name="formal">转正津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfFormalByUidAndTime(string formal, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", formal, "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改职位津贴信息
        /// </summary>
        /// <param name="position">职位津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfPositionByUidAndTime(string position, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", position,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改能力津贴信息
        /// </summary>
        /// <param name="ability">能力津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfAbilityByUidAndTime(string ability, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", ability,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改交通津贴信息
        /// </summary>
        /// <param name="traffic">交通津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfTrafficByUidAndTime(string traffic, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  traffic,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改过节津贴信息
        /// </summary>
        /// <param name="festival">过节津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfFestivalByUidAndTime(string festival, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  festival,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改全勤奖信息
        /// </summary>
        /// <param name="full">全勤奖</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfFullByUidAndTime(string full, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  full,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改奖金信息
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfBonusByUidAndTime(string bonus, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  bonus,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改住房公积金信息
        /// </summary>
        /// <param name="housing">住房公积金</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfHousingByUidAndTime(string housing, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  housing,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改社会保险信息
        /// </summary>
        /// <param name="insurance">社会保险</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfInsuranceByUidAndTime(string insurance, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  insurance,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改话费信息
        /// </summary>
        /// <param name="bill">话费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfBillByUidAndTime(string bill, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  bill,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改考勤信息
        /// </summary>
        /// <param name="attendance">考勤</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfAttendanceByUidAndTime(string attendance, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  attendance,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改卫生费信息
        /// </summary>
        /// <param name="hygiene">卫生费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfHygieneByUidAndTime(string hygiene, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  hygiene,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改餐费信息
        /// </summary>
        /// <param name="meals">餐费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfMealsByUidAndTime(string meals, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  meals,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改水电费信息
        /// </summary>
        /// <param name="utilites">水电费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfUtilitesByUidAndTime(string utilites, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  utilites,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改个人所得税信息
        /// </summary>
        /// <param name="tax">个人所得税</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfTaxByUidAndTime(string tax, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  tax,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改状态信息
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfStateByUidAndTime(string state, string uid, string time)
        {
            bool states = Basic.FullChange("T_SALARY",  state,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (states) return true; else return false;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改备注信息
        /// </summary>
        /// <param name="remark">备注</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool UpdateSalaryOfRemarkByUidAndTime(string remark, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY",  remark,  "s_uid=" + uid + " and Convert(varchar," + time + ",111)");
            if (state) return true; else return false;
        }
    }
}
