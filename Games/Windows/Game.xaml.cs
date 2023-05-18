using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Games.Windows
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
            FrameSecond.Navigate(new Pages.Catalog());
        }

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите вернуться?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                MainWindow auth = new MainWindow();
                auth.Show();
                Window.GetWindow(this).Close();
            }
                
        }
    }
}
