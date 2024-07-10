namespace FormEncode.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;
    using Crispy_Backend.EntityObjects;

    public class IndexModel
    {
        public List<ProductRecordEO> ProductSet { get; set; }
        public BasketEO Basket { get; set; }

        public UserLoginEO User { get; set; }
    }
}
