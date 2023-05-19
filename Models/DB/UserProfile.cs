using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //for primary key 

namespace JonathanDADProjectPartA.Models.DB
{
    public class UserProfile
    {
        [Key]
        public int PersonId { get; set; }

        //other columns to show in user profile 
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string? OfficeAddress { get; set; }
        public string? PhoneExtensionNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

}
