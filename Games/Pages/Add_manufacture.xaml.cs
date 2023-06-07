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
    /// Логика взаимодействия для Add_manufacture1.xaml
    /// </summary>
    public partial class Add_manufacture1 : Page
    {
        private Entities.Manufacturer curr_man = null;
        Regex name = new Regex(@"^[А-ЯЁ][а-яё]|[A-Z][a-z]+$");
        MatchCollection match;
        public Add_manufacture1(Entities.Manufacturer current_man)
        {
            InitializeComponent();
            if (current_man != null)
            {
                curr_man = current_man;
                Txt_name.Text = curr_man.name;
            }
        }
        public Add_manufacture1()
        {
            InitializeComponent();
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
                if (curr_man == null)
                {
                    var manuf = new Entities.Manufacturer { };
                    if (Txt_name.Text == "")
                    {
                        manuf = new Entities.Manufacturer
                        {
                            name = Txt_name.Text
                        };
                    }
                    else
                    {
                        manuf = new Entities.Manufacturer
                        {
                            name = Txt_name.Text
                        };
                    }

                    App.db.Manufacturers.Add(manuf);
                    App.db.SaveChanges();
                    MessageBox.Show("Производитель успешно создан", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    curr_man.name = Txt_name.Text;
                    MessageBox.Show("Производитель успешно обновлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Txt_name.Text))
                errorBuilder.AppendLine("Поле обязательно для заполнения.");
            match = name.Matches(Txt_name.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введено назвоние производителя.");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
    }
}
