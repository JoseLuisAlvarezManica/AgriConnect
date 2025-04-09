using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriConnect.Shared.DTO
{
    public class TokenDTO
    {
        public String Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
