using Crispy_Backend.EntityObjects;
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
            foreach (DataRow row in productRecords.Tables[0].Rows)
            {
                productList.Add(new ProductRecordEO
                {
                    Product = new ProductEO((int)row["MenuID"],
                                                      row["Name"].ToString(),
                                                      (decimal)row["Price"]),
                    ItemCategory = (int)row["ItemCategory"],
                    ItemStock = (int)row["ItemStock"],
                });
            }
            return productList;
        }
        internal ProductRecordEO GetProductFromID(int ID)
        {
            DataRow row = RunSP_DS("p_GetMenuItemByID_f",
                ("@Id", ID)
                ).Tables[0].Rows[0];
            ProductRecordEO productRecordEO = new ProductRecordEO
            {

                Product = new ProductEO((int)row["MenuID"],
                                                      row["Name"].ToString(),
                                                      (decimal)row["Price"]),
                ItemCategory = (int)row["ItemCategory"],
                ItemStock = (int)row["ItemStock"],
            };
        return productRecordEO;
        }
    }
}
