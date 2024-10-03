using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Data;
using System.Web;
using Crispy_Backend.EntityObjects;
using Crispy_Goggles.Utilities;

namespace FormEncode.Models
{
    public class IndexModel
    {
        public List<ProductRecordEO> ProductSet { get; set; }
        public BasketEO Basket { get; set; }

        public UserSessionEO User { get; set; }

        public decimal basketTotal { get; set; }
    }
}

