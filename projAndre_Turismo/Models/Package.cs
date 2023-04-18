using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAndre_Turismo.Models
{
    public class Package
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime RegisterDate { get; set; }
        public double Value { get; set; }
        public Client Client { get; set; }
    }
}
