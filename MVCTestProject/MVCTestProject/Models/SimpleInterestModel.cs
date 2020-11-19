using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTestProject.Models
{
    public class SimpleInterestModel
    {
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public int Year { get; set; }
    }
}