CREATE TABLE [dbo].[DONDATHANG] (
    [MaDonHang]         INT      IDENTITY (1, 1) NOT NULL,
    [Dathanhtoan]       BIT      NULL,
    [Tinhtranggiaohang] BIT      NULL,
    [Ngaydat]           DATETIME NULL,
    [Ngaygiao]          DATETIME NULL,
    [MaKH]              INT      NULL,
    CONSTRAINT [PK_DONDATHANG] PRIMARY KEY CLUSTERED ([MaDonHang] ASC)
);

