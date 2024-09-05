using Crispy_Backend.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.BusinessObject
{
    public class BasketBO
    {
        public BasketEO AddItemToBasket(BasketEO basket, ProductRecordEO product)
        {
            basket.Items.Add(product);
            return basket;
        }

        public BasketEO RemoveItemFromBasket(BasketEO basket, ProductEO product)
        {
            return basket;
        }
    }
}
