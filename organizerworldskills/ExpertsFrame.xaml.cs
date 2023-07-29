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

namespace organizerworldskills
{
    /// <summary>
    /// Логика взаимодействия для ExpertsFrame.xaml
    /// </summary>
    public partial class ExpertsFrame : Page
    {
        public ExpertsFrame()
        {
            InitializeComponent();
        }

        private void ListOfParticipantsButton_Click(object sender, RoutedEventArgs e)
        {
            ListOfParticipantsButton.Background = new SolidColorBrush(Colors.Green);
            ChampionateSettingsButton.Background = new SolidColorBrush(Colors.Blue);
            ProtocolsReportButton.Background = new SolidColorBrush(Colors.Blue);
            ListOfMainExpertsButton.Background = new SolidColorBrush(Colors.Blue);
            contentFrame.Content = new ParticipantsList();
        }
        private void ChampionateSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ChampionateSettingsButton.Background = new SolidColorBrush(Colors.Green);
            ProtocolsReportButton.Background = new SolidColorBrush(Colors.Blue);
            ListOfMainExpertsButton.Background = new SolidColorBrush(Colors.Blue);
            ListOfParticipantsButton.Background = new SolidColorBrush(Colors.Blue);
            contentFrame.Content = new ChampionateSettings();
        }
        private void ListOfMainExpertsButton_Click(object sender, RoutedEventArgs e)
        {
            ListOfMainExpertsButton.Background = new SolidColorBrush(Colors.Green);
            ChampionateSettingsButton.Background = new SolidColorBrush(Colors.Blue);
            ProtocolsReportButton.Background = new SolidColorBrush(Colors.Blue);
            ListOfParticipantsButton.Background = new SolidColorBrush(Colors.Blue);
            contentFrame.Content = new MainExperts();
        }
        private void ProtocolsReportButton_Click(object sender, RoutedEventArgs e)
        {
            ProtocolsReportButton.Background = new SolidColorBrush(Colors.Green);
            ChampionateSettingsButton.Background = new SolidColorBrush(Colors.Blue);
            ListOfMainExpertsButton.Background = new SolidColorBrush(Colors.Blue);
            ListOfParticipantsButton.Background = new SolidColorBrush(Colors.Blue);
        }


      
       
    }
}
