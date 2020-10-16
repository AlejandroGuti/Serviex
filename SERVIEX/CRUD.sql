--Query for SQL server, I use Stored Procedures to demonstrate my knowledge,however I know the simple syntax

use Pruebas
go
CREATE TABLE CrudTable  
(  
 id int IDENTITY(1,1) not null, 
 FullName varchar (100),  
 BornDate datetime,
 Gender char(1)
);  
go
create or alter PROCEDURE Insert_CrudTable
	(
		@FullName VARCHAR(100),
		@BornDate datetime,
		@Gender char(1)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			INSERT INTO CrudTable (FullName, BornDate,Gender)
				VALUES (@FullName, @BornDate,@Gender);
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO
 -- execute Insert_CrudTable @FullName='Rodrigo',@BornDate='2020-10-01',@Gender='K'
  --select* from CrudTable

create or alter PROCEDURE Search_CrudTable
	(
		@id int
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			SELECT * FROM  CrudTable 
				WHERE id=@id
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO
  --execute Search_CrudTable @id=2
 -- select* from CrudTable
  
create or alter PROCEDURE Actualizate_CrudTable
	(
		@id int,
		@FullName VARCHAR(100),
		@BornDate datetime,
		@Gender char(1)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			UPDATE  CrudTable 
				SET FullName=@FullName,BornDate=@BornDate,Gender=@Gender
				WHERE id=@id
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO
 -- execute Actualizate_CrudTable @id=1,@FullName='Kasandra',@BornDate='2020-10-01',@Gender='O'
  --select* from CrudTable

create or alter PROCEDURE Delete_CrudTable
	(
		@id int
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			DELETE FROM  CrudTable 
				WHERE id=@id
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO

  --execute Delete_CrudTable @id=2
  --select * from CrudTable