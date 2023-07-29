using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для ParticipantsList.xaml
    /// </summary>
    public partial class ParticipantsList : Page
    {
        ObservableCollection<Participants> participants = new ObservableCollection<Participants>();
        public ParticipantsList()
        {
            InitializeComponent(); 
            init();
            Competitiors.ItemsSource = participants;
        }
        private void init()
        {
            participants.Add(new Participants(1, "Иванов", "Иван", "Иванович", "Информационные технологии", "Главный эксперт", ""));
            participants.Add(new Participants(2, "Петров", "Петр", "Петрович", "Информационные технологии", "Участник", ""));
        }

        private void AgreeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
