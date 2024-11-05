
using CommonLayer;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class DatabaseConnection
    {
        public SqlConnection connection;
        public DatabaseConnection()
        {   
            connection= new SqlConnection(Connection.ConnectionString);
        }
    }
}
