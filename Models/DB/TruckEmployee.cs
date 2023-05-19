using System;
using System.Collections.Generic;

#nullable disable

namespace JonathanDADProjectPartA.Models.DB
{
    public partial class TruckEmployee
    {
        public int EmployeeId { get; set; }
        //office address exception handling
        private string officeAddress;
        public string OfficeAddress 
        { 
            get { return officeAddress; }
            set
            {
                if(value == "Ormiston" || value == "Howick" || value == "Pakuranga")
                {
                    this.officeAddress = value;
                }
                else
                {
                    throw new Exception("Our offices are only in Howick, Ormiston and Pakuranga");
                }
            }
        }
        public string PhoneExtensionNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //role exception handling
        private string role;
        public string Role
        {
            get { return role; }
            set
            {
                if (value == "Staff" || value == "Admin")
                {
                    this.role = value;
                }
                else
                {
                    throw new Exception("Role must be Staff or Admin only");
                }
            }
        }

        public virtual TruckPerson Employee { get; set; }

        internal void ToList()
        {
            throw new NotImplementedException();
        }
    }
}
