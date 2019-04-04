use master 
go 

create database DB_ADVWMS
on
(
	name='DB_ADVWMS.mdf',
	filename='E:\SelfDocument\CSharp\ADV-WMS\数据库\DB_ADVWMS.mdf'
)
go

use DB_ADVWMS
go

--登陆表
create table T_LOGIN
(
	l_id int primary key identity(1,1),
	l_accountnumber nvarchar(24) not null,
	l_password nvarchar(max) not null,
	l_level tinyint not null,
	l_position nvarchar(20),
	l_department nvarchar(20),
	l_state bit
)
go

--用户信息表
create table T_USER
(
	u_id int foreign key references T_LOGIN(l_id),
	u_name nvarchar(36) not null,
	u_gender bit,
	u_age tinyint,
	u_idcard nvarchar(18),
	u_birthday smalldatetime,
	u_address nvarchar(255),
	u_phone nvarchar(11),
	u_remark nvarchar(255),
	u_state bit
)
go

--ALTER TABLE T_USER WITH NOCHECK ADD CONSTRAINT T_LOGIN PRIMARY KEY NONCLUSTERED(u_id,l_id)
--go

--报表模板信息表
create table T_REPORT
(
	r_id int primary key identity(1,1),
	r_uid int foreign key references T_LOGIN(l_id),
	r_name nvarchar(30) not null,
	r_route nvarchar(max) not null,
	r_remark nvarchar(255),
	r_state bit
)
go

--待办事件表
create table T_EVENT
(
	e_id int primary key identity(1,1),
	e_time smalldatetime,
	e_content nvarchar(255),
	e_releaseid int foreign key references T_LOGIN(l_id),
	e_handleid int foreign key references T_LOGIN(l_id),
	e_complete smalldatetime,
	e_state nvarchar(10)
)
go

--薪资信息表
create table T_SALARY
(
	s_id int primary key identity(1,1),
	s_uid int foreign key references T_LOGIN(l_id),
	s_time smalldatetime,
	s_basicwage smallint,
	s_formal smallint,
	s_position smallint,
	s_ability smallint,
	s_traffic smallint,
	s_festival smallint,
	s_full smallint,
	s_bonus smallint,
	s_housing smallint,
	s_insurance smallint,
	s_bill smallint,
	s_attendance smallint,
	s_hygiene smallint,
	s_meals smallint,
	s_utilites smallint,
	s_tax smallint,
	s_operation int foreign key references T_LOGIN(l_id),
	s_state nvarchar(10),
	s_remark nvarchar(255)
)
go

--考勤信息表
create table T_ATTENDANCE
(
	a_id int primary key identity(1,1),
	a_uid int foreign key references T_LOGIN(l_id),
	a_time smalldatetime,
	a_type nvarchar(10)
)
go

--出勤申请表
create table T_APPLY
(
	ap_id int primary key identity(1,1),
	ap_uid int foreign key references T_LOGIN(l_id),
	ap_applytime smalldatetime,
	ap_attendance smalldatetime,
	ap_endtime smalldatetime,
	ap_comtent nvarchar(255),
	ap_type nvarchar(10),
	ap_state nvarchar(10) 
)
go

--报销信息表
create table T_REIMBURSEMENT
(
	r_id int primary key identity(1,1),
	r_uid int foreign key references T_LOGIN(l_id),
	r_allprice money,
	r_remark nvarchar(255),
	r_state nvarchar(10)
)
go

--报销内容表
create table T_REIMBURSEMENTCONTENT
(
	rc_id int primary key identity(1,1),
	rc_rid int foreign key references T_REIMBURSEMENT(r_id),
	rc_content nvarchar(255),
	rc_price money
)
go

--货物信息表
create table T_GOODS
(
	g_id int primary key identity(1,1),
	g_name nvarchar(30) not null,
	g_model nvarchar(30),
	g_pncode nvarchar(30),
	g_state nvarchar(10),
	g_remark nvarchar(255)
)
go

--采销货物表
create table T_PURCHASESALE
(
	ps_id nvarchar(255) primary key,
	ps_gid int foreign key references T_GOODS(g_id),
	ps_price money,
	ps_tax smallint,
	ps_taxprice int,
	ps_time smalldatetime
)
go

--客供信息表
create table T_CUSTOMER
(
	c_id int primary key identity(1,1),
	c_companyname nvarchar(100) not null,
	c_customer nvarchar(30),
	c_contact nvarchar(30),
	c_address nvarchar(255),
	c_remark nvarchar(255),
	c_state nvarchar(10),
	c_type nvarchar(10)
)
go

--采销信息表
create table T_PURCHASESALEMESSAGE
(
	psm_id nvarchar(255) foreign key references T_PURCHASESALE(ps_id),
	psm_insidenumber nvarchar(30),
	psm_ordertime smalldatetime,
	psm_customer int foreign key references T_CUSTOMER(c_id),
	psm_uid int foreign key references T_LOGIN(l_id),
	psm_estimatetime smalldatetime,
	psm_state nvarchar(10),
	psm_operation int foreign key references T_LOGIN(l_id),
	psm_type nvarchar(10)
)
go

--仓库货物出入表
create table T_ACCESS
(
	ac_id int foreign key references T_GOODS(g_id),
	ac_number int,
	ac_ordernumber nvarchar(255) foreign key references T_PURCHASESALE(ps_id),
	ac_warehouse nvarchar(30),
	ac_time smalldatetime,
	ac_uid int foreign key references T_LOGIN(l_id),
	ac_remark nvarchar(255)
)
go

--序列号记录表
create table T_SEQUENCE
(
	se_id nvarchar(30),
	se_gid int foreign key references T_GOODS(g_id),
	se_sequence nvarchar(30) primary key,
	se_time smalldatetime,
	se_state nvarchar(10)
)
go

--序列号操作记录表
create table T_SEQUENCEOPERATION
(
	seo_sequence nvarchar(30) foreign key references T_SEQUENCE(se_sequence),
	seo_operationcontent nvarchar(255),
	seo_time smalldatetime
)
go

--库存表
create table T_STOCK
(
	s_id int foreign key references T_GOODS(g_id),
	s_number int,
	s_company nvarchar(2)
)
go

--快递信息表
create table T_EXPRESS
(
	e_id int ,
	e_expressnumber nvarchar(30),
	e_expressname nvarchar(30),
	e_mailtime smalldatetime,
	e_receivetime smalldatetime,
)
go

--发票联表
create table T_INVOICE
(
	i_ordernumber nvarchar(255) foreign key references T_PURCHASESALE(ps_id),
	i_invoicenumber nvarchar(30),
	i_allprice money,
	i_time smalldatetime,
	i_remark nvarchar(255),
	i_state nvarchar(10),
	i_uid int foreign key references T_LOGIN(l_id)
)
go

--售后信息表
create table T_AFTERSALE
(
	as_id int primary key identity(1,1),
	as_ordernumber nvarchar(255) foreign key references T_PURCHASESALE(ps_id),
	as_gid int foreign key references T_GOODS(g_id),
	as_receivetime smalldatetime,
	as_content nvarchar(255),
	as_situation nvarchar(255),
	as_sequence nvarchar(30) foreign key references T_SEQUENCE(se_sequence),
	as_state nvarchar(10),
	as_remark nvarchar(255),
	as_type nvarchar(10)
)
go