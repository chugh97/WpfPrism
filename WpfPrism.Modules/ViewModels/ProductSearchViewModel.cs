using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Prism.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfPrism.Modules.Controllers;
using WpfPrism.Modules.Services;
using WpfPrism.Modules.Views;

namespace WpfPrism.Modules.ViewModels
{
    public class ProductSearchViewModel : IProductSearchViewModel
    {
        
        private ContentRegionController _contentController;

        public ProductSearchViewModel(ContentRegionController contentRegionController)
        {
            _contentController = contentRegionController;
            Products = _contentController.GetAllProducts();
            
            this.SearchCommand = new DelegateCommand<object>(
                                        this.Search);
        }

        public Models.Products Products { get; set; }


        private void Search(object searchTerm)
        {
            var sterm = searchTerm.ToString();
            _contentController.GetProductsByFilter(sterm);
        }
        
        public ICommand SearchCommand { get; private set; }

        
        
    }
}
