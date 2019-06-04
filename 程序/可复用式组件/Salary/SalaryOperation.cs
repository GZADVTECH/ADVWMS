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
        #region 加密类
        /// <summary>
        /// 添加薪资信息
        /// </summary>
        /// <param name="basicwage">基本工资</param>
        /// <param name="formal">转正津贴</param>
        /// <param name="position">职位津贴</param>
        /// <param name="ability">能力津贴</param>
        /// <param name="traffic">交通津贴</param>
        /// <param name="festival">过节津贴</param>
        /// <param name="full">全勤奖</param>
        /// <param name="bonus">奖金</param>
        /// <param name="housing">住房公积金</param>
        /// <param name="insurance">社会保险</param>
        /// <param name="bill">话费</param>
        /// <param name="attendance">考勤</param>
        /// <param name="hygiene">卫生费</param>
        /// <param name="meals">餐费</param>
        /// <param name="utilites">水电费</param>
        /// <param name="tax">个人所得税</param>
        /// <param name="operation">操作员编号</param>
        /// <param name="state">状态</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        private static bool InsertSalary(decimal basicwage, decimal formal, decimal position, decimal ability, decimal traffic, decimal festival, decimal full, decimal bonus, decimal housing,
            decimal insurance, decimal bill, decimal attendance, decimal hygiene, decimal meals, decimal utilites, decimal tax, string operation, string state, string remark)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@s_basicwage",basicwage),
                new SqlParameter("@s_formal",formal),
                new SqlParameter("@s_position",position),
                new SqlParameter("@s_ability",ability),
                new SqlParameter("@s_traffic",traffic),
                new SqlParameter("@s_festival",festival),
                new SqlParameter("@s_full",full),
                new SqlParameter("@s_bonus",bonus),
                new SqlParameter("@s_housing",housing),
                new SqlParameter("@s_insurance",insurance),
                new SqlParameter("@s_bill",bill),
                new SqlParameter("@s_attendance",attendance),
                new SqlParameter("@s_hygiene",hygiene),
                new SqlParameter("@s_meals",meals),
                new SqlParameter("@s_utilites",utilites),
                new SqlParameter("@s_tax",tax),
                new SqlParameter("@s_operation",operation),
                new SqlParameter("@s_state",state),
                new SqlParameter("@s_remark",remark)
            };
            int states = SQLHelper.SQLOperation.Execute("SQL", "PRO_SALARY_INSERT", System.Data.CommandType.StoredProcedure, param);
            if (states > 0) return true; else return false;
        }
        /// <summary>
        /// 查询薪资信息，返回DataSet数据类型
        /// </summary>
        /// <param name="time">查询时间</param>
        /// <returns></returns>
        private static DataSet SelectSalaryToDataSet(DateTime time)
        {
            try
            {
                DataSet ds = Basic.SelectDataSet("T_SALARY", "*", "Convert(varchar,s_time,111)='" + time == null ? "" : time.ToString("yyyy/MM/dd") + "'");
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
        private static DataTable SelectSalaryToDataTable(DateTime time)
        {
            try
            {
                DataTable dt = Basic.SelectDataTable("T_SALARY", "*", "Convert(varchar,s_time,111)='" + time == null ? "" : time.ToString("yyyy/MM/dd") + "'");
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
        private static bool UpdateSalaryOfBasicwageById(string basicwage, string sid)
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
        private static bool UpdateSalaryOfFormalById(string formal, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_formal", formal, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改职位津贴信息
        /// </summary>
        /// <param name="position">职位津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfPositionById(string position, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_position", position, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改能力津贴信息
        /// </summary>
        /// <param name="ability">能力津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfAbilityById(string ability, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_ability", ability, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改交通津贴信息
        /// </summary>
        /// <param name="traffic">交通津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfTrafficById(string traffic, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_traffic", traffic, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改过节津贴信息
        /// </summary>
        /// <param name="festival">过节津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfFestivalById(string festival, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_festival", festival, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改全勤奖信息
        /// </summary>
        /// <param name="full">全勤奖</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfFullById(string full, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_full", full, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改奖金信息
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfBonusById(string bonus, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_bonus", bonus, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改住房公积金信息
        /// </summary>
        /// <param name="housing">住房公积金</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfHousingById(string housing, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_housing", housing, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改社会保险信息
        /// </summary>
        /// <param name="insurance">社会保险</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfInsuranceById(string insurance, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_insurance", insurance, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改话费信息
        /// </summary>
        /// <param name="bill">话费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfBillById(string bill, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_bill", bill, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改考勤信息
        /// </summary>
        /// <param name="attendance">考勤</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfAttendanceById(string attendance, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_attendance", attendance, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改卫生费信息
        /// </summary>
        /// <param name="hygiene">卫生费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfHygieneById(string hygiene, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_hygiene", hygiene, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改餐费信息
        /// </summary>
        /// <param name="meals">餐费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfMealsById(string meals, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_meals", meals, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改水电费信息
        /// </summary>
        /// <param name="utilites">水电费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfUtilitesById(string utilites, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_utilites", utilites, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改个人所得税信息
        /// </summary>
        /// <param name="tax">个人所得税</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfTaxById(string tax, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_tax", tax, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过薪资ID更改状态信息
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        private static bool UpdateSalaryOfStateById(string state, string sid)
        {
            bool states = Basic.Change("T_SALARY", "s_state", state, "s_id", sid);
            return states;
        }
        /// <summary>
        /// 通过薪资ID更改备注信息
        /// </summary>
        /// <param name="remark">备注</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfRemarkById(string remark, string sid)
        {
            bool state = Basic.Change("T_SALARY", "s_remark", remark, "s_id", sid);
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改基本工资信息
        /// </summary>
        /// <param name="basicwage">基本工资</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfBasicwageByUidAndTime(string basicwage, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", basicwage, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改转正津贴信息
        /// </summary>
        /// <param name="formal">转正津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfFormalByUidAndTime(string formal, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", formal, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改职位津贴信息
        /// </summary>
        /// <param name="position">职位津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfPositionByUidAndTime(string position, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", position, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改能力津贴信息
        /// </summary>
        /// <param name="ability">能力津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfAbilityByUidAndTime(string ability, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", ability, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改交通津贴信息
        /// </summary>
        /// <param name="traffic">交通津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfTrafficByUidAndTime(string traffic, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", traffic, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改过节津贴信息
        /// </summary>
        /// <param name="festival">过节津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfFestivalByUidAndTime(string festival, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", festival, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改全勤奖信息
        /// </summary>
        /// <param name="full">全勤奖</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfFullByUidAndTime(string full, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", full, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改奖金信息
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfBonusByUidAndTime(string bonus, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", bonus, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改住房公积金信息
        /// </summary>
        /// <param name="housing">住房公积金</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfHousingByUidAndTime(string housing, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", housing, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改社会保险信息
        /// </summary>
        /// <param name="insurance">社会保险</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfInsuranceByUidAndTime(string insurance, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", insurance, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改话费信息
        /// </summary>
        /// <param name="bill">话费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfBillByUidAndTime(string bill, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", bill, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改考勤信息
        /// </summary>
        /// <param name="attendance">考勤</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfAttendanceByUidAndTime(string attendance, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", attendance, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改卫生费信息
        /// </summary>
        /// <param name="hygiene">卫生费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfHygieneByUidAndTime(string hygiene, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", hygiene, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改餐费信息
        /// </summary>
        /// <param name="meals">餐费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfMealsByUidAndTime(string meals, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", meals, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改水电费信息
        /// </summary>
        /// <param name="utilites">水电费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfUtilitesByUidAndTime(string utilites, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", utilites, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改个人所得税信息
        /// </summary>
        /// <param name="tax">个人所得税</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfTaxByUidAndTime(string tax, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", tax, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改状态信息
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfStateByUidAndTime(string state, string uid, string time)
        {
            bool states = Basic.FullChange("T_SALARY", state, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return states;
        }
        /// <summary>
        /// 通过员工ID和查询时间更改备注信息
        /// </summary>
        /// <param name="remark">备注</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        private static bool UpdateSalaryOfRemarkByUidAndTime(string remark, string uid, string time)
        {
            bool state = Basic.FullChange("T_SALARY", remark, "s_uid='" + uid + "' and Convert(varchar,'" + time + "',111)");
            return state;
        }
        #endregion

        #region 公开类
        /// <summary>
        /// 添加薪资信息
        /// </summary>
        /// <param name="basicwage">基本工资</param>
        /// <param name="formal">转正津贴</param>
        /// <param name="position">职位津贴</param>
        /// <param name="ability">能力津贴</param>
        /// <param name="traffic">交通津贴</param>
        /// <param name="festival">过节津贴</param>
        /// <param name="full">全勤奖</param>
        /// <param name="bonus">奖金</param>
        /// <param name="housing">住房公积金</param>
        /// <param name="insurance">社会保险</param>
        /// <param name="bill">话费</param>
        /// <param name="attendance">考勤</param>
        /// <param name="hygiene">卫生费</param>
        /// <param name="meals">餐费</param>
        /// <param name="utilites">水电费</param>
        /// <param name="tax">个人所得税</param>
        /// <param name="operation">操作员编号</param>
        /// <param name="state">状态</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public static bool DoInsertSalary(decimal basicwage, decimal formal, decimal position, decimal ability, decimal traffic, decimal festival, decimal full, decimal bonus, decimal housing,
            decimal insurance, decimal bill, decimal attendance, decimal hygiene, decimal meals, decimal utilites, decimal tax, string operation, string state, string remark)
        {
            return InsertSalary(basicwage, formal, position, ability, traffic, festival, full, bonus, housing, insurance, bill, attendance, hygiene, meals, utilites, tax, operation, state, remark);
        }
        /// <summary>
        /// 查询薪资信息，返回DataSet数据类型
        /// </summary>
        /// <param name="time">查询时间</param>
        /// <returns></returns>
        public static DataSet DoSelectSalaryToDataSet(DateTime time)
        {
            return SelectSalaryToDataSet(time);
        }
        /// <summary>
        /// 查询薪资信息，返回DataTable数据类型
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DataTable DoSelectSalaryToDataTable(DateTime time)
        {
            return SelectSalaryToDataTable(time);
        }
        /// <summary>
        /// 通过薪资ID更改基本工资信息
        /// </summary>
        /// <param name="basicwage">基本工资</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfBasicwageById(string basicwage, string sid)
        {
            return UpdateSalaryOfBasicwageById(basicwage, sid);
        }
        /// <summary>
        /// 通过薪资ID更改转正津贴信息
        /// </summary>
        /// <param name="formal">转正津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfFormalById(string formal, string sid)
        {
            return UpdateSalaryOfFormalById(formal, sid);
        }
        /// <summary>
        /// 通过薪资ID更改职位津贴信息
        /// </summary>
        /// <param name="position">职位津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfPositionById(string position, string sid)
        {
            return UpdateSalaryOfPositionById(position, sid);
        }
        /// <summary>
        /// 通过薪资ID更改能力津贴信息
        /// </summary>
        /// <param name="ability">能力津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfAbilityById(string ability, string sid)
        {
            return UpdateSalaryOfAbilityById(ability, sid);
        }
        /// <summary>
        /// 通过薪资ID更改交通津贴信息
        /// </summary>
        /// <param name="traffic">交通津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfTrafficById(string traffic, string sid)
        {
            return UpdateSalaryOfTrafficById(traffic, sid);
        }
        /// <summary>
        /// 通过薪资ID更改过节津贴信息
        /// </summary>
        /// <param name="festival">过节津贴</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfFestivalById(string festival, string sid)
        {
            return UpdateSalaryOfFestivalById(festival, sid);
        }
        /// <summary>
        /// 通过薪资ID更改全勤奖信息
        /// </summary>
        /// <param name="full">全勤奖</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfFullById(string full, string sid)
        {
            return UpdateSalaryOfFullById(full, sid);
        }
        /// <summary>
        /// 通过薪资ID更改奖金信息
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfBonusById(string bonus, string sid)
        {
            return UpdateSalaryOfBonusById(bonus, sid);
        }
        /// <summary>
        /// 通过薪资ID更改住房公积金信息
        /// </summary>
        /// <param name="housing">住房公积金</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfHousingById(string housing, string sid)
        {
            return UpdateSalaryOfHousingById(housing, sid);
        }
        /// <summary>
        /// 通过薪资ID更改社会保险信息
        /// </summary>
        /// <param name="insurance">社会保险</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfInsuranceById(string insurance, string sid)
        {
            return UpdateSalaryOfInsuranceById(insurance, sid);
        }
        /// <summary>
        /// 通过薪资ID更改话费信息
        /// </summary>
        /// <param name="bill">话费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfBillById(string bill, string sid)
        {
            return UpdateSalaryOfBillById(bill, sid);
        }
        /// <summary>
        /// 通过薪资ID更改考勤信息
        /// </summary>
        /// <param name="attendance">考勤</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfAttendanceById(string attendance, string sid)
        {
            return UpdateSalaryOfAttendanceById(attendance, sid);
        }
        /// <summary>
        /// 通过薪资ID更改卫生费信息
        /// </summary>
        /// <param name="hygiene">卫生费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfHygieneById(string hygiene, string sid)
        {
            return UpdateSalaryOfHygieneById(hygiene, sid);
        }
        /// <summary>
        /// 通过薪资ID更改餐费信息
        /// </summary>
        /// <param name="meals">餐费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfMealsById(string meals, string sid)
        {
            return UpdateSalaryOfMealsById(meals, sid);
        }
        /// <summary>
        /// 通过薪资ID更改水电费信息
        /// </summary>
        /// <param name="utilites">水电费</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfUtilitesById(string utilites, string sid)
        {
            return UpdateSalaryOfUtilitesById(utilites, sid);
        }
        /// <summary>
        /// 通过薪资ID更改个人所得税信息
        /// </summary>
        /// <param name="tax">个人所得税</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfTaxById(string tax, string sid)
        {
            return UpdateSalaryOfTaxById(tax, sid);
        }
        /// <summary>
        /// 通过薪资ID更改状态信息
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfStateById(string state, string sid)
        {
            return UpdateSalaryOfStateById(state, sid);
        }
        /// <summary>
        /// 通过薪资ID更改备注信息
        /// </summary>
        /// <param name="remark">备注</param>
        /// <param name="sid">薪资ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfRemarkById(string remark, string sid)
        {
            return UpdateSalaryOfRemarkById(remark, sid);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改基本工资信息
        /// </summary>
        /// <param name="basicwage">基本工资</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfBasicwageByUidAndTime(string basicwage, string uid, string time)
        {
            return UpdateSalaryOfBasicwageByUidAndTime(basicwage, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改转正津贴信息
        /// </summary>
        /// <param name="formal">转正津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfFormalByUidAndTime(string formal, string uid, string time)
        {
            return UpdateSalaryOfFormalByUidAndTime(formal, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改职位津贴信息
        /// </summary>
        /// <param name="position">职位津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfPositionByUidAndTime(string position, string uid, string time)
        {
            return UpdateSalaryOfPositionByUidAndTime(position, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改能力津贴信息
        /// </summary>
        /// <param name="ability">能力津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfAbilityByUidAndTime(string ability, string uid, string time)
        {
            return UpdateSalaryOfAbilityByUidAndTime(ability, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改交通津贴信息
        /// </summary>
        /// <param name="traffic">交通津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfTrafficByUidAndTime(string traffic, string uid, string time)
        {
            return UpdateSalaryOfTrafficByUidAndTime(traffic, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改过节津贴信息
        /// </summary>
        /// <param name="festival">过节津贴</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfFestivalByUidAndTime(string festival, string uid, string time)
        {
            return UpdateSalaryOfFestivalByUidAndTime(festival, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改全勤奖信息
        /// </summary>
        /// <param name="full">全勤奖</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfFullByUidAndTime(string full, string uid, string time)
        {
            return UpdateSalaryOfFullByUidAndTime(full, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改奖金信息
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfBonusByUidAndTime(string bonus, string uid, string time)
        {
            return UpdateSalaryOfBonusByUidAndTime(bonus, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改住房公积金信息
        /// </summary>
        /// <param name="housing">住房公积金</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfHousingByUidAndTime(string housing, string uid, string time)
        {
            return UpdateSalaryOfHousingByUidAndTime(housing, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改社会保险信息
        /// </summary>
        /// <param name="insurance">社会保险</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfInsuranceByUidAndTime(string insurance, string uid, string time)
        {
            return UpdateSalaryOfInsuranceByUidAndTime(insurance, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改话费信息
        /// </summary>
        /// <param name="bill">话费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfBillByUidAndTime(string bill, string uid, string time)
        {
            return UpdateSalaryOfBillByUidAndTime(bill, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改考勤信息
        /// </summary>
        /// <param name="attendance">考勤</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfAttendanceByUidAndTime(string attendance, string uid, string time)
        {
            return UpdateSalaryOfAttendanceByUidAndTime(attendance, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改卫生费信息
        /// </summary>
        /// <param name="hygiene">卫生费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfHygieneByUidAndTime(string hygiene, string uid, string time)
        {
            return UpdateSalaryOfHygieneByUidAndTime(hygiene, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改餐费信息
        /// </summary>
        /// <param name="meals">餐费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfMealsByUidAndTime(string meals, string uid, string time)
        {
            return UpdateSalaryOfMealsByUidAndTime(meals, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改水电费信息
        /// </summary>
        /// <param name="utilites">水电费</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfUtilitesByUidAndTime(string utilites, string uid, string time)
        {
            return UpdateSalaryOfUtilitesByUidAndTime(utilites, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改个人所得税信息
        /// </summary>
        /// <param name="tax">个人所得税</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfTaxByUidAndTime(string tax, string uid, string time)
        {
            return UpdateSalaryOfTaxByUidAndTime(tax, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改状态信息
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfStateByUidAndTime(string state, string uid, string time)
        {
            return UpdateSalaryOfStateByUidAndTime(state, uid, time);
        }
        /// <summary>
        /// 通过员工ID和查询时间更改备注信息
        /// </summary>
        /// <param name="remark">备注</param>
        /// <param name="time">查询时间</param>
        /// <param name="uid">员工ID</param>
        /// <returns></returns>
        public static bool DoUpdateSalaryOfRemarkByUidAndTime(string remark, string uid, string time)
        {
            return UpdateSalaryOfRemarkByUidAndTime(remark, uid, time);
        }
        #endregion
    }
}
