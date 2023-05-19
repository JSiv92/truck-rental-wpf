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
using JonathanDADProjectPartA.Views;
using JonathanDADProjectPartA.Models;
using JonathanDADProjectPartA.Models.DB;

namespace JonathanDADProjectPartA.Views
{
    /// <summary>
    /// Interaction logic for HomeForm.xaml
    /// </summary>
    public partial class HomeForm : Window
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        //METHOD TO SET STAFF or ADMIN features
        public void isStaff(bool value)
        {
            if (value == true)
            {
                //staff cant add employees
                addEmpMenuItem.IsEnabled = false;
                //staff cant update employees -- unable to disable save button for staff
                updateCustMenuItem.IsEnabled = false;
                
                adminLabel.Visibility = Visibility.Hidden;
                staffLabel.Visibility = Visibility.Visible;  
            }
            else
            {
                //admin has full access
                adminLabel.Visibility = Visibility.Visible;
                staffLabel.Visibility = Visibility.Hidden;;
            }
        }

        //ADD EMPLOYEE - admin only
        private void addEmpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //clear stackpanel
            centerPanel.Children.Clear();
            //create new obj of user control 
            centerPanel.Children.Add(new addEmployeeUC());
        }

        //SEARCH PERSON CONTACT DETAILS BY ID
        private void searchEmpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //clear stackpanel
            centerPanel.Children.Clear();   
            //create new obj of user control 
            centerPanel.Children.Add(new searchByIdUC());
        }

        //UPDATE EMPLOYEE GRID
        private void updateEmpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //clear stackpanel
            centerPanel.Children.Clear();
            centerPanel.Children.Add(new ViewUpdateEmpsUC());
            
        }
        //UPDATE CUSTOMER GRID
        private void updateCustMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centerPanel.Children.Clear();
            centerPanel.Children.Add(new ViewUpdateCustsUC());

        }
        //UPDATE EMPLOYEE CURRENT USER DETAILS
        private void updateEmpProfileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //clear stackpanel
            centerPanel.Children.Clear();
            centerPanel.Children.Add(new myProfileUC());
        }

        //LOGOUT BUTTON
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow form = new LoginWindow();   
            this.Hide();
            form.Show();
        }


    }
}
