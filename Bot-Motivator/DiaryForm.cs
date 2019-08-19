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
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;

namespace Bot_Motivator
{
    public partial class DiaryForm : Form
    {
        static Label l;
        MainMenu ff;
        public DiaryForm()
        {
            InitializeComponent();
        }

        public DiaryForm(MainMenu ff1)
        {
            InitializeComponent();
            ff = ff1;
        }
        private void DiaryForm_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo c1 = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(c1);
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            Choices gol = new Choices();
            gol.Add(new string[] { "запиши в расписание", "можно записывать", "измени расписание", "я закончил" });
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(gol);
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter wr = new StreamWriter("timetable.txt", true);
            wr.WriteLine("Дата: " + maskedTextBox1.Text);
            wr.WriteLine("Время: " + maskedTextBox2.Text);
            foreach(string s in richTextBox1.Lines)
            {
                wr.WriteLine(s);
            }
            wr.WriteLine("%");
            wr.Close();
            richTextBox1.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }
        public void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.60)
            {
                if (e.Result.Text == "запиши в расписание" || e.Result.Text == "можно записывать" || e.Result.Text == "измени расписание ")
                {
                    StreamWriter wr = new StreamWriter("timetable.txt", true);
                    string d1 = maskedTextBox1.Text;
                    string date = "";
                    for (int i=0; i<d1.Length; i++)
                    {
                        if(d1[i]!='0' && d1[i] != '.')
                        {
                            date += d1[i]; 
                        }
                    }
                    wr.WriteLine(date);
                    wr.WriteLine("Время: " + maskedTextBox2.Text);
                    foreach (string s in richTextBox1.Lines)
                    {
                        wr.WriteLine(s);
                    }
                    wr.WriteLine("%");
                    wr.Close();
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak("Записано.");
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                    richTextBox1.Clear();
                }
                if (e.Result.Text=="я закончил")
                {
                    MainMenu m = new MainMenu(this);
                    m.Show();
                    this.Hide();
                }
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu(this);
            m.Show();
            this.Hide();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }
    }
}
