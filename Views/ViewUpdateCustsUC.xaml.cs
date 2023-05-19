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
using JonathanDADProjectPartA.Models;
using JonathanDADProjectPartA.Views;

namespace JonathanDADProjectPartA.Views
{
    /// <summary>
    /// Interaction logic for ViewUpdateCustsUC.xaml
    /// </summary>
    public partial class ViewUpdateCustsUC : UserControl
    {
        List<CustomCustomer> custData = null;

        public ViewUpdateCustsUC()
        {
            InitializeComponent();
        }

        //get customer custom table
        private void getCustBtn_Click(object sender, RoutedEventArgs e)
        {
            custData = DAO.getCustomers();
            custGrid.ItemsSource = custData;
            //make id column uneditable
            custGrid.Columns[0].IsReadOnly = true;
        }

        //save customer custom table changes
        private void updateCustBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DAO.updateCustomer(custData);
                MessageBox.Show("Customer data updated successfully");
            }
            catch
            {
                MessageBox.Show("Check input");
            }
        }

        private void updateCustBtn_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
