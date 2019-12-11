/*IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'orders_after_update' AND [type] = 'TR')
BEGIN
      DROP TRIGGER [dbo].[orders_after_update];
END;*/

CREATE TRIGGER orders_after_update
ON Orders
AFTER UPDATE
AS

DECLARE @idaccounting INT, @idorder INT, @status INT, @quconstr INT
SET @idaccounting = -1 
SET @quconstr = 0

SELECT @idorder = idorder FROM inserted;
SELECT @status = iddocstate FROM inserted;

IF @status < 3
BEGIN
	UPDATE dbo.accounting SET deleted = GETDATE() WHERE idorder IN (SELECT idorder FROM inserted);
END
	ELSE
IF @status = 3
BEGIN

	EXEC dbo.gen_id_ex @tablename = 'gen_accounting', @qu = 1, @result = @idaccounting OUTPUT;

	UPDATE dbo.accounting SET deleted = GETDATE() WHERE idorder IN (SELECT idorder FROM INSERTED) AND typedoc IN (0) and deleted is null;
     
    SELECT @quconstr = SUM(ISNULL(oi.qu, 0)) FROM orderitem oi WHERE oi.idorder = @idorder AND
     oi.idconstructiontype NOT IN (32,33,35)
     AND oi.deleted IS NULL AND oi.typ = 1;

	INSERT INTO dbo.accounting (idaccounting, idorder, idcustomer, dtdoc, typedoc, quconstr, smdoc)
		SELECT @idaccounting, idorder, idcustomer, GETDATE(), 0, @quconstr, smbase
			FROM INSERTED WHERE deleted is null;
			
	UPDATE dbo.accounting SET deleted = GETDATE() WHERE idorder IN (@idorder) AND typedoc IN (1) and deleted is null;

	IF (SELECT COUNT(*) FROM view_orderpricechange vopc
		WHERE vopc.idorder = @idorder and vopc.deleted is null and vopc.pricechange_name = 'Бонус') > 0
	BEGIN
	
		EXEC dbo.gen_id_ex @tablename = 'gen_accounting', @qu = 1, @result = @idaccounting OUTPUT;	
	
		INSERT INTO dbo.accounting (idaccounting, idorder, idcustomer, dtdoc, typedoc, smdoc)
			SELECT @idaccounting, o.idorder, o.idcustomer, GETDATE(), 1, vopc.smbase FROM inserted o left join
				view_orderpricechange vopc ON o.idorder = vopc.idorder
			WHERE vopc.deleted is null and vopc.pricechange_name = 'Бонус';
			
	END

END