using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //DB SIMULATOR
            _products = new List<Product> {
              new Product{ProductId= 1,CategoryId=1,
                  ProductName = "Ürün1",UnitPrice=10,UnitsInStock=5},
              new Product{ProductId= 2,CategoryId=1,
                  ProductName = "Ürün2",UnitPrice=20,UnitsInStock=4},
              new Product{ProductId= 3,CategoryId=2,
                  ProductName = "Ürün3",UnitPrice=30,UnitsInStock=3},
              new Product{ProductId= 4,CategoryId=2,
                  ProductName = "Ürün4",UnitPrice=40,UnitsInStock=2},
              new Product{ProductId= 5,CategoryId=2,
                  ProductName = "Ürün5",UnitPrice=50,UnitsInStock=1},
              };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(
                p => p.ProductId == product.ProductId
                );//Just find one data with Linq like Foreach
            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //This code search products then If Sended categoryId equal productId , This method return Equals with linq
            return _products.Where(p=> p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(
                p => p.ProductId == product.ProductId
                );//Just find one data with Linq like Foreach
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
