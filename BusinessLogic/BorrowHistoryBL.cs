using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BorrowHistoryBL
    {
        BorrowHistoryDA borrowHistoryDA = new BorrowHistoryDA();

        public List<BorrowHistory> GetAll()
        {
            return borrowHistoryDA.GetAll();
        }

        public BorrowHistory GetByID(int ID)
        {
            List<BorrowHistory> allHistory = GetAll();
            foreach (var item in allHistory)
            {
                if (item.ID == ID) return item;
            }
            return null;
        }

        public int Insert(BorrowHistory borrowHistory)
        {
            return borrowHistoryDA.Insert_Update_Delete(borrowHistory, 0);
        }

        public int Update(BorrowHistory borrowHistory)
        {
            return borrowHistoryDA.Insert_Update_Delete(borrowHistory, 1);
        }

        public int Delete(BorrowHistory borrowHistory)
        {
            return borrowHistoryDA.Insert_Update_Delete(borrowHistory, 2);
        }
    }
}
