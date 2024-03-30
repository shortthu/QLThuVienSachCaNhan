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
            return bookDA.GetAll(0);
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
                    || StringExtensions.Contains(book.TenSach, key, StringComparison.OrdinalIgnoreCase)
                    || book.NamXuatBan.ToString().Contains(key)
                    || StringExtensions.Contains(book.ViTri, key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(book.GhiChu, key, StringComparison.OrdinalIgnoreCase))
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

        public List<Book> FindAvailable()
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.TrangThai == 0)
                    result.Add(book);
            return result;
        }

        public List<Book> FindLending()
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.TrangThai == 1)
                    result.Add(book);
            return result;
        }

        public List<Book> FindBorrowing()
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.TrangThai == 2)
                    result.Add(book);
            return result;
        }

        public List<Book> FindPast()
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.TrangThai == 3)
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
