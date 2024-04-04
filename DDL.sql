CREATE DATABASE QuanLySinhVien;
GO
USE QuanLySinhVien
GO
--Tạo bảng GiaoVien
CREATE TABLE GiaoVien (
    maGiaoVien NVARCHAR(25) PRIMARY KEY,
    tenGiaoVien NVARCHAR(255),
    ngaySinh DATE,
    diaChi NVARCHAR(255),
    gioiTinh BIT,
	soDienThoai NVARCHAR(25)
);
--Tạo bảng Admin
CREATE TABLE Admin (
    tenDangNhap NVARCHAR(255) PRIMARY KEY,
	matKhau NVARCHAR(255),
	maGiaoVien NVARCHAR(25) FOREIGN KEY REFERENCES GiaoVien(maGiaoVien) ON DELETE CASCADE
);

-- Tạo bảng Nganh
CREATE TABLE Nganh (
    maNganh NVARCHAR(25) PRIMARY KEY,
    tenNganh NVARCHAR(255),
	maKhoa NVARCHAR(25)
);

-- Tạo bảng SinhVien
CREATE TABLE SinhVien (
    maSinhVien NVARCHAR(25) PRIMARY KEY,
    tenSinhVien NVARCHAR(255),
    ngaySinh DATE,
    diaChi NVARCHAR(255),
	GPA FLOAT,
	email nvarchar(25),
	gioiTinh bit,
	soDienThoai nvarchar(25)
);

-- Tạo bảng Lop
CREATE TABLE Lop (
    maLop NVARCHAR(25) PRIMARY KEY,
    tenLop NVARCHAR(255),
	maNganh NVARCHAR(25),
    maSinhVien NVARCHAR(25) FOREIGN KEY REFERENCES SinhVien(maSinhVien) ON DELETE CASCADE
);

-- Tạo bảng Khoa
CREATE TABLE Khoa (
    maKhoa NVARCHAR(25) PRIMARY KEY,
    tenKhoa NVARCHAR(255),
);

-- Tạo bảng MonHoc
CREATE TABLE MonHoc (
    maMon NVARCHAR(25) PRIMARY KEY,
    tenMon NVARCHAR(255),
	ky INT,
	nam INT
);

-- Tạo bảng SinhVien_MonHoc
CREATE TABLE SinhVien_MonHoc (
    maMon NVARCHAR(25),
    maSinhVien NVARCHAR(25),
    diem FLOAT,
    PRIMARY KEY (maMon, maSinhVien),
    FOREIGN KEY (maMon) REFERENCES MonHoc(maMon) ON DELETE CASCADE,
    FOREIGN KEY (maSinhVien) REFERENCES SinhVien(maSinhVien) ON DELETE CASCADE
);