using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using VoiceBOT;

namespace WindowsFormsApp1

{
    public partial class Bot : Form
    {


        
        
        SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One); //FOR ARDUINO.


        Choices list = new Choices();//Initializes the list for normal mode 
        Choices list2 = new Choices();//Initializes the list of grammer for search mode
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();//Initializes the speech recognition engine
        SpeechSynthesizer a = new SpeechSynthesizer(); //Initializes the speech synthesizer.
        SpeechRecognitionEngine rec2 = new SpeechRecognitionEngine();//Initializes the speech recognition engine for the search mode
        SpeechSynthesizer synth = new SpeechSynthesizer();//Initializes the speech synthesizer for search mode
        private string pdf_location { get; set; }
        private string last_location { get; set; }
        //Variables and stuff
        Random rnd = new Random();
        Boolean switch1 =false;
        Boolean bing = false, search = false, video = false;
        Weather weather = new Weather();
        char pdf1 = '1', x = 'I', mode = '1';
        string sfilename, pdf;
        Bitmap img1 = VoiceBOT.Properties.Resources.youtube;
        Bitmap img2 = VoiceBOT.Properties.Resources.google1;
        Bitmap img3 = VoiceBOT.Properties.Resources.bing1;
        Bitmap img4 = VoiceBOT.Properties.Resources._584599c0bcb9df443a7fb797;
        Bitmap img5 = VoiceBOT.Properties.Resources._1600;
        Bitmap img6 = VoiceBOT.Properties.Resources.r2d2_512;
        
        public Bot()
        {   
           
            //Normal mode
            list.Add(new string[] { "hello", "open powerpoint", "open word", "start", "wait", "read pdf", "show me the news", "play rock music", "enter search mode", "play classic music", "play rap music", "play jazz music", "play pop music", "what is the temperature", "what is the weather like", "close word", "close powerpoint", "how are you", "what time is it", "what date is it", "open google", "light on", "light off", "open excel", "close excel", "minimize", "unminimize", "close browser", "enter search mode" });
            Grammar gr = new Grammar(new GrammarBuilder(list));//Initializes the grammer with list as a parameter
            //Search mode
            list2.Add(File.ReadAllLines("commands.txt")); //Adds all the lines from commands.txt to the list
            Grammar gr2 = new Grammar(new GrammarBuilder(list2)); //Initializes the grammer with the list for search mode
           
            
            //Detects if it can find a mic if it cant it will prompt the user with a box that asks him if he wants to continue
            try
            {
                //normal mode
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);//loads the grammer
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();//sets input to default audio device
                rec.RecognizeAsync(RecognizeMode.Multiple);//starts the recognizer rec
                //search mode
                rec2.RequestRecognizerUpdate();
                rec2.LoadGrammar(gr2);//loads the grammer
                rec2.SetInputToDefaultAudioDevice();//sets input to default audio device
                rec2.SpeechRecognized += rec_SpeachRecognized;
                rec2.RecognizeAsyncStop();//stops the recognizer rec2
            }
            catch
            {
                if (MessageBox.Show("No microphone detected.\nContinue anyway?", "NO Microphone", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)//Message box with prompt
                {

                }
                else
                {
                    Environment.Exit(0); //exits the app if the user hasnt clicked yes.
                }

            }

            a.SelectVoice("Microsoft Zira Desktop");//Selects the voice of the synthesizer
            a.SelectVoiceByHints(VoiceGender.Female);//selects the voice of the synthesizer
            this.FormBorderStyle = FormBorderStyle.None;



            InitializeComponent();
        }

        public void say(string h) //For simplification
        {
            a.SpeakAsync(h);

        }

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string r = e.Result.Text; //Initializes string r with the result of the synthesizer (what he understands)
           
            yourcommands.AppendText(" " + r + "\n");//Adds the string to the first textbox.
            if (search) //for searching on google
            {
                Process.Start("https://www.google.com/#q=" + r);//searches google by adding the string he understood to this url
                search = false;
            }
            if (video)//for searching on youtube
            {
                Process.Start("https://www.youtube.com/results?search_query=" + r);//searches youtube by adding the string he understood to this url
                video = false;
            }
            if (bing)//for searching on bing 
            {
                Process.Start("http://www.bing.com/search?q=" + r);//searches bing by adding the string he understood to this url
                bing = false;

            }
            if (mode == '2')
            {
                switch (r)
                {
                    case "search for":

                        search = true;
                        break;
                    case "search video":

                        video = true;
                        break;
                    case "search bing":

                        bing = true;

                        break;
                    case "exit search mode":
                        mode = '1';
                        rec2.RecognizeAsyncStop();//stops the search recognizer
                        rec.RecognizeAsync(RecognizeMode.Multiple); //starts the normal recognizer
                        robotpicture2.BackgroundImage = img4; 
                        robotpicture3.BackgroundImage = img5;
                        robotpicture4.BackgroundImage = img6;
                        label1.Text = "";//resets the label text
                        break;
                    case "close browser":
                        AppShut.KillBrowsers();
                        break;
                    case "focus":
                        this.WindowState = FormWindowState.Normal;
                        break;
                }
            }
            if (mode == '3')
            {
                switch (r)
                {
                    case "start":
                        mode = '1';
                        break;
                }

            }

            if (mode == '1')
            {
                
                

                
                switch (r)
                {

                    case "read pdf":
                        PDF_BUTTON.PerformClick();//Performs click on pdf_button
                        break;
                    case "what is the weather like":
                        rec.RecognizeAsyncStop();//Stops the bot so it wont understand and take his own words as commands
                        say("The weather is " + weather.GetWeather("cond"));//gets the weather from Weather.cs
                        response.AppendText("The weather is " + weather.GetWeather("cond") + "\n");// Gets the weather and writes it to the second textbox.
                        rec.RecognizeAsync(RecognizeMode.Multiple); //starts the bot again
                        break;
                    case "hello":
                        
                            rec.RecognizeAsyncStop(); //stops the bot
                            int hour = Int32.Parse(DateTime.Now.ToString("HH")); //takes the current time as hours and assigns it to the integer hour (i made this so it has more variety)
                            if (hour >= 2 && hour <= 13)//checks if the integer hour is between these numbers
                            {
                                say("Good Morning");//says good morning
                                response.AppendText("Good Morning" + "\n");//Appends the text to the second textbox
                            }
                            if (hour > 12 && hour < 16)//checks if the integer hour is between these numbers
                            {
                                say("Good Afternoon");//says good afternoon
                                response.AppendText("Good Afternoon" + "\n");

                            }
                            if (hour >= 16 && hour < 20)//checks if the integer hour is between these numbers
                            {

                                say("Good Evening");//says good evening
                                response.AppendText("Good Evening" + "\n");
                            }
                            if (hour >= 20 && hour <= 24)//checks if the integer hour is between these numbers
                            {
                                say("Hello user");
                                response.AppendText("Hello user" + "\n");

                            }
                            rec.RecognizeAsync(RecognizeMode.Multiple);//starts the recognizer again
                        break;
                    case "show me the news":
                        Process.Start("https://news.google.com/news/headlines?ned=us&hl=en&gl=US"); //Just connects to this webpage
                        break;
                    case "what is the temperature":
                        rec.RecognizeAsyncStop();//stops the recognizer
                        say("The temperature is " + weather.GetWeather("temp") + "Degrees"); //gets the degress from Weather.cs
                        response.AppendText("The temperature is " + weather.GetWeather("temp") + "Degrees" + "\n"); //appends the result to the second textbox
                        rec.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    case "enter search mode":
                        rec2.RecognizeAsync(RecognizeMode.Multiple); //starts the second recognition engine
                        rec.RecognizeAsyncStop(); //stops the first
                        mode = '2'; 
                        label1.Text = "Search mode active."; 
                        robotpicture2.BackgroundImage = img1;
                        robotpicture3.BackgroundImage = img3;
                        robotpicture4.BackgroundImage = img2;
                        break;
                    case "wait":
                        mode = '3'; 
                        break;
                    case "light on": //Turns a light on the arduino
                        try
                        {
                            port.Open(); //opens the port
                            port.WriteLine("A"); //writes a 
                            port.Close();// closes the port
                        }
                        catch
                        {
                            say("arduino not connected ");
                        }
                        break;
                    case "light off"://turns the light off
                        try
                        {


                            port.Open();//opens the port
                            port.WriteLine("B");//writes B
                            port.Close();//closes the port
                        }
                        catch
                        {
                                say("arduino not connected");
                        }
                        break;
                    case "close browser":
                        AppShut.KillBrowsers(); //calls the function in appshut.cs
                        break;
                    case "open excel":
                        try
                        {
                            Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.exe"); //opens excel by starting it from this location only works with office 2016 :/
                        }
                        catch 
                        {
                            try
                            {
                                Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office15\EXCEL.exe"); //opens the office 2013 one 
                            }
                            catch //incase non of them are installed
                            {
                                say("could not find microsoft excel");
                            }
                        }
                        break;
                    case "open powerpoint":

                        try
                        {
                            Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\POWERPNT.exe");
                        }
                        catch
                        {
                            try
                            {
                                Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office15\POWERPNT.exe"); //opens the office 2013 one 
                            }
                            catch //incase non of them are installed
                            {
                                say("could not find microsoft powerpoint");
                            }
                        }
                        break;
                    case "open word":

                        try
                        {
                            Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.exe");
                        }
                        catch
                        {
                            try
                            {
                                Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.exe");
                            }
                            catch {
                                say("could not find microsoft WORD");
                            }
                        }
                        break;
                    case "close excel":

                        try
                        {
                            AppShut.KillOffice("EXCEL"); //closes excel by calling the static function kill office from the class appshut
                        }
                        catch
                        {
                                say("excel is not running");
                        }
                        break;
                    case "play rap music":

                        webBrowser1.Navigate("https://www.youtube.com/watch?v=4LfJnj66HVQ&index=1&list=PLw-VjHDlEOgsIgak3vJ7mrcy-OscZ6OAs");
                        timer3.Start();
                        rec.RecognizeAsyncStop();
                        maintxtbox.Enabled = false;
                        PDF_BUTTON.Enabled = false;
                        x = 'I';
                        pause.Text = "Pause Music";
                        break;
                    case "play pop music":

                        webBrowser1.Navigate("https://www.youtube.com/watch?v=lp-EO5I60KA&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj");
                        timer3.Start();
                        rec.RecognizeAsyncStop();
                        maintxtbox.Enabled = false;
                        PDF_BUTTON.Enabled = false;
                        x = 'I';
                        pause.Text = "Pause Music";
                        break;
                    case "play jazz music":

                        webBrowser1.Navigate("https://www.youtube.com/watch?v=vmDDOFXSgAs&list=RDQM-bY2C3snbw8");
                        timer3.Start();
                        rec.RecognizeAsyncStop();
                        maintxtbox.Enabled = false;
                        PDF_BUTTON.Enabled = false;
                        x = 'I';
                        pause.Text = "Pause Music";
                        break;
                    case "play rock music":
                        webBrowser1.Navigate("https://www.youtube.com/watch?v=ktvTqknDobU&list=PLkgWEYvTsgqHO6vTqQEqWxBlW_6ykRmYz");
                        timer3.Start();
                        maintxtbox.Enabled = false;
                        PDF_BUTTON.Enabled = false;
                        rec.RecognizeAsyncStop();
                        x = 'I';
                        pause.Text = "Pause Music";
                        break;
                    case "play classic music":

                        webBrowser1.Navigate("https://www.youtube.com/watch?v=GRxofEmo3HA&list=PLVXq77mXV53-Np39jM456si2PeTrEm9Mj");
                        timer3.Start();
                        rec.RecognizeAsyncStop();
                        maintxtbox.Enabled = false;
                        PDF_BUTTON.Enabled = false;
                        x = 'I';
                        pause.Text = "Pause Music";
                        break;
                    case "close powerpoint":

                        try
                        {
                            AppShut.KillOffice("POWERPNT");
                        }
                        catch
                        {
                                say("Powerpoint is not running");
                        }
                        break;
                    case "close word":

                        try
                        {
                            AppShut.KillOffice("WINWORD");
                        }
                        catch
                        {
                                say("Word is not running");
                        }
                        break;

                    case "what time is it":
                            rec.RecognizeAsyncStop();
                            say(DateTime.Now.ToString("h:mm tt")); //gets the time as h:mm tt format
                            response.AppendText(DateTime.Now.ToString("h:mm tt") + "\n");
                            rec.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    case "minimize":
                        this.WindowState = FormWindowState.Minimized; //this minimizes the program
                        break;
                    case "unminimize":
                        this.WindowState = FormWindowState.Normal; //this unminimizes the program
                        break;
                    case "open google":
                        Process.Start("www.google.com");//just opens google
                        break;
                    case "what date is it":
                            rec.RecognizeAsyncStop();
                            say(DateTime.Now.ToString("M/d/yyyy")); //gets the date as M/d/yyyy Format
                            response.AppendText(DateTime.Now.ToString("M / d / yyyy") + "\n");
                            rec.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    case "how are you":
                        rec.RecognizeAsyncStop();
                        int res = rnd.Next(1, 4); //assigns integer res to a random number between 1 and 4 (this is for diversity)
                        if (res == 1)
                        {
                            say("Great");
                            response.AppendText("Great" + "\n");
                        }
                        if (res == 3)
                        {
                            say("Fine");
                            response.AppendText("Fine" + "\n");
                        }
                        if (res == 2)
                        {
                            say("Happy");
                            response.AppendText("Happy" + "\n");
                        }
                        if (res == 4)
                        {
                            say("Bored");
                            response.AppendText("Bored" + "\n");
                        }
                        rec.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                }
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")] //imports this dll in order to create rectangle effect on the form
        private static extern IntPtr CreateRoundRectRgn 
   (
       int nLeftRect,
       int nTopRect,
       int nRightRect,
       int nBottomRect,
       int nWidthEllipse,
       int nHeightEllipse
    );
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(Color.Black, 2); //initializes the object pen with the color black and 2 pixels as the size
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height); //creates the rectangle with the height
            e.Graphics.DrawRectangle(pen, rect);
        }
        protected override void WndProc(ref Message m) //Makes the form movable
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            voicebox.SelectedIndex = 0;
            stylebox.SelectedIndex = 2;
            this.ActiveControl = maintxtbox;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (stylebox.SelectedIndex ==2) 
            {
                yourcommands.BackColor = Color.FromArgb(47, 49, 54);
                yourcommands.ForeColor = Color.FromArgb(115, 138, 215);
                maintxtbox.BackColor = Color.FromArgb(60, 63, 68);
                maintxtbox.ForeColor = Color.FromArgb(115, 138, 215);
                sendbtn.BackColor = Color.FromArgb(60, 63, 68);
                sendbtn.ForeColor = Color.FromArgb(115, 138, 215);
                response.BackColor = Color.FromArgb(47, 49, 54);
                response.ForeColor = Color.FromArgb(115, 138, 215);
                Titlelbl.ForeColor = Color.FromArgb(115, 138, 215);
                Titlelbl.BackColor = Color.FromArgb(40, 43, 48);
                next.BackColor = Color.FromArgb(60, 63, 68);
                next.ForeColor = Color.FromArgb(115, 138, 215);
                last.BackColor = Color.FromArgb(60, 63, 68);
                last.ForeColor = Color.FromArgb(115, 138, 215);
                pause.BackColor = Color.FromArgb(60, 63, 68);
                pause.ForeColor = Color.FromArgb(115, 138, 215);
                PDF_BUTTON.BackColor = Color.FromArgb(60, 63, 68);
                PDF_BUTTON.ForeColor = Color.FromArgb(115, 138, 215);
                Pausepdfbtn.BackColor = Color.FromArgb(60, 63, 68);
                Pausepdfbtn.ForeColor = Color.FromArgb(115, 138, 215);
                stylebox.BackColor = Color.FromArgb(47, 49, 54);
                stylebox.ForeColor = Color.FromArgb(115, 138, 215);
                voicebox.BackColor = Color.FromArgb(47, 49, 54);
                voicebox.ForeColor = Color.FromArgb(115, 138, 215);
                label1.ForeColor = Color.FromArgb(115, 138, 215);
                robotpicture2.BackColor = Color.FromArgb(40, 43, 48);
                robotpicture3.BackColor = Color.FromArgb(40, 43, 48);
                minimizebtn.BackColor = Color.FromArgb(40, 43, 48);
                minimizebtn.ForeColor = Color.Gray;
                helpbtn.BackColor = Color.FromArgb(40, 43, 48);
                helpbtn.ForeColor = Color.Gray;
                quitbtn.BackColor = Color.FromArgb(40, 43, 48);
                quitbtn.ForeColor = Color.Gray;
                this.BackColor = System.Drawing.Color.FromArgb(40, 43, 48);
            }
            if (stylebox.SelectedIndex == 1)
            {
                yourcommands.BackColor = Color.FromArgb(47, 49, 54);
                yourcommands.ForeColor = Color.FromArgb(152, 117, 252);
                maintxtbox.BackColor = Color.FromArgb(60, 63, 68);
                maintxtbox.ForeColor = Color.FromArgb(152, 117, 252);
                sendbtn.BackColor = Color.FromArgb(60, 63, 68);
                sendbtn.ForeColor = Color.FromArgb(152, 117, 252);
                response.BackColor = Color.FromArgb(47, 49, 54);
                response.ForeColor = Color.FromArgb(152, 117, 252);
                Titlelbl.ForeColor = Color.FromArgb(152, 117, 252);
                Titlelbl.BackColor = Color.FromArgb(255, 255, 255);
                pause.BackColor = Color.FromArgb(60, 63, 68);
                next.BackColor = Color.FromArgb(60, 63, 68);
                next.ForeColor = Color.FromArgb(152, 117, 252);
                Pausepdfbtn.BackColor = Color.FromArgb(60, 63, 68);
                Pausepdfbtn.ForeColor = Color.FromArgb(152, 117, 252);
                pause.ForeColor = Color.FromArgb(152, 117, 252);
                last.BackColor = Color.FromArgb(60, 63, 68);
                last.ForeColor = Color.FromArgb(152, 117, 252);
                PDF_BUTTON.BackColor = Color.FromArgb(60, 63, 68);
                PDF_BUTTON.ForeColor = Color.FromArgb(152, 117, 252);
                stylebox.BackColor = Color.FromArgb(47, 49, 54);
                stylebox.ForeColor = Color.FromArgb(152, 117, 252);
                voicebox.BackColor = Color.FromArgb(47, 49, 54);
                voicebox.ForeColor = Color.FromArgb(152, 117, 252);
                label1.ForeColor = Color.FromArgb(152, 117, 252);

                robotpicture2.BackColor = Color.FromArgb(255, 255, 255);
                robotpicture3.BackColor = Color.FromArgb(255, 255, 255);
                minimizebtn.BackColor = Color.FromArgb(255, 255, 255);
                minimizebtn.ForeColor = Color.Gray;
                quitbtn.BackColor = Color.FromArgb(255, 255, 255);
                quitbtn.ForeColor = Color.Gray;
                helpbtn.BackColor = Color.FromArgb(255, 255, 255);
                helpbtn.ForeColor = Color.Gray;
                this.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            if (stylebox.SelectedIndex == 0)
            {
                yourcommands.BackColor = Color.FromArgb(47, 49, 54);
                yourcommands.ForeColor = Color.FromArgb(255, 45, 85);
                maintxtbox.BackColor = Color.FromArgb(60, 63, 68);
                maintxtbox.ForeColor = Color.FromArgb(255, 45, 85);
                sendbtn.BackColor = Color.FromArgb(60, 63, 68);
                sendbtn.ForeColor = Color.FromArgb(255, 45, 85);
                next.BackColor = Color.FromArgb(60, 63, 68);
                next.ForeColor = Color.FromArgb(255, 45, 85);
                last.BackColor = Color.FromArgb(60, 63, 68);
                last.ForeColor = Color.FromArgb(255, 45, 85);
                pause.BackColor = Color.FromArgb(60, 63, 68);
                pause.ForeColor = Color.FromArgb(255, 45, 85);
                Pausepdfbtn.BackColor = Color.FromArgb(60, 63, 68);
                Pausepdfbtn.ForeColor = Color.FromArgb(255, 45, 85);
                response.BackColor = Color.FromArgb(47, 49, 54);
                response.ForeColor = Color.FromArgb(255, 45, 85);
                Titlelbl.ForeColor = Color.FromArgb(255, 45, 85);
                Titlelbl.BackColor = Color.FromArgb(255, 255, 255);
                label1.ForeColor = Color.FromArgb(255, 45, 85);
                PDF_BUTTON.BackColor = Color.FromArgb(60, 63, 68);
                PDF_BUTTON.ForeColor = Color.FromArgb(255, 45, 85);
                stylebox.BackColor = Color.FromArgb(47, 49, 54);
                stylebox.ForeColor = Color.FromArgb(255, 45, 85);
                voicebox.BackColor = Color.FromArgb(47, 49, 54);
                voicebox.ForeColor = Color.FromArgb(255, 45, 85);
                robotpicture2.BackColor = Color.FromArgb(255, 255, 255);
                robotpicture3.BackColor = Color.FromArgb(255, 255, 255);
                minimizebtn.BackColor = Color.FromArgb(255, 255, 255);
                minimizebtn.ForeColor = Color.Gray;
                quitbtn.BackColor = Color.FromArgb(255, 255, 255);
                quitbtn.ForeColor = Color.Gray;
                helpbtn.BackColor = Color.FromArgb(255, 255, 255);
                helpbtn.ForeColor = Color.Gray;
                this.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }     
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //changes the type of voice
        {
            if (voicebox.SelectedIndex ==0)
            {
                a.Rate = 1; //changes the speed of the voice
                a.SelectVoiceByHints(VoiceGender.Female);
            }
            if (voicebox.SelectedIndex == 1)
            {
                a.Rate = 1;//changes the speed of the voice
                a.SelectVoiceByHints(VoiceGender.Male);
            }
            if (voicebox.SelectedIndex == 3)
            {
                a.Rate = -10;//changes the speed of the voice
                a.SelectVoiceByHints(VoiceGender.Male);
            }
            if (voicebox.SelectedIndex == 4)
            {
                a.Rate = -10;//changes the speed of the voice
                a.SelectVoiceByHints(VoiceGender.Female);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; //minimizes the form
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string d = maintxtbox.Text;
            yourcommands.AppendText(" " + d + "\n");
            if (search)
            {
                Process.Start("https://www.google.com/#q=" + d);
                search = false;
            }
            if (video)
            {
                Process.Start("https://www.youtube.com/results?search_query=" + d);
                video = false;
            }
            if (bing)
            {
                Process.Start("http://www.bing.com/search?q=" + d);
                bing = false;

            }
            if (mode == '2')
            {
                switch (d)
                {
                    case "search for":
                        search = true;
                        break;
                    case "search video":
                        video = true;
                        break;
                    case "search bing":
                        bing = true;
                        break;
                    case "exit search mode":
                        mode = '1';
                        rec2.RecognizeAsyncStop();
                        rec.RecognizeAsync(RecognizeMode.Multiple);
                        robotpicture2.BackgroundImage = img4;
                        robotpicture3.BackgroundImage = img5;
                        robotpicture4.BackgroundImage = img6;
                        label1.Text = "";
                        break;
                    case "close browser":
                        AppShut.KillBrowsers();
                        break;
                    case "focus":
                        this.WindowState = FormWindowState.Normal;
                        break;
                }




            }
            switch (d)
            {
                case "play rap music":

                    webBrowser1.Navigate("https://www.youtube.com/watch?v=4LfJnj66HVQ&index=1&list=PLw-VjHDlEOgsIgak3vJ7mrcy-OscZ6OAs");
                    timer3.Start();
                    rec.RecognizeAsyncStop();
                    mode = '3';
                    maintxtbox.Enabled = false;
                    PDF_BUTTON.Enabled = false;
                    x = 'I';
                    pause.Text = "Pause Music";
                    break;
                case "play pop music":

                    webBrowser1.Navigate("https://www.youtube.com/watch?v=lp-EO5I60KA&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj");
                    timer3.Start();
                    rec.RecognizeAsyncStop();
                    mode = '3';
                    maintxtbox.Enabled = false;
                    PDF_BUTTON.Enabled = false;
                    x = 'I';
                    pause.Text = "Pause Music";
                    break;
                case "play jazz music":

                    webBrowser1.Navigate("https://www.youtube.com/watch?v=vmDDOFXSgAs&list=RDQM-bY2C3snbw8");
                    timer3.Start();
                    rec.RecognizeAsyncStop();
                    mode = '3';
                    maintxtbox.Enabled = false;
                    PDF_BUTTON.Enabled = false;
                    x = 'I';
                    pause.Text = "Pause Music";
                    break;

                case "play rock music":

                    webBrowser1.Navigate("https://www.youtube.com/watch?v=ktvTqknDobU&list=PLkgWEYvTsgqHO6vTqQEqWxBlW_6ykRmYz");
                    timer3.Start();

                    rec.RecognizeAsyncStop();
                    mode = '3';
                    maintxtbox.Enabled = false;
                    PDF_BUTTON.Enabled = false;
                    x = 'I';
                    pause.Text = "Pause Music";
                    break;
                case "play classic music":

                    webBrowser1.Navigate("https://www.youtube.com/watch?v=GRxofEmo3HA&list=PLVXq77mXV53-Np39jM456si2PeTrEm9Mj");

                    timer3.Start();
                    rec.RecognizeAsyncStop();
                    mode = '3';
                    maintxtbox.Enabled = false;
                    PDF_BUTTON.Enabled = false;
                    x = 'I';
                    pause.Text = "Pause Music";
                    break;


            }
            if (mode == '1')
            {
                switch (d)
                {
                    case "enter search mode":
                        rec2.RecognizeAsync(RecognizeMode.Multiple);
                        rec.RecognizeAsyncStop();
                        mode = '2';
                        robotpicture2.BackgroundImage = img1;
                        robotpicture3.BackgroundImage = img2;
                        robotpicture4.BackgroundImage = img3;
                        label1.Text = "Search mode active.";
                        break;
                    case "bye":
                        Environment.Exit(0);
                        break;
                    case "hello":                       
                            rec.RecognizeAsyncStop();
                            string time = DateTime.Now.ToString("HH");
                            int hour = Int32.Parse(time);
                            if (hour >= 2 && hour <= 13)
                            {
                                say("Good Morning");
                                response.AppendText("Good Morning" + "\n");
                            }
                            if (hour > 12 && hour < 16)
                            {
                                say("Good Afternoon");
                                response.AppendText("Good Afternoon" + "\n");

                            }
                            if (hour >= 16 && hour < 20)
                            {

                                say("Good Evening");
                                response.AppendText("Good Evening" + "\n");
                            }
                            if (hour >= 20 && hour <= 24)
                            {
                                say("Hello user");
                                response.AppendText("Hello user" + "\n");

                            }
                        rec.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    case "light on":

                        try
                        {
                            port.Open();
                            port.WriteLine("A");
                            port.Close();
                        }
                        catch
                        {

                            say("Arduino not connected");


                        }
                        break;
                    case "show me the news":
                        Process.Start("https://news.google.com/news/headlines?ned=us&hl=en&gl=US");
                        break;

                    case "what is the weather like":
                        say("The weather is " + weather.GetWeather("cond"));
                        response.AppendText("The weather is " + weather.GetWeather("cond") + "\n");
                        break;
                    case "what is the temperature":
                        say("The temperature is " + weather.GetWeather("temp") + "Degrees");
                        response.AppendText("The temperature is " + weather.GetWeather("temp") + "Degrees" + "\n");
                        break;
                    case "light off":
                        try
                        {
                            port.Open();
                            port.WriteLine("B");
                            port.Close();
                        }
                        catch
                        {                                                      
                                say("Arduino not connected");                                                                                                            
                        }
                        break;
                    case "shutdown":
                        Process.Start("shutdown", "/s /t 0");
                        break;
                    case "close browser":
                        AppShut.KillBrowsers();
                        break;
                    case "open excel":
                        try
                        {
                            Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.exe");
                        }
                        catch
                        {
                            try
                            {
                                Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office15\EXCEL.exe"); //opens the office 2013 one 
                            }
                            catch //incase non of them are installed
                            {
                                say("could not find microsoft excel");
                            }
                        }
                        break;
                    case "open powerpoint":

                        try
                        {
                            Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\POWERPNT.exe");
                        }
                        catch
                        {
                            try
                            {
                                Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office15\POWERPNT.exe"); //opens the office 2013 one 
                            }
                            catch //incase non of them are installed
                            {
                                say("could not find microsoft powerpoint");
                            }
                        }
                        break;
                    case "open word":

                        try
                        {
                            Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.exe");
                        }
                        catch
                        {
                            try
                            {
                                Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office15\WINWORD.exe"); //opens the office 2013 one 
                            }
                            catch //incase non of them are installed
                            {
                                say("could not find microsoft word");
                            }
                        }
                        break;
                    case "close excel":
                        try
                        {
                            AppShut.KillOffice("EXCEL");
                        }
                        catch
                        {
                            try
                            {

                                say("excel is not running");

                            }
                            catch
                            {

                            }
                        }
                        break;
                    case "close powerpoint":
                        try
                        {
                            AppShut.KillOffice("POWERPNT");
                        }
                        catch
                        {
                            try
                            {

                                say("Powerpoint is not running");

                            }
                            catch
                            {

                            }
                        }
                        break;
                    case "close word":
                        try
                        {
                            AppShut.KillOffice("WINWORD");
                        }
                        catch
                        {
                            try
                            {

                                say("Word is not running");

                            }
                            catch
                            {

                            }
                        }
                        break;
                    case "what time is it":
                            say(DateTime.Now.ToString("h:mm tt"));
                            response.AppendText(DateTime.Now.ToString("h:mm tt") + "\n");
                        break;
                    case "minimize":
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case "unminimize":
                        this.WindowState = FormWindowState.Normal;
                        break;
                    case "open google":
                        Process.Start("www.google.com");
                        break;
                    case "what date is it":
                            say(DateTime.Now.ToString("M/d/yyyy"));
                            response.AppendText(DateTime.Now.ToString("M/d/yyyy") + "\n");
                        break;
                    case "read pdf":
                        PDF_BUTTON.PerformClick();
                        break;
                    case "how are you":
                        int res = rnd.Next(1, 4);
                        if (res == 1)
                        {
                            say("Great");
                            response.AppendText("Great" + "\n");
                        }
                        if (res == 3)
                        {
                            say("Fine");
                            response.AppendText("Fine" + "\n");
                        }
                        if (res == 2)
                        {
                            say("Happy");
                            response.AppendText("Happy" + "\n");
                        }
                        if (res == 4)
                        {
                            say("Bored");
                            response.AppendText("Bored" + "\n");
                        }
                        break;
                }
            }
            maintxtbox.Text = "";
        } // important
        private void button6_Click(object sender, EventArgs e) //shows all the commands
        {
            MessageBox.Show("Voice commands\nConversation:Hello, How are you,What is the temperature,What is the weather like What time is it, What date is it\nControl: Minimize, Unminimize, bye\nApps:Open google,Close browser,Open excel/powerpoint/word,Close excel/word/powerpoint\nMisc.:Enter/Exit search mode,Play classic/rap/pop/rock/jazz music LIGHT ON, LIGHT OFF,Read pdf\n\nProgrammed and designed by David D. J. 9-I  ");
        }             
        private void timer3_Tick(object sender, EventArgs e)
        {
            this.ActiveControl = maintxtbox;
            timer3.Stop(); //stops the timer
            HtmlDocument doc = webBrowser1.Document;
            HtmlElementCollection elems = doc.GetElementsByTagName("TITLE");
            String title = String.Empty;
            if (elems.Count > 0)
            {
                HtmlElement elem = elems[0];
                title = elem.InnerText;
            }
            label1.Text = "Playing: " + title;
            next.Visible = true;
            last.Visible = true;
            pause.Visible = true;
            timer1.Start();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                HtmlDocument doc = webBrowser1.Document;
                HtmlElementCollection elems = doc.GetElementsByTagName("TITLE");
                String title = String.Empty;
                if (elems.Count > 0)
                {
                    HtmlElement elem = elems[0];
                    title = elem.InnerText;
                }
                label1.Text = "Playing: " + title;
            }
            catch
            {
                
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (last_location==sfilename)
            {
                
                SendKeys.Send("^(h)");

            }
           
            timer2.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (switch1 == false)
            {
                synth.Pause();
                Pausepdfbtn.Text = "Resume";
                switch1 = true;
            }
            else
            {
                synth.Resume();
                Pausepdfbtn.Text = "Pause";
                switch1 = false;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)

        {
            
            webBrowser1.Select();
            webBrowser1.Focus();
            
            SendKeys.Send(" ");
            if (x == 'O')
            {
                rec.RecognizeAsyncStop();
                last.Visible = true;
                next.Visible = true;
                pause.Text = "Pause Music";
                x = 'I';
                timer3.Start();
                maintxtbox.Enabled = false;
                PDF_BUTTON.Enabled = false;
                
            }
            else
            {
                rec.RecognizeAsync(RecognizeMode.Multiple);
                x = 'O';
                last.Visible = false;
                next.Visible = false;
                pause.Text = "Resume Music";               
                maintxtbox.Enabled = true;
                PDF_BUTTON.Enabled = true;
                timer1.Stop();
                label1.Text = "";
            }

            mode = '1';

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Select();
            webBrowser1.Focus();
            timer3.Start();

            SendKeys.Send("+P");

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Select();
            webBrowser1.Focus();
            timer3.Start();

            SendKeys.Send("+N");

        }
        private void Bot_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void button1_Click_3(object sender, EventArgs e)
        {
            try
            {
                if (pdf1 == '2')
                {

                    robotpicture2.BackgroundImage = img4;
                    robotpicture3.BackgroundImage = img5;
                    robotpicture4.BackgroundImage = img6;
                    response.Visible = true;
                    yourcommands.Visible = true;
                    synth.SpeakAsyncCancelAll();
                    pause.Enabled = true;

                    maintxtbox.Enabled = true;
                    pdf1 = '1';
                    pdf = "";
                    mode = '1';
                    last_location = pdf_location;
                    Pausepdfbtn.Enabled = false;
                    rec.RecognizeAsync(RecognizeMode.Multiple);
                }
                else
                {
                    axAcroPDF1.Visible = true;
                    rec.RecognizeAsyncStop();
                    rec2.RecognizeAsyncStop();
                    OpenFileDialog choofdlog = new OpenFileDialog();
                    choofdlog.Filter = "pdf files only (*.pdf*)|*.pdf*";
                    choofdlog.FilterIndex = 1;
                    pause.Enabled = false;
                    maintxtbox.Enabled = false;

                    if (choofdlog.ShowDialog() == DialogResult.OK)
                    {
                        sfilename = choofdlog.FileName;


                    }
                    StringBuilder text = new StringBuilder();
                    using (PdfReader reader = new PdfReader(sfilename))
                    {
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                    }
                    axAcroPDF1.setShowToolbar(false);
                   axAcroPDF1.setLayoutMode("SinglePage");
                
                    axAcroPDF1.src = sfilename;
                    pdf_location = sfilename;
                    response.Visible = false;
                    yourcommands.Visible = false;
                    pdf = text.ToString();
                    Pausepdfbtn.Enabled = true;

                    timer2.Start();
                    
                    
                   
                    synth.SpeakAsync(pdf);
                    pdf1 = '2';
                    
                 
                }
            }
            catch
            {

                robotpicture2.BackgroundImage = img4;
                robotpicture3.BackgroundImage = img5;
                robotpicture4.BackgroundImage = img6;
                response.Visible = true;
                yourcommands.Visible = true;
                synth.SpeakAsyncCancelAll();
                maintxtbox.Enabled = true;
                PDF_BUTTON.Enabled = true;
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            label1.Text = "";
        }
    }
}

