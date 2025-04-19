

USE master
GO

IF (SELECT COUNT(*)
		 FROM sys.databases
		 WHERE name = 'ContactDB' ) = 1
	 ALTER DATABASE ContactDB SET SINGLE_USER 
	 WITH ROLLBACK IMMEDIATE

DROP DATABASE IF EXISTS ContactDB
GO


CREATE DATABASE ContactDB
GO

USE ContactDB
GO

CREATE TABLE PersonInfo(ContactID smallint PRIMARY KEY IDENTITY ,
						FirstName nvarchar(50) NOT NULL ,
						LastName nvarchar(50) NOT NULL ,
						Age tinyint NOT NULL ,
						PhoneNumber varchar(11) NOT NULL ,
						EmailAddress nvarchar(50) NOT NULL , 
						Address nvarchar(MAX))
