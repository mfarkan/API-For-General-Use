using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Test.TokenTest.Models
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string surname { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
    }

}
