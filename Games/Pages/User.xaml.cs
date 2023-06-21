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

namespace Games.Pages
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
            listviewUser.ItemsSource = App.db.Users.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Bt_add_user_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_user());
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void listviewUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bt_del_Click(object sender, RoutedEventArgs e)
        {
            var add_user = (sender as Button).DataContext as Entities.User;
            if (MessageBox.Show($"Вы уверены, что хотите удалить категорию: {add_user.name}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.db.Users.Remove(add_user);
                App.db.SaveChanges();
                Update();
            }
        }

        private void Bt_edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var add_user = button.DataContext as Entities.User;
            NavigationService.Navigate(new Add_user(add_user));
        }
        private void Update()
        {
            var up_games = App.db.Users.ToList();

            listviewUser.ItemsSource = up_games;
        }
    }
}
