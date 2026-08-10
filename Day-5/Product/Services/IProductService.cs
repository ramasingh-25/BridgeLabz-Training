using Student.Models;

namespace Student.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    void CreateProduct(Product product);
}