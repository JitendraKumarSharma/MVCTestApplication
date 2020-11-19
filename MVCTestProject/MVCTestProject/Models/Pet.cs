using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTestProject.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
}