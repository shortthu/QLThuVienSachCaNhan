using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthorDA
    {
        public List<Author> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Author_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Author> list = new List<Author>();
            while (reader.Read())
            {
                Author author = new Author();
                author.ID = Convert.ToInt32(reader["ID"]);
                author.TenTacGia = reader["TenTacGia"].ToString();
                list.Add(author);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Author author, int action)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Utilities.Author_InsertUpdateDelete;

                SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
                IDPara.Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add(IDPara).Value = author.ID;
                cmd.Parameters.Add("@TenTacGia", SqlDbType.NVarChar, 50).Value = author.TenTacGia;
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
