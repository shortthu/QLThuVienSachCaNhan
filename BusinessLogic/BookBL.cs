using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BookBL
    {
        BookDA bookDA = new BookDA();

        public List<Book> GetAll()
        {
            return bookDA.GetAll();
        }

        public Book GetByID(int ID)
        {
            List<Book> allBooks = GetAll();
            foreach (var book in allBooks)
            {
                if (book.ID == ID) return book;
            }
            return null;
        }

        public List<Book> Find(string key)
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
            {
                if (book.ID.ToString().Contains(key)
                    || book.TenSach.Contains(key)
                    || book.NamXuatBan.ToString().Contains(key)
                    || book.ViTri.Contains(key)
                    || book.GhiChu.Contains(key))
                    result.Add(book);
            }
            return result;
        }

        public List<Book> FilterBookByCategory(int category)
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.ID_TheLoai == category)
                    result.Add(book);
            return result;
        }

        public int Insert(Book book)
        {
            return bookDA.Insert_Update_Delete(book, 0);
        }

        public int Update(Book book)
        {
            return bookDA.Insert_Update_Delete(book, 1);
        }

        public int Delete(Book book)
        {
            return bookDA.Insert_Update_Delete(book, 2);
        }
    }
}
