CREATE PROCEDURE [dbo].[sp_HOPE]
    @Id int out,
	@UserID int,
    @Camera Text,
	@Time Text
AS
    INSERT INTO HOPETable(UserID,Time, Camera)
    VALUES (@UserID, @Time, @Camera)

	SET @Id=SCOPE_IDENTITY()

GO
