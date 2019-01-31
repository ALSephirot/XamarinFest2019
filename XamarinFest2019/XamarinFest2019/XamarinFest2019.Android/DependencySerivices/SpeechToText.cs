using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Views;
using Android.Widget;
using XamarinFest2019.Contracts;
using XamarinFest2019.Droid.DependencySerivices;

[assembly:Xamarin.Forms.Dependency(typeof(SpeechToText))]
namespace XamarinFest2019.Droid.DependencySerivices
{
    public class SpeechToText : ISpeech
    {
        private readonly int VOICE = 10;
        private Activity _activity;
        public SpeechToText()
        {
            _activity = MainActivity.currentActivity;
        }
        public void StartSpeechToText()
        {
            StartRecordingAndRecognizing();
        }

        private void StartRecordingAndRecognizing()
        {
            string rec = global::Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec == "android.hardware.microphone")
            {
                var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);


                voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");

                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, "es");
                _activity.StartActivityForResult(voiceIntent, VOICE);
            }
            else
            {
                throw new Exception("No mic found");
            }
        }

        public void StopSpeechToText()
        {
            throw new NotImplementedException();
        }
    }
}