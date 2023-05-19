using System;
using System.Collections.Generic;

#nullable disable

namespace JonathanDADProjectPartA.Models.DB
{
    public partial class TruckCustomer
    {
        public TruckCustomer()
        {
            TruckRentals = new HashSet<TruckRental>();
        }

        public int CustomerId { get; set; }
        public string LicenseNumber { get; set; }
        //age exceptions 
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 99 & value > 16 )
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Enter a valid age");
                }
            }
        }
        //licency expiry exceptions
        public DateTime expiry;
        public DateTime LicenseExpiryDate 
        { 
            get { return expiry; }
            set
            {
                if(value <= DateTime.Now.Date)
                {
                    this.expiry = value;
                }
                else
                {
                    throw new Exception("Expiry cannot be before current date");
                }
            }
        }

        public virtual TruckPerson Customer { get; set; }
        public virtual ICollection<TruckRental> TruckRentals { get; set; }
    }
}
