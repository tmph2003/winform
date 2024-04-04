using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BTL_Nhom1.DataContext
{
    public partial class QuanLySinhVienContext : DbContext
    {
        public QuanLySinhVienContext()
        {
        }

        public QuanLySinhVienContext(DbContextOptions<QuanLySinhVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<GiaoVien> GiaoVien { get; set; }
        public virtual DbSet<Khoa> Khoa { get; set; }
        public virtual DbSet<Lop> Lop { get; set; }
        public virtual DbSet<MonHoc> MonHoc { get; set; }
        public virtual DbSet<Nganh> Nganh { get; set; }
        public virtual DbSet<SinhVien> SinhVien { get; set; }
        public virtual DbSet<SinhVienMonHoc> SinhVienMonHoc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=TRANMINHPHUONG\\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.TenDangNhap)
                    .HasName("PK__Admin__59267D4B7BF2E025");

                entity.Property(e => e.TenDangNhap)
                    .HasColumnName("tenDangNhap")
                    .HasMaxLength(255);

                entity.Property(e => e.MaGiaoVien)
                    .HasColumnName("maGiaoVien")
                    .HasMaxLength(25);

                entity.Property(e => e.MatKhau)
                    .HasColumnName("matKhau")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MaGiaoVienNavigation)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.MaGiaoVien)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Admin__maGiaoVie__267ABA7A");
            });

            modelBuilder.Entity<GiaoVien>(entity =>
            {
                entity.HasKey(e => e.MaGiaoVien)
                    .HasName("PK__GiaoVien__6C8109AABBCEC9D3");

                entity.Property(e => e.MaGiaoVien)
                    .HasColumnName("maGiaoVien")
                    .HasMaxLength(25);

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(255);

                entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");

                entity.Property(e => e.NgaySinh)
                    .HasColumnName("ngaySinh")
                    .HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(25);

                entity.Property(e => e.TenGiaoVien)
                    .HasColumnName("tenGiaoVien")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("PK__Khoa__C79B8C22F2AE13A8");

                entity.Property(e => e.MaKhoa)
                    .HasColumnName("maKhoa")
                    .HasMaxLength(25);

                entity.Property(e => e.TenKhoa)
                    .HasColumnName("tenKhoa")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop)
                    .HasName("PK__Lop__261ECAE3EAB8364F");

                entity.Property(e => e.MaLop)
                    .HasColumnName("maLop")
                    .HasMaxLength(25);

                entity.Property(e => e.MaNganh)
                    .HasColumnName("maNganh")
                    .HasMaxLength(25);

                entity.Property(e => e.MaSinhVien)
                    .HasColumnName("maSinhVien")
                    .HasMaxLength(25);

                entity.Property(e => e.TenLop)
                    .HasColumnName("tenLop")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.Lop)
                    .HasForeignKey(d => d.MaSinhVien)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Lop__maSinhVien__2D27B809");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMon)
                    .HasName("PK__MonHoc__27547BFAB50994C2");

                entity.Property(e => e.MaMon)
                    .HasColumnName("maMon")
                    .HasMaxLength(25);

                entity.Property(e => e.Ky).HasColumnName("ky");

                entity.Property(e => e.Nam).HasColumnName("nam");

                entity.Property(e => e.TenMon)
                    .HasColumnName("tenMon")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(e => e.MaNganh)
                    .HasName("PK__Nganh__4E0C0217DF492A29");

                entity.Property(e => e.MaNganh)
                    .HasColumnName("maNganh")
                    .HasMaxLength(25);

                entity.Property(e => e.MaKhoa)
                    .HasColumnName("maKhoa")
                    .HasMaxLength(25);

                entity.Property(e => e.TenNganh)
                    .HasColumnName("tenNganh")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSinhVien)
                    .HasName("PK__SinhVien__D9B6EE603967900C");

                entity.Property(e => e.MaSinhVien)
                    .HasColumnName("maSinhVien")
                    .HasMaxLength(25);

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(25);

                entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.NgaySinh)
                    .HasColumnName("ngaySinh")
                    .HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(25);

                entity.Property(e => e.TenSinhVien)
                    .HasColumnName("tenSinhVien")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SinhVienMonHoc>(entity =>
            {
                entity.HasKey(e => new { e.MaMon, e.MaSinhVien })
                    .HasName("PK__SinhVien__3ACF151CCBDAD940");

                entity.ToTable("SinhVien_MonHoc");

                entity.Property(e => e.MaMon)
                    .HasColumnName("maMon")
                    .HasMaxLength(25);

                entity.Property(e => e.MaSinhVien)
                    .HasColumnName("maSinhVien")
                    .HasMaxLength(25);

                entity.Property(e => e.Diem).HasColumnName("diem");

                entity.HasOne(d => d.MaMonNavigation)
                    .WithMany(p => p.SinhVienMonHoc)
                    .HasForeignKey(d => d.MaMon)
                    .HasConstraintName("FK__SinhVien___maMon__33D4B598");

                entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.SinhVienMonHoc)
                    .HasForeignKey(d => d.MaSinhVien)
                    .HasConstraintName("FK__SinhVien___maSin__34C8D9D1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
