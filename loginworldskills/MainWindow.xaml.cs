using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
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

namespace loginworldskills
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string link = "https://localhost:7212/api/Users";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {

            if (init())
            {
                MessageBox.Show("Вы вошли!");
            }
            else
                MessageBox.Show("Вы допустили ошибку(");
        }
        private bool init()
        {
            bool istrue = false;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(link).Result;
            if (response.Content.ReadAsStringAsync().Result.Contains(loginInput.Text))
            {
                if (response.Content.ReadAsStringAsync().Result.Contains(passwordInput.Text))
                {
                    istrue = true;

                }
                else
                    istrue = false;
            }
            return istrue;
        }

    }
}
