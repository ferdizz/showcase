using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Input;
using System.Diagnostics;
using Finnder.Models;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Finnder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        Queue<Annonse> entries = new Queue<Annonse>();

        int x1, x2;
        int pagenumber = 1;
        public MainPage()
        {
            this.InitializeComponent();
            loadData();
            
            ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            ManipulationStarted += (s, e) => x1 = (int)e.Position.X;
            ManipulationCompleted += (s, e) => { x2 = (int)e.Position.X;
                if (x1 > x2)
                {
                    Debug.WriteLine("Swiped left (no)");
                    nextEntry();
                } else if (x1 < x2){
                    Debug.WriteLine("Swiped right (yes)");
                    nextEntry();
                };
            };
        }

        private async void loadData()
        {
            loadingScreen.Visibility = Visibility.Visible;
            await Models.FinnModel.GetDataFromWeb();
            nextEntry();
            loadingScreen.Visibility = Visibility.Collapsed;
        }

        private void NextButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nextEntry();
        }

        private void InfoButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LaunchSite(currentUrl);
        }

        private async void LaunchSite(string siteAddress)
        {
            try
            {
                Uri uri = new Uri(siteAddress);
                var launched = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch (Exception)
            {
                //handle the exception
            }
        }

        private void BookmarkButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //bookmarkIcon.Text = "";
            bookmarkIcon.Foreground = new SolidColorBrush(Colors.Red);
        }

        private string currentUrl = "";
        private void nextEntry()
        {
            if (entries.Count() < 11)
            {
                List<Annonse> dem_entries = Models.FinnModel.GetLoadedData();
                foreach (Annonse e in dem_entries)
                {
                    entries.Enqueue(e);
                }
            }
            pagenumber++;
            Debug.WriteLine("Attempting to pop from queue...");
            Annonse newAnnonse = entries.Dequeue();
            picture.Source = new BitmapImage(new Uri(newAnnonse.image, UriKind.Absolute));
            tittel.Text = newAnnonse.title;
            pris.Text = "" + newAnnonse.price + " kr";
            currentUrl = newAnnonse.link;
            bookmarkIcon.Foreground = new SolidColorBrush(Colors.Black);
            Debug.WriteLine("Popped entry from queue");
        }

    }
}
