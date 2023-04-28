using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;

namespace projAndre_Turismo.Controllers
{
    public class TicketController
    {
        public bool Insert(Ticket ticket)
        {
            return new TicketService().Insert(ticket);
        }

        public List<Ticket> FindAll()
        {
            return new TicketService().FindAll();
        }

        public int FindTicket(Ticket ticket)
        {
            return new TicketService().FindTicket(ticket);
        }

        public bool Update(int Id, Ticket ticket)
        {
            return new TicketService().Update(Id, ticket);
        }

        public bool Delete(int Id)
        {
            return new TicketService().Delete(Id);
        }
    }
}
