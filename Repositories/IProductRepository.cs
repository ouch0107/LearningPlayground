using LearningPlayground.Models;

namespace LearningPlayground.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
    }
}
