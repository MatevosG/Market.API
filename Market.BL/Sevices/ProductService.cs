using Market.BL.Contracts;
using Market.DAL.Contracts;
using Market.DAL.Entities;
using Market.DAL.Models;
using Market.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Sevices
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public bool AddProduct(Product product)
        {
            bool res = false;
            var productFromRepo =  _productRepository.Add(product);
            if (productFromRepo!=null)
            {
                res = true;
            }
            return res;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.Get();
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.Get(id);
            return product;
        }

        public ProductCategoryModel GetProductsAndCategories()
        {
            ProductCategoryModel result = new ProductCategoryModel();
            var categories = _categoryRepository.Get();
            if (categories != null && categories.Count() != 0)
            {
                foreach (var category in categories)
                {
                    ProductCategoryEntity temp = new ProductCategoryEntity();
                    temp.CategoryId = category.Id;
                    temp.CategoryName = category.Name;

                    var products = _productRepository.Get().Where(x => x.CategoryId == category.Id);
                    foreach (var product in products)
                    {
                        ProductEntity tempProduct = new ProductEntity();
                        tempProduct.ProductId = product.Id;
                        tempProduct.ProductName = product.Name;
                        temp.Products.Add(tempProduct);
                    }
                    result.Data.Add(temp);
                }
            }
            return result;
        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            var products = _productRepository.Get().Where(x=>x.CategoryId==id);
            return products;
        }

        public bool UpdateProduct(Product product)
        {
            bool res = false;
            var productForUpdate = _productRepository.Update(product);
            if (productForUpdate!=null)
            {
                res = true;
            }
            return res;
        }
    }
}
