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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        //Авторизация
        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            var currect_user = App.db.Users.FirstOrDefault(u => u.email == TxbLogin.Text && u.password == TxbPassword.Password );
            if (currect_user != null)
            {
                
                App.CurrentUser = currect_user;
                //NavigationService.Navigate(new Catalog());
                Windows.Game game = new Windows.Game();
                game.Show();
                Window.GetWindow(this).Close();
            }
            else 
            {
                MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {

        }
        //Поле логин пустое при обновлении
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TxbLogin.Text = string.Empty;
        }
    }
}
