using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAndre_Turismo.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public DateTime RegisterDate { get; set; }

        public override string ToString()
        {
            return $"{this.Street}, {this.Number} - {this.ZipCode} - {this.Neighborhood} - {this.City.Description}";
        }
    }
}
