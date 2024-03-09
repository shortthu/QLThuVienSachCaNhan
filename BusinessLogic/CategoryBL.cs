using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CategoryBL
    {
        CategoryDA categoryDA = new CategoryDA();

        public List<Category> GetAll()
        {
            return categoryDA.GetAll();
        }

        public int Insert(Category category)
        {
            return categoryDA.Insert_Update_Delete(category, 0);
        }

        public int Update(Category category)
        {
            return categoryDA.Insert_Update_Delete(category, 1);
        }

        public int Delete(Category category)
        {
            return categoryDA.Insert_Update_Delete(category, 2);
        }
    }
}
