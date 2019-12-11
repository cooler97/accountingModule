CREATE TRIGGER orderpricechange_after_insert
ON orderpricechange
AFTER INSERT
AS

DECLARE @idaccounting INT, @idorder INT
SET @idaccounting = -1 

SELECT @idorder = idorder FROM inserted;

IF (SELECT iddocstate FROM orders WHERE idorder = @idorder) > 1
BEGIN

	UPDATE dbo.accounting SET deleted = GETDATE() WHERE idorder IN (@idorder) AND typedoc IN (1) and deleted is null;

	IF (SELECT COUNT(*) FROM inserted i left join
		pricechange pc ON i.idpricechange = pc.idpricechange
		WHERE i.deleted is null and pc.name = 'Бонус') > 0
	BEGIN
	
		EXEC dbo.gen_id_ex @tablename = 'gen_accounting', @qu = 1, @result = @idaccounting OUTPUT;	
	
		INSERT INTO dbo.accounting (idaccounting, idorder, idcustomer, dtdoc, typedoc, smdoc)
			SELECT @idaccounting, o.idorder, o.idcustomer, GETDATE(), 1, opc.smbase FROM inserted opc LEFT JOIN
				orders o ON opc.idorder = o.idorder LEFT JOIN
				pricechange pc ON opc.idpricechange = pc.idpricechange 
			WHERE o.idorder = @idorder and pc.name = 'Бонус' and opc.deleted is null and o.deleted is null;
			
	END

END