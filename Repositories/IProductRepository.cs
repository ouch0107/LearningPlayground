using LearningPlayground.Models;

namespace LearningPlayground.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(string id);
    }
}
