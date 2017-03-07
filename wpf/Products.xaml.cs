﻿using System;
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
            var item = (sender as FrameworkElement).DataContext;
            int index = listView.Items.IndexOf(item);
        }
    }
}
