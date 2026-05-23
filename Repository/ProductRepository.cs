using IMS.Models;
using System.Collections.Generic;
using System.Linq;
public class ProductRepository
{
    private static List<Product> _products = new List<Product>
    {
        new Product
        {
            Id = 1,
            CategoryId = 1,
            Name = "Laptop",
            Description = "High performance laptop",
            Price = 100000,
            Quantity = 5
        },
        new Product
        {
            Id = 2,
            CategoryId = 1,
            Name = "Desktop PC",
            Description = "Powerful gaming desktop",
            Price = 120000,
            Quantity = 3
        },
        new Product
        {
            Id = 3,
            CategoryId = 2,
            Name = "Smartphone",
            Description = "Latest Android phone",
            Price = 50000,
            Quantity = 10
        },
        new Product
        {
            Id = 4,
            CategoryId = 3,
            Name = "Headphones",
            Description = "Noise cancelling headphones",
            Price = 8000,
            Quantity = 20
        },
        new Product
        {
            Id = 5,
            CategoryId = 3,
            Name = "Keyboard",
            Description = "Mechanical keyboard",
            Price = 4000,
            Quantity = 15
        }
    };
    // Get all products
    public static List<Product> GetAll()
    {
        return _products;
    }

    // Get product by Id
    public static Product GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    // Add product
    public static void Add(Product product)
    {
        _products.Add(product);
    }

    // Update full product
    public static void Update(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        //var existingProduct GetById(product.Id);

        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;
        }
    }

    // ✅ Update only Name
    public static void UpdateName(int id, string name)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        //var existingProduct GetById(Id);

        if (existingProduct != null)
        {
            existingProduct.Name = name;
        }
    }

    // Delete product
    public static void Delete(int id)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        //var existingProduct GetById(id);

        if (existingProduct != null)
        {
            _products.Remove(existingProduct);
        }
    }
}