using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using XamarinFest2019.CustomRenderers;
using XamarinFest2019.Droid.CustomRenderers;

[assembly:ExportRenderer(typeof(CMap),typeof(CMapRenderer))]
namespace XamarinFest2019.Droid.CustomRenderers
{
    public class CMapRenderer:MapRenderer
    {
        public CMapRenderer(Context context):base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement != null)
            {

            }

            if(e.NewElement != null)
            {
                var map = (CMap)e.NewElement;


            }
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();

            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));

            return marker;
        }
    }
}