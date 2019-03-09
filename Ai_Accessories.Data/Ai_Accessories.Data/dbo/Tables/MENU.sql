CREATE TABLE [dbo].[MENU] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Ten]      NVARCHAR (50) NULL,
    [Child]    INT           NULL,
    [Flag]     NCHAR (100)   NULL,
    [IsParent] BIT           NULL,
    CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED ([Id] ASC)
);



