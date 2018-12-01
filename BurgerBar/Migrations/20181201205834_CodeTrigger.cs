using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class CodeTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER TRIGGER [dbo].[Burger_Insert] ON [dbo].[Product]
    AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

            IF((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

            DECLARE @Id INT

            SELECT @Id = INSERTED.Id
    FROM INSERTED


    DECLARE @Length int;
            DECLARE @CharPool varchar(256);
            DECLARE @PoolLength int;
            DECLARE @LoopCount int;
            DECLARE @RandomString varchar(256);

            SET @Length = 8


    SET @CharPool =
        'ABCDEFGHIJKLMNPQRSTUVWXYZ23456789'

    SET @PoolLength = Len(@CharPool)


    SET @LoopCount = 0

    SET @RandomString = ''


    WHILE(@LoopCount < @Length) BEGIN
       SELECT @RandomString = @RandomString +
           SUBSTRING(@Charpool, CONVERT(int, RAND() * @PoolLength), 1)

        SELECT @LoopCount = @LoopCount + 1

    END

    UPDATE dbo.Product
    SET Code = @RandomString
    WHERE Id = @Id

    AND Discriminator = 'Burger'
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER [dbo].[Burger_Insert]");
        }
    }
}
