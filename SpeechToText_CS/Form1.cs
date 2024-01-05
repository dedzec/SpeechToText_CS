using System.Globalization;
using System.Speech.Recognition;

namespace SpeechToText_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo cInfo = new CultureInfo("en-US");
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToDefaultAudioDevice();
            Grammar grammar = new DictationGrammar();
            recognizer.LoadGrammar(new DictationGrammar());
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text += e.Result.Text + "\r\n";
        }
    }
}