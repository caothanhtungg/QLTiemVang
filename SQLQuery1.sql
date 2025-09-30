-- 1) Database
CREATE DATABASE QLTiemVang;
GO
USE QLTiemVang;
GO

-- 2) Bảng chính
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    DiaChi NVARCHAR(200),
    GhiChu NVARCHAR(200)
);

CREATE TABLE SanPham (
    MaSP INT IDENTITY(1,1) PRIMARY KEY,
    TenSP NVARCHAR(100) NOT NULL,
    Loai NVARCHAR(50),              -- Nhẫn, Dây chuyền, Bông tai...
    TrongLuong DECIMAL(10,2),       -- gram
    Gia DECIMAL(18,2) NOT NULL      -- giá bán/đơn vị
);

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT(GETDATE()),
    MaKH INT NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT(0),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE ChiTietHD (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,  -- chốt theo thời điểm bán
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- 3) Người dùng đăng nhập (đơn giản)
CREATE TABLE NguoiDung (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) UNIQUE NOT NULL,
    MatKhau VARCHAR(100) NOT NULL,  -- demo: lưu plain hoặc hash đơn giản
    VaiTro NVARCHAR(20) DEFAULT N'User' -- Admin/User
);

-- 4) Dữ liệu mẫu nhanh để test
INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro) VALUES ('admin','123','Admin');

INSERT INTO KhachHang (TenKH, SDT, DiaChi) VALUES
(N'Nguyễn A','0900000001',N'Hà Nội'),
(N'Trần B','0900000002',N'Đà Nẵng');

INSERT INTO SanPham (TenSP, Loai, TrongLuong, Gia) VALUES
(N'Nhẫn tròn trơn 18K', N'Nhẫn', 3.50, 5200000),
(N'Dây chuyền 24K 5 chỉ', N'Dây chuyền', 18.75, 15500000);
