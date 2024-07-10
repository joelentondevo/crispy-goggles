using Crispy_Backend.EntityObjects;
using FormEncode.Models;

namespace Crispy_Goggles.Models
{
    public class SessionModel
    {

        public int Id { get; set; } 
        public string Username { get; set; }

        public BasketEO Basket { get; set; }

        public List<ProductRecordEO> ProductSet { get; set; }
    }
}
