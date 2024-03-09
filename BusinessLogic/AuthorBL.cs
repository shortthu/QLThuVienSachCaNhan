using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AuthorBL
    {
        AuthorDA authorDA = new AuthorDA();

        public List<Author> GetAll()
        {
            return authorDA.GetAll();
        }

        public int Insert(Author author)
        {
            return authorDA.Insert_Update_Delete(author, 0);
        }

        public int Update(Author author)
        {
            return authorDA.Insert_Update_Delete(author, 1);
        }

        public int Delete(Author author)
        {
            return authorDA.Insert_Update_Delete(author, 2);
        }
    }
}
