using System;
using System.Collections.Generic;

#nullable disable

namespace JonathanDADProjectPartA.Models.DB
{
    public partial class TruckModel
    {
        public int ModelId { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }
    }
}
