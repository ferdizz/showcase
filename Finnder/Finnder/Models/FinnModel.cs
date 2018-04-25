using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Diagnostics;

namespace Finnder.Models
{
    class FinnModel
    {
        private static List<Annonse> DataFromWeb;
        public static List<Annonse> GetLoadedData()
        {
            return DataFromWeb;
        }

        public static async Task GetDataFromWeb()
        {
            if (DataFromWeb == null)
                await ReadDataFromWeb();
        }

        private static async Task ReadDataFromWeb()
        {
            var uri = "http://finnderapp.azurewebsites.net/api.php";
            var client = new HttpClient();
            var response = await client.GetAsync(new Uri(uri));
            var result = await response.Content.ReadAsStringAsync();

            DataFromWeb = new List<Annonse>();

            var finnData = JsonArray.Parse(result);
            foreach (JsonValue row in finnData)
            {
                JsonObject obj = row.GetObject();
                Annonse a = new Annonse();

                a.link = obj.GetNamedString("link");
                a.updated = obj.GetNamedString("updated");
                a.image = obj.GetNamedString("image");
                a.title = obj.GetNamedString("title");
                a.price = obj.GetNamedNumber("price");
                DataFromWeb.Add(a);
            }

        }

    }

}