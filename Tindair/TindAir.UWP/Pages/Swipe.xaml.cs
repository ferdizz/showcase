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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TindAir.UWP.Pages
{
    public sealed partial class Swipe : Page
    {
        public Swipe()
        {
            this.InitializeComponent();
            
        }

        double pos;

        private void card_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            pos = e.Position.X;
        }

        private void card_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {

            if (e.Position.X > 250)
            {
                Debug.WriteLine("Swiped right!");
            }
            else if (e.Position.X < 20)
            {
                Debug.WriteLine("Swiped left!");
            }
            else
            {
                Canvas.SetLeft(card, 0);
                card.RenderTransform = new RotateTransform() { CenterX = 0, CenterY = 0, Angle = 0 };
            }

        }

        private void card_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Canvas.SetLeft(card, (e.Position.X - pos));
            double offset = 0;
            offset += (e.Position.X - pos);
            Debug.WriteLine("X: " + e.Position.X);
            Debug.WriteLine("Y: " + e.Position.Y);
            card.RenderTransform = new RotateTransform() { CenterX = e.Position.X, CenterY = 400, Angle = (offset/6) };
        }


    }
}
