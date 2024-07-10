using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.EntityObjects
{
    public class UserSessionEO : BaseEO
    {
        public String Username { get; set; }
        public int UserID { get; set; }
    }
}
