using Prism.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPrism.Modules.ViewModels;

namespace WpfPrism.Modules.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
        }
        public ProductView(ProductSearchViewModel vm) : this()
        {
            //InitializeComponent();
            DataContext = vm;
        }

        public ProductSearchViewModel ViewModel
        {
            get
            {
                return (ProductSearchViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
