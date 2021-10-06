using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class SPReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE AddReservation2
                     @contactName varchar, @contactType int, @contactPhone varchar, @birthday date, @reservationPlace varchar, @reservationDate datetime,
                     @reservationId INT OUTPUT
                     AS
                    BEGIN
                        DECLARE @contactId int = 0;

                        SET @contactId = (SELECT Id
                        FROM Contacts
                        WHERE ContactName = @contactName AND ContactType = @contactType AND ContactPhone = @contactPhone AND Birthday = @birthday);

                        IF @contactId IS NULL OR @contactId = 0
                        BEGIN
                            INSERT INTO[Contacts](ContactName, ContactType, ContactPhone, Birthday) VALUES(@contactName, @contactType, @contactPhone, @birthday);
                            SELECT @contactId = SCOPE_IDENTITY();
                        END

                        INSERT INTO[Reservations](ContactId, ReservationPlace, ReservationDate, Favorite) VALUES(@contactId, @reservationPlace, @reservationDate, 0);
                        SELECT @reservationId = SCOPE_IDENTITY();
                    END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
