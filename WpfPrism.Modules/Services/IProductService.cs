using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPrism.Modules.Models;

namespace WpfPrism.Modules.Services
{
    public interface IProductService
    {
        Products GetAllProducts();

        Products GetFilteredProductByName(string nameOrDescription);

    }
}
