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
    /// Логика взаимодействия для MainExperts.xaml
    /// </summary>
    public partial class MainExperts : Page
    {
        List<Experts> experts = new List<Experts>();
        public MainExperts()
        {
            InitializeComponent();
            init();
            ListOfExperts.ItemsSource = experts;
        }
        private void init()
        {
            experts.Add(new Experts(1, "Иванов Иван Иванович", "Гланвый эксперт", "Информационные технологии", "+7(912)442-05-11", "ivanivanbl4@mail.ru"));
        }

    }
}
