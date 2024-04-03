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

        public List<Book> Search(List<Book> listToSearch, string key)
        {
            List<Book> searchedBooks = new List<Book>();
            BooksProperties booksProperties = new BooksProperties();

            foreach (var book in listToSearch)
            {
                booksProperties.book = book;
                if (book.ID.ToString().Contains(key)
                    || StringExtensions.Contains(booksProperties.Name(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.Type(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.Status(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.CategoryName(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.AuthorName(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.PublisherName(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.PublishedYear(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.Location(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.Notes(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.BorrowName(), key, StringComparison.OrdinalIgnoreCase)
                    || StringExtensions.Contains(booksProperties.BorrowPhoneNum(), key, StringComparison.OrdinalIgnoreCase))
                    searchedBooks.Add(book);
            }
            return searchedBooks;
        }

        public List<Book> FilterBookByCategory(int category)
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.ID_TheLoai == category && book.TrangThai < 3)
                    result.Add(book);
            return result;
        }

        public List<Book> FilterCurrent()
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.TrangThai < 3)
                    result.Add(book);
            return result;
        }

        public List<Book> FilterLending()
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.TrangThai == 1)
                    result.Add(book);
            return result;
        }

        public List<Book> FilterBorrowing()
        {
            List<Book> allBooks = GetAll();
            List<Book> result = new List<Book>();
            foreach (var book in allBooks)
                if (book.TrangThai == 2)
                    result.Add(book);
            return result;
        }

        public List<Book> FilterPast()
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
