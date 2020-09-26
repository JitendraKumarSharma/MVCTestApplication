using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCTestProject.Models
{
    public class CascadeModel
    {
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Cities { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
    }
}