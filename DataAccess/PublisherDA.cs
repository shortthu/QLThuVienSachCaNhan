using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PublisherDA
    {
        public List<Publisher> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Publisher_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Publisher> list = new List<Publisher>();
            while (reader.Read())
            {
                Publisher publisher = new Publisher();
                publisher.ID = Convert.ToInt32(reader["ID"]);
                publisher.TenNhaXuatBan = reader["TenNhaXuatBan"].ToString();
                list.Add(publisher);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Publisher publisher, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Publisher_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            cmd.Parameters.Add(IDPara).Value = publisher.ID;
            cmd.Parameters.Add("@TenNhaXuatBan", SqlDbType.NVarChar, 50).Value = publisher.TenNhaXuatBan;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@ID"].Value;
            return 0;
        }
    }
}
