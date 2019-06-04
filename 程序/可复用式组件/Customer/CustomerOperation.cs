using Basics;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer
{
    /// <summary>
    /// 客供信息类
    /// </summary>
    public class CustomerOperation
    {
        #region 加密类
        /// <summary>
        /// 插入客供信息
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <param name="customer">负责人</param>
        /// <param name="contact">联系方式</param>
        /// <param name="addresss">联系地址</param>
        /// <param name="remark">备注</param>
        /// <param name="state">状态</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        private static bool InsertCustomer(string company, string customer, string contact, string addresss, string remark, string state, string type)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@c_companyname",company),
                new SqlParameter("@c_customer",customer),
                new SqlParameter("@c_contact",contact),
                new SqlParameter("@c_address",addresss),
                new SqlParameter("@c_remark",remark),
                new SqlParameter("@c_state",state),
                new SqlParameter("@c_type",type)
            };
            int states = SQLOperation.Execute("SQL", "PRO_CUSTOMER_INSERT", CommandType.StoredProcedure, param);
            if (states > 0) return true; else return false;
        }
        /// <summary>
        /// 查询客供信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        private static DataSet SelectCustomerToDataSet()
        {
            DataSet ds = Basic.SelectDataSet("T_CUSTOMER", "*", "");
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 查询所有客供信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectCustomerToDataTable()
        {
            DataTable dt = Basic.SelectDataTable("T_CUSTOMER", "*", "");
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过查询条件查询客供信息，返回DataSet数据类型
        /// </summary>
        /// <param name="conditionvalue">查询条件</param>
        /// <returns></returns>
        private static DataSet SelectCustomerToDataSetByCondition(string conditionvalue)
        {
            string value = "";
            if (conditionvalue.Contains("公司"))
            {
                value = "c_companyname like '%" + conditionvalue + "%'";
            }
            else if (Regex.IsMatch(conditionvalue, @"^[0-9]*$"))
            {
                value = "c_contact like '%" + conditionvalue + "%'";
            }
            else if (conditionvalue.Contains("省") || conditionvalue.Contains("市") || (conditionvalue.Contains("区") || conditionvalue.Contains("县")))
            {
                value = "c_address like '%" + conditionvalue + "%'";
            }
            else if (conditionvalue == "客户")
            {
                value = "c_type='客户'";
            }
            else if (conditionvalue == "供应商")
            {
                value = "c_type='供应商'";
            }
            else
            {
                value = "c_customer like '%" + conditionvalue + "%'";
            }
            DataSet ds = Basic.SelectDataSet("T_CUSTOMER", "*", value);
            if (ds == null) return null; else return ds;
        }
        /// <summary>
        /// 通过查询条件查询客供信息，返回DataTable数据类型
        /// </summary>
        /// <param name="conditionvalue">查询条件</param>
        /// <returns></returns>
        private static DataTable SelectCustomerToDataTableByCondition(string conditionvalue)
        {
            string value = "";
            if (conditionvalue.Contains("公司"))
            {
                value = "c_companyname like '%" + conditionvalue + "%'";
            }
            else if (Regex.IsMatch(conditionvalue, @"^[0-9]*$"))
            {
                value = "c_contact like '%" + conditionvalue + "%'";
            }
            else if (conditionvalue.Contains("省") || conditionvalue.Contains("市") || (conditionvalue.Contains("区") || conditionvalue.Contains("县")))
            {
                value = "c_address like '%" + conditionvalue + "%'";
            }
            else if (conditionvalue == "客户")
            {
                value = "c_type='客户'";
            }
            else if (conditionvalue == "供应商")
            {
                value = "c_type='供应商'";
            }
            else
            {
                value = "c_customer like '%" + conditionvalue + "%'";
            }
            DataTable dt = Basic.SelectDataTable("T_CUSTOMER", "*", value);
            if (dt == null) return null; else return dt;
        }
        /// <summary>
        /// 通过客供编号更改公司名称
        /// </summary>
        /// <param name="fieldvalue">公司名称</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        private static bool UpdateCustomerOfCompanynameById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_CUSTOMER", "c_companyname", fieldvalue, "c_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过客供编号更改负责人
        /// </summary>
        /// <param name="fieldvalue">负责人</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        private static bool UpdateCustomerOfCustomerById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_CUSTOMER", "c_customer", fieldvalue, "c_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过客供编号更改联系方式
        /// </summary>
        /// <param name="fieldvalue">联系方式</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        private static bool UpdateCustomerOfContactById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_CUSTOMER", "c_contact", fieldvalue, "c_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过客供编号更改联系地址
        /// </summary>
        /// <param name="fieldvalue">联系地址</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        private static bool UpdateCustomerOfAddressById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_CUSTOMER", "c_address", fieldvalue, "c_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过客供编号更改备注
        /// </summary>
        /// <param name="fieldvalue">备注</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        private static bool UpdateCustomerOfRemarkById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_CUSTOMER", "c_remark", fieldvalue, "c_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过客供编号更改状态
        /// </summary>
        /// <param name="fieldvalue">状态</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        private static bool UpdateCustomerOfStateById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_CUSTOMER", "c_state", fieldvalue, "c_id", conditionvalue);
            return state;
        }
        /// <summary>
        /// 通过客供编号更改类型
        /// </summary>
        /// <param name="fieldvalue">类型</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        private static bool UpdateCustomerOfTypeById(string fieldvalue, string conditionvalue)
        {
            bool state = Basic.Change("T_CUSTOMER", "c_type", fieldvalue, "c_id", conditionvalue);
            return state;
        }
        #endregion

        #region 公开类
        /// <summary>
        /// 插入客供信息
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <param name="customer">负责人</param>
        /// <param name="contact">联系方式</param>
        /// <param name="addresss">联系地址</param>
        /// <param name="remark">备注</param>
        /// <param name="state">状态</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool DoInsertCustomer(string company, string customer, string contact, string addresss, string remark, string state, string type)
        {
            return InsertCustomer(company, customer, contact, addresss, remark, state, type);
        }
        /// <summary>
        /// 查询客供信息，返回DataSet数据类型
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSelectCustomerToDataSet()
        {
            return SelectCustomerToDataSet();
        }
        /// <summary>
        /// 查询所有客供信息，返回DataTable数据类型
        /// </summary>
        /// <returns></returns>
        public static DataTable DoSelectCustomerToDataTable()
        {
            return SelectCustomerToDataTable();
        }
        /// <summary>
        /// 通过查询条件查询客供信息，返回DataSet数据类型
        /// </summary>
        /// <param name="conditionvalue">查询条件</param>
        /// <returns></returns>
        public static DataSet DoSelectCustomerToDataSetByCondition(string conditionvalue)
        {
            return SelectCustomerToDataSetByCondition(conditionvalue);
        }
        /// <summary>
        /// 通过查询条件查询客供信息，返回DataTable数据类型
        /// </summary>
        /// <param name="conditionvalue">查询条件</param>
        /// <returns></returns>
        public static DataTable DoSelectCustomerToDataTableByCondition(string conditionvalue)
        {
            return SelectCustomerToDataTableByCondition(conditionvalue);
        }
        /// <summary>
        /// 通过客供编号更改公司名称
        /// </summary>
        /// <param name="fieldvalue">公司名称</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        public static bool DoUpdateCustomerOfCompanynameById(string fieldvalue, string conditionvalue)
        {
            return UpdateCustomerOfCompanynameById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过客供编号更改负责人
        /// </summary>
        /// <param name="fieldvalue">负责人</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        public static bool DoUpdateCustomerOfCustomerById(string fieldvalue, string conditionvalue)
        {
            return UpdateCustomerOfCustomerById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过客供编号更改联系方式
        /// </summary>
        /// <param name="fieldvalue">联系方式</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        public static bool DoUpdateCustomerOfContactById(string fieldvalue, string conditionvalue)
        {
            return UpdateCustomerOfContactById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过客供编号更改联系地址
        /// </summary>
        /// <param name="fieldvalue">联系地址</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        public static bool DoUpdateCustomerOfAddressById(string fieldvalue, string conditionvalue)
        {
            return UpdateCustomerOfAddressById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过客供编号更改备注
        /// </summary>
        /// <param name="fieldvalue">备注</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        public static bool DoUpdateCustomerOfRemarkById(string fieldvalue, string conditionvalue)
        {
            return UpdateCustomerOfRemarkById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过客供编号更改状态
        /// </summary>
        /// <param name="fieldvalue">状态</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        public static bool DoUpdateCustomerOfStateById(string fieldvalue, string conditionvalue)
        {
            return UpdateCustomerOfStateById(fieldvalue, conditionvalue);
        }
        /// <summary>
        /// 通过客供编号更改类型
        /// </summary>
        /// <param name="fieldvalue">类型</param>
        /// <param name="conditionvalue">客供编号</param>
        /// <returns></returns>
        public static bool DoUpdateCustomerOfTypeById(string fieldvalue, string conditionvalue)
        {
            return UpdateCustomerOfTypeById(fieldvalue, conditionvalue);
        }
        #endregion
    }
}
