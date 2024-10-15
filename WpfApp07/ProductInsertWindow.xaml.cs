using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace WpfApp07
{
    public partial class ProductInsertWindow : Window
    {
        private readonly ProductBusiness _productBusiness;
        public ProductInsertWindow()
        {
            InitializeComponent();
            _productBusiness = new ProductBusiness();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = txtProductName.Text.Trim();
                string priceText = txtProductPrice.Text.Trim();
                string stockText = txtProductStock.Text.Trim();

                if (decimal.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal productPrice) &&
                    int.TryParse(stockText, out int productStock))
                {
                    if (!string.IsNullOrEmpty(productName) && productPrice > 0 && productStock > 0)
                    {
                        Product newProduct = new Product
                        {
                            Name = productName,
                            Price = productPrice,
                            Stock = productStock,
                            Active = true 
                        };

                        _productBusiness.InsertProduct(newProduct);

                        MessageBox.Show("Producto agregado correctamente.");
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Por favor, completa todos los campos correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Formato de precio o stock inválido. Por favor, usa el formato correcto (ej: 40.10).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}