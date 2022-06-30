using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.DTOs.General
{
    public class BannerIndex
    {
        public int id { get; set; }

        public Uri url { get; set; }
    }

    public class BannerCruz
    {
        public int id { get; set; }

        public string texto { get; set; }

        public string classTexto { get; set; }

        public Uri imgRuta { get; set; }
    }

    public class MetadataBlobImg
    {
        public Uri Uri{ get; set; }

        public string Title { get; set; }

        public string Color { get; set; }
    }


}
