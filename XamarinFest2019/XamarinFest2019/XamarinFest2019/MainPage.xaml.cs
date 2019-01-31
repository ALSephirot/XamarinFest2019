using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinFest2019.Contracts;

namespace XamarinFest2019
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(6.344704, -75.5100245), Distance.FromMiles(1)));
                var marker = new Pin()
                {
                    Position = new Position(6.344704, -75.5100245),
                    Label = "Pin de Prueba",
                    Address = "Prueba",
                    Type = PinType.Place
                };

                map.Pins.Add(marker);
                return false;
            });

            MessagingCenter.Subscribe<IMessageSender,string>(this, "STT", (IMessageSender sender, string args) =>
            {
                DisplayAlert("Resultado Speech", args,"Ok");
            });
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var ds = DependencyService.Get<ISpeech>();
            ds.StartSpeechToText();
        }
    }
}
