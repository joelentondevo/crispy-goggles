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
                productToAdd.Product = product.Product;
                productToAdd.ProductCount = 1;
                basket.Items.Add(productToAdd);
            }
            else if (basket.GetItem(product.Product.Id) != null)
            {
                basket.GetItem(product.Product.Id).ProductCount++;
            }
        }

        public void RemoveItemFromBasket(BasketEO basket, ProductRecordEO product)
        {
            if (basket.GetItem(product.Product.Id) != null)
            {
                if (basket.GetItem(product.Product.Id).ProductCount > 1)
                {
                    basket.GetItem(product.Product.Id).ProductCount--;
                }
                else if (basket.GetItem(product.Product.Id).ProductCount < 2)
                {
                    foreach (var Item in basket.Items)
                    {
                        if (product.Product.Id == Item.Product.Id)
                        {
                            basket.Items.Remove(Item);
                            return;
                        }
                    }

                }
            }
        }
    }
}
