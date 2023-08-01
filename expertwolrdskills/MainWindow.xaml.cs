using System;
using System.Collections.Generic;
using System.Linq;
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

namespace expertwolrdskills
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<char> words = new List<char>() { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public MainWindow()
        {
            InitializeComponent();
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                AccessCodeText.Text += words[random.Next(words.Count)];
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void ListOfParticipantsButton_Click(object sender, RoutedEventArgs e)
        {
            ListOfParticipantsButton.Background = new SolidColorBrush(Colors.Green);
            ListOfExpertsButton.Background = new SolidColorBrush(Colors.Blue);
            ProtocolsButton.Background = new SolidColorBrush(Colors.Blue);
            ContentFrame.Content = new ParticipantsFrame(this);
        }
        private void ListOfExpertsButton_Click(object sender, RoutedEventArgs e)
        {
            ListOfExpertsButton.Background = new SolidColorBrush(Colors.Green);
            ListOfParticipantsButton.Background = new SolidColorBrush(Colors.Blue);
            ProtocolsButton.Background = new SolidColorBrush(Colors.Blue);
            ContentFrame.Content = new ListOfExperts();
        }

        private void ProtocolsButton_Click(object sender, RoutedEventArgs e)
        {
            ProtocolsButton.Background = new SolidColorBrush(Colors.Green);
            ListOfParticipantsButton.Background = new SolidColorBrush(Colors.Blue);
            ListOfExpertsButton.Background = new SolidColorBrush(Colors.Blue);
        }


    }
}
