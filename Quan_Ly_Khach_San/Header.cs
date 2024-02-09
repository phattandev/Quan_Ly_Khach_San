using System.Data;
using static System.Console;

namespace Quan_Ly_Khach_San
{
    public class Nguoi : KhachSan
    {
        public string HoTen;
        public long CMND;
        public int SoNgay;
        public char LoaiPhong;
        public Nguoi(string hoten, long cmnd, int songay, char loaiphong, string tinhtrang)
        {
            HoTen = hoten;
            CMND = cmnd; 
            SoNgay = songay;
            LoaiPhong = loaiphong;
            TinhTrang = tinhtrang;
        }
    }

    public class KhachSan
    {
        public static int soLuongPhong = 100;
        public string TinhTrang;
        public KhachSan(string tinhtrang)
        {
            TinhTrang = tinhtrang;
        }
        public KhachSan() // Phương thức khởi tạo mặc định
        {
            TinhTrang = "Trong";
        }
    }

    public class QuanLy : KhachSan
    {

        public QuanLy(string tinhtrang):base(tinhtrang)
        {
            
        }


        public static void GetInfo(ref List<Nguoi> danhSach)
        {
            Write("Nhap ten: ");
            string ten = ReadLine();
            Write("Nhap CMND: ");
            string Checkcmnd = ReadLine();
            long cmnd;
            //bool flagCMND = true;
            while (true)
            {
                if (long.TryParse(Checkcmnd, out cmnd))
                {
                    if (Checkcmnd.Length == 12)
                    {
                        bool flagCMND = true;
                        foreach (var nguoi in danhSach)
                        {
                            if (nguoi.CMND == cmnd)
                            {
                                flagCMND = false;
                                break;
                            }
                        }

                        if (!flagCMND)
                        {
                            Write("CMND da bi trung!!! Nhap lai CMND: ");
                            Checkcmnd = ReadLine();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Write("Nhap sai cmnd!!! Moi nhap lai: ");
                    Checkcmnd = ReadLine();
                }
            }
            

            Write("Nhap so ngay thue: ");
            int songay = int.Parse(Console.ReadLine());
            Write("Nhap loai phong ( A || B || C ): ");
            char loaiphong;// = char.Parse(Console.ReadLine());
            string tempLoaiPhong = ReadLine().ToUpper();
            while (true)
            {
                if (char.TryParse(tempLoaiPhong, out loaiphong))
                {
                    if (loaiphong < 'A' || loaiphong > 'C')
                    {
                        Write("Nhap sai! Moi nhap lai loai phong ( A || B || C ): ");
                        tempLoaiPhong = ReadLine();
                    }
                    else
                    {
                        switch (loaiphong)
                        {
                            case 'A':
                                WriteLine("Loai phong vua chon la A voi gia 500$/1day");
                                break;
                            case 'B':
                                WriteLine("Loai phong vua chon la B voi gia 300$/1day");
                                break;
                            case 'C':
                                WriteLine("Loai phong vua chon la C voi gia 100$/1day");
                                break;
                        }
                    }
                    break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai loai phong ( A || B || C ): ");
                    tempLoaiPhong = ReadLine();
                }
            }
            
            string tinhTrang = "Co nguoi";
            Nguoi customer = new Nguoi(ten, cmnd, songay, loaiphong, tinhTrang);
            danhSach.Add(customer);
        }

        public static void XuatDanhSach(List<Nguoi> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
            {
                WriteLine("Danh sách không có khách hàng nào!!!");
                return;
            }

            foreach (var nguoi in danhSach)
            {
                Console.WriteLine($"Ho ten: {nguoi.HoTen}, CMND: {nguoi.CMND}, So ngay thue: {nguoi.SoNgay}, Loai phong: {nguoi.LoaiPhong}");
            }
        }

        public static void XoaKhachHang(ref List<Nguoi> danhSach)
        {
            Write("Nhap cmnd khach hang da tra phong:");
            string Checkcmnd = ReadLine();
            long cmnd;
            while (true)
            {
                if(long.TryParse(Checkcmnd, out cmnd))
                {
                    Nguoi customer = null;
                    foreach (var nguoi in danhSach)
                    {
                        if (nguoi.CMND == cmnd)
                        {
                            customer = nguoi;
                            break;
                        }
                    }
                    if (customer != null)
                    {
                        danhSach.Remove(customer);
                        customer.TinhTrang = "Trong";
                        WriteLine($"Da xoa khach hang co CMND: {customer.CMND} khoi danh sach.");
                    }
                    else
                    {
                        WriteLine($"Khong tim that khach hang co CMND: {customer.CMND} trong danh sach.");
                    }
                    break;
                }
                else
                {
                    Write("Nhap sai cmnd!!! Moi nhap lai: ");
                    Checkcmnd = ReadLine();
                }
            }
        }

        public static void TinhTien(List<Nguoi> danhSach)
        {
            Write("Nhap cmnd khach hang can tinh tien:");
            string Checkcmnd = ReadLine();
            long cmnd;
            while (true)
            {
                if (long.TryParse(Checkcmnd, out cmnd))
                {
                    if (Checkcmnd.Length != 12)
                    {
                        Write("Nhap sai cmnd!!! Moi nhap lai: ");
                        Checkcmnd = ReadLine();
                    }
                    else
                    {
                        Nguoi customer = null;
                        foreach (var nguoi in danhSach)
                        {
                            if (nguoi.CMND == cmnd)
                            {
                                customer = nguoi;
                                break;
                            }
                        }
                        if (customer != null)
                        {
                            int tongTien = 0;
                            if (customer.LoaiPhong == 'A' || customer.LoaiPhong == 'a')
                                tongTien = customer.SoNgay * 500;
                            else if (customer.LoaiPhong == 'B' || customer.LoaiPhong == 'b')
                                tongTien = customer.SoNgay * 300;
                            else if (customer.LoaiPhong == 'C' || customer.LoaiPhong == 'c')
                                tongTien = customer.SoNgay * 100;
                            WriteLine($"Tong so tien khach hang {customer.HoTen} phai thanh toan la: {tongTien}$");
                        }
                        else
                        {
                            WriteLine($"Khong tim that khach hang co CMND: {customer.CMND} trong danh sach.");
                        }
                        break;
                    }
                }
                else
                {
                    Write("Nhap sai cmnd!!! Moi nhap lai: ");
                    Checkcmnd = ReadLine();
                }
            }
        }

        public static void Menu(List<Nguoi> danhSach)
        {
            WriteLine("---------------Menu---------------");
            WriteLine("     1.Them khach.");
            WriteLine("     2.Xuat danh sach khach hang.");
            WriteLine("     3.Xoa khach theo cmnd.");
            WriteLine("     4.Tinh tien.");
            WriteLine("     5.Thoat chuong trinh.");
            WriteLine("----------------------------------");
            Write("Chon chuc nang: ");
            string tempChoose = ReadLine();
            int choose;
            while (true)
            {
                if(int.TryParse(tempChoose, out choose))
                {
                    if (choose < 1 || choose > 5)
                    {
                        Clear();
                        Menu(danhSach);
                        Write("Lua chon khong ton tai. Moi chon lai: ");
                        tempChoose = ReadLine();
                    }
                    else break;

                }
                else
                {
                    Write("Nhap sai! Moi nhap lai: ");
                    tempChoose = ReadLine();
                }
            }
            switch (choose)
            {
                case 1:
                    Clear(); WriteLine();
                    WriteLine("--Nhap thong tin khach hang--");
                    //Ko co static
                    //QuanLy quanly = new QuanLy("Trong");
                    //quanly.GetInfo(ref danhSach);
                    //Co static
                    QuanLy.GetInfo(ref danhSach);
                    Menu(danhSach);
                    break;
                case 2:
                    Clear();WriteLine();
                    WriteLine("--Xuat thong tin khach hang--");
                    XuatDanhSach(danhSach);
                    Menu(danhSach);
                    break;
                case 3:
                    Clear(); WriteLine();
                    XoaKhachHang(ref danhSach);
                    Menu(danhSach);
                    break;
                case 4:
                    Clear(); WriteLine();
                    TinhTien(danhSach);
                    Menu(danhSach);
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
    }
}
