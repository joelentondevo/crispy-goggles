using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.EntityObjects
{
    public class ProductEO
    {

        public ProductEO(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; set; } 
        public string Name { get; set; }    
        public decimal Price {  get; set; }

    }
}
