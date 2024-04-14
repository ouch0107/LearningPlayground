using Dapper;
using LearningPlayground.Context;
using LearningPlayground.Models;
using static LearningPlayground.Enums.DatabaseEnum;

namespace LearningPlayground.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context) => _context = context;

        public async Task<Product> GetProduct(string id)
        {
            string query = "SELECT * FROM [SalesLT].[Product] WHERE ProductID = @Id";
            using (var connection = _context.CreateConnection(DatabaseType.SqlServer))
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new
                {
                    Id = id
                });
                return product;
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            string query = "SELECT * FROM [SalesLT].[Product]";
            using (var connection = _context.CreateConnection(DatabaseType.SqlServer))
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }
        }

        public async Task<IEnumerable<Product>> GetFirst100Product()
        {
            string query = "SELECT * FROM production.product ORDER BY productid ASC LIMIT 100";
            using (var connection = _context.CreateConnection(DatabaseType.Postgres))
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }
        }
    }
}
