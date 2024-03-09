using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PublisherBL
    {
        PublisherDA publisherDA = new PublisherDA();

        public List<Publisher> GetAll()
        {
            return publisherDA.GetAll();
        }

        public int Insert(Publisher publisher)
        {
            return publisherDA.Insert_Update_Delete(publisher, 0);
        }

        public int Update(Publisher publisher)
        {
            return publisherDA.Insert_Update_Delete(publisher, 1);
        }

        public int Delete(Publisher publisher)
        {
            return publisherDA.Insert_Update_Delete(publisher, 2);
        }
    }
}
