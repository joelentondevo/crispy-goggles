using Crispy_Backend.DataObjects;
using Crispy_Backend.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.BusinessObject
{
    public class ProductBO
    {
        public List<ProductRecordEO> GetFullProductList()
        {
            List<ProductRecordEO> productList = new ProductDO().GetMenuItems();
            return productList;
        }
    }
}
