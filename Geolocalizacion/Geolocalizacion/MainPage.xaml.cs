using System;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Geolocalizacion
{
    public partial class MainPage : ContentPage
    {
        Position pos;
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                //double latt = 15.4;
                //double longg = -86.9;

                if (location != null)
                {
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    lblcoor.Text=($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                    pos = new Position(location.Latitude, location.Longitude);

                    //Como Calcular la Distancia entre dos puntos
                    double dis = location.CalculateDistance(location.Latitude, location.Longitude, DistanceUnits.Miles);
                    DisplayAlert("Distancia", dis.ToString(), "OK");

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                //DisplayAlert("Error", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Mapa(pos));
        }
    }
}
