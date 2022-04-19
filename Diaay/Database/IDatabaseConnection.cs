using System.Data.SqlClient;

namespace Diary.Database
{
    public interface IDatabaseConnection
    {
        int ExecuteNonQuery(string sql);

        void ExecuteReader(string sql, out SqlDataReader dataReader);
    }
}