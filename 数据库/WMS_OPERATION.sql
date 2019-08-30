/*----------function----------*/
--function of random number
create function f_random_number(@count int=0)
returns nvarchar(100)
as
begin
	declare @randomnumber nvarchar(100)
	--select rowcount of table
	set @count=@count+1
	set @randomnumber=Convert(nvarchar,GETDATE(),112)+RIGHT('000000000000'+CONVERT(nvarchar,@count),10)
	return @randomnumber
end
go



/*----------procedure----------*/
--general data information query
create procedure p_universal_query
@table nvarchar(30),
@fieldvalue nvarchar(225),
@conditionvalue nvarchar(225)=''
as
begin
	begin try
	declare @sql nvarchar(max)
	set @sql=N'select '+@fieldvalue+' from '+@table+' where 1=1 '
	if(@conditionvalue<>'') 
	begin
	set @sql+='and '+@conditionvalue
	end
	exec sp_executesql @sql,N' @table nvarchar(30),@fieldvalue nvarchar(225),@conditionvalue nvarchar(225)',@table,@fieldvalue,@conditionvalue
	end try
	begin catch
	end catch
end
go

--general data information modification
create procedure p_universal_update
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
		return 0--successfull operation
	end try
	begin catch
	rollback transaction
		return 1--failed operation
	end catch
end
go

--general data information complete modification
create procedure p_universal_full_update
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
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--registered user
create procedure p_register_user
@ws_number nvarchar(30),
@ws_password nvarchar(max),
@ws_name nvarchar(30),
@ws_level tinyint=9,
@ws_department nvarchar(10)='业务部',
@ws_position nvarchar(10)='员工'--,
--@pru_returns tinyint=0 output--output message(return 0:faile;return 1:success;return 2:exists)
as
begin 
	begin try
		begin transaction
			--determine whether the data exists
			if((select count(*) from wms_signin where ws_number=@ws_number)>0)
			return 6--the data exists
			--insert data into wms_signin
			--the administrator register
			if(@ws_number='Administrator' and @ws_name='System Administrator')
			insert into wms_signin values(@ws_number,@ws_password,@ws_name,@ws_level,@ws_department,@ws_position,1)
			--the ordinary users register
			else
			insert into wms_signin values(@ws_number,@ws_password,@ws_name,@ws_level,@ws_department,@ws_position,1)
			insert into wms_user(wu_ws_id) values((select ws_id from wms_signin where ws_number=@ws_number and ws_password=@ws_password))
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--logon authentication and recording
create procedure p_signin_authentication_recording
@ws_number nvarchar(30),
@ws_password nvarchar(max),
@ws_ipaddress nvarchar(30)
as
begin
	begin try
		begin transaction
			--create parameters
			declare @ws_id int,@ws_status bit,@wso_id nvarchar(100),@wso_count int,@wso_status bit
			--determine whether the data exists
			if((select count(*) from wms_signin where ws_number=@ws_number)=0)
			return 2--the number is incorrect
			if((select count(*) from wms_signin where ws_number=@ws_number and ws_password=@ws_password)=0)
			return 3--the password is incorrect
			--select id and state of the user
			select @ws_id=ws_id,@ws_status=ws_status from wms_signin where ws_number=@ws_number and ws_password=@ws_password
			if(@ws_status=0)
			return 4--the states is Non-existent
			--select the status been logged in
			select top 1 @wso_status=wso_status from wms_signinoperation where wso_ws_id=@ws_id order by wso_time desc
			if(@wso_status=1)
			return 5--the users is logining in
			--select the counts of wms_signinoperation
			set @wso_count=(select Count(*) from wms_signinoperation where wso_time like GETDATE())
			exec @wso_id=f_random_number @wso_count
			insert into wms_signinoperation values(@wso_id,@ws_id,GETDATE(),@ws_ipaddress,1)--record operation log
			--return the successfull data
			select ws_id,ws_name,ws_level,ws_department,ws_position from wms_signin where ws_number=@ws_number and ws_password=@ws_password and ws_status=1
		commit transaction
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--add message to user messsage table
create procedure p_add_user
@wu_ws_id int,
@wu_gender bit=0,
@wu_age tinyint=0,
@wu_idcard nvarchar(24)='',
@wu_birthday smalldatetime='',
@wu_address nvarchar(255)='',
@wu_phone nvarchar(11)='',
@wu_email nvarchar(50)='',
@wu_remark nvarchar(255)=''
as
begin
	begin try
		begin transaction
			insert into wms_user values(@wu_ws_id,@wu_gender,@wu_age,@wu_idcard,@wu_birthday,@wu_address,@wu_phone,@wu_email,@wu_remark)
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--add message to goods inventory
create procedure p_add_goods_inventroy
@wgi_name nvarchar(100),
@wgi_model nvarchar(100)='',
@wgi_amount int=0,
@wgi_unit nvarchar(4)='个',
@wgi_supplier int,
@wgi_remark nvarchar(100)=''
as
begin
	begin try
		begin transaction
			--create parameter
			declare @wgi_id nvarchar(100),@wgi_count int
			--select the data exists
			if((select count(*) from wms_goods_inventory where wgi_name=@wgi_name and wgi_model=@wgi_model and wgi_supplier=@wgi_supplier)>0)
			return 7--the data exists
			--select the supplier exists
			if((select count(*) from wms_customer_supplier where wcs_id=@wgi_supplier)=0)
			return 8--the supplier is incorrect
			--create random id
			select @wgi_count=(select count(*) from wms_goods_inventory)
			exec @wgi_id=f_random_number @wgi_count
			insert into wms_goods_inventory values(@wgi_id,@wgi_name,@wgi_model,@wgi_amount,@wgi_unit,@wgi_supplier,@wgi_remark)
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--add message to goods access
create procedure p_add_goods_access
@wga_wgi_id nvarchar(100),
@wga_amount int,
@wga_wps_id nvarchar(100),
@wga_type nvarchar(10),
@wga_pncode nvarchar(100)='',
@wga_location nvarchar(100),
@wga_ws_id int,
@wga_remark nvarchar(100)
as
begin
	begin try
		begin transaction
			--select the user exists
			if((select count(*) from wms_signin where ws_id=@wga_ws_id)=0)
			return 2--the user is incorrect
			--select the goods exists
			if((select count(*) from wms_goods_inventory where wgi_id=@wga_wgi_id)=0)
			return 8--the goods is incorrect
			--select the purchasing and sales exists
			if((select count(*) from wms_purchasing_sales where wps_id=@wga_wps_id)=0)
			return 10--the purchasing and sales is incorrect
			--add message to goods access
			insert into wms_goods_access values(@wga_wgi_id,@wga_amount,@wga_wps_id,@wga_type,@wga_pncode,@wga_location,GETDATE(),@wga_ws_id,@wga_remark)
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--create trigger of goods access table and goods inventory table by insert
create trigger t_insert_goods_inventory_access
on wms_goods_access
after insert
as
begin
	declare @wga_wgi_id nvarchar(100),@wga_amount int,@wga_type nvarchar(10)
	select @wga_wgi_id=wga_wgi_id,@wga_amount=wga_amount,@wga_type=wga_type from inserted
	if(@wga_type='采购' or @wga_type='归还')
		update wms_goods_inventory set wgi_amount+=@wga_amount where wgi_id=@wga_wgi_id
	else if(@wga_type='销售' or @wga_type='借出')
		update wms_goods_inventory set wgi_amount-=@wga_amount where wgi_id=@wga_wgi_id
end
go

--create trigger of goods access table and goods inventory table by update
create trigger t_update_goods_inventory_access
on wms_goods_access
after update
as 
begin
	--create parameter
	declare @i_wga_id nvarchar(100),@d_wga_id nvarchar(100),@i_wga_amount int,@d_wga_amount int,@i_wga_type nvarchar(10),@d_wga_type nvarchar(10)
	--select the new data
	select @i_wga_id=wga_wgi_id,@i_wga_amount=wga_amount,@i_wga_type=wga_type from inserted
	--select the old data
	select @d_wga_id=wga_wgi_id,@d_wga_amount=wga_amount,@d_wga_type=wga_type from deleted
	--determine whether the id is the same
	if(@d_wga_type='采购' or @d_wga_type='归还')
	update wms_goods_inventory set wgi_amount-=@d_wga_amount where wgi_id=@d_wga_id
	else if(@d_wga_type='销售' or @d_wga_type='借出')
	update wms_goods_inventory set wgi_amount+=@d_wga_amount where wgi_id=@d_wga_id
	if(@i_wga_type='采购' or @i_wga_type='归还')
	update wms_goods_inventory set wgi_amount+=@i_wga_amount where wgi_id=@i_wga_id
	else if(@i_wga_type='销售' or @i_wga_type='借出')
	update wms_goods_inventory set wgi_amount-=@i_wga_amount where wgi_id=@i_wga_id
end
go

--add message to purchasing and sales table
create procedure p_add_purchasing_sales
@wps_inside nvarchar(100),
@wps_customer int,
@wps_outside nvarchar(100)='',
@wps_cycle int=0,
@wps_status bit=0,
@wps_ws_id int,
@wps_type bit
as
begin
	begin try
		begin transaction
			--create parameter
			declare @wps_id nvarchar(100),@wps_count int
			--select the user exists
			if((select count(*) from wms_signin where ws_id=@wps_ws_id)=0)
			return 2--the user is incorrect
			if((select count(*) from wms_customer_supplier where wcs_id=@wps_customer)=0)
			return 9--the customer is incorrect
			--insert data to table
			set @wps_count=(select Count(*) from wms_signinoperation where wso_time like GETDATE())
			exec @wps_id=f_random_number @wps_count
			insert into wms_purchasing_sales values(@wps_id,@wps_inside,GETDATE(),@wps_customer,@wps_outside,@wps_cycle,@wps_status,@wps_ws_id,@wps_type)
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--add message to purchasing and sales 's goods
create procedure p_add_goods_purchasing_sales
@wgops_wps_id nvarchar(100),
@wgops_wgi_id nvarchar(100),
@wgops_amount int=0,
@wgops_price money=0,
@wgops_tax decimal=0
as
begin
	begin try
		begin transaction
			--create parameter
			declare @randomnumber nvarchar(100),@count int
			--select the data exists
			if((select count(*) from wms_purchasing_sales where wps_id=@wgops_wps_id)=0)
			return 10--the data is incorrect
			if((select count(*) from wms_goods_inventory where wgi_id=@wgops_wgi_id)=0)
			return 8--the data is incorrect
			--create random number
			set @count=(select count(*) from wms_goods_of_purchasing_sales where wgops_wps_id=@wgops_wps_id)+1
			set @randomnumber=@wgops_wps_id+RIGHT('000000000000'+CONVERT(nvarchar,@count),10)
			--insert data to table
			insert into wms_goods_of_purchasing_sales values(@randomnumber,@wgops_wps_id,@wgops_wgi_id,@wgops_amount,@wgops_price,@wgops_tax,(@wgops_price*@wgops_tax),GETDATE())
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--add message to serial record table
create procedure p_add_serial_record
@wsr_wps_id nvarchar(100),
@wsr_wgi_id nvarchar(100),
@wsr_serial nvarchar(100)
as
begin
	begin try
		begin transaction
			--create parameter
			declare @randomnumber nvarchar(100),@count int
			--select the data exists
			if((select count(*) from wms_purchasing_sales where wps_id=@wsr_wps_id)=0)
			return 10--the data is incorrect
			if((select count(*) from wms_goods_inventory where wgi_id=@wsr_wgi_id)=0)
			return 8--the data is incorrect
			--create random number
			set @count=(select count(*) from wms_goods_of_purchasing_sales where wgops_wps_id=@wsr_wps_id)+1
			set @randomnumber=@wsr_wps_id+@wsr_wgi_id++RIGHT('000000000000'+CONVERT(nvarchar,@count),10)
			--insert data to table
			insert into wms_serial_record values(@randomnumber,@wsr_wps_id,@wsr_wgi_id,@wsr_serial,GETDATE())
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

--create trigger of serial record table and serial table by insert
create trigger t_insert_serial_record
on wms_serial_record
after insert
as
begin
	begin try
		begin transaction
			--create parameter
			declare @wsr_id nvarchar(100),@wsr_wgi_id nvarchar(100),@wsr_serial nvarchar(100)
			select @wsr_id=wsr_id,@wsr_wgi_id=wsr_wgi_id,@wsr_serial=wsr_serial from inserted
			--insert data to serial
			insert into wms_serial values(@wsr_id,@wsr_wgi_id,@wsr_serial,1)
		commit transaction
	end try
	begin catch
		rollback transaction
	end catch
end
go

--create trigger of serial record table and serial table by update
create trigger t_update_serial_record
on wms_serial_record
after update
as
begin
	begin try
		begin transaction
			--create parameter
			declare @wsr_id nvarchar(100),@i_wsr_wgi_id nvarchar(100),@i_wsr_serial nvarchar(100)
			--select new data of serial record by inserted
			select @wsr_id=wsr_id,@i_wsr_wgi_id=wsr_wgi_id,@i_wsr_serial=wsr_serial from inserted
			--update data to serial
			update wms_serial set ws_wgi_id=@i_wsr_wgi_id,ws_serial=@i_wsr_serial where ws_id=@wsr_id
		commit transaction
	end try
	begin catch
		rollback transaction
	end catch
end
go

--add message to supplier and customer table
create procedure p_add_supplier_customer
@wcs_companyname nvarchar(100),
@wcs_customer nvarchar(30)='',
@wcs_contact nvarchar(30)='',
@wcs_address nvarchar(30)='',
@wcs_remark nvarchar(100)='',
@wcs_type bit=0
as
begin
	begin try
		begin transaction
			--insert data to table
			insert into wms_customer_supplier values(@wcs_companyname,@wcs_customer,@wcs_contact,@wcs_address,@wcs_remark,1,@wcs_type)
		commit transaction
		return 0--successfull operation
	end try
	begin catch
		rollback transaction
		return 1--failed operation
	end catch
end
go

/**
	the error code docements
	code	message
	0		success
	1		failed
	2		the data is not exists
	3		the password is not exists
	4		the status is loginin
	5		the data exists
	6		the number exists
	7		the goods exists
	8		the goods is not exists
	9		the customer or supplier is not exists
	10		the purchasing or sales is not exists
**/