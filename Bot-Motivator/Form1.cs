using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;



namespace Bot_Motivator
{
    public partial class MainMenu : Form
    {
        public int eve { get; set; }
        string timedate { get; set; }
        public string [] day;
        public bool chisl;
        public string[] month;
        DiaryForm f;
        HelloForm HF;
        Talking t;
        public List<string> tt { get; set; }

        public MainMenu()
        {

            InitializeComponent();
            tt = new List<string>();
        }

        TalkingBad tb;
        public MainMenu(TalkingBad tb1)
        {
            InitializeComponent();
            tb = tb1;
        }

        public MainMenu(DiaryForm f1)
        {
            InitializeComponent();
            tt = new List<string>();
            f = f1;
        }

        public MainMenu(HelloForm HF1)
        {
            InitializeComponent();
            tt = new List<string>();
            HF = HF1;
        }
        public MainMenu(Talking t1)
        {
            InitializeComponent();
            tt = new List<string>();
            t = t1;
        }
        static Label l;
        public  void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int timet = 0;
            if (e.Result.Confidence > 0.50)
            {
                if (e.Result.Text == "мне плохо" || e.Result.Text == "все надоело" || e.Result.Text == "все плохо" || e.Result.Text == "нужен совет" || e.Result.Text == "хочу высказаться")
                {
                    TalkingBad b = new TalkingBad(this);
                    b.Show();
                    this.Hide();
                }
                else { 
                switch (e.Result.Text)
                {

                    case "я хочу поговорить":
                        SpeechSynthesizer synth = new SpeechSynthesizer();
                        synth.SetOutputToDefaultAudioDevice();
                            synth.Speak("Ха-ха! А я не хочу!");
                            synth.Speak("Сейчас вроде презентация. Думаю, самое время сломаться.");
                            synth.Speak("Ладно, так и быть. Давайте поговорим!");
                        Talking t = new Talking(this);
                        t.Show();
                        this.Hide();
                        break;

                    case "Бот, запиши в расписание":
                        SpeechSynthesizer synth1 = new SpeechSynthesizer();
                        synth1.SetOutputToDefaultAudioDevice();
                        synth1.Speak("Открываю расписание");
                        DiaryForm df = new DiaryForm(this);
                        df.Show();
                        this.Hide();
                        break;

                    case "Бот, список дел":
                        string months1 = "";
                        string days1 = "";
                        l.Text = e.Result.Text;
                        SpeechSynthesizer synth4 = new SpeechSynthesizer();
                        synth4.Speak("На какой день и месяц?");
                        break;

                    case "тупой бот":
                        SpeechSynthesizer synth3 = new SpeechSynthesizer(); 
                        synth3.SetOutputToDefaultAudioDevice();
                        synth3.Speak("Я обиделся");
                        Application.Exit();
                        break;

                        case "Бот, ты мне нужен.":
                            SpeechSynthesizer synth10= new SpeechSynthesizer();  
                            synth10.SetOutputToDefaultAudioDevice();
                            synth10.Speak("А ты мне нет!");
                            synth10.Speak("");
                            synth10.Speak("Ладно, так и быть, я покажусь.");
                            this.Show();
                            notifyIcon1.Visible = false;
                            WindowState = FormWindowState.Normal;
                            break;

                        case "Бот, можешь отдохнуть.":
                            SpeechSynthesizer synth8 = new SpeechSynthesizer(); 
                            synth8.SetOutputToDefaultAudioDevice();
                            synth8.Speak("Наконец-то я могу отдохнуть! Так, ребята, сворачиваемся в трей.");
                            WindowState = FormWindowState.Minimized;
                            if (WindowState == FormWindowState.Minimized)
                            {
                                this.Hide();
                                notifyIcon1.Visible = true;
                                notifyIcon1.ShowBalloonTip(1000);
                            }
                            else if (FormWindowState.Normal == this.WindowState)
                            {
                                notifyIcon1.Visible = false;
                            }
                            this.Hide();
                                notifyIcon1.Visible = true;
                                notifyIcon1.ShowBalloonTip(1000);

                            if (FormWindowState.Normal == this.WindowState)
                            {
                                notifyIcon1.Visible = false;
                            }
                            break;

                        default:
                        chisl = true;
                        l.Text = e.Result.Text;
                        timedate = l.Text;
                        string[] mas = timedate.Split();
                    
                        if (mas.Length == 3)
                        {
                            mas[0] += " " + mas[1];
                            mas[1] = mas[2];
                            Array.Resize(ref mas, mas.Length - 1);
                        }
                      
                        string months = "";
                        string days = "";
                        for (int i = 0; i < day.Length; i++)
                            for (int j = 0; j < mas.Length; j++)
                            {
                                if (day[i] == mas[j])
                                {

                                    days = Convert.ToString(i + 1);
                                    break;
                                }
                            }

                        for (int i = 0; i < month.Length; i++)
                            for (int j = 0; j < mas.Length; j++)
                            {
                                if (month[i] == mas[j])
                                {
                                    months = Convert.ToString(i + 1);
                                    break;
                                }
                            }

                        timedate = "";
                        timedate += days + ",";
                        timedate += months;
                        if (timedate.Length == 3)
                        {
                            timedate = timedate.Insert(0, "0");
                
                            timedate = timedate.Insert(3, "0");
                        }

                        bool flag = false;
                        int h = 0;
                        string buf = "";
                  
                        StreamReader read = new StreamReader("timetable.txt", Encoding.Default);
                        while (!read.EndOfStream)
                        {
                            if (flag == true)
                            {
                                buf = read.ReadLine();
                                if (buf != "%")
                                {
                                    tt.Add(buf);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                buf = read.ReadLine();
                                if (buf == timedate)
                                {
                                    flag = true;
                                }
                            }
                        }
                        foreach (string l in tt)
                        {
                    
                        }
                        read.Close();
                        SpeechSynthesizer synth5 = new SpeechSynthesizer();
                        synth5.SetOutputToDefaultAudioDevice();
                        string said = "";
                        foreach (string s in tt)
                        {
                            said += s + " ";
                        }
                            if (said == "")
                            {
                                synth5.Speak("У вас на этот день ничего не запланировано. Вы полностью свободны. Пока что.");
                            }
                            else
                            {
                                synth5.Speak("Диктую расписание на " + l.Text);
                                synth5.Speak(said);
                                said = "";
                            }
                        break;
                }
            }    
            }
            else {
                if (chisl==true)
                {
                    l.Text = e.Result.Text;
                    SpeechSynthesizer synth2 = new SpeechSynthesizer();
                    // Configure the audio output.   
                    synth2.SetOutputToDefaultAudioDevice();
                    // Speak a string.
                    synth2.Speak("Боюсь, я не совсем вас понял.");
                    chisl = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chisl = false;
            notifyIcon1.BalloonTipTitle = "Бот-мотиватор";
            notifyIcon1.BalloonTipText = "Наконец-то я могу отдохнуть! Так, ребята, сворачиваемся в трей.";
            notifyIcon1.Text = "Бот-мотиватор";
            day = new string[] { "первое", "второе", "третье", "четвертое", "пятое", "шестое", "седьмое", "восьмое", "девятое", "десятое", "одиннадцатое", "двенадцатое", "тринадцатое", "четырнадцатое", "пятнадцатое", "шестнадцатое", "семнадцатое", "восемнадцатое", "девятнцадцатое", "двадцатое", "двадцать первое", "двадцать второе", "двадцать третье", "двадцать четвертое", "двадцать пятое", "двадцать шестое", "двадцать седьмое", "двадцать восьмое", "двадцать девятое", "тридцатое", "тридцать первое" };
            month = new string[] { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(0,0, button1.Width, button1.Height); 
            Region myRegion = new Region(myPath);
            button1.Region = myRegion;
            System.Drawing.Drawing2D.GraphicsPath myPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            myPath2.AddEllipse(0, 0, button2.Width, button2.Height);
            Region myRegion2 = new Region(myPath2);
            button2.Region = myRegion2;
            System.Drawing.Drawing2D.GraphicsPath myPath3 = new System.Drawing.Drawing2D.GraphicsPath();
            myPath3.AddEllipse(0, 0, button3.Width, button3.Height);
            Region myRegion3 = new Region(myPath3);
            button3.Region = myRegion3;
            // spbot.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Talking t = new Talking(this);
            t.Show();
            this.Hide();
        }

        private void monthCalendar1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TalkingBad b = new TalkingBad(this);
            b.Show();
            this.Hide();
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            l = label1;
            System.Globalization.CultureInfo c1 = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(c1);
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            Choices gol = new Choices();
            gol.Add(new string[] { "Бот, ты мне нужен.", "Бот, можешь отдохнуть.","Я знаю про секретку.", "мне плохо", "все надоело", "все плохо", "нужен совет", "хочу высказаться","я хочу поговорить", "Пантофля", "Пушин Кэт", "Мыкыта", "Бот, список дел", "Бот, запиши в расписание", "тупой бот", "Бот, cкажи мне список дел", "первое мая", "второе мая", "третье мая", "четвертое мая", "пятое мая", "шестое мая", "седьмое мая", "восьмое мая", "девятое мая", "десятое мая", "одиннадцатое мая", "двенадцатое мая", "тринадцатое мая", "четырнадцатое мая", "пятнадцатое мая", "шестнадцатое мая", "семнадцатое мая", "восемнадцатое мая", "девятнцадцатое мая", "двадцатое мая", "двадцать первое мая", "двадцать второе мая", "двадцать третье мая", "двадцать четвертое мая", "двадцать пятое мая", "двадцать шестое мая", "двадцать седьмое мая", "двадцать восьмое мая", "двадцать девятое мая", "тридцатое мая", "тридцать первое мая" +
                "первое января", "второе января", "третье января", "четвертое января", "пятое января", "шестое января", "седьмое января", "восьмое января", "девятое января", "десятое января", "одиннадцатое января", "двенадцатое января", "тринадцатое января", "четырнадцатое января", "пятнадцатое января", "шестнадцатое января", "семнадцатое января", "восемнадцатое января", "девятнцадцатое января", "двадцатое января", "двадцать первое января", "двадцать второе января", "двадцать третье января", "двадцать четвертое января", "двадцать пятое января", "двадцать шестое января", "двадцать седьмое января", "двадцать восьмое января", "двадцать девятое января", "тридцатое января", "тридцать первое января" +
                "первое февраля", "второе февраля", "третье февраля", "четвертое февраля", "пятое февраля", "шестое февраля", "седьмое февраля", "восьмое февраля", "девятое февраля", "десятое февраля", "одиннадцатое февраля", "двенадцатое февраля", "тринадцатое февраля", "четырнадцатое февраля", "пятнадцатое февраля", "шестнадцатое февраля", "семнадцатое февраля", "восемнадцатое февраля", "девятнцадцатое февраля", "двадцатое февраля", "двадцать первое февраля", "двадцать второе февраля", "двадцать третье февраля", "двадцать четвертое февраля", "двадцать пятое февраля", "двадцать шестое февраля", "двадцать седьмое февраля", "двадцать восьмое февраля", "двадцать девятое февраля", "тридцатое февраля", "тридцать первое февраля" +
                "первое марта", "второе марта", "третье марта", "четвертое марта", "пятое марта", "шестое марта", "седьмое марта", "восьмое марта", "девятое марта", "десятое марта", "одиннадцатое марта", "двенадцатое марта", "тринадцатое марта", "четырнадцатое марта", "пятнадцатое марта", "шестнадцатое марта", "семнадцатое марта", "восемнадцатое марта", "девятнцадцатое марта", "двадцатое марта", "двадцать первое марта", "двадцать второе марта", "двадцать третье марта", "двадцать четвертое марта", "двадцать пятое марта", "двадцать шестое марта", "двадцать седьмое марта", "двадцать восьмое марта", "двадцать девятое марта", "тридцатое марта", "тридцать первое марта" +
                "первое апреля", "второе апреля", "третье апреля", "четвертое апреля", "пятое апреля", "шестое апреля", "седьмое апреля", "восьмое апреля", "девятое апреля", "десятое апреля", "одиннадцатое апреля", "двенадцатое апреля", "тринадцатое апреля", "четырнадцатое апреля", "пятнадцатое апреля", "шестнадцатое апреля", "семнадцатое апреля", "восемнадцатое апреля", "девятнцадцатое апреля", "двадцатое апреля", "двадцать первое апреля", "двадцать второе апреля", "двадцать третье апреля", "двадцать четвертое апреля", "двадцать пятое апреля", "двадцать шестое апреля", "двадцать седьмое апреля", "двадцать восьмое апреля", "двадцать девятое апреля", "тридцатое апреля", "тридцать первое апреля" +
                "первое июня", "второе июня", "третье июня", "четвертое июня", "пятое июня", "шестое июня", "седьмое июня", "восьмое июня", "девятое июня", "десятое июня", "одиннадцатое июня", "двенадцатое июня", "тринадцатое июня", "четырнадцатое июня", "пятнадцатое июня", "шестнадцатое июня", "семнадцатое июня", "восемнадцатое июня", "девятнцадцатое июня", "двадцатое июня", "двадцать первое июня", "двадцать второе июня", "двадцать третье июня", "двадцать четвертое июня", "двадцать пятое июня", "двадцать шестое июня", "двадцать седьмое июня", "двадцать восьмое июня", "двадцать девятое июня", "тридцатое июня", "тридцать первое июня" +
                "первое июля", "второе июля", "третье июля", "четвертое июля", "пятое июля", "шестое июля", "седьмое июля", "восьмое июля", "девятое июля", "десятое июля", "одиннадцатое июля", "двенадцатое июля", "тринадцатое июля", "четырнадцатое июля", "пятнадцатое июля", "шестнадцатое июля", "семнадцатое июля", "восемнадцатое июля", "девятнцадцатое июля", "двадцатое июля", "двадцать первое июля", "двадцать второе июля", "двадцать третье июля", "двадцать четвертое июля", "двадцать пятое июля", "двадцать шестое июля", "двадцать седьмое июля", "двадцать восьмое июля", "двадцать девятое июля", "тридцатое июля", "тридцать первое июля" +
                "первое августа", "второе августа", "третье августа", "четвертое августа", "пятое августа", "шестое августа", "седьмое августа", "восьмое августа", "девятое августа", "десятое августа", "одиннадцатое августа", "двенадцатое августа", "тринадцатое августа", "четырнадцатое августа", "пятнадцатое августа", "шестнадцатое августа", "семнадцатое августа", "восемнадцатое августа", "девятнцадцатое августа", "двадцатое августа", "двадцать первое августа", "двадцать второе августа", "двадцать третье августа", "двадцать четвертое августа", "двадцать пятое августа", "двадцать шестое августа", "двадцать седьмое августа", "двадцать восьмое августа", "двадцать девятое августа", "тридцатое августа", "тридцать первое августа" +
                "первое сентября", "второе сентября", "третье сентября", "четвертое сентября", "пятое сентября", "шестое сентября", "седьмое сентября", "восьмое сентября", "девятое сентября", "десятое сентября", "одиннадцатое сентября", "двенадцатое сентября", "тринадцатое сентября", "четырнадцатое сентября", "пятнадцатое сентября", "шестнадцатое сентября", "семнадцатое сентября", "восемнадцатое сентября", "девятнцадцатое сентября", "двадцатое сентября", "двадцать первое сентября", "двадцать второе сентября", "двадцать третье сентября", "двадцать четвертое сентября", "двадцать пятое сентября", "двадцать шестое сентября", "двадцать седьмое сентября", "двадцать восьмое сентября", "двадцать девятое сентября", "тридцатое сентября", "тридцать первое сентября" +
                "первое октября", "второе октября", "третье октября", "четвертое октября", "пятое октября", "шестое октября", "седьмое октября", "восьмое октября", "девятое октября", "десятое октября", "одиннадцатое октября", "двенадцатое октября", "тринадцатое октября", "четырнадцатое октября", "пятнадцатое октября", "шестнадцатое октября", "семнадцатое октября", "восемнадцатое октября", "девятнцадцатое октября", "двадцатое октября", "двадцать первое октября", "двадцать второе октября", "двадцать третье октября", "двадцать четвертое октября", "двадцать пятое октября", "двадцать шестое октября", "двадцать седьмое октября", "двадцать восьмое октября", "двадцать девятое октября", "тридцатое октября", "тридцать первое октября" +
                "первое ноября", "второе ноября", "третье ноября", "четвертое ноября", "пятое ноября", "шестое ноября", "седьмое ноября", "восьмое ноября", "девятое ноября", "десятое ноября", "одиннадцатое ноября", "двенадцатое ноября", "тринадцатое ноября", "четырнадцатое ноября", "пятнадцатое ноября", "шестнадцатое ноября", "семнадцатое ноября", "восемнадцатое ноября", "девятнцадцатое ноября", "двадцатое ноября", "двадцать первое ноября", "двадцать второе ноября", "двадцать третье ноября", "двадцать четвертое ноября", "двадцать пятое ноября", "двадцать шестое ноября", "двадцать седьмое ноября", "двадцать восьмое ноября", "двадцать девятое ноября", "тридцатое ноября", "тридцать первое ноября" +
                "первое декабря", "второе декабря", "третье декабря", "четвертое декабря", "пятое декабря", "шестое декабря", "седьмое декабря", "восьмое декабря", "девятое декабря", "десятое декабря", "одиннадцатое декабря", "двенадцатое декабря", "тринадцатое декабря", "четырнадцатое декабря", "пятнадцатое декабря", "шестнадцатое декабря", "семнадцатое декабря", "восемнадцатое декабря", "девятнцадцатое декабря", "двадцатое декабря", "двадцать первое декабря", "двадцать второе декабря", "двадцать третье декабря", "двадцать четвертое декабря", "двадцать пятое декабря", "двадцать шестое декабря", "двадцать седьмое декабря", "двадцать восьмое декабря", "двадцать девятое декабря", "тридцатое декабря", "тридцать первое декабря"
                });
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(gol);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth1 = new SpeechSynthesizer();
            // Configure the audio output.   
            synth1.SetOutputToDefaultAudioDevice();
            // Speak a string.
            synth1.Speak("Открываю расписание");
            DiaryForm df = new DiaryForm(this);
            df.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);

            }
            else if(FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
