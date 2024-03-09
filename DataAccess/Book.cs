using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Book
    {
        public int ID { get; set; }
        public int LoaiSach { get; set; }
        public int ID_TheLoai { get; set; }
        public string TenSach { get; set; }
        public int ID_TacGia { get; set; }
        public string NamXuatBan { get; set; }
        public int ID_NhaXuatBan { get; set; }
        public string ViTri { get; set; }
        public int TenTrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}
