USE QuanLySinhVien
GO
INSERT INTO GiaoVien (maGiaoVien, tenGiaoVien, ngaySinh, diaChi, gioiTinh, soDienThoai)
VALUES
    ('GV001', 'Nguyen Van A', '1980-01-01', 'Ha Noi', 1, '0123456789'),
    ('GV002', 'Tran Thi B', '1975-05-05', 'Ho Chi Minh', 0, '0987654321');

INSERT INTO Admin (tenDangNhap, matKhau, maGiaoVien)
VALUES
    ('admin1', 'password1', 'GV001'),
    ('admin2', 'password2', 'GV002');

INSERT INTO Nganh (maNganh, tenNganh, maKhoa)
VALUES
    ('N01', 'Information Technology', 'K01'),
    ('N02', 'Economics', 'K02');

INSERT INTO SinhVien (maSinhVien, tenSinhVien, ngaySinh, diaChi, GPA, email, gioiTinh, soDienThoai)
VALUES
    ('SV001', 'Nguyen Thi C', '2000-07-07', 'Da Nang', 3.5, 'sv001@example.com', 1, '0123456789'),
    ('SV002', 'Le Van D', '2001-08-08', 'Hai Phong', 3.2, 'sv002@example.com', 0, '0987654321');

INSERT INTO Lop (maLop, tenLop, maNganh, maSinhVien)
VALUES
    ('L01', 'Class 01', 'N01', 'SV001'),
    ('L02', 'Class 02', 'N02', 'SV002');

INSERT INTO Khoa (maKhoa, tenKhoa)
VALUES
    ('K01', 'Faculty of Information Technology'),
    ('K02', 'Faculty of Economics');

INSERT INTO MonHoc (maMon, tenMon, ky, nam)
VALUES
    ('MH001', 'Subject 1', 1, 2022),
    ('MH002', 'Subject 2', 1, 2022);

INSERT INTO SinhVien_MonHoc (maMon, maSinhVien, diem)
VALUES
    ('MH001', 'SV001', 8.5),
    ('MH001', 'SV002', 7.5);
GO
DECLARE @i INT = 3;
WHILE @i <= 50
BEGIN
    DECLARE @maSinhVien NVARCHAR(25) = 'SV' + RIGHT('00' + CAST(@i AS NVARCHAR(2)), 3);
    DECLARE @tenSinhVien NVARCHAR(255) = 'Sinh viên ' + CAST(@i AS NVARCHAR(2));
    DECLARE @ngaySinh DATE = DATEADD(year, -@i, GETDATE());
    DECLARE @diaChi NVARCHAR(255) = 'Dia chi ' + CAST(@i AS NVARCHAR(2));
    DECLARE @GPA FLOAT = RAND() * (4 - 2) + 2;
    DECLARE @maNganh NVARCHAR(25) = 'Nganh01';
	DECLARE @soDienThoai NVARCHAR(255) = '01234567' + CAST(@i AS NVARCHAR(2));
	DECLARE @email NVARCHAR(255) = 'abc' + CAST(@i AS NVARCHAR(2)) + '@gmail.com';
	DECLARE @randomBit INT;
	SET @randomBit = ROUND(RAND(), 0);
	DECLARE @gioiTinh BIT;
	SET @gioiTinh = CASE WHEN @randomBit = 1 THEN 1 ELSE 0 END;

    INSERT INTO SinhVien (maSinhVien, tenSinhVien, ngaySinh, diaChi, GPA, email, gioiTinh, soDienThoai)
    VALUES (@maSinhVien, @tenSinhVien, @ngaySinh, @diaChi,  @GPA, @email, @gioiTinh, @soDienThoai);

    SET @i = @i + 1;
END;
GO
DECLARE @j INT = 1;
WHILE @j <= 10
BEGIN
    DECLARE @maMon NVARCHAR(25) = 'MH' + RIGHT('00' + CAST(@j AS NVARCHAR(2)), 3);
    DECLARE @tenMon NVARCHAR(255) = 'Mon hoc ' + CAST(@j AS NVARCHAR(2));
    DECLARE @ky INT = RAND() * (8 - 1) + 1;
    DECLARE @nam INT = RAND() * (2023 - 2022) + 2022; -- Giả sử năm học từ 2022 đến 2023

    INSERT INTO MonHoc (maMon, tenMon, ky, nam)
    VALUES (@maMon, @tenMon, @ky, @nam);

    SET @j = @j + 1;
END;
GO
DECLARE @k INT = 1;
WHILE @k <= 50
BEGIN
    DECLARE @maSinhVien NVARCHAR(25) = 'SV' + RIGHT('00' + CAST(@k AS NVARCHAR(2)), 3);
    DECLARE @maMon NVARCHAR(25) = 'MH' + RIGHT('00' + CAST((@k % 10) + 1 AS NVARCHAR(2)), 3);
    DECLARE @diem FLOAT = RAND() * (10 - 0) + 0;
    INSERT INTO SinhVien_MonHoc(maMon, maSinhVien, diem)
    VALUES (@maMon, 'SV001', @diem);

    SET @k = @k + 1;
END;
