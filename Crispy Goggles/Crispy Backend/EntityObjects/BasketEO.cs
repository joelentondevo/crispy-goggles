﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.EntityObjects
{
    public class BasketEO
    {
        public List<ProductInstanceEO>? Items { get; set; }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            if (Items != null)
            {
                foreach (ProductInstanceEO item in Items)
                {
                    total += item.Product.Price * item.ProductCount;
                };
            }
            return total;
        }

        public ProductInstanceEO GetItem(int ItemToFind)
        {
            foreach (ProductInstanceEO item in Items)
            {
                if (item.Product.Id.Equals(ItemToFind))
                {
                    return item;
                }
            }
            return null;
        }

    }
}
