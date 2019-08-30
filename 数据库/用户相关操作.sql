--用户注册
create procedure PRO_LOGIN_REGISTER
@l_accountnumber nvarchar(24),
@l_password nvarchar(max),
@l_level tinyint,
@l_position nvarchar(20),
@l_department nvarchar(20),
@u_name nvarchar(36)
as
begin
	begin try
	begin transaction tran_login_register
	insert into T_LOGIN values(@l_accountnumber,@l_password,@l_level,@l_position,@l_department,0)
	insert into T_USER(u_id,u_name) values((select l_id from T_LOGIN where l_accountnumber=@l_accountnumber),@u_name)
	commit transaction tran_login_register
	end try
	begin catch
	rollback transaction tran_login_register
	end catch
end
go
--测试
exec PRO_LOGIN_REGISTER 'Jason','E10ABC3949BA59ABBE56E057F20F883E',1,'经理','管理部','杰森'
go
select * from T_LOGIN
go
select * from T_USER
go

--登录验证
create procedure PRO_LOGIN_VERIFICATION
@l_accountnumber nvarchar(24),
@l_password nvarchar(max)
as
begin
	select l_id,l_level,l_position,l_department,l_state from T_LOGIN where l_accountnumber=@l_accountnumber and l_password=@l_password
end
go
--测试
exec PRO_LOGIN_VERIFICATION 'Jason','E10ABC3949BA59ABBE56E057F20F883E'
go

--通用数据信息查询
create procedure PRO_SELECT
@table nvarchar(30),
@fieldvalue nvarchar(225),
@conditionvalue nvarchar(225)=''
as
begin
	begin try
	begin transaction
	declare @sql nvarchar(max)
	set @sql=N'select '+@fieldvalue+' from '+@table+' where 1=1 '
	if(@conditionvalue<>'') 
	begin
	set @sql+='and '+@conditionvalue
	end
	exec sp_executesql @sql,N' @table nvarchar(30),@fieldvalue nvarchar(225),@conditionvalue nvarchar(225)',@table,@fieldvalue,@conditionvalue
	commit transaction
	end try
	begin catch
	rollback transaction
	end catch
end
go
--测试
exec PRO_SELECT 'T_LOGIN','*','l_id=1'
go

--通用数据信息修改
create procedure PRO_FULLUPDATE
@table nvarchar(30),
@fieldvalue nvarchar(225),
@conditionvalue nvarchar(225)=''
as
begin
	begin try
	begin transaction
	declare @sql nvarchar(max)
	set @sql=N'update '+@table+' set '+@fieldvalue+' where 1=1 '
	if(@conditionvalue<>'') 
	begin
	set @sql+='and '+@conditionvalue
	end
	exec sp_executesql @sql,N' @table nvarchar(30),@fieldvalue nvarchar(225),@conditionvalue nvarchar(225)',@table,@fieldvalue,@conditionvalue
	commit transaction
	end try
	begin catch
	rollback transaction
	end catch
end
go

--通用数据信息修改
create procedure PRO_UPDATE
@table nvarchar(30),
@field nvarchar(30),
@fieldvalue nvarchar(30),
@condition nvarchar(30),
@conditionvalue nvarchar(30)
as
begin
	begin try
	begin transaction
	declare @sql nvarchar(max)
	set @sql=N'update '+@table+' set '+@field+'=@fieldvalue where '+@condition+'=@conditionvalue'
	exec sp_executesql @sql,N' @table nvarchar(30),@field nvarchar(30),@fieldvalue nvarchar(30),@condition nvarchar(30),@conditionvalue nvarchar(30)',@table,@field,@fieldvalue,@condition,@conditionvalue
	commit transaction
	end try
	begin catch
	rollback transaction
	end catch
end
go
--测试
exec PRO_UPDATE 'T_USER','u_age','33','u_id','1'
go

--添加报表模板信息
create procedure PRO_REPORT_INSERT
@r_uid int,
@r_name nvarchar(30),
@r_route nvarchar(max),
@r_remark nvarchar(255)
as
begin
	begin try
	begin transaction
	insert into T_REPORT values(@r_uid,@r_name,@r_route,@r_remark,1)
	commit transaction
	end try
	begin catch
	rollback transaction
	end catch
end
go
--测试
exec PRO_REPORT_INSERT 1,'基础报表','E://REPORT/',''
go
select * from T_REPORT
go

--添加待办事件信息
create procedure PRO_EVENT_INSERT
@e_conent nvarchar(255),
@e_releaseid int,
@e_handleid int
as
begin
	begin try
	begin transaction
	insert into T_EVENT(e_time,e_content,e_releaseid,e_handleid,e_state) values(GETDATE(),@e_conent,@e_releaseid,@e_handleid,'未读')
	end try
	begin catch
	rollback transaction
	end catch
end
go

--添加薪资信息
create procedure PRO_SALARY_INSERT
@s_uid int,
@s_basicwage money,
@s_formal money,
@s_position money,
@s_ability money,
@s_traffic money,
@s_festival money,
@s_full money,
@s_bonus money,
@s_housing money,
@s_insurance money,
@s_bill money,
@s_attendance money,
@s_hygiene money,
@s_meals money,
@s_utilites money,
@s_tax decimal,
@s_operation int,
@s_state nvarchar(10),
@s_remark nvarchar(255)
as
begin
	begin try
	begin transaction
	insert into T_SALARY values(@s_uid,Convert(varchar,GETDATE(),111),@s_basicwage,@s_formal,@s_position,@s_ability
	,@s_traffic,@s_festival,@s_full,@s_bonus,@s_housing,@s_insurance,@s_bill,@s_attendance
	,@s_hygiene,@s_meals,@s_utilites,@s_tax,@s_operation,@s_state,@s_remark)
	commit transaction
	end try
	begin catch
		rollback transaction
	end catch
end
go

--添加考勤信息
create procedure PRO_ATTENDANCE_INSERT
@a_uid int,
@a_type nvarchar(10)
as
begin
	insert into T_ATTENDANCE values(@a_uid,GETDATE(),@a_type)
end
go

--添加出勤申请信息
create procedure PRO_APPLY_INSERT
@ap_uid int,
@ap_applytime smalldatetime,
@ap_attendance smalldatetime,
@ap_endtime smalldatetime,
@ap_comtent nvarchar(255),
@ap_type nvarchar(10),
@ap_state nvarchar(10) 
as
begin
	insert into T_APPLY values(@ap_uid,@ap_applytime,@ap_attendance,@ap_endtime,@ap_comtent,@ap_type,@ap_state)
end
go

--添加报销内容
create procedure PRO_REIMBURSEMENTCONTENT_INSERT
@rc_rid int,
@rc_content nvarchar(255),
@rc_price money
as
begin
	insert into T_REIMBURSEMENTCONTENT values(@rc_rid,@rc_content,@rc_price)
end
go

--添加报销信息
create procedure PRO_REIMBURSEMENT_INSERT
@r_uid int,
@r_allprice money,
@r_remark nvarchar(255),
@r_state nvarchar(10)
as
begin
	insert into T_REIMBURSEMENT values(@r_uid,@r_allprice,@r_remark,@r_state)
end
go

--添加货物信息
create procedure PRO_GOODS_INSERT
@g_name nvarchar(30),
@g_model nvarchar(30),
@g_pncode nvarchar(30),
@g_state nvarchar(10),
@g_remark nvarchar(255)
as
begin
	insert into T_GOODS values(@g_name,@g_model,@g_pncode,@g_state,@g_remark)
end
go

--添加采销货物
alter procedure PRO_PURCHASESALE_INSERT
@ps_id nvarchar(255),
@ps_gid int,
@ps_number decimal,
@ps_price money,
@ps_tax smallint,
@ps_taxprice money,
@ps_time smalldatetime
as
begin
	insert into T_PURCHASESALE values(@ps_id,@ps_gid,@ps_number,@ps_price,@ps_tax,@ps_taxprice,@ps_time)
end
go

--添加客供信息表
create procedure PRO_CUSTOMER_INSERT
@c_companyname nvarchar(100),
@c_customer nvarchar(30),
@c_contact nvarchar(30),
@c_address nvarchar(255),
@c_remark nvarchar(255),
@c_state nvarchar(10),
@c_type nvarchar(10)
as
begin
	insert into T_CUSTOMER values(@c_companyname,@c_customer,@c_contact,@c_address,@c_remark,@c_state,@c_type)
end
go

--添加采销信息
create procedure PRO_PURCHASESALEMESSAGE_INSERT
@psm_id nvarchar(255),
@psm_insidenumber nvarchar(30),
@psm_customer int,
@psm_uid int,
@psm_estimatetime smalldatetime,
@psm_state nvarchar(10),
@psm_operation int,
@psm_type nvarchar(10)
as
begin
	insert into T_PURCHASESALEMESSAGE values(@psm_id,@psm_insidenumber,GETDATE(),@psm_customer,@psm_uid,@psm_estimatetime,@psm_state,@psm_operation,@psm_type)
end
go

--添加仓库货物出入信息
create procedure PRO_ACCESS_INSRT
@ac_id int,
@ac_number int,
@ac_ordernumber nvarchar(255),
@ac_warehouse nvarchar(30),
@ac_uid int,
@ac_remark nvarchar(255)
as
begin
	insert into T_ACCESS values(@ac_id,@ac_number,@ac_ordernumber,@ac_warehouse,GETDATE(),@ac_uid,@ac_remark)
end
go

--添加序列号操作记录
create procedure PRO_SEQUENCEOPERATION_INSERT
@seo_sequence nvarchar(30),
@seo_operationcontent nvarchar(255)
as
begin
	insert into T_SEQUENCEOPERATION values(@seo_sequence,@seo_operationcontent,GETDATE())
end
go

--添加序列号信息
create procedure PRO_SEQUENCE_INSERT
@se_gid int,
@se_sequence nvarchar(30),
@se_state nvarchar(10)
as
begin
	insert into T_SEQUENCE values((select count(*) from T_SEQUENCE)+1,@se_gid,@se_sequence,GETDATE(),@se_state)
	exec PRO_SEQUENCEOPERATION_INSERT @se_sequence,'添加'
end
go

--添加库存信息
create procedure PRO_STOCK_INSERT
@s_id int,
@s_number int,
@s_company nvarchar(2)
as
begin
	insert into T_STOCK values(@s_id,@s_number,@s_company)
end
go

--添加快递信息
create procedure PRO_EXPRESS_INSERT
@e_id int ,
@e_expressnumber nvarchar(30),
@e_expressname nvarchar(30),
@e_mailtime smalldatetime,
@e_receivetime smalldatetime
as
begin
	insert into T_EXPRESS values(@e_id,@e_expressnumber,@e_expressname,@e_mailtime,@e_receivetime)
end
go

--添加发票联信息
create procedure PRO_INVOICE_INSERT
@i_ordernumber nvarchar(255),
@i_invoicenumber nvarchar(30),
@i_allprice money,
@i_remark nvarchar(255),
@i_state nvarchar(10),
@i_uid int
as
begin
	insert into T_INVOICE values(@i_ordernumber,@i_invoicenumber,@i_allprice,GETDATE(),@i_remark,@i_state,@i_uid)
end
go

--添加售后信息
create procedure PRO_AFTERSALE_INSERT
@as_ordernumber nvarchar(255),
@as_gid int,
@as_receivetime smalldatetime,
@as_content nvarchar(255),
@as_situation nvarchar(255),
@as_sequence nvarchar(30),
@as_state nvarchar(10),
@as_remark nvarchar(255),
@as_type nvarchar(10)
as
begin
	insert into T_AFTERSALE values(@as_ordernumber,@as_gid,@as_receivetime,@as_content,@as_situation,@as_sequence,@as_state,@as_remark,@as_type)
end
go

--添加登录记录信息
create procedure PRO_LOGINRECORD_INSERT
@lr_uid int,
@lr_ipaddress nvarchar(30)
as
begin
	begin try
	begin transaction
	if (select top 1 lr_exittime from T_LOGINRECORD where lr_uid=@lr_uid order by lr_id desc)<>null
	begin
		insert into T_LOGINRECORD(lr_id,lr_uid,lr_logintime,lr_ipaddress) values((select count(*) from T_LOGINRECORD)+1,@lr_uid,GETDATE(),@lr_ipaddress)
	end
	else
	begin
		update T_LOGINRECORD set lr_exittime=GETDATE() where lr_id=(select max(lr_id) from T_LOGINRECORD where lr_uid=@lr_uid)
	end
	commit transaction
	end try
	begin catch
	rollback transaction
	end catch
end
go