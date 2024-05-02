namespace FormEncode.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;
    using Crispy_Backend.EntityObjects;

    public class ProductsModel
    {
        public List<ProductRecordEO> ProductSet { get; set; }
    }
}
