﻿CREATE TABLE [dbo].[LOAISP] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [TenloaiSP] NVARCHAR (50) NULL,
    [Flag]      VARCHAR (100) NULL,
    CONSTRAINT [PK_LOAISP] PRIMARY KEY CLUSTERED ([Id] ASC)
);



