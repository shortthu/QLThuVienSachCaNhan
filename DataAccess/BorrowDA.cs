using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BorrowDA
    {
        public List<Borrow> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Borrow_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Borrow> list = new List<Borrow>();
            while (reader.Read())
            {
                Borrow borrow = new Borrow();
                borrow.ID = Convert.ToInt32(reader["ID"]);
                borrow.Ten = reader["Ten"].ToString();
                borrow.SoDienThoai = reader["SoDienThoai"].ToString();
                list.Add(borrow);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Borrow borrow, int action)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Utilities.Borrow_InsertUpdateDelete;

                SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
                IDPara.Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add(IDPara).Value = borrow.ID;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 50).Value = borrow.Ten;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.NChar, 10).Value = borrow.SoDienThoai;
                cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return (int)cmd.Parameters["@ID"].Value;
            }
            catch { return -2; }
            return 0;
        }
    }
}
