using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.EntityObjects
{
    public class ProductRecordEO
    {
        public ProductEO Product { get; set; }
        public int ItemCategory { get; set; }
        public int ItemStock { get; set; }        
    }
}
