using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetConnection.Models
{
    public class PetData
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Sex { get; set; }
        public string Color { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}