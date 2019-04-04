--�û�ע��
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
--����
exec PRO_LOGIN_REGISTER 'Jason','E10ABC3949BA59ABBE56E057F20F883E',1,'����','����','��ɭ'
go
select * from T_LOGIN
go
select * from T_USER
go

--��¼��֤
create procedure PRO_LOGIN_VERIFICATION
@l_accountnumber nvarchar(24),
@l_password nvarchar(max)
as
begin
	select l_id,l_level,l_position,l_department,l_state from T_LOGIN where l_accountnumber=@l_accountnumber and l_password=@l_password
end
go
--����
exec PRO_LOGIN_VERIFICATION 'Jason','E10ABC3949BA59ABBE56E057F20F883E'
go

--ͨ��������Ϣ��ѯ
create procedure PRO_SELECT
@table nvarchar(30)
as
begin
	declare @sql nvarchar(max)
	set @sql='select * from '+@table
	exec(@sql)
end
go
--����
exec PRO_SELECT T_LOGIN
go

--ͨ��������Ϣ�޸�
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
--����
exec PRO_UPDATE 'T_USER','u_age','33','u_id','1'
go

--��ӱ���ģ����Ϣ
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
--����
exec PRO_REPORT_INSERT 1,'��������','E://REPORT/',''
go
select * from T_REPORT
go

--��Ӵ����¼���Ϣ
create procedure PRO_EVENT_INSERT
@e_conent nvarchar(255),
@e_releaseid int,
@e_handleid int
as
begin
	begin try
	begin transaction
	insert into T_EVENT(e_time,e_content,e_releaseid,e_handleid,e_state) values(GETDATE(),@e_conent,@e_releaseid,@e_handleid,'δ��')
	end try
	begin catch
	rollback transaction
	end catch
end
go