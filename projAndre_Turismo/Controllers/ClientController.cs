using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;

namespace projAndre_Turismo.Controllers
{
    public class ClientController
    {
        public bool Insert(Client client)
        {
            return new ClientService().Insert(client);
        }

        public List<Client> FindAll()
        {
            return new ClientService().FindAll();
        }

        public int FindClient(Client client)
        {
            return new ClientService().FindClient(client);
        }
    }
}
