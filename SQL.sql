﻿CREATE TABLE Categories
(
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT Newid(),
  CreatedAt DATETIMEOFFSET,
  ModifiedAt DATETIMEOFFSET,
  [Object] VARCHAR(30),
  [Value] NVARCHAR(MAX)
)
GO

CREATE TABLE Home
(
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT Newid(),
  CreatedAt DATETIMEOFFSET,
  ModifiedAt DATETIMEOFFSET,
  TypeId UNIQUEIDENTIFIER
)
GO

CREATE TABLE Language
(
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT Newid(),
  CreatedAt DATETIMEOFFSET,
  ModifiedAt DATETIMEOFFSET,
  [Object] VARCHAR(30),
  [Key] UNIQUEIDENTIFIER,
  [Code] CHAR(2),
  [Value] NVARCHAR(MAX)
)

GO

CREATE TABLE About
(
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT Newid(),
  CreatedAt DATETIMEOFFSET,
  ModifiedAt DATETIMEOFFSET,
  TypeId UNIQUEIDENTIFIER,
  ImageUtilityId UNIQUEIDENTIFIER
)

GO

CREATE TABLE ImageUtilities
(
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT Newid(),
  CreatedAt DATETIMEOFFSET,
  ModifiedAt DATETIMEOFFSET,
  Name NVARCHAR(MAX),
  ObjectName NVARCHAR(MAX)
)

GO

CREATE TABLE Service
(
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT Newid(),
  CreatedAt DATETIMEOFFSET,
  ModifiedAt DATETIMEOFFSET
)

GO

CREATE TABLE ServiceDetail
(
  Tid UNIQUEIDENTIFIER PRIMARY KEY DEFAULT Newid(),
  CreatedAt DATETIMEOFFSET,
  ModifiedAt DATETIMEOFFSET,
  TypeId UNIQUEIDENTIFIER,
  ImageUtilityId UNIQUEIDENTIFIER,
  ServiceId UNIQUEIDENTIFIER
)