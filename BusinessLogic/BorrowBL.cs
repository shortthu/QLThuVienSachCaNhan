using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BorrowBL
    {
        BorrowDA borrowDA = new BorrowDA();

        public List<Borrow> GetAll()
        {
            return borrowDA.GetAll();
        }

        public int Insert(Borrow borrow)
        {
            return borrowDA.Insert_Update_Delete(borrow, 0);
        }

        public int Update(Borrow borrow)
        {
            return borrowDA.Insert_Update_Delete(borrow, 1);
        }

        public int Delete(Borrow borrow)
        {
            return borrowDA.Insert_Update_Delete(borrow, 2);
        }
    }
}
