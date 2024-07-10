using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.EntityObjects
{
    public class UserLoginEO : BaseEO
    {
        internal string Username {  get; set; }
        internal string Password { get; set; }

    }
}
