using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TindAir.UWP.Models
{
    class Place
    {
        public String imgUri { get; set; }
        public String placename { get; set; }
        public String placedesc { get; set; }
        public Place() {
            placename = "";
            placedesc = "";
            imgUri = "";
        }
        public Place(String placename, String placedesc, String imgUri) {
            this.placename = placename;
            this.placedesc = placedesc;
            this.imgUri = imgUri;
        }

    }
}
