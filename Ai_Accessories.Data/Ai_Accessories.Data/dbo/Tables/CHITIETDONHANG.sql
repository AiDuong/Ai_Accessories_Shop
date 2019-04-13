CREATE TABLE [dbo].[CHITIETDONHANG] (
    [MaDonHang] INT NOT NULL,
    [Masp]      INT NOT NULL,
    [Soluong]   INT NULL,
    [Dongia]    INT NULL,
    CONSTRAINT [PK_CHITIETDONHANG] PRIMARY KEY CLUSTERED ([MaDonHang] ASC, [Masp] ASC)
);

