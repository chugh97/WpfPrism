using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Prism.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrism.Modules
{
    public class ModuleAModule : IModule
    {
        IUnityContainer _container;

        IRegionManager _manager;
        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _manager = regionManager;
        } 

        public void Initialize()
        {
            _container.RegisterType<ToolbarA>();
            _container.RegisterType<ContentA>();
            _container.RegisterType<IContentAViewModel, ContentAViewModel>();
            _manager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarA));
            _manager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentA));
        }
        
    }
}
