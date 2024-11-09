using Crispy_Backend.BusinessObject;
using Crispy_Backend.EntityObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.DataObjects
{
    internal class BasketDO : BaseDO
    {
        internal void AddBasketItem(ProductInstanceEO Item, UserSessionEO user)
        {
            RUNSP_Bool("p_AddBasketItem_f", ("@userId", user.UserID),
                ("@productId", Item.Product.Id), ("@productCount", Item.ProductCount));
        }

            internal void AmendBasketItem(ProductInstanceEO Item, UserSessionEO user)
        {
            RUNSP_Bool("p_AmendBasketItem_f", ("@userId", user.UserID),
               ("@productId", Item.Product.Id), ("@productCount", Item.ProductCount));
        }

        internal void RemoveBasketItem(ProductInstanceEO Item, UserSessionEO user)
        {
            RUNSP_Bool("p_RemoveBasketItem_f", ("@userId", user.UserID),
               ("@productId", Item.Product.Id));
        }

        internal BasketEO GetBasketFromData(UserSessionEO user)
        {
            BasketEO basket = new BasketEO()
            {
                Items = new List<ProductInstanceEO>()
            };
            ProductDO productDO = new ProductDO();
            DataSet BasketStorageData = RunSP_DS("p_getBasketData_f", ("@userid", user.UserID));
            if (BasketStorageData != null)
            {
                foreach (DataRow row in BasketStorageData.Tables[0].Rows)
                {
                    ProductRecordEO productRecord = productDO.GetProductFromID((int)row["ProductID"]);
                    basket.Items.Add(new ProductInstanceEO
                    {
                        Product = productRecord.Product,
                        ProductCount = (int)row["ProductCount"],
                    });
                }
            }
            return basket;
        }
    }
}
