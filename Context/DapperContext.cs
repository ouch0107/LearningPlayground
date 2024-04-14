using Npgsql;
using System.Data;
using System.Data.SqlClient;
using static LearningPlayground.Enums.DatabaseEnum;

namespace LearningPlayground.Context
{    
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Specific connection
        /// </summary>
        /// <param name="dbType">Specific DB type</param>
        /// <returns></returns>
        public IDbConnection CreateConnection(DatabaseType dbType)
        {
            switch(dbType)
            {
                case DatabaseType.SqlServer:
                    return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                case DatabaseType.Postgres:
                    return new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQLConnection"));
                default:
                    throw new NotImplementedException("資料庫連線類型尚未建立");
            }
        }
    }
}
