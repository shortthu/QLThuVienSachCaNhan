using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDA
    {
        public List<Category> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Category_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Category> list = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(reader["ID"]);
                category.TenTheLoai = reader["TenTheLoai"].ToString();
                list.Add(category);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Category category, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Utilities.Category_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            cmd.Parameters.Add(IDPara).Value = category.ID;
            cmd.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar, 50).Value = category.TenTheLoai;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@ID"].Value;
            return 0;
        }
    }
}
