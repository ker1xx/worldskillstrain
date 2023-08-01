using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace expertwolrdskills
{
    /// <summary>
    /// Логика взаимодействия для AddingParticipant.xaml
    /// </summary>
    public partial class AddingParticipant : Page
    {
        private List<char> symb = new List<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '@', '#', '$', '%', '&', '_', '-', '+', '=', '.' };
       private List<int> numb = new List<int>() {1,2,3,4,5,6,7,8,9,0 };
        private int idOfChamp;
        private int idOFCompetition;
        public AddingParticipant(int idOfChamp,int idOfCompetition)
        {
            InitializeComponent();
            this.idOfChamp = idOfChamp;
            this.idOFCompetition = idOfCompetition;
            getRegions();
        }
        private void getRegions()
        {
            List<string> regionNames = new List<string>();
            HttpClient client = new HttpClient();
            string link = "https://localhost:7212/api/Regions";
            HttpResponseMessage message = client.GetAsync(link).Result;
            string jsonresponse = message.Content.ReadAsStringAsync().Result;
            List<Regions> regions = JsonConvert.DeserializeObject<List<Regions>>(jsonresponse);
            foreach (Regions region in regions)
            {
                regionNames.Add(region.name);
            }
            RegionChoiseBox.ItemsSource = regionNames;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string link = "https://localhost:7212/api/Users";
            DBUserModel model = new DBUserModel();
            model.Fio = SurnameInput.Text + " " + NameInput.Text + " " + LastnameInput.Text;
            if (Male.IsChecked == true)
                model.Gender = "м";
            else if (Female.IsChecked == true)
                model.Gender = "ж";
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                model.Password += symb[rand.Next(symb.Count)];
            }
            for (int i = 0; i < 5; i++)
            {
                model.Pin += numb[rand.Next(numb.Count)];
            }
            string[] date = BirthDateInput.Text.Split('.');
            model.ДатаРождения = new DateTime(Int32.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            model.IdRole = 1;
            model.Skill = idOFCompetition;
            model.Region = RegionChoiseBox.SelectedIndex + 1;
            model.Чемпионат = idOfChamp;
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(link, content).Result;
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Участник добавлен!");
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Участник не добавлен!");
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}
