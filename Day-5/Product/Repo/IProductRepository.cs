using Student.Models;

namespace Student.Repo;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    void Add(Product product);
}