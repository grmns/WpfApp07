using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness
    {
        private readonly ProductData _productData;

        public ProductBusiness()
        {
            _productData = new ProductData();
        }

        public List<Product> GetProductsByName(string name)
        {
            var allProducts = _productData.GetAllProducts();
            return allProducts.Where(p => p.Name.Contains(name)).ToList();
        }
    }
}
