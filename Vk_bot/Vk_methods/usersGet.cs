using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk_bot
{
    public class usersGet
    {
        public class Response
        {
            public int id;
            public string first_name;
            public string last_name;
            public bool can_access_closed;
            public bool is_closed;
            public string photo_100;
        }
        public List<Response> response = new List<Response>();
    }
}
