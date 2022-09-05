using Entities;

namespace Infrastructure;

public class ProductReposetiory
{

    private ProductDbContext _productDbContext;


    public ProductReposetiory(ProductDbContext context)
    {
        _productDbContext = context;
    }


    public List<Product> GetAllProduct()
    {
        return _productDbContext.ProductTable.ToList();
    }

    public Product InsertProduct(Product product)
    {
        _productDbContext.ProductTable.Add(product);
        _productDbContext.SaveChanges();
        return product;
    }

    public void CreateDb()
    {
        _productDbContext.Database.EnsureDeleted();
        _productDbContext.Database.EnsureCreated();
    }
}