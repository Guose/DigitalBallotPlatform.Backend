CREATE TABLE [County] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50),
  [AddressId] integer UNIQUE NOT NULL,
  [VoterSystemId] integer NOT NULL,
  [BallotSystemId] integer NOT NULL
)
GO

CREATE TABLE [ElectionSetup] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [ElectionDate] date,
  [Description] nvarchar(255),
  [WatermarkId] integer UNIQUE NOT NULL,
  [CountyId] integer UNIQUE NOT NULL,
  [BallotSpecsId] integer UNIQUE NOT NULL,
)
GO

CREATE TABLE [Party] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(25),
  [Acronym] nvarchar(10),
  [Abbreviations] nvarchar(3),
  [ElectionId] integer NOT NULL,
)
GO


ALTER TABLE [ElectionSetup] ADD FOREIGN KEY ([WatermarkId]) REFERENCES [Watermark] ([Id])
ALTER TABLE [ElectionSetup] ADD FOREIGN KEY ([CountyId]) REFERENCES [County] ([Id])
ALTER TABLE [ElectionSetup] ADD FOREIGN KEY ([BallotSpecsId]) REFERENCES [Ballot.BallotSpecs] ([Id])
GO

ALTER TABLE [County] ADD FOREIGN KEY ([AddressId]) REFERENCES [Platform.Address] ([Id])
GO

ALTER TABLE [Party] ADD FOREIGN KEY ([ElectionId]) REFERENCES [ElectionSetup] ([Id])
GO

