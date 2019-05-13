CREATE TABLE [dbo].[CLIENTACCOUNT] (
    [Id]          INT            NOT NULL,
    [AccountName] NVARCHAR (50)  NOT NULL,
    [PassWord]    NVARCHAR (50)  NOT NULL,
    [ClientName]  NVARCHAR (255) NOT NULL,
    [Gender]      BIT            NULL,
    [PhoneNumber] NCHAR (11)     NULL,
    [Email]       NVARCHAR (50)  NULL,
    [Address]     NVARCHAR (255) NULL,
    [Note]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ClientAccount] PRIMARY KEY CLUSTERED ([Id] ASC)
);

