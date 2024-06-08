using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk_bot.Vk_methods
{
    internal class FriendsGet
    {
        public Response response { get; set; }

        public class Item
        {
            public int id { get; set; }
            public string track_code { get; set; }
            public string photo_50 { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public bool can_access_closed { get; set; }
            public bool is_closed { get; set; }
            public List<int> lists { get; set; }
        }

        public class Response
        {
            public int count { get; set; }
            public List<Item> items { get; set; }
        }
    }
}
