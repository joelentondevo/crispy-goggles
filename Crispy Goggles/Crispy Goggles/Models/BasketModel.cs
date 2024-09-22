using Crispy_Backend.EntityObjects;

namespace Crispy_Goggles.Models
{
    public class BasketModel
    {
        public BasketEO Basket { get; set; }
        public ProductRecordEO Product { get; set; }
        public UserSessionEO User { get; set; }

        public String SessionTag { get; set; }

    }
}
