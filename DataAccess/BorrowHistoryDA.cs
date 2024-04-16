using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BorrowHistoryDA
    {
        public List<BorrowHistory> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.BorrowHistory_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<BorrowHistory> list = new List<BorrowHistory>();
            while (reader.Read())
            {
                BorrowHistory borrowHistory = new BorrowHistory();
                borrowHistory.ID = Convert.ToInt32(reader["ID"]);
                borrowHistory.TenSach = reader["TenSach"].ToString();
                borrowHistory.TenNguoiMuon = reader["TenNguoiMuon"].ToString();
                borrowHistory.SoDienThoaiMuon = reader["SoDienThoaiMuon"].ToString();
                borrowHistory.HinhThuc = Convert.ToInt32(reader["HinhThuc"]);
                borrowHistory.ThoiGian = Convert.ToDateTime(reader["ThoiGian"]);
                list.Add(borrowHistory);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(BorrowHistory borrowHistory, int action)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Utilities.BorrowHistory_InsertUpdateDelete;

                SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
                IDPara.Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add(IDPara).Value = borrowHistory.ID;
                cmd.Parameters.Add("@TenSach", SqlDbType.NVarChar, 100).Value = borrowHistory.TenSach;
                cmd.Parameters.Add("@TenNguoiMuon", SqlDbType.NVarChar, 50).Value = borrowHistory.TenNguoiMuon;
                cmd.Parameters.Add("@SoDienThoaiMuon", SqlDbType.NChar, 10).Value = borrowHistory.SoDienThoaiMuon;
                cmd.Parameters.Add("@HinhThuc", SqlDbType.SmallInt).Value = borrowHistory.HinhThuc;
                cmd.Parameters.Add("@ThoiGian", SqlDbType.DateTime).Value = borrowHistory.ThoiGian;
                cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return (int)cmd.Parameters["@ID"].Value;
            }
            catch (SqlException ex) { Console.WriteLine(ex); return -2; }
            return 0;
        }
    }
}
