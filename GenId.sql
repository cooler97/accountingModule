CREATE FUNCTION gen_id_func(@n varchar(32)) RETURNS INTEGER

AS
BEGIN
   DECLARE @id INTEGER

   EXEC dbo.gen_id_ex @tablename = @n, @qu = 1, @result = @id OUTPUT;	

   RETURN @id
END