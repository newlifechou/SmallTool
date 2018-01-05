using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;

namespace SpeakIt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text.Trim();
            SpVoice voice = new SpVoice();
            voice.Rate = 0;
            voice.Volume = 100;
            voice.Voice = voice.GetVoices().Item(0);
            voice.Speak($"开始朗读{txt}");
        }
    }
}
