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