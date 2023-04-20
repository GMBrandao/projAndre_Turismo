using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAndre_Turismo.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return $"Id:{this.Id}\nOrigin: {this.Origin}\nDestination {this.Destination}\nValue: {this.Value}\nDate: {this.Date}\nClient: {this.Client}\n";
        }
    }
}
