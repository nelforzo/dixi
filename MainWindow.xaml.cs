using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dixi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string? filename;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer talker = new SpeechSynthesizer();
            System.Collections.ObjectModel.ReadOnlyCollection<InstalledVoice> voices = talker.GetInstalledVoices();
            foreach (InstalledVoice voice in voices)
                combo1.Items.Add(voice.VoiceInfo.Name);

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(filename);
        }
    }
}
