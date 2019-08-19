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
using System.Speech.Synthesis;

namespace Bot_Motivator
{
    public partial class TalkingBad : Form
    {
        public List<string> qw { get; set; }
        public List<string> motiv { get; set; }
        public int numMot { get; set; }
        public int AnsC { get; set; }
        public int interv { get; set; }
        public string mot { get; set; }
        public string[] beginDiag;
        Random r = new Random();
        public TalkingBad()
        {
            qw = new List<string>();
            InitializeComponent();
            motiv = new List<string>();
        }
        MainMenu m;
        public TalkingBad(MainMenu m1)
        {
            qw = new List<string>();
            InitializeComponent();
            m = m1;
            motiv = new List<string>();
        }

        private void TalkingBad_Load(object sender, EventArgs e)
        {
            beginDiag = new string [] {"Здравствуйте. Что случилось?", "Приветствую. В чем дело?", "Вижу, вы хотите о чем-то рассказать. Я слушаю.", "Хотите чем-то поделиться? Я готов.", "Я здесь. Рассказывайте." };
            Random r = new Random();
            int phrase_Numb = r.Next(0,beginDiag.Length);
            label1.Text = beginDiag[phrase_Numb];
            interv = 0;
            StreamReader rea = new StreamReader("like.txt", Encoding.Default);
            SpeechSynthesizer synth3 = new SpeechSynthesizer();
            synth3.SetOutputToDefaultAudioDevice(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth3 = new SpeechSynthesizer();
            StreamReader read = new StreamReader("like.txt", Encoding.Default);
            while (!read.EndOfStream)
            {
                motiv.Add(read.ReadLine());
            }  
            Random ran = new Random();
            int motii = ran.Next(0,motiv.Count);
            synth3.SetOutputToDefaultAudioDevice();
            StreamReader re = new StreamReader("helloPsychologist.txt", Encoding.Default);
            List<string> hello = new List<string>();
            while (!re.EndOfStream)
            {
                hello.Add(re.ReadLine());
            }
            Random ry = new Random();
            re.Close();
            label1.Text = hello[r.Next(0,qw.Count)];
            synth3.Speak(label1.Text);
            synth3.Speak(motiv[motii]);
            label1.Text = "Быть может, пришло время заняться любимым делом?";
            synth3.Speak(label1.Text);
            StreamReader rep = new StreamReader("psychologist.txt", Encoding.Default);
            List<string> ps = new List<string>();
            while (!rep.EndOfStream)
            {
                ps.Add(rep.ReadLine());
            }
            rep.Close();
            label1.Text = ps[r.Next(0, ps.Count)];
            synth3.Speak(label1.Text);
            richTextBox1.Clear();
            label1.Text = "Я уверен, у вас все получится.";
            synth3.Speak(label1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu(this);
            m.Show();
            this.Hide();
        }

        private void TalkingBad_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            interv++;
            if (interv==1)
            {
                SpeechSynthesizer synth3 = new SpeechSynthesizer();
                synth3.SetOutputToDefaultAudioDevice();
                synth3.Speak(label1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
