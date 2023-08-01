using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ParticipantsFrame.xaml
    /// </summary>
    public partial class ParticipantsFrame : Page
    {
        List<ParticipantModel> participants = new List<ParticipantModel>();
        Random random = new Random();
        int idOfChamp;
        int idOfCompetition;
        MainWindow window;
        public ParticipantsFrame(MainWindow window)
        {
            InitializeComponent();
            idOfChamp = random.Next(20);
            idOfCompetition = random.Next(294);
            GetFromDB();
            ListOfParticipantsGrid.ItemsSource = participants;
            this.window = window;
        }
        private void GetFromDB()
        {
            bool ishave = false;
            List<string> _championtsList = new List<string>();
            HttpClient client = new HttpClient();
            string link = "https://localhost:7212/api/Users";
            HttpResponseMessage message = client.GetAsync(link).Result;
            string jsonresponse = message.Content.ReadAsStringAsync().Result;
            List<DBUserModel> competitions = JsonConvert.DeserializeObject<List<DBUserModel>>(jsonresponse);
            while (!ishave)
            {
                if (competitions.Any(x => x.Чемпионат == idOfChamp && x.Skill == idOfCompetition))
                {
                    ishave = true;
                    break;
                }
                else
                {
                    idOfCompetition = random.Next(294);
                }
            }
            foreach (var a in competitions)
            {
                if (a.Чемпионат == idOfChamp)
                {
                    if (a.Skill == idOfCompetition)
                    {
                        if (a.IdRole == 1)
                        {
                            string[] fio = a.Fio.Split(' ');
                            string surname = fio[0];
                            string name = fio[1];
                            string lastname = fio[2];
                            double yearofBirth = Math.Round(((Convert.ToDouble((DateTime.Today - Convert.ToDateTime(a.ДатаРождения)).Days / 365))));
                            participants.Add(new ParticipantModel(participants.Count, surname, name, lastname, a.ДатаРождения, Convert.ToInt32(yearofBirth), false));
                        }
                    }
                }
            }
        }

        private void AddParticipantButton_Click(object sender, RoutedEventArgs e)
        {
            window.ContentFrame.Content = new AddingParticipant(idOfChamp,idOfCompetition);
        }
    }
}
