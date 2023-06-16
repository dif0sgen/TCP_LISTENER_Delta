CREATE PROCEDURE [dbo].[sp_HOPE]
    @Id int out,
    @Camera Text,
	@Time Text
AS
    INSERT INTO HOPETable(Time, Camera)
    VALUES (@Time, @Camera)
 
    SET @Id=SCOPE_IDENTITY()
GO
