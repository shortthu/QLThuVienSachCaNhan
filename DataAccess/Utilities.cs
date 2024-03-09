using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Utilities
    {
        private static string StrName = "ConnectionStringName";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;

        public static string Publisher_GetAll = "Publisher_GetAll";
        public static string Publisher_InsertUpdateDelete = "Publisher_InsertUpdateDelete";

        public static string Book_GetAll = "Book_GetAll";
        public static string Book_InsertUpdateDelete = "Book_InsertUpdateDelete";

        public static string Author_GetAll = "Author_GetAll";
        public static string Author_InsertUpdateDelete = "Author_InsertUpdateDelete";

        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";
    }
}
