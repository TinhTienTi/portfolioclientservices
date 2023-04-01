﻿CREATE TABLE Categories (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,[Object] VARCHAR(30)
 ,[Value] NVARCHAR(MAX)
 ,Priority SMALLINT
)
GO

CREATE TABLE Home (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,TypeId UNIQUEIDENTIFIER
)
GO

CREATE TABLE Language (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,[Object] VARCHAR(30)
 ,[Key] UNIQUEIDENTIFIER
 ,[Code] CHAR(2)
 ,[Value] NVARCHAR(MAX)
)

GO

CREATE TABLE About (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,TypeId UNIQUEIDENTIFIER
 ,ImageGroupId UNIQUEIDENTIFIER
)

GO

CREATE TABLE ImageUtilities (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,Name NVARCHAR(MAX)
 ,ObjectName NVARCHAR(MAX)
)

GO

CREATE TABLE Service (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
)

GO

CREATE TABLE ServiceDetail (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,TypeId UNIQUEIDENTIFIER
 ,ImageUtilityId UNIQUEIDENTIFIER
 ,ServiceId UNIQUEIDENTIFIER
)

GO

CREATE TABLE Client (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,Name NVARCHAR(MAX)
 ,ImageGroupId UNIQUEIDENTIFIER
)

GO

CREATE TABLE ClientComment (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,ClientId UNIQUEIDENTIFIER
)

GO

CREATE TABLE SocicalLink (
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID()
 ,CreatedAt DATETIMEOFFSET
 ,ModifiedAt DATETIMEOFFSET
 ,[Url] VARCHAR(MAX)
 ,[Name] NVARCHAR(MAX)
 ,Disable BIT
)