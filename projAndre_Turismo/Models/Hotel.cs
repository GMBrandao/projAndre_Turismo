using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAndre_Turismo.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public double Value { get; set; }
    }
}
