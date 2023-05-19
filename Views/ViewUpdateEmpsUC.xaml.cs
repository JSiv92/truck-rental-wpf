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
    /// Interaction logic for ViewUpdateEmpsUC.xaml
    /// </summary>
    public partial class ViewUpdateEmpsUC : UserControl
    {
        //initialise custom class "UserProfile" list for employees
        List<UserProfile> empData = null;
        public ViewUpdateEmpsUC()
        {
            InitializeComponent();
        }

        //get employee custom table 
        private void getEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            empData = DAO.getEmployees();
            empGrid.ItemsSource = empData;
            //make id column uneditable
            empGrid.Columns[0].IsReadOnly = true;
        }

        //save changes made to employee custom class table
        private void updateEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DAO.updateEmployee(empData);
                MessageBox.Show("Employee data updated successfully");
            }
            catch
            {
                MessageBox.Show("Please check fields");
            }
        }




        private void empGrid_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        //validate empty cells
        private void empGrid_Error(object sender, ValidationErrorEventArgs e)
        {
            
        }
    }
}
