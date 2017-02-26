using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using wpf.SQL;

namespace wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private async Task process_login()
        {
            string password_text = password.Password;
            string email = login.Text;
        
            Task process = Task.Factory.StartNew(() =>
            {
                checkEmail input = new checkEmail(email);
                if (input.check_if_correct(email))
                {
                    getHash hpass = new getHash(email);
                    
                    if(BCrypt.Net.BCrypt.Verify(password_text,hpass.hashValue))
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {

                            //your code
                            Products window_product = new Products();
                            window_product.Show();
                            this.Close();
                        });
                        
                    }
                    else { MessageBox.Show($"Login is incorrect. Please try again!"); }
                }
                else { MessageBox.Show($"Login is incorrect. Please try again!"); }
            });
            await process;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await process_login();
            
            //Sync version 
            //checkEmail input = new checkEmail(login.Text);
            //if (input.check_if_correct(login.Text))
            //{
            //    getHash hpass = new getHash(login.Text);

            //    if (BCrypt.Net.BCrypt.Verify(password.Password, hpass.hashValue))
            //    {
            //        Application.Current.Dispatcher.Invoke((Action)delegate {

            //            //your code
            //            Products window_product = new Products();
            //            window_product.Show();
            //            this.Close();
            //        });

            //    }
            //}
            //else { MessageBox.Show($"Login is incorrect. Please try again!"); }
        }
    }
}
