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

        public override string ToString()
        {
            return $"\nHotel:\nId: {this.Id}\nName: {this.Name}\nAddress: {this.Address}\n" +
                $"Value: {this.Value}\nRegister Date: {this.RegisterDate}";
        }
    }
}
