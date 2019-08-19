using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Bot_Motivator
{
    public partial class HelloForm : Form
    {
        public int A = 0;
        public int R = 0;
        public int G = 0;
        public int B = 0;
        public string time;

        Random r = new Random();

        public HelloForm()
        {
            InitializeComponent();
        }

        private void HelloForm_Load(object sender, EventArgs e)
        {
            label1.Width = this.Width;
            label2.Width = this.Width;
            label3.Width = this.Width;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (A >= 255 && R >= 255 && G >= 255 && B >= 255)
            {
                timer1.Stop();
                MainMenu portal = new MainMenu(this);
                portal.Show();
                this.Hide();

            }
            else
            {
                label1.ForeColor = Color.FromArgb(A, R, G, B);
                label2.ForeColor = Color.FromArgb(A, R, G, B);
                label3.ForeColor = Color.FromArgb(A, R, G, B);
                A += 7;
                R += 7;
                G += 7;
                B += 7;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label1.Left = this.Width / 2 - label1.Width / 2;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            label2.Left = this.Width / 2 - label2.Width / 2;
        }

        private void HelloForm_Shown(object sender, EventArgs e)
        {
            
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("Приветствую!");
            DateTime now = DateTime.Now;
            time = now.ToString("HH:MM");
            string bufHour = "";
            bufHour += time[0];
            bufHour += time[1];
            string morning = "4";
            string day = "12";
            string evening = "18";
            string night = "24";

            if (Convert.ToInt32(bufHour) > Convert.ToInt32(evening) && Convert.ToInt32(bufHour) < Convert.ToInt32(night) || Convert.ToInt32(bufHour) == Convert.ToInt32(evening))
            {
                int choice = r.Next(1, 7);
                switch (choice)
                {
                    case 1:
                        label1.Text = "Вечер - это время";
                        label2.Text = "в кругу родных";
                        label3.Text = "сериалов, пледа и депрессии...";
                        break;
                    case 2:
                        label1.Text = "О, чудесное время, когда ";
                        label2.Text = "можно расслабиться и сделать работу,";
                        label3.Text = "которую не успели закончить днем.";
                        break;
                    case 3:
                        label1.Text = "Эй, Брэйн, чем мы будем заниматься ";
                        label2.Text = "Тем жсегодня вечером?Тем же, чем и всегда,";
                        label3.Text = "Пинки, попробуем завоевать мир.";
                        break;
                    case 4:
                        label1.Text = "Если тебе никто не позвонил вечером,";
                        label2.Text = "всегда можно включить";
                        label3.Text = "любимого бота и нажаловаться.";
                        break;
                    case 5:
                        label1.Text = "Сегодня вечером я жду";
                        label2.Text = "чего - то доброго, светлого,";
                        label3.Text = "нефильтрованного.";
                        break;
                    case 6:
                        label1.Text = "Настоящее мужество — ";
                        label2.Text = "залезть после шести вечера в холодильник за кефиром";
                        label3.Text = "и взять не вино и кальмара, а КЕФИР!";
                        break;
                }
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                string say = label1.Text + " " + label2.Text + " "+ label3.Text;
                synth.Speak(say);
            }

            if (Convert.ToInt32(bufHour) > Convert.ToInt32(morning) && Convert.ToInt32(bufHour) < Convert.ToInt32(day) || Convert.ToInt32(bufHour) == Convert.ToInt32(morning))
            {
                int choice = r.Next(1, 7);
                bool trig = false;
                switch (choice)
                {
                    case 1:
                        label1.Text = "Какое ужасное утро!";
                        label2.Text = "Зато вы сегодня сияете";
                        label3.Text = "непревзойденной красотой!";
                        break;
                    case 2:
                        label1.Text = "Вставайте, господин!";
                        label2.Text = "Вас ждут великие свершения!";
                        trig = true;
                        break;
                    case 3:
                        label1.Text = "День начинается с чашкой крепкого";
                        label2.Text = "виски... ";
                        trig = true;
                        break;
                    case 4:
                        label1.Text = "Кто рано встает,";
                        label2.Text = "тому на работу с утра...";
                        trig = true;
                        break;
                    case 5:
                        label1.Text = "Утро! Самое время пить...";
                        label2.Text = "Нет, не кофе, а просто пить.";
                        trig = true;
                        break;
                    case 6:
                        label1.Text = "Доброго начала дня! Сегодня тот день,";
                        label2.Text = "когда вы приблизитесь";
                        label3.Text = "к исполнению своей мечты.";
                        break;
                    
                }
                label1.Visible = true;
                label2.Visible = true;
                string say = "";
                if (trig == true)
                {
                    label3.Visible = false;
                    say = label1.Text + " " + label2.Text;
                }
                else
                {
                    say = label1.Text + " " + label2.Text + " " + label3.Text;
                    label3.Visible = true;
                }
                synth.Speak(say);
            }

            if (Convert.ToInt32(bufHour) > Convert.ToInt32(day) && Convert.ToInt32(bufHour) < Convert.ToInt32(evening) || Convert.ToInt32(bufHour) == Convert.ToInt32(day))
            {
                int choice = r.Next(1, 7);
                switch (choice)
                {
                    case 1:
                        label1.Text = "День в самом разгаре, а я уже устал.";
                        label2.Text = "Если вы нет, то я восхищен!";
                        break;
                    case 2:
                        label1.Text = "Каждое сегодня - это новые возможности";
                        label2.Text = "для того, чтобы отложить все на завтра";
                        break;
                    case 3:
                        label1.Text = "Должно быть, вы устали за утро.";
                        label2.Text = "Даже если нет, найдите время для себя любимого.";
                        break;
                    case 4:
                        label1.Text = "Работа - это прекрасно. Успех вас ждет.";
                        label2.Text = "А еще я вру.";
                        break;
                    case 5:
                        label1.Text = "Сегодня вас ожидает крупная удача.";
                        label2.Text = "Я уверен, удачно будет отложить свою работу.";
                        break;
                    case 6:
                        label1.Text = "Вижу, вы работаете над счастьем";
                        label2.Text = "вашего начальника. Начальство одобряет! ";
                        break;
                }
                label1.Visible = true;
                label2.Visible = true;
                synth.Speak(label1.Text);
                synth.Speak(label2.Text);
            }
            
            if (Convert.ToInt32(bufHour) > Convert.ToInt32(night) && Convert.ToInt32(bufHour) < Convert.ToInt32(morning) || Convert.ToInt32(bufHour) == Convert.ToInt32(night))
            {
                int choice = r.Next(2, 8);
                switch (choice)
                {
                    case 1:
                        label1.Text = "Чтобы сэкономить время на утренний сон,";
                        label2.Text = "я советую вам поесть ночью";
                        break;
                    case 2:
                        label1.Text = "Ночь полна страхов. Но не переживайте.";
                        label2.Text = "Только утром вы почувствуете настоящий ужас.";
                        break;
                    case 3:
                        label1.Text = "Делу - время, потехе час,";
                        label2.Text = "интернету - ночь, сну - не сейчас!";
                        break;
                    case 4:
                        label1.Text = "Коль вредно кушать на ночь глядя,";
                        label2.Text = "закрой глаза и молча ешь!";
                        break;
                    case 5:
                        label1.Text = "Если ты на ночь глядя гонял чаи, ";
                        label2.Text = "то ночью в отместку они будут гонять тебя";
                        break;
                    case 6:
                        label1.Text = "Планы на ночь: 1. Прогнать кота, чтобы не мешал.";
                        label2.Text = "2. Переживать, что кот обиделся. 3. Взять кота назад";
                        break;

                }
                 label1.Visible = true;
                label2.Visible = true;
                synth.Speak(label1.Text);
                synth.Speak(label2.Text);
            }
            timer1.Start();
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            label1.Left = this.Width / 2 - label1.Width / 2;
        }

        private void label3_TextChanged_1(object sender, EventArgs e)
        {
            label3.Left = this.Width / 2 - label3.Width / 2;
        }
    }
}
