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
using JonathanDADProjectPartA.Models.DB;
using JonathanDADProjectPartA.Views;
using JonathanDADProjectPartA.Models;


namespace JonathanDADProjectPartA
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {

            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //get login details
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            //call dao login method
            DAO.Login(username, password);
            this.Hide();
        }
    }
}
    

