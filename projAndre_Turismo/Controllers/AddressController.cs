using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;

namespace projAndre_Turismo.Controllers
{
    public class AddressController
    {
        public bool Insert(Address address)
        {
            return new AddressService().Insert(address);
        }

        public List<Address> FindAll()
        {
            return new AddressService().FindAll();
        }

        public int FindAddress(Address address)
        {
            return new AddressService().FindAddress(address);
        }

        public bool Update(int Id, Address address)
        {
            return new AddressService().Update(Id, address);
        }

        public bool Delete(int Id)
        {
            return new AddressService().Delete(Id);
        }
    }
}
