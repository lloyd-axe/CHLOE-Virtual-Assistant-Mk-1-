using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;



namespace CHLOE
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            string intro1 = "STATUS: ONLINE";
            label1.Text = intro1;
            synthesizer.SpeakAsync("calibrating virtual environment, We are now online and ready. Hello sir Lloyd, how are you?");
            //Recognition part//
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnOff.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Choices commands = new Choices();
            commands.Add(new string[] { "hi chloe", "chloe give me information about your creator","chloe i want to play chess","chloe define enthalpy", "chloe initialize teacher mode on", "chloe can you please help me to review",  "chloe could you please motivate me", "chloe play some smooth jazz",  "chloe could you please run u torrent", "chloe could you please launch autocad 2017", "chloe could you please launch solidworks", "chloe launch google chrome", "chloe play some funky jazz", "chloe could you please show me your code?", "chloe explain poisons ratio", "chloe open the deformable bodies folder", "chloe play some new york jazz", "chloe play the song wont go home without you by maroon 5", "chloe play the song the way i was by maroon 5", "chloe play the song this love by maroon 5", "chloe play the song fix you by coldplay", "chloe play the song yellow by coldplay", "chloe could you play some smooth song","chloe who is the most beautiful girl in the world","chloe play some sad song","chloe please open my presentation","chloe do you like pigs", "put me into youtube", "chloe give me the beat", "chloe who created you","chloe what are you", "open my folder", "play the movie ironman","who is the most handsome guy in the world","get me into the library","how much is 1+1","state the first law of thermodynamics", "can you sing rap God","chloe what time is it" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            foreach (var v in synthesizer.GetInstalledVoices().Select(v => v.VoiceInfo))
            {
                Console.WriteLine("Name:{0}, Gender:{1}, Age:{2}",
                  v.Description, v.Gender, v.Age);
            }

          
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

            

        }
        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "hi chloe":
                    PromptBuilder pBuilder = new PromptBuilder();

                    pBuilder.StartSentence();
                    pBuilder.AppendText("Hello Sir Lloyd.");
                    pBuilder.EndSentence();

                    pBuilder.AppendBreak(new TimeSpan(1));

                    pBuilder.StartSentence();
                    pBuilder.AppendText("How are you?", PromptEmphasis.Strong);
                    pBuilder.EndSentence();

                    synthesizer.SpeakAsync(pBuilder);
                    break;
                case "open my folder":
                    PromptBuilder pBuilder2 = new PromptBuilder();

                    pBuilder2.StartSentence();
                    pBuilder2.AppendText("As you wish sir Lloyd.");
                    pBuilder2.EndSentence();
                    synthesizer.SpeakAsync(pBuilder2);

                    pBuilder2.AppendBreak(new TimeSpan(3));
                  
                  
                    Process.Start(@"C:\Users\user\Documents\ACHA Files");
                    synthesizer.SpeakAsync("The folder a cha Files is now initiated.");
                    break;
                case "play the movie ironman":
                    synthesizer.SpeakAsync("Right away sir.");
                    Process.Start(@"C:\Users\user\Videos\Movies\Iron Man Trilogy\Iron Man [1080p]\Iron.Man.2008.1080p.BrRip.x264.YIFY.mp4");
                    synthesizer.SpeakAsync("Please enjoy the movie Sir.");

                    break;
                case "who is the most handsome guy in the world":
                    synthesizer.SpeakAsync("No doubt sir that it is you sir Lloyd.");
                    break;
                
                case "chloe could you please motivate me":
                    synthesizer.SpeakAsync("Here's to the crazy ones. The misfits. The rebels. The troublemakers. The round pegs in the square holes. The ones who see things differently. They're not fond of rules.And they have no respect for the status quo.You can quote them, disagree with them, glorify or vilify them.About the only thing you can't do is ignore them. Because they change things. They push the human race forward. And while some may see them as the crazy ones, we see genius. Because the people who are crazy enough to think they can change the world, are the ones who do.");
                    break;
                case "chloe explain poisons ratio":
                    synthesizer.SpeakAsync("the ratio of the transverse strain to the axial strain is constant for stresses within the proportional limit.");
                    break;
                case "chloe give me information about your creator":
                    synthesizer.SpeakAsync("This is the only information i can give you.");
                    Form2 fInfo = new Form2();
                    fInfo.ShowDialog();
                    break;
                case "chloe give me the beat":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\DNCE - Cake By The Ocean.mp3");
                    break;
                case "chloe can you please help me to review":
                    synthesizer.SpeakAsync("I will now initiate teacher mode.");
                    Process.Start(@"C:\Users\user\Documents\ACHA Files\Projects\Programming\Visual Studio 2015\Projects\CHLOE v2\CHLOE v2\bin\Debug\CHLOE v2.exe");
                    break;
                case "chloe intialize teacher mode on":
                    synthesizer.SpeakAsync("I will now initiate teacher mode.");
                    Process.Start(@"C:\Users\user\Documents\ACHA Files\Projects\Programming\Visual Studio 2015\Projects\CHLOE v2\CHLOE v2\bin\Debug\CHLOE v2.exe");
                    break;
                case "chloe play some smooth jazz":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Jazz\Trumpet - Tropic trail Jazz.mp3");
                    break;

                case "chloe launch google chrome":
                    synthesizer.SpeakAsync("Right away sir, please wait while im launching the chrome browser.");
                    Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Google Chrome.lnk");
                    synthesizer.SpeakAsync("the chrome browser is now running. Hope your internet connection is good sir, enjoy browsing the internet.");
                    break;
                case "chloe play some funky jazz":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Jazz\Funky Jazz.mp3");
                    break;
                case "chloe define enthalpy":
                    synthesizer.SpeakAsync("It is the thermodynamic quantity equivalent to the total heat content of a system. It is equal to the internal energy of the system plus the product of pressure and volume.");
                  
                    break;
                case "chloe could you please launch autocad 2017":
                    synthesizer.SpeakAsync("Right a way sir, please wait while im launching the autocad software, this may take a while.");
                    Process.Start(@"C:\Users\Public\Desktop\AutoCAD 2017 - English.lnk");
                    break;
                case "chloe could you please launch solidworks":
                    synthesizer.SpeakAsync("Right a way sir, please wait while im launching the solidworks software, this may take a while.");
                    Process.Start(@"C:\Users\Public\Desktop\SOLIDWORKS 2016 x64 Edition.lnk");
                    break;
                case "chloe could you please run u torrent":
                    synthesizer.SpeakAsync("Right a way sir, i will now start running the u torrent application. all downloads will resume immediately.");
                    Process.Start(@"C:\Users\user\AppData\Roaming\Microsoft\Windows\Start Menu\µTorrent.lnk");
                    break;

                case "chloe could you please show me your code?":
                    synthesizer.SpeakAsync("its is my pleasure sir lloyd, i would be please to show you my code. but as much as possible please be carefull with me.");
                    Process.Start(@"C:\Users\user\Documents\ACHA Files\Projects\Programming\Visual Studio 2015\Projects\CHLOE\CHLOE.sln");
                    break;
                case "chloe play some new york jazz":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Jazz\New York Jazz Lounge - Bar Jazz Classics.mp3");
                    break;
                case "chloe play the song yellow by coldplay":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\05 Yellow1.mp3");
                    break;
                case "chloe play the song fix you by coldplay":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Coldplay - Fix You (Album Version).mp3");
                    break;
                case "chloe play the song this love by maroon 5":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Songs About Jane\02 - Maroon 5 - This Love.mp3");
                    break;
                case "chloe open the deformable bodies folder":
                    synthesizer.SpeakAsync("Right away sir lloyd.");
                    Process.Start(@"C:\Users\user\Documents\ACHA Files\Library\Deformable Bodies");
                    synthesizer.SpeakAsync("the deformable bodies folder is now opened.");
                    break;
                case "chloe play the song the way i was by maroon 5":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Maroon 5 - It Wont Be Soon Before Long (Limited Deluxe Edition) [2008] - Pop [www.torrentazos.com]\17 - Maroon 5 - The Way I Was.mp3");
                    break;
                case "chloe play the song wont go home without you by maroon 5":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Maroon 5 - It Wont Be Soon Before Long (Limited Deluxe Edition) [2008] - Pop [www.torrentazos.com]\05 - Maroon 5 - Won't Go Home Without You.mp3");
                    break;
                case "chloe i want to play chess":
                    synthesizer.SpeakAsync("Right away sir.");
                    Process.Start(@"C:\Program Files\Microsoft Games\Chess\Chess.exe");
                    synthesizer.SpeakAsync("Enjoy your game sir and Goodluck!");
                    break;
                case "chloe who is the most beautiful girl in the world":
                    synthesizer.SpeakAsync("Sir, we already know that jameel de los reyes is the most beautiful girl in the world!! this is a photo of her.");
                    Process.Start(@"C:\Users\user\Pictures\16111859_118879701952187_302070870_n.jpg");

                    break;
                case "chloe play some sad song":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\Maroon 5 - It Wont Be Soon Before Long (Limited Deluxe Edition) [2008] - Pop [www.torrentazos.com]\11 - Maroon 5 - Better That We Break.mp3");
                    break;
                case "chloe could you play some smooth song":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Music\audio.mp3");
                    break;

                case "put me into youtube":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Documents\ACHA Files\Projects\Programming\CHLOE\Web\Youtube\YouTube.html");
                    synthesizer.SpeakAsync("The computer will now start running the Youtube page, please wait, it may take a while.");
                    break;
                case "chloe please open my presentation":
                    synthesizer.SpeakAsync("As you wish sir.");
                    Process.Start(@"C:\Users\user\Documents\ACHA Files\ACHA FILES (Current)\3y_2s ENGINEERING MANAGEMENT\COMMUNICATING.pptx");
                    synthesizer.SpeakAsync("I will now start running the powerpoint presentation, Goodluck sir lloyd! why are you so handsome?");
                    break;

                
                case "get me into the library":
                    synthesizer.SpeakAsync("Right away sir.");
                    Process.Start(@"C:\Users\user\Documents\ACHA Files\Library");
                    synthesizer.SpeakAsync("You are now into the library folder.");

                    break;
                
                case "how much is 1+1":
                    synthesizer.SpeakAsync("i am not yet capable to do some calculations, but i know that 1+1=3, Joke! its 2.");
                    break;
                
                case "state the first law of thermodynamics":
                    synthesizer.SpeakAsync("When energy pass as work, heat, or into matter, or into or out to a system, the systems internal energy, changes in accord with the law of conservation of energy.");
                    break;
                case "can you sing rap God":
                    synthesizer.SpeakAsync("Im not a singer but ill try, Uh, summa lumma dooma lumma you assuming I'm a human What I gotta do to get it through to you I'm superhuman Innovative and I'm made of rubber so that anything you say is Ricochet in off a me and it'll glue to you And I'm devastating more than ever demonstrating How to give a motherfuckin' audience a feeling like it's levitating Never fading and I know that haters are forever waiting For the day that they can say I fell off they'll be celebrating Cause I know the way to get 'em motivated I make elevating music You make elevator music");
                    break;
                case "chloe what are you":
                   
                    synthesizer.SpeakAsync("I am a specialized program that is created to assist the user of this computer to do simple things as he or she commands");
                    break;
                case "chloe who created you":
                    synthesizer.SpeakAsync("A guy named Lloyd Nikko A cha created me, and gosh! he is so handsome!");
                    break;
               
                case "chloe do you like pigs":
                    synthesizer.SpeakAsync("Pigs are great! they are so fat and fluffyy, i like pigs, they are delicious! Oink oink!");
                    break;




            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            string outtro1 = "STATUS: OFFLINE";
            label1.Text = outtro1;
            synthesizer.SpeakAsync("Goodbye Sir.");
            recEngine.RecognizeAsyncStop();
            btnOff.Enabled = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
