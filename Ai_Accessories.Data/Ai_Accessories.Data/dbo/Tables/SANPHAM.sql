CREATE TABLE [dbo].[SANPHAM] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [TenSP]      NVARCHAR (100) NULL,
    [Gia]        INT            NULL,
    [HinhanhSP]  NVARCHAR (100) NULL,
    [Conhang]    BIT            NULL,
    [ThongtinSP] NVARCHAR (MAX) NULL,
    [LoaiSP]     INT            NULL,
    [Ngaydang]   DATETIME       NULL,
    [Solanmua]   INT            NULL,
    CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SANPHAM_LOAISP] FOREIGN KEY ([LoaiSP]) REFERENCES [dbo].[LOAISP] ([Id])
);



