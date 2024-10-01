using Business;
using Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private readonly ProductBusiness _productBusiness;

        public MainWindow()
        {
            InitializeComponent();
            _productBusiness = new ProductBusiness();
            LoadAllProducts();


        }
        private void LoadAllProducts()
        {
            List<Product> products = _productBusiness.GetProductsByName("");
            dgProducts.ItemsSource = products;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            List<Product> products = _productBusiness.GetProductsByName(productName);
            dgProducts.ItemsSource = products;
        }

    }
}