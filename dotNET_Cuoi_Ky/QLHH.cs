namespace dotNET_Cuoi_Ky.DAL
{
    using dotNET_Cuoi_Ky.DTO;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class QLHH : DbContext
    {
        // Your context has been configured to use a 'QLHH' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'dotNET_Cuoi_Ky.DAL.QLHH' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLHH' 
        // connection string in the application configuration file.
        public QLHH()
            : base("name=QLHH")
        {
            Database.SetInitializer<QLHH>(new DB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<LoaiHang> LoaiHang { get; set; }
        public virtual DbSet<HangHoa> HangHoa { get; set; }
        public virtual DbSet<NhapKho> NhapKho { get; set; }
        public virtual DbSet<NhapKho_CT> NhapKho_CT { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
    public class DB : CreateDatabaseIfNotExists<QLHH>
    {
        protected override void Seed(QLHH context)
        {
            // Tao 5 loai hang
            LoaiHang loaiHang1 = new LoaiHang
            {
                TenLoai = "PC",              
            };
            LoaiHang loaiHang2 = new LoaiHang
            {
                TenLoai = "Laptop"
            };
            LoaiHang loaiHang3 = new LoaiHang
            {
                TenLoai = "Điện thoại"
            };
            LoaiHang loaiHang4 = new LoaiHang
            {
                TenLoai = "Màn hình máy tính"
            };
            LoaiHang loaiHang5 = new LoaiHang
            {
                TenLoai = "Bàn phím"
            };            
            context.LoaiHang.Add(loaiHang1);
            context.LoaiHang.Add(loaiHang2);
            context.LoaiHang.Add(loaiHang3);
            context.LoaiHang.Add(loaiHang4);
            context.LoaiHang.Add(loaiHang5);
            context.SaveChanges();

            // Tao mat hang
            HangHoa hangHoa1 = new HangHoa
            {
                TenHang = "Máy tính bộ HP AIO",
                NhaCC = "HP",
                DVTinh = "Cái",
                MaLoai = 1
            };
            HangHoa hangHoa2 = new HangHoa
            {
                TenHang = "Dell 3577",
                NhaCC = "Dell",
                DVTinh = "Cái",
                MaLoai = 2
            };
            HangHoa hangHoa3 = new HangHoa
            {
                TenHang = "iPhone 6s",
                NhaCC = "Apple",
                DVTinh = "Cái",
                MaLoai = 3
            };
            HangHoa hangHoa4 = new HangHoa
            {
                TenHang = "Màn hình cong Samsung Curved 4k 27 inch",
                NhaCC = "Samsung",
                DVTinh = "Cái",
                MaLoai = 4
            };
            HangHoa hangHoa5 = new HangHoa
            {
                TenHang = "Bàn phím Dell K1224",
                NhaCC = "Dell",
                DVTinh = "Cái",
                MaLoai = 5
            };
            context.HangHoa.Add(hangHoa1);
            context.HangHoa.Add(hangHoa2);
            context.HangHoa.Add(hangHoa3);
            context.HangHoa.Add(hangHoa4);
            context.HangHoa.Add(hangHoa5);
            context.SaveChanges();

            // Tao phieu NhapKho
            NhapKho nhapKho = new NhapKho
            {
                NgayNhap = Convert.ToDateTime("11 Jan 2019"),
                NguoiNhap = "Võ Văn An",
                LyDoNhap = "Nhập thêm hàng"
            };
            NhapKho nhapKho2 = new NhapKho
            {
                NgayNhap = Convert.ToDateTime("06 Jan 2019"),
                NguoiNhap = "Dương Văn Tuấn",
                LyDoNhap = "Nhập thêm hàng"
            };
            context.NhapKho.Add(nhapKho);
            context.NhapKho.Add(nhapKho2);
            context.SaveChanges();

            // Tao Phieu NhapKho_CT
            NhapKho_CT nhapKho_CT1 = new NhapKho_CT
            {
                SoPhieuN = 1,
                MaHang = 1,
                SLNhap = 20,
                DGNhap = 18000000
            };           
            NhapKho_CT nhapKho_CT2 = new NhapKho_CT
            {
                SoPhieuN = 1,
                MaHang = 2,
                SLNhap = 10,
                DGNhap = 27000000
            };
            NhapKho_CT nhapKho_CT3 = new NhapKho_CT
            {
                SoPhieuN = 2,
                MaHang = 3,
                SLNhap = 5,
                DGNhap = 13500000
            };
            NhapKho_CT nhapKho_CT4 = new NhapKho_CT
            {
                SoPhieuN = 1,
                MaHang = 1,
                SLNhap = 2,
                DGNhap = 4850000
            };
            NhapKho_CT nhapKho_CT5 = new NhapKho_CT
            {
                SoPhieuN = 2,
                MaHang = 1,
                SLNhap = 30,
                DGNhap = 150000
            };
            context.NhapKho_CT.Add(nhapKho_CT1);
            context.NhapKho_CT.Add(nhapKho_CT2);
            context.NhapKho_CT.Add(nhapKho_CT3);
            context.NhapKho_CT.Add(nhapKho_CT4);
            context.NhapKho_CT.Add(nhapKho_CT5);
            context.SaveChanges();
        }
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}