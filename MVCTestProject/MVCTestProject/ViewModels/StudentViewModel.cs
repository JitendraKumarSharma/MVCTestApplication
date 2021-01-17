using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTestProject.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public int Marks { get; set; }
    }
}