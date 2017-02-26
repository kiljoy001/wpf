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

        private void Submit_newproduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
