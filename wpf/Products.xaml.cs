using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public Products()
        {
            InitializeComponent();
            showProducts get_data = new showProducts();
            if (get_data.result != null)
            {

            }
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            addProducts insert_product = new addProducts();
            insert_product.Show();
            this.Close();
        }
    }
}
