using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BooksProperties
    {
        public Book book = new Book();
        CategoryBL categoryBL = new CategoryBL();
        AuthorBL authorBL = new AuthorBL();
        PublisherBL publisherBL = new PublisherBL();
        BorrowBL borrowBL = new BorrowBL();

        public string Name()
        {
            return book.TenSach;
        }

        public string Type()
        {
            if (book.LoaiSach == 0)
                return "Sách đơn";
            else return "Sách bộ";
        }

        public string Status()
        {
            switch (book.TrangThai)
            {
                case 0:
                    return "Đang có sẵn";
                case 1:
                    return "Cho mượn";
                case 2:
                    return "Đang mượn";
                case 3:
                    return "Đã trả";
                default:
                    return "Unknown";
            }
        }

        public string CategoryName()
        {
            List<Category> categoryList = categoryList = categoryBL.GetAll();
            return categoryList.Find(x => x.ID == book.ID_TheLoai).TenTheLoai;
        }

        public string AuthorName()
        {
            List<Author> authorList = authorList = authorBL.GetAll();
            return (book.ID_TacGia != null) ? authorList.Find(x => x.ID == book.ID_TacGia).TenTacGia : null;
        }

        public string PublisherName()
        {
            List<Publisher> publisherList = publisherBL.GetAll();
            return (book.ID_NhaXuatBan != null) ? publisherList.Find(x => x.ID == book.ID_NhaXuatBan).TenNhaXuatBan : null;
        }

        public string PublishedYear()
        {
            return book.NamXuatBan;
        }

        public string Location()
        {
            return book.ViTri;
        }

        public string Notes()
        {
            return book.GhiChu;
        }

        public string BorrowName()
        {
            List<Borrow> borrowList = borrowBL.GetAll();
            return (book.ID_Muon != null) ? borrowList.Find(x => x.ID == book.ID_Muon).Ten : null;
        }

        public string BorrowPhoneNum()
        {
            List<Borrow> borrowList = borrowBL.GetAll();
            return (book.ID_Muon != null) ? borrowList.Find(x => x.ID == book.ID_Muon).SoDienThoai : null;
        }
    }
}
