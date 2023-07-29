using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace organizerworldskills
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getChampionats();
        }

        private void ChampionateSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ChampionateSettingsButton.Background = new SolidColorBrush(Colors.Green);
            ExpertsManagementButton.Background = new SolidColorBrush(Colors.Blue);
            ProtocolsButton.Background = new SolidColorBrush(Colors.Blue);
        }

        private void ExpertsManagementButton_Click(object sender, RoutedEventArgs e)
        {
            ChampionateSettingsButton.Background = new SolidColorBrush(Colors.Blue);
            ExpertsManagementButton.Background = new SolidColorBrush(Colors.Green);
            ProtocolsButton.Background = new SolidColorBrush(Colors.Blue);
            ContentFrame.Content = new ExpertsFrame();
        }

        private void ProtocolsButton_Click(object sender, RoutedEventArgs e)
        {
            ChampionateSettingsButton.Background = new SolidColorBrush(Colors.Blue);
            ExpertsManagementButton.Background = new SolidColorBrush(Colors.Blue);
            ProtocolsButton.Background = new SolidColorBrush(Colors.Green);
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void getChampionats()
        {
            List<string> _championtsList = new List<string>();
            HttpClient client = new HttpClient();
            string link = "https://localhost:7212/api/Competitions";
            HttpResponseMessage message = client.GetAsync(link).Result;
            string jsonresponse = message.Content.ReadAsStringAsync().Result;
            List<Competition> competitions = JsonConvert.DeserializeObject<List<Competition>>(jsonresponse);
            foreach (var a in competitions)
            {
                _championtsList.Add(a.Title);
            }
            ChampionatePicker.ItemsSource = _championtsList;
        }
    }
}
