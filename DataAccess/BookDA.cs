using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDA
    {
        public List<Book> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Book_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Book> list = new List<Book>();
            while (reader.Read())
            {
                Book book = new Book();
                book.ID = Convert.ToInt32(reader["ID"]);
                book.LoaiSach = Convert.ToInt32(reader["LoaiSach"]);
                book.ID_TheLoai = Convert.ToInt32(reader["ID_TheLoai"]);
                book.TenSach = reader["TenSach"].ToString();
                book.ID_TacGia = Convert.ToInt32(Convert.IsDBNull(reader["ID_TacGia"]) ? null : reader["ID_TacGia"]);
                book.NamXuatBan = reader["NamXuatBan"].ToString();
                book.ID_NhaXuatBan = Convert.ToInt32(Convert.IsDBNull(reader["ID_NhaXuatBan"]) ? null : reader["ID_NhaXuatBan"]);
                book.ViTri = reader["ViTri"].ToString();
                book.TenTrangThai = Convert.ToInt32(Convert.IsDBNull(reader["TenTrangThai"]) ? null : reader["TenTrangThai"]);
                book.GhiChu = reader["GhiChu"].ToString();
                list.Add(book);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Book book, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Book_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            cmd.Parameters.Add(IDPara).Value = book.ID;
            cmd.Parameters.Add("@LoaiSach", SqlDbType.Int).Value = book.LoaiSach;
            cmd.Parameters.Add("@ID_TheLoai", SqlDbType.Int).Value = book.ID_TheLoai;
            cmd.Parameters.Add("@TenSach", SqlDbType.NVarChar, 100).Value = book.TenSach;
            cmd.Parameters.Add("@ID_TacGia", SqlDbType.Int).Value = book.ID_TacGia;
            cmd.Parameters.Add("@NamXuatBan", SqlDbType.NChar, 4).Value = book.NamXuatBan;
            cmd.Parameters.Add("@ID_NhaXuatBan", SqlDbType.Int).Value = book.ID_NhaXuatBan;
            cmd.Parameters.Add("@ViTri", SqlDbType.NVarChar, 50).Value = book.ViTri;
            cmd.Parameters.Add("@TenTrangThai", SqlDbType.SmallInt).Value = book.TenTrangThai;
            cmd.Parameters.Add("@ghiChu", SqlDbType.NText).Value = book.GhiChu;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@ID"].Value;
            return 0;
        }
    }
}
