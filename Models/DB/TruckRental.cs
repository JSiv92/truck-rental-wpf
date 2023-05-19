using System;
using System.Collections.Generic;

#nullable disable

namespace JonathanDADProjectPartA.Models.DB
{
    public partial class TruckRental
    {
        public int RentalId { get; set; }
        public int TruckId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual TruckCustomer Customer { get; set; }
    }
}
