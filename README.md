###################
WebAPI
###################

WebAPI for testing purposes. It is configure to run on https://localhost:5001


*******************
Release Information
*******************

This API has 3 Controllers with CRUD Operations. The endpoints are as follows:

**ContactsController**
* GET api/Contacts (return all Contacts)
* GET api/Contacts/:name (return Contact by Name)
* POST api/Contacts (Create new Contact)
* PUT api/Contacts (Update a Contact)
* DELETE api/Contacts/:id (Delete a Contact by Id)

**ReservationController**
* GET api/Reservations (return all Reservations)
* GET api/Reservation/:id (return a Reservation by Id)
* POST api/Reservations (Create new Reservation and a new Contact if not exists)
* PUT api/Contacts (Update a Reservation)
* DELETE api/Contacts/:id (Delete a Reservation by Id)

**ContactTypesController**
* GET api/ContactTypes (return all ContactTypes)
* GET api/ContactTypes/:id (return a ContactType by Id)

**************************
**Migration and Database**
**************************

To create the database:
* Open PM Console
* Type Add-Migration "Initial"

That process generate a Initial.cs inside of Migrations folder

* Then open that file
* Go to the end of void Up, before '}'
* Hit Enter to create space to insert this:

var sp = @"CREATE PROCEDURE AddReservation @contactName varchar, @contactType int, @contactPhone varchar, @birthday date, @reservationPlace varchar, @reservationDate datetime, @reservationId INT OUTPUT
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


* Type Update-Database

After this, the database is created, so it is ready to use.

