
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrism.Modules.Services
{
    public class ProductService : IProductService
    {
        private Models.Products _products = new Models.Products();
        private Models.Products _filteredProducts = new Models.Products();

        public ProductService()
        {
            _products.Add(new Models.Product { Id = 1, Name = "Soap", Description = "Radox", Cost = 1.60m });
            _products.Add(new Models.Product { Id = 2, Name = "Cat food", Description = "Sheeba", Cost = 9.99m });
        
        }
        public Models.Products GetAllProducts()
        {
            return _products;
        }

        public Models.Products GetFilteredProductByName(string nameOrDescription)
        {
            _filteredProducts.Clear();
            List<Models.Product> list = _products.Where(x => x.Description.StartsWith(nameOrDescription) || x.Name.StartsWith(nameOrDescription)).ToList();
            foreach (var item in list)
            {
                _filteredProducts.Add(item);
            }
            return _filteredProducts;
        }
    }
}
