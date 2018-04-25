using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TindAir.UWP.Models
{
    class Person
    {
        private String username { get; set; }
        private String fullName { get; set; }
        private String imgUri { get; set; }
        private List<Place> places;

        public Person()
        {
            places = new List<Place>();
            username = "";
            fullName = "";
            imgUri = "";
        }
        public Person(String username, String fullname, String imgUri) {
            // TODO hent listen fra DB
            places = new List<Place>();
            this.username = username;
            this.fullName = fullname;
            this.imgUri = imgUri;
        }

    }
}
