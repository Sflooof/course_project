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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private Entities.User add_user = null;
        private byte[] img = null;
        Regex pass = new Regex(@"^\w{8,50}$");
        Regex email = new Regex(@"^[w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        Regex name = new Regex(@"^[А-ЯЁ][а-яё]+$");
        MatchCollection match;
        public Registration()
        {
            InitializeComponent();
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Txt_surname.Text))
                errorBuilder.AppendLine("Поле обязательно для заполнения.");
            match = name.Matches(Txt_surname.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введена фамилия");
            if (string.IsNullOrWhiteSpace(Txt_name.Text))
                errorBuilder.AppendLine("Поле обязательно для заполнения.");
            match = name.Matches(Txt_name.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введено имя.");
            match = name.Matches(Txt_name.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введено отчество.");
            if (string.IsNullOrWhiteSpace(Txt_email.Text))
                errorBuilder.AppendLine("Поле обязательно для заполнения.");
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введен пароль.");
            if (string.IsNullOrWhiteSpace(Txt_password.Text))
                errorBuilder.AppendLine("Поле обязательно для заполнения.");
            if (string.IsNullOrWhiteSpace(Txt_right_password.Text))
                errorBuilder.AppendLine("Поле обязательно для заполнения.");
            if (Txt_password != Txt_right_password)
                errorBuilder.AppendLine("Пароли не совпадают.");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = CheckErrors();
            if (error.Length > 0)
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (add_user == null)
                {
                    var user = new Entities.User { };
                    if (Txt_patr.Text == "")
                    {
                        user = new Entities.User
                        {
                            surname = Txt_surname.Text,
                            name = Txt_name.Text,
                            patronymic = "NULL",
                            email = Txt_email.Text,
                            password = Txt_password.Text,
                            role = 2
                        };
                    }
                    else
                    {
                        user = new Entities.User
                        {
                            surname = Txt_surname.Text,
                            name = Txt_name.Text,
                            patronymic = Txt_patr.Text,
                            email = Txt_email.Text,
                            password = Txt_password.Text,
                            role = 2
                        };
                    }

                    App.db.Users.Add(user);
                    App.db.SaveChanges();
                    MessageBox.Show("Пользователь успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    add_user.surname = Txt_surname.Text;
                    add_user.name = Txt_name.Text;
                    add_user.patronymic = Txt_patr.Text;
                    add_user.email = Txt_email.Text;
                    add_user.password = Txt_password.Text;
                }
                NavigationService.GoBack();
            }
        }   
    }
}
