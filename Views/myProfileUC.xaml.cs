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
using JonathanDADProjectPartA.Models;
using JonathanDADProjectPartA.Models.DB;
using JonathanDADProjectPartA.Views;

namespace JonathanDADProjectPartA.Views
{
    /// <summary>
    /// Interaction logic for myProfileUC.xaml
    /// </summary>
    public partial class myProfileUC : UserControl
    {
        //current user object
        TruckEmployee currentUser;

        public myProfileUC()
        {
            
            InitializeComponent();
        }
        private void saveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            //get new information from textboxes and send to db
            
        }

        //ORANGE SHOW BUTTON 
        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            //get logged in users details to edit in grid --- I AM NOT SURE HOW TO SAVE WHO IS LOGGED IN 
            string userUsername = empProfileUsernameTextBox.Text;
            string userPassword = empProfilePasswordTextBox.Text;
            

            //this is the current user 
            currentUser = DAO.getUser(userUsername, userPassword);

            //populate textfields 
            userOfficeExtensionTextBox.Text = currentUser.PhoneExtensionNumber;
            userOfficeAddressTextBox.Text = currentUser.OfficeAddress;
            userPassTextBox.Text = currentUser.Password;
            userUsernameTextBox.Text = currentUser.Username;
            userRoleTextBox.Text = currentUser.Role;
             
        }

        //RED EDIT BTN to edit user profile
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            userOfficeAddressTextBox.IsEnabled = true;
            userOfficeExtensionTextBox.IsEnabled = true;
            userPassTextBox.IsEnabled = true;
            userUsernameTextBox.IsEnabled = true;
            userRoleTextBox.IsEnabled = false; //cant change roles


        }
    }
}
