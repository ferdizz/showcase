using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TindAir.UWP.Models;
namespace TindAir.UWP.Controller
{
    class ServerStuff
    {
        List<Person> personer;
        string response = string.Empty;

        // Generisk metode for å få parset JSON data fra en GET request
        public dynamic getResponse(String url) {
            GetRequest(url);
            return JsonConvert.DeserializeObject(response);
        }

        public Person getUser(String username)
        {
            string url = @"http://tindair.azurewebsites.net/users/"+username;
            GetRequest(url);
            dynamic stuff = JsonConvert.DeserializeObject(response);
            return new Person(username, stuff.name, stuff.profilePicture);

        }
       


        // Async bitch
        public async void GetRequest(String url)
        {
            Uri geturi = new Uri(url); //replace your url  
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage responseGet = await client.GetAsync(geturi);
            response = await responseGet.Content.ReadAsStringAsync();
        }
    }
}
