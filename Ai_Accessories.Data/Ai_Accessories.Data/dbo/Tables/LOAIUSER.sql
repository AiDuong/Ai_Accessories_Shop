CREATE TABLE [dbo].[LOAIUSER] (
    [MaloaiUser]  INT           IDENTITY (1, 1) NOT NULL,
    [TenloaiUser] NVARCHAR (50) NULL,
    CONSTRAINT [PK_LOAIUSER] PRIMARY KEY CLUSTERED ([MaloaiUser] ASC)
);

