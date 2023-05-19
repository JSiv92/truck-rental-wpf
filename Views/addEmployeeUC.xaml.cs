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


namespace JonathanDADProjectPartA.Views
{
    /// <summary>
    /// Interaction logic for addCustomerUC.xaml
    /// </summary>
    public partial class addEmployeeUC : UserControl
    {
        public addEmployeeUC()
        {
            InitializeComponent();
        }
        //add new customer button
        private void addEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            //make sure fields arent empty 
            if (string.IsNullOrWhiteSpace(empNameTextBox.Text) ||
               string.IsNullOrWhiteSpace(empAddressTextBox.Text) ||
               string.IsNullOrWhiteSpace(empPhoneTextBox.Text) ||
               string.IsNullOrWhiteSpace(empExtTextBox.Text) ||
               string.IsNullOrWhiteSpace(empUsernameTextBox.Text) ||
               string.IsNullOrWhiteSpace(empPasswordTextBox.Text) ||
               string.IsNullOrWhiteSpace(empOfficeComboBox.Text) ||
               string.IsNullOrWhiteSpace(empRoleComboBox.Text)) 
            {
                MessageBox.Show("Check all fields are valid");
            }
            else
            {
                //get variables from textboxes
                string personName = empNameTextBox.Text;
                string personAddress = empAddressTextBox.Text;
                string personPhone = empPhoneTextBox.Text;
                string empExt = empExtTextBox.Text;
                string empUser = empUsernameTextBox.Text;
                string empPassword = empPasswordTextBox.Text;
                string empOffice = empOfficeComboBox.Text;
                string empRole = empRoleComboBox.Text;

                //make obj of truckperson, parent table object
                TruckPerson p = new TruckPerson();
                //add values to do with person table
                p.Name = personName;
                p.Telephone = personPhone;
                p.Address = personAddress;

                //make obj of employee, child class object
                TruckEmployee emp = new TruckEmployee();
                //add values to do with employee table
                emp.OfficeAddress = empOffice;
                emp.Password = empPassword;
                emp.Username = empUser;
                emp.PhoneExtensionNumber = empExt;
                emp.Role = empRole;

                //link person and employee 
                emp.Employee = p;

                //try to send this obj to DAO and add to DB
                try
                {
                    DAO.addEmployee(emp);
                    MessageBox.Show("Employee added successfully");
                //reset fields
                    empNameTextBox.Clear();
                    empAddressTextBox.Clear();
                    empPhoneTextBox.Clear();
                    empOfficeComboBox.SelectedIndex = -1;
                    empUsernameTextBox.Clear();
                    empPasswordTextBox.Clear();
                    empExtTextBox.Clear();
                    empRoleComboBox.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }  
            }
        }
    }
}
