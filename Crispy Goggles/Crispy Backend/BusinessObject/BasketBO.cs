using Crispy_Backend.DataObjects;
using Crispy_Backend.EntityObjects;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void SaveBasket(BasketEO basket, UserSessionEO user) 
        {
            BasketEO StoredBasket = GetBasket(user);
            if (basket.Items.Count > 0)
            {
                BasketDO basketDO = new BasketDO();
                 foreach (var Item in basket.Items) 
                {
                    if (StoredBasket.Items.Exists(item => item.Product.Id == Item.Product.Id))
                    {
                        basketDO.AmendBasketItem(Item, user);
                    }
                    if (!StoredBasket.Items.Exists(item => item.Product.Id == Item.Product.Id))
                    {
                        basketDO.AddBasketItem(Item, user);
                    }

                }
                foreach (var StoredItem in StoredBasket.Items)
                {
                    if (!basket.Items.Exists(item => item.Product.Id == StoredItem.Product.Id))
                    {
                        basketDO.RemoveBasketItem(StoredItem, user);
                    }
                }
            }
        }

        public BasketEO GetBasket(UserSessionEO user)
        {
            BasketEO basket = new BasketEO();
            if (user != null) 
            { 
                basket = new BasketDO().GetBasketFromData(user);
            }
            return basket;
        }
    }
}
