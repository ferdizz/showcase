using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TindAir.UWP.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TindAir.UWP.Controller;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TindAir.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyPlaces : Page
    {
        
        Place hei = new Place("Dubai", "veldig bra habibi", "http://media-cdn.tripadvisor.com/media/photo-s/07/bd/a1/8a/downtown-dubai-cityscape.jpg");
        Place hei2 = new Place("Jemen", "veldig bra habibi", "http://media-cdn.tripadvisor.com/media/photo-s/07/bd/a1/8a/downtown-dubai-cityscape.jpg");
        Place hei3 = new Place("bitch", "veldig bra habibi", "http://media-cdn.tripadvisor.com/media/photo-s/07/bd/a1/8a/downtown-dubai-cityscape.jpg");
        List<Place> places = new List<Place>();
        public String title;
        public String URI;
        public MyPlaces()
            
        {

            this.InitializeComponent();
            places.Add(hei);
            places.Add(hei2);
            places.Add(hei3);
            foreach (Place p in places) {
                place_list.Items.Add(p.placename);
            }
            
        }

    }
}
