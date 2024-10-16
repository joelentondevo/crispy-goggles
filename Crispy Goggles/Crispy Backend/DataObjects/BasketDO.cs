﻿using Crispy_Backend.BusinessObject;
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
            BasketEO basket = new BasketEO();
            DataSet BasketStorageData = RunSP_DS("p_getBasketData_f", ("@userid", user.UserID));
            foreach (DataRow row in BasketStorageData.Tables[0].Rows)
            {
                basket.Items.Add(new ProductInstanceEO
                {
                    Product = new ProductEO((int)row["MenuID"],
                                                      row["Name"].ToString(),
                                                      (int)row["Price"]),
                    ProductCount = (int)row["ProductCount"],
                });
            }
            return basket;
        }
    }
}
