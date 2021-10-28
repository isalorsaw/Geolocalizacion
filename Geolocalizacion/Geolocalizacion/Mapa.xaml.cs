using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Geolocalizacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        public Mapa()
        {
            InitializeComponent();
        }
        public Mapa(Position p)
        {
            InitializeComponent();
            DisplayLocal(p);
        }

        public void DisplayLocal(Position p)
        {
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = p,
                Label = "Destination",
                Address = "Lat: " + p.Latitude + ", Long: " + p.Longitude,
            };
            map.Pins.Add(pin);

            MapSpan m = MapSpan.FromCenterAndRadius(p, Distance.FromMeters(800));
            map.MoveToRegion(m);
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}