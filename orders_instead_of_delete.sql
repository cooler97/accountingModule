USE [Plastconstructor_2005]
GO
/****** Object:  Trigger [dbo].[orders_instead_of_delete]    Script Date: 09/20/2019 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER trigger [dbo].[orders_instead_of_delete] on [dbo].[orders] instead of delete
as begin
	delete from installdocpos 
	where idorderitem in (select idorderitem 
						  from orderitem
						  where idorder in (select idorder from deleted))

	delete from finparamcalc
	where idmodel is null and
			idorder in (select idorder from deleted)

	delete from ordersetting
	where idmodel is null and
			idorder in (select idorder from deleted)

	delete from ordergoodservice
	where idgoodservice is null and
			idgoodservice in (select idorder from deleted)

	delete from orderitem
	where idorder in (select idorder from deleted)

	delete from model
	where idorder in (select idorder from deleted)

	delete from ordererror
	where idorder in (select idorder from deleted)

	delete from orders 
	where idorder in (select idorder from deleted)

	update servicedoc set idorderdest = null
	where idorderdest in (select idorder from deleted)
	
	update orderpricechange set deleted = GETDATE()
	where idorder in (select idorder from deleted)
end
