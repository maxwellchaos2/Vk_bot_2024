using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk_bot
{
    internal class VideoGet
    {
        public Response response;
        public class Response
        {
            public int count;

            public List<Items>  items;
            public class Items
            {
                public int adding_date;
                public List<_Image> image;
                public class _Image
                {
                    public int width;
                }
                
            }
        }

    }
}
