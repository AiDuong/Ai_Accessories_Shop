﻿CREATE TABLE [dbo].[ANHBIA] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [URL]     NVARCHAR (100) NULL,
    [TenHinh] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ANHBIA] PRIMARY KEY CLUSTERED ([Id] ASC)
);

