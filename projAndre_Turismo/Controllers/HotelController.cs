using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;

namespace projAndre_Turismo.Controllers
{
    public class HotelController
    {
        public bool Insert(Hotel hotel)
        {
            return new HotelService().Insert(hotel);
        }

        public List<Hotel> FindAll()
        {
            return new HotelService().FindAll();
        }

        public int FindHotel(Hotel hotel)
        {
            return new HotelService().FindHotel(hotel);
        }

        public bool Delete(int Id)
        {
            return new HotelService().Delete(Id);
        }
    }
}
