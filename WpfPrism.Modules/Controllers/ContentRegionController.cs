using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Prism.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPrism.Modules.Services;
using WpfPrism.Modules.ViewModels;
using WpfPrism.Modules.Views;

namespace WpfPrism.Modules.Controllers
{
    public class ContentRegionController
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private readonly IProductService dataService;

        public ContentRegionController(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IProductService dataService)
        {
            this.container = container;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.dataService = dataService;

            this.eventAggregator.GetEvent<ProductFiltered>().Subscribe(GetProductsByFilter);
        }

        public void GetProductsByFilter(string nameOrDesc)
        {
            if (string.IsNullOrEmpty(nameOrDesc))
            {
                nameOrDesc = "Cat";
            }

            // Get the employee entity with the selected ID.
            var products = dataService.GetFilteredProductByName(nameOrDesc);

            IRegion mainRegion = regionManager.Regions[RegionNames.ContentRegion];
            if (mainRegion == null) return;

            // Check to see if we need to create an instance of the view.
            ProductView view = mainRegion.GetView("ProductView") as ProductView;
            if (view == null)
            {
                view = container.Resolve<ProductView>();
                SetViewModel(products, view);
                mainRegion.Add(view, "ProductView");
            }
            else
            {
                SetViewModel(products, view);
                mainRegion.Activate(view);
            }

           
        
        }

        private static void SetViewModel(Models.Products products, ProductView view)
        {
            ProductSearchViewModel viewModel = view.DataContext as ProductSearchViewModel;
            if (viewModel != null)
            {
                viewModel.Products = products;
            }
        }

        public Models.Products GetAllProducts()
        {
            return dataService.GetAllProducts();
        }
    }
}
