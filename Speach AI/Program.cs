using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace Speach_AI
{
    public class Program
    {
        // prepare voice to talk 
        SpeechSynthesizer ComputerTalk = new SpeechSynthesizer();
        Choices List = new Choices();

        public static void Main(string[] args)
        {
            
            Program a = new Program();
            Boolean wake= true;

            // make voice as a female
            a.ComputerTalk.SelectVoiceByHints(VoiceGender.Female);

            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            a.List.Add(new string[] { "hello, my maker", "how are you " ,"no thanks", "my name is anhh" , "hi" ,"hello","hii","fine" ,"what is your name" });
            a.List.Add(new string[] {"what is today" ,"what time is it","wake","sleep","open ping","google" , "open facebook" ,"facebook"});
            Grammar gr = new Grammar(new GrammarBuilder(a.List));
            a.ComputerTalk.Speak("hello , i'm voice bot");
        
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += Rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }

             void  Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                string r = e.Result.Text;


                if (r == "wake") wake = true;
                if (r == "sleep") wake = false;

                if (wake == true)
                {
                    //what you say 
                    if (r == "hi" || r == "hello")
                    {
                        // what it say
                        a.ComputerTalk.Speak("Hello ,my maker ");

                    }

                    //what you say 
                    if (r == "what is your name")
                    {
                        // what it say
                        a.ComputerTalk.Speak("my name is babos");

                    }

                    //what you say 
                    if (r == "what time is it" || r=="what the time now")
                    {
                        // what it say
                        a.ComputerTalk.Speak(DateTime.Now.ToString("h:ss:tt"));

                    }

                    //what you say 
                    if (r == "open ping" || r == "google")
                    {
                        // what it say
                        a.ComputerTalk.Speak("Okay");
                        Process.Start("https://www.google.com/");

                    }

                    //what you say 
                    if (r == "open facebook" || r == "facebook")
                    {
                        // what it say
                        a.ComputerTalk.Speak("Okay");
                        Process.Start("https://www.facebook.com/");

                    }

                    //what you say 
                    if (r == "how are you")
                    {
                        // what it say
                        a.ComputerTalk.Speak("Great , what about you?");

                    }

                    //what you say 
                    if (r == "fine")
                    {
                        // what it say
                        a.ComputerTalk.Speak("good , any question ?");

                    }

                    //what you say 
                    if (r == "no thanks")
                    {
                        a.ComputerTalk.Speak("okay i'll close ");
                        Environment.Exit(0);
                    }

                }

            }

            Console.ReadKey();
        }

       
    }
}
