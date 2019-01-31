using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android;
using Android.Content;
using Android.Speech;
using Xamarin.Forms;
using XamarinFest2019.Contracts;

namespace XamarinFest2019.Droid
{
    [Activity(Label = "XamarinFest2019", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IMessageSender
    {
        public static Activity currentActivity;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            currentActivity = this;
            ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessCoarseLocation, Manifest.Permission.RecordAudio },0);

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if(requestCode == 10)
            {
                if(resultCode == Result.Ok)
                {
                    var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                    if(matches.Count > 0)
                    {
                        string text = matches[0];
                        MessagingCenter.Send<IMessageSender,string>(this,"STT", text);
                    }
                }
            }
            base.OnActivityResult(requestCode, resultCode, data);

        }
    }
}