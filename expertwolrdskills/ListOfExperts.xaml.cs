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
    /// Логика взаимодействия для ListOfExperts.xaml
    /// </summary>
    public partial class ListOfExperts : Page
    {
        List<ExpertModel> experts = new List<ExpertModel>();
        Random random = new Random();
        int idOfChamp;
        int idOfCompetition;
        public ListOfExperts()
        {
            InitializeComponent();
            idOfChamp = random.Next(20);
            idOfCompetition = random.Next(294);
            init();
            ListOfParticipantsGrid.ItemsSource = experts;
        }
        private void init()
        {
                experts.Add(new ExpertModel(1,"Иванов","Иван","Иванович","Васиин Ваислий Васильевич",false));
                experts.Add(new ExpertModel(2,"Петров","Петр","Петрович","Семенов Семен Семенович",false));
        }
    }
}
