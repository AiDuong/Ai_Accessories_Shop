CREATE TABLE [dbo].[USER] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [UserName] NCHAR (50)    NULL,
    [Password] NCHAR (50)    NULL,
    [Hoten]    NVARCHAR (50) NULL,
    [LoaiUser] INT           NULL,
    CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_USER_LOAIUSER] FOREIGN KEY ([LoaiUser]) REFERENCES [dbo].[LOAIUSER] ([MaloaiUser])
);

