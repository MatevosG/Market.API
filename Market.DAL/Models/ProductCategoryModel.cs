using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Models
{
    public class ProductCategoryModel
    {
        public ProductCategoryModel()
        {
            Data = new List<ProductCategoryEntity>();
        }
        public List<ProductCategoryEntity> Data { get; set; }

    }

    public class ProductCategoryEntity
    {
        public ProductCategoryEntity()
        {
            Products = new List<ProductEntity>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductEntity> Products { get; set; }
    }

    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
