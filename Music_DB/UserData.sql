CREATE TABLE [dbo].[UserData] (
    [Id]        NVARCHAR (50) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [UserName]  NVARCHAR (50) NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (15) NOT NULL,
	[img]      VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

