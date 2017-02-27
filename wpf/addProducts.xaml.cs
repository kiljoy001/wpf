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
using System.Windows.Shapes;
using wpf.SQL;

namespace wpf
{
    /// <summary>
    /// Interaction logic for addProducts.xaml
    /// </summary>
    public partial class addProducts : Window
    {
        public addProducts()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Products product = new Products();
            product.Show();
            this.Close();
        }

        private async void Submit_newproduct_Click(object sender, RoutedEventArgs e)
        {
            int validate_amount;
            double validate_price;
            int.TryParse(pAmount.Text, out validate_amount);
            double.TryParse(pPrice.Text, out validate_price);
            if ( validate_price == 0|| validate_amount == 0  )
            {
                MessageBox.Show($"Entries that are not numbers will be saved as 0 in the database. You have entered Amount: {pAmount.Text} Price: {pPrice.Text}\nIf you have entered 0 as the amount, you can ignore this message.", $"Please check your values for price and amount." ,MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            await add_product(pName.Text, validate_amount, validate_price);
            pName.Clear();
            pAmount.Clear();
            pPrice.Clear();
        }
        private async Task  add_product(string name, int amount, double price)
        {
            Task process = Task.Factory.StartNew(() =>
            {
                insertProduct entry = new insertProduct(name, amount, price);
            });
            await process;
        }
    }
}
