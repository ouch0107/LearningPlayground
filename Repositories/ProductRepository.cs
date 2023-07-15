using Dapper;
using LearningPlayground.Context;
using LearningPlayground.Models;

namespace LearningPlayground.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetProducts()
        {
            string query = "SELECT * FROM [SalesLT].[Product]";
            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }
        }
    }
}
