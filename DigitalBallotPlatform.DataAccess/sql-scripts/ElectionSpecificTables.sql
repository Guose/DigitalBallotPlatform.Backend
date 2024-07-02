CREATE TABLE [County] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [CompanyId] integer UNIQUE NOT NULL,
  [VoterSystemId] integer UNIQUE NOT NULL,
  [BallotSystemId] integer UNIQUE NOT NULL
)
GO

CREATE TABLE [ElectionSetup] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [ElectionDate] date,
  [Watermark] nvarchar(255),
  [WatermarkColor] nvarchar(255),
  [HeaderColor] nvarchar(255)
)
GO

CREATE TABLE [BallotCategory] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Category] nvarchar(255) NOT NULL,
  [SubCategory] nvarchar(255),
  [Description] nvarchar(255) NOT NULL,
  [IsTestdeck] bool,
  [Enabled] bool,
  [BallotSpecId] integer UNIQUE NOT NULL
)
GO

CREATE TABLE [BallotSpecs] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Length] integer,
  [Width] integer,
  [StubSize] integer,
  [IsTopStub] bool
)
GO

CREATE TABLE [BallotMaterial] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Weight] integer NOT NULL,
  [TextWeight] bool,
  [CompanyId] integer UNIQUE NOT NULL
)
GO

CREATE TABLE [Company] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Description] nvarchar(255),
  [Ofc_Address1] nvarchar(255) NOT NULL,
  [Ofc_Address2] nvarchar(255) NOT NULL,
  [Ofc_City] nvarchar(255) NOT NULL,
  [Ofc_State] nvarchar(255) NOT NULL,
  [Ofc_Zip] integer NOT NULL,
  [Shp_Address1] nvarchar(255),
  [Shp_Address2] nvarchar(255),
  [Shp_City] nvarchar(255),
  [Shp_State] nvarchar(255),
  [Shp_Zip] integer
)
GO

CREATE TABLE [PlatformUser] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [PrimaryPhone] nvarchar(255) NOT NULL,
  [SecondaryPhone] nvarchar(255),
  [CountyId] integer UNIQUE NOT NULL,
  [RoleId] integer UNIQUE NOT NULL
)
GO

CREATE TABLE [Role] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Description] nvarchar(255),
  [CreatedAt] date NOT NULL,
  [UpdatedAt] data,
  [Enabled] bool,
  [CompanyId] integer UNIQUE
)
GO

ALTER TABLE [BallotCategory] ADD FOREIGN KEY ([BallotSpecId]) REFERENCES [BallotSpecs] ([Id])
GO

ALTER TABLE [PlatformUser] ADD FOREIGN KEY ([CountyId]) REFERENCES [County] ([Id])
GO

ALTER TABLE [Role] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

CREATE TABLE [Company_County] (
  [Company_Id] integer,
  [County_CompanyId] integer,
  PRIMARY KEY ([Company_Id], [County_CompanyId])
);
GO

ALTER TABLE [Company_County] ADD FOREIGN KEY ([Company_Id]) REFERENCES [Company] ([Id]);
GO

ALTER TABLE [Company_County] ADD FOREIGN KEY ([County_CompanyId]) REFERENCES [County] ([CompanyId]);
GO

