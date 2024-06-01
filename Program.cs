using System;
using System.Data;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto.Generators;
class Program
{
        static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1.Quan ly sinh vien");
            Console.WriteLine("2.Quan ly giang vien");
            Console.WriteLine("3.Cac quan ly khac");
            Console.WriteLine("4.Quan ly Khoa Hoc");
            Console.WriteLine("5.Quan ly dang ki ");
            Console.WriteLine("0.Thoat");
            Console.WriteLine("Chon mot tuy chon");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    MenuQLSV();
                    break;
                case "2":
                    MenuQLGV();
                    break;
                case "3":
                    QLkhac();
                    break;
                case "4":
                    QuanlyKhoaHoc();
                    break;
                case "5":
                    QuanLyDangKi();
                    break;
                case "0":
                    return;
                default:
                Console.WriteLine("Tuy chon khong hop le. Vui long thu lai.");
                Console.ReadKey();
                break;
            }
        }
    }
    static void MenuQLSV()
    {
        string connectionString = "server=localhost;user=root;password=12345678;database=quan_ly_sinh_vien";
        List<SinhVien> danhsachSinhVien = new List<SinhVien>();
        bool tieptuc = true;
        while(tieptuc)
        {
            Console.WriteLine("====Menu===");
            Console.WriteLine("1.Xem danh sach sinh vien");
            Console.WriteLine("2. Them Sinh Vien");
            Console.WriteLine("3. Sua thong tin sinh vien");
            Console.WriteLine("4. Xoa sinh vien");
            Console.WriteLine("5. Tim kiem sinh vien theo ma sinh vien :");
            Console.WriteLine("0.THoat");
            Console.WriteLine("Chon chuc nang");
            int luachon = int.Parse(Console.ReadLine());
            switch(luachon)
            {
                case 1:
                    HienThiDanhSachSinhVien(danhsachSinhVien);
                    break;
                case 2:
                    ThemSinhVien(danhsachSinhVien, connectionString);
                    break;
                case 3:
                    SuathongtinSinhVien(danhsachSinhVien, connectionString);
                    break;
                case 4 :
                    XoaSinhVien(danhsachSinhVien, connectionString);
                    break;
                case 5 :
                    TimkiemsinhvientheoMaSinhVien(danhsachSinhVien, connectionString);
                    break;
                case 0:
                    tieptuc = false;
                    break;
                default:
                    Console.WriteLine("Chuc nang khong hop le. Vui long chon lai");
                    break;
            }                        
        }
    }
    static void MenuQLGV()
    {
        string connectionString = "server=localhost;user=root;password=12345678;database=quan_ly_sinh_vien";
        List<GiangVien> danhsachGiangVien = new List<GiangVien>();
        while(true)
        {
            Console.WriteLine("Quan ly giang vien");
            Console.WriteLine("1.Xem danh sach giang vien");
            Console.WriteLine("2. Xoa giang vien");
            Console.WriteLine("3. Sua thong tin giang vien");
            Console.WriteLine("6. Them Giang Vien");
            Console.WriteLine("5.Tim kiem giang vien theo ma giang vien :");
            Console.WriteLine("0. Quay lai menu chinh");
            Console.Write("Chon mot tuy chon :");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    Xemdanhsachgiangvien(danhsachGiangVien);
                    break;
                case "2":
                    Xoagiangvien(danhsachGiangVien, connectionString);
                    break;
                case "3":
                    SuaGiangVien(danhsachGiangVien, connectionString);
                    break;
                case "6":
                    ThemGiangVien(danhsachGiangVien, connectionString);
                    break;
                case "5":
                    TimkiemgiangvientheomaGv(danhsachGiangVien, connectionString);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Tuy chon khong hop le. Vui long thu lai");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void QuanlyKhoaHoc()
    {
        string connectionString = "Server=localhost;user=root;Pwd=12345678;Database=quan_ly_sinh_vien";
        List<KhoaHoc> danhsachKhoaHoc = new List<KhoaHoc>();
        bool tieptuc = true;
        while(tieptuc)
        {
        Console.WriteLine("====Menu========");
        Console.WriteLine("1.Them Khoa Hoc moi");
        Console.WriteLine("2. Sua thong tin khoa hoc");
        Console.WriteLine("3. Xoa Khoa Hoc ");
        Console.WriteLine("4. Liet ke khoa hoc");
        Console.WriteLine("5.Tim kiem khoa hoc theo ma khoa hoc");
        Console.WriteLine("0.Quay lai menu chinh ");
        Console.WriteLine("Lua chon cua ban: ");
        int choice = int.Parse(Console.ReadLine());
        switch(choice)
            {
                case 1:
                    ThemKhoaHocMoi(danhsachKhoaHoc, connectionString);
                    break;
                case 2:
                    SuathongtinKhoaHoc(danhsachKhoaHoc, connectionString);
                    break;
                case 3:
                    XoaKhoaHoc(danhsachKhoaHoc, connectionString);
                    break;
                case 4:
                    LietkeKhoaHoc(danhsachKhoaHoc);
                    break;
                case 5:
                    Timkiemkhoahoctheoma(danhsachKhoaHoc, connectionString);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le");
                    break;
            }
        }
        
    }
    static void QuanLyDangKi()
    {
        string connectionString = "Server=localhost;user=root;Database=quan_ly_sinh_vien;Pwd=12345678";
        List<DangKi> danhsachDangKi = new List<DangKi>();
        bool tieptuc = true;
        while(true)
        {
            Console.WriteLine("====Menu====");
            Console.WriteLine("1.Them sinh vien dki khoa hoc:");
            Console.WriteLine("2.Xem danh sach dang ki ");
            Console.WriteLine("0.Tro ve menu chinh");
            int luachon = int.Parse(Console.ReadLine());
            switch(luachon)
            {
                case 1:
                    ThemsinhvienDki(danhsachDangKi,connectionString);
                    break;
                case 2:
                    XemdanhsachDki(danhsachDangKi);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le");
                    break;
            }
            
        }
    }
    static void QLkhac()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Cac quan ly khav :");
            Console.WriteLine("0. Quay lai menu chinh");
            Console.Write("Chon mot tuy chon");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                    return;
                default:
                    Console.WriteLine("Tuy chon khong hop le. Vui long thu lai");
                    Console.ReadKey();
                    break;
            }
        }
    }

    
    static void HienThiDanhSachSinhVien(List<SinhVien> danhsachSinhVien){
        Console.WriteLine("==== Danh sach Sinh Vien ====");
            foreach(var sv in danhsachSinhVien)
                {
                    Console.WriteLine($"Ma sinh vien : {sv.MaSinhVien},Lop: {sv.Lop}, Ho ten: {sv.HoTen}, Ngay Sinh {sv. NgaySinh}, GioiTinh: {sv.GioiTinh}, Email: {sv.Email}, So dien thoai: {sv.SoDienThoai}, Dia chi : {sv.DiaChi}, Ma Nganh Hoc: {sv.MaNganhHoc}");
                }
    }
    static void ThemSinhVien(List<SinhVien> danhsachSinhVien, string connectionString)
    {
        Console.WriteLine("Nhap thong tin sinh vien moi");
        SinhVien sv = new SinhVien();
        Console.Write("Nhap ma sinh vien");
        sv.MaSinhVien = int.Parse(Console.ReadLine());
        Console.Write("Nhap ho ten");
        sv.HoTen = Console.ReadLine();
        Console.Write("Nhap Ngay Sinh");
        sv.NgaySinh = DateTime.Parse(Console.ReadLine());
        Console.Write("Nhap gioi tinh");
        sv.GioiTinh = Console.ReadLine();
        Console.Write("Nhap email");
        sv.Email = Console.ReadLine();
        Console.Write("Nhap so dien thoai");
        sv.SoDienThoai = Console.ReadLine();
        Console.Write("Nhap dia chi");
        sv.DiaChi = Console.ReadLine();
        Console.Write("Nhap ma nganh hoc");
        sv.MaNganhHoc = int.Parse(Console.ReadLine());
        Console.Write("Nhap ten Lop :");
        sv.Lop = Console.ReadLine();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO sinh_vien(Ma_Sinh_Vien, Ho_ten, Ngay_sinh, Gioi_tinh, Email, So_dien_thoai, Dia_chi, Ma_nganh_hoc, Lop) Values (@MaSinhVien, @HoTen, @NgaySinh, @GioiTinh , @Email, @SoDienThoai, @DiaChi, @MaNganhHoc, @Lop)";
            using (MySqlCommand command = new MySqlCommand(query , connection))
            {
            command.Parameters.AddWithValue("@MaSinhVien",sv.MaSinhVien);
            command.Parameters.AddWithValue("@HoTen", sv.HoTen);
            command.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
            command.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
            command.Parameters.AddWithValue("@Email", sv.Email);
            command.Parameters.AddWithValue("@SoDienThoai", sv.SoDienThoai);
            command.Parameters.AddWithValue("@Diachi", sv.DiaChi);
            command.Parameters.AddWithValue("@MaNganhHoc", sv.MaNganhHoc);
            command.Parameters.AddWithValue("@Lop", sv.Lop);
            command.ExecuteNonQuery();
            }
            danhsachSinhVien.Add(sv);
            Console.WriteLine("Them sinh vien thanh cong");
        }
    } 
    static void SuathongtinSinhVien(List<SinhVien> danhsachSinhVien, string connectionString)
    {
        Console.WriteLine("Nhap ma sinh vien can sua");
        int MaSinhVien = int.Parse(Console.ReadLine());
        SinhVien sv = danhsachSinhVien.Find(s=>s.MaSinhVien == MaSinhVien);
        if(sv != null)
        {
            Console.Write("Nhap thong tin moi");
            Console.Write("Nhap ma sinh vien");
            sv.MaSinhVien = int.Parse(Console.ReadLine());
            Console.Write("Nhap ho ten");
            sv.HoTen = Console.ReadLine();
            Console.Write("Nhap Ngay Sinh");
            sv.NgaySinh = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhap gioi tinh");
            sv.GioiTinh = Console.ReadLine();
            Console.Write("Nhap email");
            sv.Email = Console.ReadLine(); 
            Console.Write("Nhap so dien thoai");
            sv.SoDienThoai = Console.ReadLine();
            Console.Write("Nhap dia chi");
            sv.DiaChi = Console.ReadLine();
            Console.Write("Nhap ma nganh hoc");
            sv.MaNganhHoc = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten lop :");
            sv.Lop = Console.ReadLine();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE sinh_vien Set Ho_ten = @HoTen, Lop = @Lop, Ngay_sinh = @NgaySinh, Email = @Email, So_dien_thoai = @SoDienThoai, Gioi_tinh = @GioiTinh WHERE Ma_Sinh_Vien = @MaSinhVien";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien",sv.MaSinhVien);
                    command.Parameters.AddWithValue("@HoTen", sv.HoTen);
                    command.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                    command.Parameters.AddWithValue("@Email", sv.Email);
                    command.Parameters.AddWithValue("@SoDienThoai", sv.SoDienThoai);
                    command.Parameters.AddWithValue("@Diachi", sv.DiaChi);
                    command.Parameters.AddWithValue("@MaNganhHoc", sv.MaNganhHoc);
                    command.Parameters.AddWithValue("@Lop", sv.Lop);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Sua thanh cong");
            }
        }
        else
        {
            Console.WriteLine("loi");
        }
    }
    static void XoaSinhVien(List<SinhVien> danhsachSinhVien, string connectionString)
    {
        Console.WriteLine("Nhap id can xoa");
        int MaSinhVien = int.Parse(Console.ReadLine());
        SinhVien sv = danhsachSinhVien.Find(s=>s.MaSinhVien == MaSinhVien);
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM sinh_vien WHERE Ma_Sinh_Vien = @MaSinhVien";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien", MaSinhVien);
                    command.ExecuteNonQuery();
                }
            }
        danhsachSinhVien.Remove(sv);
        Console.WriteLine("Xoa sinh vien hoan tat");
    }
    static void Xemdanhsachgiangvien(List<GiangVien> danhsachGiangVien)
    {
        Console.WriteLine("==== Danh sach Giang Vien ====");
        foreach(var gv in danhsachGiangVien)
        {
            Console.WriteLine($"MaGiangVien: {gv.MaGiangVien}, HoTen: {gv.HoTen}, Email: {gv.Email}, SoDienThoai: {gv.SoDienThoai}, Khoa: {gv.Khoa}, ChucDanh: {gv.ChucDanh} ");
        }
    }
    static void ThemGiangVien(List<GiangVien> danhsachGiangVien, string connectionString)
    {
        Console.WriteLine("Nhap Giang Vien moi:");
        GiangVien gv = new GiangVien();
        Console.Write("Nhap Ma Giang Vien :");
        gv.MaGiangVien = int.Parse(Console.ReadLine());
        Console.Write("Nhap Ho Ten giang vien: ");
        gv.HoTen = Console.ReadLine();
        Console.WriteLine(" Nhap email giang vien :");
        gv.Email = Console.ReadLine();
        Console.Write("Nhap Sdt: ");
        gv.SoDienThoai = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhap Khoa :");
        gv.Khoa = Console.ReadLine();
        Console.WriteLine("Nhap Chuc Danh:");
        gv.ChucDanh = Console.ReadLine();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO giang_vien1(HoTen, MaGiangVien, Email , SoDienThoai, Khoa , ChucDanh) VALUES(@HoTen, @MaGiangVien, @Email, @SoDienThoai, @Khoa , @ChucDanh)";
            using (MySqlCommand command = new MySqlCommand(query , connection))
            {
                command.Parameters.AddWithValue("@HoTen", gv.HoTen);
                command.Parameters.AddWithValue("@Email", gv.Email);
                command.Parameters.AddWithValue("@MaGiangVien", gv.MaGiangVien);
                command.Parameters.AddWithValue("@SoDienThoai", gv.SoDienThoai);
                command.Parameters.AddWithValue("@Khoa", gv.Khoa);
                command.Parameters.AddWithValue("@ChucDanh", gv.ChucDanh);
                command.ExecuteNonQuery();
            }
        }
            danhsachGiangVien.Add(gv);
            Console.WriteLine("Da them giang vien moi thanh cong");
    }
    static void SuaGiangVien(List<GiangVien> danhsachGiangVien, string connectionString)
    {
        Console.WriteLine("Nhap ma giang vien can sua");
        int MaGiangVien = int.Parse(Console.ReadLine());
        GiangVien gv = danhsachGiangVien.Find(s => s.MaGiangVien ==  MaGiangVien);
        if(gv!=null)
        {
            Console.WriteLine("Nhap thong tin giang vien can sua");
            Console.Write("Nhap Ma Giang Vien: ");
            gv.MaGiangVien = int.Parse(Console.ReadLine());
            Console.Write("Nhap Ho ten giang vien moi: ");
            gv.HoTen = Console.ReadLine();
            Console.Write("Nhap Sdt");
            gv.SoDienThoai = int.Parse(Console.ReadLine());
            Console.Write("Nhap Email:");
            gv.Email = Console.ReadLine();
            Console.Write("Nhap Khoa :");
            gv.Khoa = Console.ReadLine();
            Console.Write("Nhap Chuc Danh :");
            gv.ChucDanh = Console.ReadLine();
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE giang_vien1 SET HoTen = @HoTen, Email = @Email, SoDienThoai = @SoDienThoai, ChucDanh = @ChucDanh, Khoa = @Khoa WHERE MaGiangVien = @MaGiangVien";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HoTen", gv.HoTen);
                    command.Parameters.AddWithValue("@Email", gv.Email);
                    command.Parameters.AddWithValue("@SoDienThoai", gv.SoDienThoai);
                    command.Parameters.AddWithValue("@MaGiangVien", gv.MaGiangVien);
                    command.Parameters.AddWithValue("@ChucDanh", gv.ChucDanh);
                    command.Parameters.AddWithValue("@Khoa", gv.Khoa);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Sua thong tin giang vien thanh cong");
        }
        else{
            Console.WriteLine("Khong tim thay giang vien co id");
        }
    }
    static void Xoagiangvien(List<GiangVien> danhsachGiangVien, string connectionString)
    {
        Console.WriteLine("Nhap Ma Giang Vien can xoa :");
        int MaGiangVien = int.Parse(Console.ReadLine());
        GiangVien gv = danhsachGiangVien.Find(s=>s.MaGiangVien==MaGiangVien);
        using(MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM giang_vien1 WHERE MaGiangVien = @MaGiangVien";
            using(MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MaGiangVien", MaGiangVien);
                command.ExecuteNonQuery();
            }
        danhsachGiangVien.Remove(gv);
        Console.WriteLine("Xoa Hoan tat");
        }
    }
    static void TimkiemsinhvientheoMaSinhVien(List<SinhVien> danhsachSinhVien , string connectionString)
    {
        Console.WriteLine("Nhap ma sinh vien can tim :");
        string keyword = Console.ReadLine();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM sinh_vien WHERE Ma_Sinh_Vien LIKE @Keyword ";
            using(MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        Console.WriteLine("Ket qua tim kiem :");
                        while(reader.Read())
                        {
                            Console.WriteLine($"MaSinhVien: {reader ["Ma_Sinh_Vien"]}, HoTen: {reader ["Ho_ten"]}, GioiTinh: {reader ["Gioi_tinh"]}, NgaySinh: {reader["Ngay_sinh"]}, Lop: {reader["Lop"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Khong tim thay SinhVien co ma SinhVien tren :");
                    }
                }
            }
        }
    }
    static void TimkiemgiangvientheomaGv(List<GiangVien> danhsachGiangVien, string connectionString)
    {
        Console.WriteLine("Nhap ma Giang Vien can tim ");
        string keyword = Console.ReadLine();
        using(MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM giang_vien1 WHERE MaGiangVien LIKE @Keyword ";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        Console.WriteLine("Ket qua tim kiem :");
                        while (reader.Read())
                        {
                            Console.WriteLine($"MaGiangVien:{reader["MaGiangVien"]}, HoTen: {reader["HoTen"]}, Khoa: {reader["Khoa"]}, ChucDanh: {reader["ChucDanh"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Khong tim thay GiangVien co ma GiangVien tren :");
                    }
                }
            }
        }
    }
    static void ThemKhoaHocMoi(List<KhoaHoc> danhsachKhoaHoc, string connectionString)
    {
        Console.WriteLine("Nhap thong tin Khoa Hoc :");
        KhoaHoc kh = new KhoaHoc();
        Console.Write("Nhap Ma Khoa Hoc : ");
        kh.MaKhoaHoc = int.Parse(Console.ReadLine());
        Console.Write("Nhap ten khoa hoc :");
        kh.TenKhoaHoc = Console.ReadLine();
        Console.Write("Viet Mo Ta :");
        kh.MoTa = Console.ReadLine();
        Console.Write("Nhap ten nguoi Phu Trach : ");
        kh.PhuTrach = Console.ReadLine();
        using(MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO khoa_hoc(Ma_Khoa_Hoc, Ten_Khoa_Hoc, Mo_Ta, Phu_Trach) VALUES (@MaKhoaHoc , @TenKhoaHoc, @MoTa, @PhuTrach)";
            using(MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MaKhoaHoc", kh.MaKhoaHoc);
                command.Parameters.AddWithValue("@TenKhoaHoc", kh.TenKhoaHoc);
                command.Parameters.AddWithValue("@MoTa", kh.MoTa);
                command.Parameters.AddWithValue("@PhuTrach", kh.PhuTrach);
                command.ExecuteNonQuery();
            }
        }
        danhsachKhoaHoc.Add(kh);
        Console.WriteLine("Da them thanh cong ");

    }
    static void LietkeKhoaHoc(List<KhoaHoc> danhsachKhoaHoc)
    {
        Console.WriteLine(" Danh sach khoa hoc : ");
        foreach(var kh in danhsachKhoaHoc)
        {
            Console.WriteLine($"MaKhoaHoc: {kh.MaKhoaHoc}, TenKhoaHoc: {kh.TenKhoaHoc}, MoTa: {kh.MoTa}, PhuTrach: {kh.PhuTrach} ");
        }
    }
    static void XoaKhoaHoc(List<KhoaHoc> danhsachKhoaHoc , string connectionString)
    {
        Console.WriteLine("Nhap Ma Khoa Hoc can xoa :");
        int MaKhoaHoc = int.Parse(Console.ReadLine());
        KhoaHoc kh = danhsachKhoaHoc.Find(s=>s.MaKhoaHoc==MaKhoaHoc);
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM khoa_hoc WHERE Ma_Khoa_Hoc = @MaKhoaHoc";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MaKhoaHoc", kh.MaKhoaHoc);
                command.ExecuteNonQuery();
            }
        }
        danhsachKhoaHoc.Remove(kh);
        Console.WriteLine("Xoa hoan tat ");
    }
    static void SuathongtinKhoaHoc(List<KhoaHoc> danhsachKhoaHoc, string connectionString)
    {
        Console.WriteLine("Nhap ma khoa hoc can sua :");
        int MaKhoaHoc = int.Parse(Console.ReadLine());
        KhoaHoc kh = danhsachKhoaHoc.Find(s=>s.MaKhoaHoc==MaKhoaHoc);
        Console.Write("Nhap ten khoa hoc :");
        kh.TenKhoaHoc = Console.ReadLine();
        Console.Write("Nhap mo ta :");
        kh.MoTa = Console.ReadLine();
        Console.Write("Nhap phu trach :");
        kh.PhuTrach = Console.ReadLine();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE khoa_hoc SET Ten_Khoa_Hoc = @TenKhoaHoc, Mo_Ta = @MoTa, Phu_Trach = @PhuTrach WHERE Ma_Khoa_Hoc = @MaKhoaHoc)";
            using (MySqlCommand command = new MySqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@MaKhoaHoc", MaKhoaHoc);
                command.Parameters.AddWithValue("@TenKhoaHoc", kh.TenKhoaHoc);
                command.Parameters.AddWithValue("@MoTa", kh.MoTa);
                command.Parameters.AddWithValue("@PhuTrach", kh.PhuTrach);
            }
        }
        Console.WriteLine("Sua thanh cong");

    }
    static void Timkiemkhoahoctheoma(List<KhoaHoc> danhsachKhoaHoc , string connectionString)
    {
        Console.WriteLine("Nhap ma khoa hoc can tim :");
        string keyword = Console.ReadLine();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM khoa_hoc WHERE Ma_Khoa_Hoc LIKE @Keyword";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        Console.WriteLine("Ket qua tim kiem :");
                        while(reader.Read())
                        {
                            Console.WriteLine($"MaKhoaHoc{reader["Ma_Khoa_Hoc"]}, TenKhoaHoc: {reader["Ten_Khoa_Hoc"]}, MoTa: {reader["Mo_Ta"]}, Phu_Trach: {reader["Phu_Trach"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Khong tim thay ");
                    }
                }
            }
        }
    }
    static void ThemsinhvienDki(List<DangKi> danhsachDangKi , string connectionString)
    {
        Console.WriteLine("Them danh sach dang ki ");
        DangKi dk = new DangKi();
        Console.Write("Nhap Ma Dang Ki :");
        dk.MaDangKi = int.Parse(Console.ReadLine());
        Console.Write("Nhap Ma Sinh Vien: ");
        dk.MaSinhVien = int.Parse(Console.ReadLine());
        Console.Write("Nhap Ma Khoa Hoc: ");
        dk.MaKhoaHoc = int.Parse(Console.ReadLine());
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO dangki(Ma_Dang_Ki, Ma_Sinh_Vien, Ma_Khoa_Hoc) VALUES (@MaDangKi, @MaSinhVien, @MaKhoaHoc)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MaDangKi", dk.MaDangKi);
                command.Parameters.AddWithValue("@MaSinhVien", dk.MaSinhVien);
                command.Parameters.AddWithValue("@MaKhoaHoc", dk.MaKhoaHoc);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("dki hoan tat");
    }
    static void XemdanhsachDki(List<DangKi> danhsachDangKi)
    {
        foreach (var dk in danhsachDangKi)
        {
            Console.WriteLine($"MaDangKi: {dk.MaDangKi}, MaSinhVien: {dk.MaSinhVien}, MaKhoaHoc: {dk.MaKhoaHoc}");
        }
    }
}

