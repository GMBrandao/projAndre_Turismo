using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;

namespace projAndre_Turismo.Controllers
{
    public class CityController
    {
        public bool Insert(City city)
        {
            return new CityService().Insert(city);
        }

        public List<City> FindAll()
        {
            return new CityService().FindAll();
        }

        public int FindCity(City city)
        {
            return new CityService().FindCity(city);
        }

        public bool Delete(int Id)
        {
            return new CityService().Delete(Id);
        }
    }
}
