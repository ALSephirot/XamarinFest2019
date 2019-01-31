using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFest2019.Contracts
{
    public interface ISpeech
    {
        void StartSpeechToText();
        void StopSpeechToText();
    }
}
