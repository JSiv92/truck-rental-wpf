using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanDADProjectPartA.Models.DB;
using JonathanDADProjectPartA.Models;
using Microsoft.EntityFrameworkCore;
using JonathanDADProjectPartA.Views;
using System.Windows;

namespace JonathanDADProjectPartA.Models
{
    internal class DAO
    {


        //method to search truckperson by personID
        public static TruckPerson searchPersonByID(int id)
        {
            using(DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                return ctx.TruckPerson.Where(person => person.PersonId == id).FirstOrDefault();
            }
        }
        //method to validate login
        public static void Login(String username, String password)
        {
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                //check database for username and password
                TruckEmployee user = ctx.TruckEmployees.Where(c => c.Username == username && c.Password == password).FirstOrDefault();

                //check user is valid
                if (user == null)
                {
                    MessageBox.Show("Check Username and Password");
                    LoginWindow login = new LoginWindow();
                    login.Show();
                }
                else
                {
                    //if user is admin do this
                    if (user.Role == "Admin")
                    {
                        HomeForm form = new HomeForm();
                        
                        form.isStaff(false);
                        form.Show();
                    }
                    else //if user is regular staff do this
                    {
                        HomeForm form = new HomeForm();
                        form.isStaff(true);
                        form.Show();
                    }
                }

            }
        }
 
       
        //Add a truck employee
        public static void addEmployee(TruckEmployee emp)
        {
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                if (!containsUsername(emp.Username))
                {
                    ctx.TruckEmployees.Add(emp);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception("Username taken! choose another one");
                }
            }
        }

        //check for employee usernames 
        private static bool containsUsername(string username)
        {
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                //search emp table for usernames
                TruckEmployee emp = ctx.TruckEmployees.Where(em => em.Username == username).FirstOrDefault();
                if (emp == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //display a datagrid list of employees in ViewUpdateEmpsUC
        public static List<UserProfile> getEmployees()
        {
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                return ctx.TruckPerson
                    .Include(empA => empA.TruckEmployee)
                    .Where(empA => empA.TruckEmployee.EmployeeId != null)
                    .Select(empAA => new UserProfile()
                    {
                        PersonId = empAA.PersonId,
                        Name = empAA.Name,
                        Address = empAA.Address,
                        Telephone = empAA.Telephone,
                        OfficeAddress = empAA.TruckEmployee.OfficeAddress,
                        PhoneExtensionNumber = empAA.TruckEmployee.PhoneExtensionNumber,
                        Username = empAA.TruckEmployee.Username,
                        Password = empAA.TruckEmployee.Password,
                        Role = empAA.TruckEmployee.Role

                    }).ToList();
            }
        }
        //display a datagrid list of customers in ViewUpdateEmpsUC
        public static List<CustomCustomer> getCustomers()
        {
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                return ctx.TruckPerson
                    .Include(custA => custA.TruckCustomer)
                    .Where(custA => custA.TruckCustomer.CustomerId != null)
                    .Select(custAA => new CustomCustomer()
                    {
                        PersonId = custAA.PersonId,
                        Name = custAA.Name,
                        Address = custAA.Address,
                        Telephone = custAA.Telephone,
                        LicenseNumber = custAA.TruckCustomer.LicenseNumber,
                        LicenseExpiryDate = custAA.TruckCustomer.LicenseExpiryDate,
                        Age = custAA.TruckCustomer.Age

                    }).ToList();
            }
        }

        //display a datagrid of employee details in myProfileUC
        
        /* NOT ABLE TO CONVERT LOGIN USER TO CUSTOM CLASS EMPLOYEE & SHOW/EDIT INFO
         * ONLY ABLE TO DO IT FOR EMP TABLE
         */
        public static TruckEmployee getUser(string username, string password)
        {
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                return ctx.TruckEmployees.Where(emp => emp.Username == username && emp.Password == password).FirstOrDefault();
            }
        }

        //add customer changes made to 'ViewUpdateEmpsUC' datagrid to the database
        public static void updateCustomer(List<CustomCustomer> custData)
        { 
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                foreach (CustomCustomer customer in custData) 
                    {
                        //join the person and customer with the matching id 
                        TruckPerson person = ctx.TruckPerson.Include(c => c.TruckCustomer).Where(p => p.PersonId == customer.PersonId).FirstOrDefault();
                        //assign fields to update   
                        person.Address = customer.Address;    
                        person.Telephone = customer.Telephone;
                        person.Name = customer.Name;
                        person.TruckCustomer.LicenseExpiryDate = customer.LicenseExpiryDate;
                        person.TruckCustomer.Age = customer.Age;
                        person.TruckCustomer.LicenseNumber = customer.LicenseNumber;

                        try
                        {
                           //for person table
                            ctx.Entry(person).State = EntityState.Modified;
                           //for linked (customer) table
                            ctx.Entry(person.TruckCustomer).State = EntityState.Modified;
                            ctx.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("Please enter appropriate data");
                        }
                } 
            } 
        }
        //add employee changes made to 'ViewUpdateEmpsUC' datagrid to the database
        public static void updateEmployee(List<UserProfile> empData)
        {
            using (DAD_JonathanContext ctx = new DAD_JonathanContext())
            {
                foreach (UserProfile profile in empData)
                {
                    TruckPerson emp_person = ctx.TruckPerson.Include(e => e.TruckEmployee).Where(p => p.PersonId == profile.PersonId).FirstOrDefault();

                    emp_person.Address = profile.Address;
                    emp_person.Telephone = profile.Telephone;
                    emp_person.Name = profile.Name;
                    emp_person.TruckEmployee.Username = profile.Username;
                    emp_person.TruckEmployee.Password = profile.Password;
                    emp_person.TruckEmployee.Role = profile.Role;
                    emp_person.TruckEmployee.OfficeAddress = profile.OfficeAddress;
                    emp_person.TruckEmployee.PhoneExtensionNumber = profile.PhoneExtensionNumber;

                    try
                    {
                        //for person table
                        ctx.Entry(emp_person).State = EntityState.Modified;
                        //for emp table
                        ctx.Entry(emp_person.TruckEmployee).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Please enter appropriate data");
                    }
                }
            }
        }
    }
}