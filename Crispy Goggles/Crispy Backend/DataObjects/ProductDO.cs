﻿using Crispy_Backend.EntityObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.DataObjects
{
    internal class ProductDO : BaseDO
    {
        internal List<ProductRecordEO> GetMenuItems()
        {
            List<ProductRecordEO> productList = new List<ProductRecordEO>();
            DataSet productRecords = RunSP_DS("p_GetMenu_f");
            for ( int i = 0; i < productRecords.Tables[0].Rows.Count; i++)
            {
                productList.Add(new ProductRecordEO
                {
                    Product = new ProductEO((int)productRecords.Tables[0].Rows[i]["MenuID"],
                                                      productRecords.Tables[0].Rows[i]["Name"].ToString(),
                                                      (decimal)productRecords.Tables[0].Rows[i]["Price"]),
                    ItemCategory = (int)productRecords.Tables[0].Rows[i]["ItemCategory"],
                    ItemStock = (int)productRecords.Tables[0].Rows[i]["ItemStock"],
                });
            }
            return productList;
        }
        internal ProductRecordEO GetProductFromID(int ID)
        {
            DataSet Product = RunSP_DS("p_GetMenuItemByID_f",
                ("@Id", ID)
                );
            ProductRecordEO productRecordEO = new ProductRecordEO
            {
                Product = new ProductEO((int)Product.Tables[0].Rows[0]["MenuID"],
                                                      Product.Tables[0].Rows[0]["Name"].ToString(),
                                                      (decimal)Product.Tables[0].Rows[0]["Price"]),
                ItemCategory = (int)Product.Tables[0].Rows[0]["ItemCategory"],
                ItemStock = (int)Product.Tables[0].Rows[0]["ItemStock"],
            };
        return productRecordEO;
        }
    }
}
