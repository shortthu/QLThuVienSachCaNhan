using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BorrowHistory
    {
        public int ID { get; set; }
        public string TenSach { get; set; }
        public string TenNguoiMuon { get; set; }
        public string SoDienThoaiMuon { get; set; }
        public int HinhThuc { get; set; }
        public DateTime ThoiGian { get; set; }
    }
}
