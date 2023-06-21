using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Add_user.xaml
    /// </summary>
    public partial class Add_user : Page
    {
        private Entities.User curr_user = null;
        private byte[] img = null;
        Regex pass = new Regex(@"^\w{4,50}$");
        Regex email = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        Regex name = new Regex(@"^[А-ЯЁ][а-яё]+$");
        MatchCollection match;
        public Add_user()
        {
            InitializeComponent();
        }
        public Add_user(Entities.User user)
        {
            InitializeComponent();
            if (user != null)
            {
                curr_user = user;
                Txt_surname.Text = curr_user.surname;
                Txt_name.Text = curr_user.name;
                Txt_patr.Text = curr_user.patronymic;
                Txt_email.Text = curr_user.email;
                Txt_password.Password = curr_user.password;
                CB_role.SelectedIndex = curr_user.role - 1;
            }
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var role_admin = App.db.Roles.Where(c => c.name == CB_role.SelectedItem.ToString()).FirstOrDefault();
                if (curr_user == null)
                {

                    var users = new Entities.User
                    {
                        surname = Txt_surname.Text,
                        name = Txt_name.Text,
                        patronymic = "NULL",
                        email = Txt_email.Text,
                        password = Txt_password.Password,
                        role = role_admin.Id
                    };

                    App.db.Users.Add(users);
                    App.db.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    curr_user.surname = Txt_surname.Text;
                    curr_user.name = Txt_name.Text;
                    curr_user.patronymic = Txt_patr.Text;
                    curr_user.email = Txt_email.Text;
                    curr_user.password = Txt_password.Password;
                    curr_user.role = role_admin.Id;
                    App.db.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                NavigationService.GoBack();
            }
        }
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Txt_surname.Text))
                errorBuilder.AppendLine("Поле Фамилия обязательно для заполнения.");
            match = name.Matches(Txt_surname.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введена фамилия");
            if (string.IsNullOrWhiteSpace(Txt_name.Text))
                errorBuilder.AppendLine("Поле Имя обязательно для заполнения.");
            match = name.Matches(Txt_name.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введено имя.");
            match = name.Matches(Txt_patr.Text);
            if (Txt_patr.Text != "")
            {
                if (match.Count == 0)
                    errorBuilder.AppendLine("Некорректно введено отчество.");
            }
            if (string.IsNullOrWhiteSpace(Txt_email.Text))
                errorBuilder.AppendLine("Поле Эл. почта обязательно для заполнения.");
            match = email.Matches(Txt_email.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введена электронная почта.");
            match = pass.Matches(Txt_password.Password);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введен пароль.");
            if (string.IsNullOrWhiteSpace(Txt_password.Password))
                errorBuilder.AppendLine("Поле Пароль обязательно для заполнения.");
            if (CB_role.SelectedItem == null)
                errorBuilder.AppendLine("Поле Роль обязательно для заполнения.");

            return errorBuilder.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var cb_user = App.db.Roles.OrderBy(p => p.Id).Select(p => p.name).ToArray();

            for (int i = 0; i < cb_user.Length; i++)
                CB_role.Items.Add(cb_user[i]);
        }
    }
}
