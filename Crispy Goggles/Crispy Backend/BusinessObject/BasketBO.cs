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
        public void AddItemToBasket(BasketEO basket, ProductRecordEO product)
        {
            if (basket.GetItem(product.Product.Id) == null)
            {
                ProductInstanceEO productToAdd = new ProductInstanceEO();
                productToAdd.product.Name = product.Product.Name;
                productToAdd.product.Price = product.Product.Price;
                productToAdd.product.Id = product.Product.Id;
                productToAdd.ProductCount = 1;
                basket.Items.Add(productToAdd);
            }
            else if (basket.GetItem(product.Product.Id) != null)
            {
                basket.GetItem(product.Product.Id).ProductCount++;
            }
        }

        public void RemoveItemFromBasket(BasketEO basket, ProductInstanceEO product)
        {
            if (basket.GetItem(product.product.Id).ProductCount > 1)
            {
                basket.GetItem(product.product.Id).ProductCount--;
            }
            else if (basket.GetItem(product.product.Id).ProductCount == 1)
            {
               // basket.Remove(new ProductInstanceEO() { Name == product.Name });
            }
        }
    }
}
