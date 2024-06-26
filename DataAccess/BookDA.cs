﻿using System;
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
        public List<Book> GetAll(int func)
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            switch (func)
            {
                case 0:
                    cmd.CommandText = Utilities.Book_GetAll;
                    break;
                case 1:
                    cmd.CommandText = Utilities.Book_GetAllPresent;
                    break;
                case 2:
                    cmd.CommandText = Utilities.Book_GetAllHistory;
                    break;
            }

            SqlDataReader reader = cmd.ExecuteReader();
            List<Book> list = new List<Book>();
            while (reader.Read())
            {
                Book book = new Book();
                book.ID = Convert.ToInt32(reader["ID"]);
                book.LoaiSach = Convert.ToInt32(reader["LoaiSach"]);
                book.ID_TheLoai = Convert.ToInt32(reader["ID_TheLoai"]);
                book.TenSach = reader["TenSach"].ToString();
                if (Convert.IsDBNull(reader["ID_TacGia"]))
                    book.ID_TacGia = null;
                else
                    book.ID_TacGia = Convert.ToInt32(reader["ID_TacGia"]);
                book.NamXuatBan = reader["NamXuatBan"].ToString();
                if (Convert.IsDBNull(reader["ID_NhaXuatBan"]))
                    book.ID_NhaXuatBan = null;
                else
                    book.ID_NhaXuatBan = Convert.ToInt32(reader["ID_NhaXuatBan"]);
                book.ViTri = reader["ViTri"].ToString();
                if (Convert.IsDBNull(reader["TrangThai"]))
                    book.TrangThai = null;
                else
                    book.TrangThai = Convert.ToInt32(reader["TrangThai"]);
                book.GhiChu = reader["GhiChu"].ToString();
                if (Convert.IsDBNull(reader["ID_Muon"]))
                    book.ID_Muon = null;
                else
                    book.ID_Muon = Convert.ToInt32(reader["ID_Muon"]);
                list.Add(book);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Book book, int action)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Utilities.Book_InsertUpdateDelete;

                SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
                IDPara.Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add(IDPara).Value = book.ID;
                cmd.Parameters.Add("@LoaiSach", SqlDbType.Int).Value = book.LoaiSach;
                cmd.Parameters.Add("@ID_TheLoai", SqlDbType.Int).Value = book.ID_TheLoai;
                cmd.Parameters.Add("@TenSach", SqlDbType.NVarChar, 100).Value = book.TenSach;
                cmd.Parameters.Add("@ID_TacGia", SqlDbType.Int).Value = book.ID_TacGia;
                cmd.Parameters.Add("@NamXuatBan", SqlDbType.NChar, 4).Value = book.NamXuatBan;
                cmd.Parameters.Add("@ID_NhaXuatBan", SqlDbType.Int).Value = book.ID_NhaXuatBan;
                cmd.Parameters.Add("@ViTri", SqlDbType.NVarChar, 50).Value = book.ViTri;
                cmd.Parameters.Add("@TrangThai", SqlDbType.SmallInt).Value = book.TrangThai;
                cmd.Parameters.Add("@ghiChu", SqlDbType.NText).Value = book.GhiChu;
                cmd.Parameters.Add("@ID_Muon", SqlDbType.Int).Value = book.ID_Muon;
                cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return (int)cmd.Parameters["@ID"].Value;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return -2;
            }
            return 0;
        }
    }
}
