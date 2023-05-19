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
using JonathanDADProjectPartA.Views;
using JonathanDADProjectPartA.Models;
using JonathanDADProjectPartA.Models.DB;

namespace JonathanDADProjectPartA.Views
{
    /// <summary>
    /// Interaction logic for searchByIdUC.xaml
    /// </summary>
    public partial class searchByIdUC : UserControl
    {
        public searchByIdUC()
        {
            InitializeComponent();
        }

        //SEARCH BY ID BUTTON
        private void searchIDBtn_Click(object sender, RoutedEventArgs e)
        {
            //get searched id
            int personId = int.Parse(searchIDTextBox.Text);
            //call dao search method 
            TruckPerson p = DAO.searchPersonByID(personId);
            if(p == null)
            {
                MessageBox.Show("No record matching this ID");
            }
            else
            {
                nameSearchTextBox.Text = p.Name;
                addressSearchTextBox.Text = p.Address;
                telephoneSearchTextBox.Text = p.Telephone;
                
            }

        }
    }
}
