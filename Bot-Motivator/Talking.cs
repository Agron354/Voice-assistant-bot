using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;

namespace Bot_Motivator
{
    public partial class Talking : Form
    {
        public bool dywt { get; set; }
        public string ilike { get; set; }
        public string dontlike { get; set; }
        Random r = new Random();
        public List<string> qw { get; set; }
        public int nextqw { get; set; }
        public int AnsCount { get; set; }
        public string[] good;
        MainMenu lin;
        public string theme { get; set; }
        public int vib { get; set; }
        public int tmi { get; set; }
        public Talking()
        {
            InitializeComponent();
            qw = new List<string>();
        }

        public Talking(MainMenu lin1)
        {
            InitializeComponent();
            lin = lin1;
            qw = new List<string>();
        }

        static Label l;
        public void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.60)
            {
                l.Text = e.Result.Text;
                if (e.Result.Text == "поговорим о жизни")
                {
                    dywt = true;
                    StreamReader read = new StreamReader("life.txt", Encoding.Default);
                    while (!read.EndOfStream)
                    {
                        string buf = read.ReadLine();
                        qw.Add(buf);
                    }
                    nextqw = r.Next(0, qw.Count);
                    string qwest = qw[nextqw];
                    string correctqw = "";
                    for (int u=0; u<qwest.Length; u++)
                    {
                        if (qwest[u]!='1'&& qwest[u] != '2' && qwest[u] != '3' && qwest[u] != '4' && qwest[u] != '5' && qwest[u] != '6' && qwest[u] != '7' && qwest[u] != '8' && qwest[u] != '9' && qwest[u] != '0' && qwest[u] != '.')
                        {
                            correctqw += qwest[u];
                        }
                    }
                    label2.Text = correctqw;
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(label2.Text);
                    read.Close();
                }
                if (e.Result.Text == "поговорим о еде")
                {
                    dywt = true;
                    StreamReader read = new StreamReader("food.txt", Encoding.Default);
                    while (!read.EndOfStream)
                    {
                        string buf = read.ReadLine();
                        qw.Add(buf);
                    }
                    nextqw = r.Next(0, qw.Count);
                    string qwest = qw[nextqw];
                    string correctqw = "";
                    for (int u = 0; u < qwest.Length; u++)
                    {
                        if (qwest[u] != '1' && qwest[u] != '2' && qwest[u] != '3' && qwest[u] != '4' && qwest[u] != '5' && qwest[u] != '6' && qwest[u] != '7' && qwest[u] != '8' && qwest[u] != '9' && qwest[u] != '0' && qwest[u] != '.')
                        {
                            correctqw += qwest[u];
                        }
                    }

                    label2.Text = correctqw;
                    SpeechSynthesizer synth = new SpeechSynthesizer();   
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(label2.Text);
                    read.Close();
                 
              
                }
                if (e.Result.Text == "Бот, что ты умеешь?")
                {
                    label2.Text = "Пока умею распознавать человеческую речь, говорить о еде, кино, хобби, жизни, играх, вести ваше личное расписание, говорить и читать, а также давать советы.";
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(label2.Text);
                }
            }
            else
            {
                StreamWriter w = new StreamWriter("test.txt", true);
                w.WriteLine(AnsCount + ". " + e.Result.Text);
                w.WriteLine("%");
                w.Close();
            }
        }

        private void Talking_Load(object sender, EventArgs e)
        {
            good = new string[] { "нравится", "люблю", "приятно", "обожаю", "радует", "восхищает", "восторге", "тащусь", "штырит", "плющит", "экстазе" };
            tmi = 0;
            timer2.Start();
            StreamReader r = new StreamReader("ansCount.txt");
            AnsCount = Convert.ToInt32(r.ReadLine());
            label2.Width = this.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (richTextBox1.Text)
            {
                case "поговорим о жизни":
                    theme = "жизнь";
                        dywt = true;
                        StreamReader read = new StreamReader("life.txt", Encoding.Default);
                        while (!read.EndOfStream)
                        {
                            string buf = read.ReadLine();
                            qw.Add(buf);
                        }
                        nextqw = r.Next(0, qw.Count);
                        string qwest = qw[nextqw];
                        string correctqw = "";
                        for (int u = 0; u < qwest.Length; u++)
                        {
                            if (qwest[u] != '1' && qwest[u] != '2' && qwest[u] != '3' && qwest[u] != '4' && qwest[u] != '5' && qwest[u] != '6' && qwest[u] != '7' && qwest[u] != '8' && qwest[u] != '9' && qwest[u] != '0' && qwest[u] != '.')
                            {
                                correctqw += qwest[u];
                            }
                        }
                        label2.Text = correctqw;
                        SpeechSynthesizer synth = new SpeechSynthesizer();
                        synth.SetOutputToDefaultAudioDevice();
                        synth.Speak(label2.Text);
                        read.Close();
                    break;

                case "поговорим об играх":
                    theme = "игры";
                    dywt = true;
                    StreamReader read5 = new StreamReader("games.txt", Encoding.Default);
                    while (!read5.EndOfStream)
                    {
                        string buf = read5.ReadLine();
                        qw.Add(buf);
                    }
                    nextqw = r.Next(0, qw.Count);
                    string qwest5 = qw[nextqw];
                    string correctqw5 = "";
                    for (int u = 0; u < qwest5.Length; u++)
                    {
                        if (qwest5[u] != '1' && qwest5[u] != '2' && qwest5[u] != '3' && qwest5[u] != '4' && qwest5[u] != '5' && qwest5[u] != '6' && qwest5[u] != '7' && qwest5[u] != '8' && qwest5[u] != '9' && qwest5[u] != '0' && qwest5[u] != '.')
                        {
                            correctqw5 += qwest5[u];
                        }
                    }
                    label2.Text = correctqw5;
                    SpeechSynthesizer synth5 = new SpeechSynthesizer();
                    synth5.SetOutputToDefaultAudioDevice();
                    synth5.Speak(label2.Text);
                    read5.Close();
                    break;

                case "поговорим о музыке":
                    theme = "музыка";
                    dywt = true;
                    StreamReader read6 = new StreamReader("music.txt", Encoding.Default);
                    while (!read6.EndOfStream)
                    {
                        string buf = read6.ReadLine();
                        qw.Add(buf);
                    }
                    nextqw = r.Next(0, qw.Count);
                    string qwest6 = qw[nextqw];
                    string correctqw6 = "";
                    for (int u = 0; u < qwest6.Length; u++)
                    {
                        if (qwest6[u] != '1' && qwest6[u] != '2' && qwest6[u] != '3' && qwest6[u] != '4' && qwest6[u] != '5' && qwest6[u] != '6' && qwest6[u] != '7' && qwest6[u] != '8' && qwest6[u] != '9' && qwest6[u] != '0' && qwest6[u] != '.')
                        {
                            correctqw6 += qwest6[u];
                        }
                    }
                    label2.Text = correctqw6; 
                    SpeechSynthesizer synth6 = new SpeechSynthesizer();
                    synth6.SetOutputToDefaultAudioDevice();
                    synth6.Speak(label2.Text);
                    read6.Close();
                    break;

                case "поговорим о хобби":
                    theme = "хобби";
                    dywt = true;
                    StreamReader read9 = new StreamReader("hobby.txt", Encoding.Default);
                    while (!read9.EndOfStream)
                    {
                        string buf = read9.ReadLine();
                        qw.Add(buf);
                    }
                    nextqw = r.Next(0, qw.Count);
                    string qwest9 = qw[nextqw];
                    string correctqw9 = "";
                    for (int u = 0; u < qwest9.Length; u++)
                    {
                        if (qwest9[u] != '1' && qwest9[u] != '2' && qwest9[u] != '3' && qwest9[u] != '4' && qwest9[u] != '5' && qwest9[u] != '6' && qwest9[u] != '7' && qwest9[u] != '8' && qwest9[u] != '9' && qwest9[u] != '0' && qwest9[u] != '.')
                        {
                            correctqw9 += qwest9[u];
                        }
                    }
                    label2.Text = correctqw9;
                    SpeechSynthesizer synth9 = new SpeechSynthesizer();
                    synth9.SetOutputToDefaultAudioDevice();
                    synth9.Speak(label2.Text);
                    read9.Close();
                    break;

                case "поговорим о еде":
                    theme = "еда";
                    dywt = true;
                    StreamReader read1 = new StreamReader("food.txt", Encoding.Default);
                    while (!read1.EndOfStream)
                    {
                        string buf = read1.ReadLine();
                        qw.Add(buf);
                    }
                    nextqw = r.Next(0, qw.Count);
                    string qwest2 = qw[nextqw];
                    string correctqw2 = "";
                    for (int u = 0; u < qwest2.Length; u++)
                    {
                        if (qwest2[u] != '1' && qwest2[u] != '2' && qwest2[u] != '3' && qwest2[u] != '4' && qwest2[u] != '5' && qwest2[u] != '6' && qwest2[u] != '7' && qwest2[u] != '8' && qwest2[u] != '9' && qwest2[u] != '0' && qwest2[u] != '.')
                        {
                            correctqw2 += qwest2[u];
                        }
                    }
                    label2.Text = correctqw2; 
                    SpeechSynthesizer synth2 = new SpeechSynthesizer();
                    synth2.SetOutputToDefaultAudioDevice();
                    synth2.Speak(label2.Text);
                    read1.Close();
                    break;

                case "поговорим о кино":
                    theme = "кино";
                    dywt = true;
                    StreamReader read13 = new StreamReader("films.txt", Encoding.Default);
                    while (!read13.EndOfStream)
                    {
                        string buf = read13.ReadLine();
                        qw.Add(buf);
                    }
                    nextqw = r.Next(0, qw.Count);
                    string qwest3 = qw[nextqw];
                    string correctqw3 = "";
                    for (int u = 0; u < qwest3.Length; u++)
                    {
                        if (qwest3[u] != '1' && qwest3[u] != '2' && qwest3[u] != '3' && qwest3[u] != '4' && qwest3[u] != '5' && qwest3[u] != '6' && qwest3[u] != '7' && qwest3[u] != '8' && qwest3[u] != '9' && qwest3[u] != '0' && qwest3[u] != '.')
                        {
                            correctqw3 += qwest3[u];
                        }
                    }
                    label2.Text = correctqw3; 
                    SpeechSynthesizer synth13 = new SpeechSynthesizer();
                    synth13.SetOutputToDefaultAudioDevice();
                    synth13.Speak(label2.Text);
                    read13.Close();
                    break;

                default: 
                    string[] words = { };
                    if (richTextBox1.Text != "")
                    {
                        StreamWriter wr = new StreamWriter("talking.txt", false);
                        foreach (string s in richTextBox1.Lines)
                        {
                            wr.WriteLine(s);
                        }
                        wr.WriteLine("%");
                        wr.Close();
                        int nespos = 0;
                        StreamReader re = new StreamReader("talking.txt", true);
                            string buf = "";
                            buf = re.ReadLine();
                            if (buf[buf.Length-1]!='.')
                            {
                            buf += ".";
                            }
                            re.Close();
                            bool trig = false;
                            words = buf.Split(new char[] { ' ', ',', ';', ':', '(', ')', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);

                        while (trig == false)
                        {
                            for (int i = 0; i < words.Length; i++)
                            {

                                string check = words[i];
                                for (int j = 0; j < check.Length; j++)
                                {
                                    if (check[j] == '.' || check[j] == '!' || check[j] == '?')
                                    {
                                        Array.Resize(ref words, words.Length + 1);
                                        words[words.Length - 1] = Convert.ToString(check[j]);
                                       
                                        check = check.Substring(0, check.Length - 1);
                                        words[i] = check;
                                   
                                        trig = true;
                                        break;
                                    }
                                }
                                if (trig == true)
                                {
                                    break;
                                }  
                            }
                        }
                            for (int i = 0; i < good.Length; i++)
                                for (int j = 0; j < words.Length; j++)
                                {
                                    if (words[j] == good[i])
                                    {
                                        nespos = j;
                                        break;
                                    }
                                }
                        ilike = "";
                        dontlike = "";
                        bool bad= false;
                        for (int i=0; i < nespos; i++)
                        {
                            if (words[i]=="не")
                            {
                                bad = true;
                                break;
                            }
                        }
                            if (bad == true)
                            {

                                for (int i = 0; i < words.Length; i++)
                                {

                                    if (words[i] != "." && words[i] != "!" && words[i] != "?")
                                    {
                                       
                                        dontlike += words[i]+" ";
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                StreamWriter w = new StreamWriter("dontlike.txt", true);
                                w.WriteLine(dontlike);
                                w.Close();
                            }
                            else
                            {
                                for (int i = nespos - 1; i < words.Length; i++)
                                {
                                    if (words[i] != "." && words[i] != "!" && words[i] != "?")
                                    {
                                        ilike += words[i] + " ";
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                StreamWriter w = new StreamWriter("like.txt", true);
                                w.WriteLine(ilike);
                                w.Close();
                            }
                        if (ilike!="" || dontlike != "")
                        {
                            qw.RemoveAt(nextqw);
                        }
                        if (qw.Count > 0)
                        {
                            nextqw = r.Next(0, qw.Count);
                            string qwest1 = qw[nextqw];
                            string correctqw1 = "";
                            for (int u = 0; u < qwest1.Length; u++)
                            {
                                if (qwest1[u] != '1' && qwest1[u] != '2' && qwest1[u] != '3' && qwest1[u] != '4' && qwest1[u] != '5' && qwest1[u] != '6' && qwest1[u] != '7' && qwest1[u] != '8' && qwest1[u] != '9' && qwest1[u] != '0' && qwest1[u] != '.')
                                {
                                    correctqw1 += qwest1[u];
                                }
                            }
                            label2.Text = correctqw1;
                            // Initialize a new instance of the SpeechSynthesizer.  
                            SpeechSynthesizer synth1 = new SpeechSynthesizer();
                            synth1.SetOutputToDefaultAudioDevice();
                            synth1.Speak(label2.Text);
                        }
                        else
                        {
                            SpeechSynthesizer synth1 = new SpeechSynthesizer();
                            synth1.SetOutputToDefaultAudioDevice();
                            synth1.Speak("Мне надоело говорить на эту тему. Давайте поговорим о чем-нибудь другом или закончим пока беседу.");
                            vib = r.Next(1, 4);
                            if (vib == 1)
                            {
                                label2.Text = "О чем поговорим?";
                                label2.Visible = true;
                                SpeechSynthesizer synth11 = new SpeechSynthesizer();  
                                synth11.SetOutputToDefaultAudioDevice();
                                synth11.Speak(label2.Text);
                            }
                            if (vib == 2)
                            {
                                label2.Text = "На какую тему будем общаться?";
                                label2.Visible = true;
                                SpeechSynthesizer synth11 = new SpeechSynthesizer();   
                                synth11.SetOutputToDefaultAudioDevice();
                                synth11.Speak(label2.Text);
                            }
                            if (vib == 3)
                            {
                                label2.Text = "Предлагайте тему для разговора!";
                                label2.Visible = true;
                                SpeechSynthesizer synth11 = new SpeechSynthesizer();
                                synth11.SetOutputToDefaultAudioDevice();
                                synth11.Speak(label2.Text);
                            }
                        }
                    }
                    break;
            }
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu(this);
            m.Show();
            this.Hide();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            label2.Left = this.Width / 2 - label2.Width / 2;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void Talking_Shown(object sender, EventArgs e)
        {
            l = label1;
            System.Globalization.CultureInfo c1 = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(c1);
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            Choices gol = new Choices();
            gol.Add(new string[] { "Бот, что ты умеешь?", "поговорим о жизни", "поговорим о кино", "поговорим о музыке", "поговорим о еде", "поговорим, как прошел день", "поговорим о хобби", "поговорим об играх"});
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(gol);
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tmi>=3)
            {
                vib = r.Next(1,4);
                if (vib == 1)
                {
                    label2.Text = "О чем поговорим?";
                    label2.Visible = true;
                    SpeechSynthesizer synth = new SpeechSynthesizer(); 
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(label2.Text);
                }
                if (vib == 2)
                {
                    label2.Text = "На какую тему будем общаться?";
                    label2.Visible = true;
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(label2.Text);
                }
                if (vib == 3)
                {
                    label2.Text = "Предлагайте тему для разговора!";
                    label2.Visible = true;
                    SpeechSynthesizer synth = new SpeechSynthesizer();   
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(label2.Text);
                }
                timer2.Stop();
            }
            else
            {
                tmi++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
