using MVCTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;

namespace MVCTestProject.Controllers
{
    public class DropdownUsingHelperController : Controller
    {
        // GET: DropdownUsingHelper
        private static readonly CascadeModel cm = new CascadeModel();
        public ActionResult Index()
        {
            cm.Countries = (List<SelectListItem>)LoadCountries().Select(cntry => new SelectListItem()
            {
                Text = cntry.CountryName,
                Value = cntry.CountryId.ToString()
            }).ToList();
            cm.States = new List<SelectListItem>();
            cm.Cities = new List<SelectListItem>();
            return View(cm);
            
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

        public List<State> LoadStateByCountry(int id)
        {
            return LoadStates().Where(state => state.CountryId == id).ToList();
        }

        public List<City> LoadCityByState(int id)
        {
            return LoadCities().Where(city => city.StateId == id).ToList();
        }

        [HttpPost]
        public ActionResult Index(int? countryId, int? stateId)
        {
            CascadeModel cm = new CascadeModel();
            if (countryId > 0)
            {
                cm.Countries = LoadCountries().Select(cntry => new SelectListItem()
                {
                    Text = cntry.CountryName,
                    Value = cntry.CountryId.ToString(),
                    Selected = countryId != null && countryId > 0 && cntry.CountryId == countryId
                }).ToList();

                cm.States = LoadStateByCountry(Convert.ToInt32(countryId)).Select(state => new SelectListItem()
                {
                    Text = state.StateName,
                    Value = state.StateId.ToString()
                }).ToList();

                if (stateId > 0)
                {
                    cm.Cities = LoadCityByState(Convert.ToInt32(stateId)).Select(city => new SelectListItem()
                    {
                        Text = city.CityName,
                        Value = city.CityId.ToString()
                    }).ToList();
                }
                else if (cm.States.Any())
                    cm.Cities = LoadCityByState(Convert.ToInt32(cm.States[0].Value)).Select(city => new SelectListItem()
                    {
                        Text = city.CityName,
                        Value = city.CityId.ToString()
                    }).ToList();
            }

            return View(cm);
        }

    }
}
