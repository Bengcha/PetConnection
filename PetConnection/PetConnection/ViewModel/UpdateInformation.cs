using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetConnection.Models;

namespace PetConnection.ViewModel
{
    public class UpdateInformation
    { 
        public User users { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<ZipCode> ZipCodes { get; set; }
        public IEnumerable<States> State { get; set; }
    }
}