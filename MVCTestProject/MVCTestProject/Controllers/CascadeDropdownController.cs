using MVCTestProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCTestProject.Controllers
{
    public class CascadeDropdownController : Controller
    {
        public ActionResult Index()
        {
            TempData["Country"] = LoadCountries();
            TempData["State"] = LoadStates();
            TempData["City"] = LoadCities();
            return View();
        }

        public List<Country> LoadCountries()
        {
            var countries = new List<Country>
            {
                new Country { CountryName = "India", CountryId = 1 },
                new Country { CountryName = "Srilanka", CountryId = 2 },
                new Country { CountryName = "USA", CountryId = 3 }
            };
            return countries;
        }

        public List<State> LoadStates()
        {
            var states = new List<State>
            {
                new State { StateName = "Uttar Pradesh", StateId = 1, CountryId =1 },
                new State { StateName = "Bihar", StateId = 2, CountryId =1 },
                new State { StateName = "Himachal Pradesh", StateId = 3, CountryId =1},

                new State { StateName = "Colombo", StateId = 4, CountryId =2 },

                new State { StateName = "Alaska", StateId = 5, CountryId =3 },
                new State { StateName = "Alabama", StateId = 6, CountryId =3 },
            };
            return states;
        }

        public List<City> LoadCities()
        {
            var cities = new List<City>
            {
                new City { CityName = "Lucknow",  CityId = 1, StateId = 1 },
                new City { CityName = "Kanpur", CityId = 2, StateId = 1  },
                new City { CityName = "Barabanki", CityId = 3, StateId = 1 },

                new City { CityName = "Patna",  CityId = 4, StateId = 2 },
                new City { CityName = "Bodh Gaya", CityId = 5, StateId = 2  },
                new City { CityName = "Nalanda", CityId = 6, StateId = 2 },

                new City { CityName = "Simla",  CityId = 7, StateId = 3 },
                new City { CityName = "Manali", CityId = 8, StateId = 3  },
                new City { CityName = "Kullu", CityId = 9, StateId = 3 },

                new City { CityName = "Colombo",  CityId = 10, StateId = 4 },
                new City { CityName = "Moratuwa", CityId = 11, StateId = 4  },
                new City { CityName = "Sri Jawewardenepura Kotte", CityId = 12, StateId = 4 },

                new City { CityName = "Sitka",  CityId = 13, StateId = 5 },
                new City { CityName = "Nome", CityId = 14, StateId = 5  },
                new City { CityName = "Bethal", CityId = 15, StateId = 5 },

                new City { CityName = "Mobile",  CityId = 16, StateId = 6 },
                new City { CityName = "Auburn", CityId = 17, StateId = 6  },
                new City { CityName = "Selma", CityId = 18, StateId = 6 }
            };
            return cities;
        }

        public JsonResult LoadStateByCountry(int id)
        {
            var stateList = (List<State>)TempData.Peek("State");
            var stateByCountry = stateList.Where(state => state.CountryId == id).ToList();
            return Json(stateByCountry, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadCityByState(int id)
        {
            var cityList = (List<City>)TempData.Peek("City");
            var cityByState = cityList.Where(city => city.StateId == id).ToList();
            return Json(cityByState, JsonRequestBehavior.AllowGet);
        }
    }
}