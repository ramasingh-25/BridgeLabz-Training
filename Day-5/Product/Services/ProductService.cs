using Student.Models;
using Student.Repo;

namespace Student.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }

    public void CreateProduct(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name is required.");

        _repository.Add(product);
    }
}