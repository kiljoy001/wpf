using System.Windows;
using wpf.SQL;

namespace wpf
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        showProducts get_data = new showProducts();
        public Products()
        {
            InitializeComponent();
            
            if (get_data.result != null)
            {
                foreach(product item in get_data.result)
                { //check to make sure that the value is not false
                    if (item.Show_Item)
                    {
                        listView.Items.Add(new product { Product_name = item.Product_name, Number = item.Number, Amount = item.Amount });
                    }
                }
            }
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            addProducts insert_product = new addProducts();
            insert_product.Show();
            this.Close();
        }

        private void removeProduct_Click(object sender, RoutedEventArgs e)
        {
            int index = listView.SelectedIndex;
            product selected = get_data.result[index];
            if (selected != null)
            {
                disable_product remove = new disable_product(selected.ID, Properties.Settings.Default.user_login);
                listView.Items.Clear();
                foreach (product item in get_data.result)
                { //check to make sure that the value is not false
                    if (item.Show_Item)
                    {
                        listView.Items.Add(new product { Product_name = item.Product_name, Number = item.Number, Amount = item.Amount });
                    }
                }
            }

        }

        private void Search_Copy_Click(object sender, RoutedEventArgs e)
        {
            Reports fake_report = new Reports();
            fake_report.Show();
            this.Close();
        }
    }
}
