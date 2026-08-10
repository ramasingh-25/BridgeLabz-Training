using Student.Models;

namespace Student.Repo;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>();
    private int _nextId = 1;

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public void Add(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
    }
}