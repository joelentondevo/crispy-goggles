using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.EntityObjects
{
    public class BasketEO
    {
        public List<ProductRecordEO>? Items { get; set; }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (ProductRecordEO item in Items)
            {
                total += item.Price;
            };
            return total;
        }

        public int CountItem(string itemtocount)
        {
            int count = 0;
            foreach (ProductRecordEO item in Items) 
            {
                if (item.Name == itemtocount)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
