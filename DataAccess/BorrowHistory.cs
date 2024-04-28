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
        public int ID_Sach { get; set; }
        public int ID_Muon { get; set; }
        public int HinhThuc { get; set; }
        public DateTime ThoiGian { get; set; }
    }
}
