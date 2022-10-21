CREATE TABLE [dbo].[Songs] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [SongName] VARCHAR (90)      NULL,
    [Catagory] VARCHAR (50)      NULL,
    [img]      VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

