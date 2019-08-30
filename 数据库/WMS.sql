use master
go

create database DB_WMS
go

use DB_WMS
go 

--table of user login
create table wms_signin
(
	ws_id int identity(1,1) primary key,
	ws_number nvarchar(30) unique not null,
	ws_password nvarchar(max) not null,
	ws_name nvarchar(30) not null,
	ws_level tinyint not null,
	ws_department nvarchar(10) not null,
	ws_position nvarchar(10) not null,
	ws_status bit default(0),
)
go

--user message
create table wms_user
(
	wu_ws_id int foreign key references wms_signin(ws_id),
	wu_gender bit default(0),
	wu_age tinyint default(0),
	wu_idcard nvarchar(24),
	wu_birthday smalldatetime,
	wu_address nvarchar(255),
	wu_phone nvarchar(11),
	wu_email nvarchar(50),
	wu_remark nvarchar(255),
)
go

--sign in operation record
create table wms_signinoperation
(
	wso_id nvarchar(100) primary key,
	wso_ws_id int foreign key references wms_signin(ws_id),
	wso_time smalldatetime,
	wso_ipaddress nvarchar(30),
	wso_status bit default(0),
)
go

--goods inventory
create table wms_goods_inventory
(
	wgi_id nvarchar(100) primary key,
	wgi_name nvarchar(100) not null,
	wgi_model nvarchar(100),
	wgi_amount int default(0),
	wgi_unit nvarchar(4) default('¸ö'),
	wgi_supplier int foreign key references wms_customer_supplier(wcs_id),
	wgi_remark nvarchar(100),
)
go

--goods access
create table wms_goods_access
(
	wga_wgi_id nvarchar(100) foreign key references wms_goods_inventory(wgi_id),
	wga_amount int default(0),
	wga_wps_id nvarchar(100) foreign key references wms_purchasing_sales(wps_id),
	wga_type nvarchar(10),
	wga_pncode nvarchar(100),
	wga_location nvarchar(100),
	wga_time smalldatetime,
	wga_ws_id int foreign key references wms_signin(ws_id),
	wga_remark nvarchar(100),
)
go

--purchasing and sales
create table wms_purchasing_sales
(
	wps_id nvarchar(100) primary key,
	wps_inside nvarchar(100),
	wps_time smalldatetime,
	wps_customer int foreign key references wms_customer_supplier(wcs_id),
	wps_outside nvarchar(100),
	wps_cycle int default(0),
	wps_status bit default(0),
	wps_ws_id int foreign key references wms_signin(ws_id),
	wps_type bit default(0),
)
go

--purchasing and sales 's goods
create table wms_goods_of_purchasing_sales
(
	wgops_id nvarchar(100) primary key,
	wgops_wps_id nvarchar(100) foreign key references wms_purchasing_sales(wps_id),
	wgops_wgi_id nvarchar(100) foreign key references wms_goods_inventory(wgi_id),
	wgops_amount int default(0),
	wgops_price money default(0),
	wgops_tax decimal default(0),
	wgops_taxprice money default(0),
	wgops_time smalldatetime,
)
go

--serial record
create table wms_serial_record
(
	wsr_id nvarchar(100) primary key,
	wsr_wps_id nvarchar(100) foreign key references wms_purchasing_sales(wps_id),
	wsr_wgi_id nvarchar(100) foreign key references wms_goods_inventory(wgi_id),
	wsr_serial nvarchar(100),
	wsr_time smalldatetime,
)
go

--serial message
create table wms_serial
(
	ws_id nvarchar(100) primary key,
	ws_wgi_id nvarchar(100) foreign key references wms_goods_inventory(wgi_id),
	ws_serial nvarchar(100) unique not null,
	ws_status bit default(1),
)
go


--supplier and customer
create table wms_customer_supplier
(
	wcs_id int primary key identity(1,1),
	wcs_companyname nvarchar(100) not null,
	wcs_customer nvarchar(30),
	wcs_contact nvarchar(30),
	wcs_address nvarchar(255),
	wcs_remark nvarchar(100),
	wcs_status bit default(0),
	wcs_type bit default(0),
)
go