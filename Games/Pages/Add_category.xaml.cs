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
    /// Логика взаимодействия для Add_category1.xaml
    /// </summary>
    public partial class Add_category1 : Page
    {
        private Entities.Category curr_cat = null;
        Regex name = new Regex(@"^[а-яё]+$");
        MatchCollection match;
        public Add_category1()
        {
            InitializeComponent();
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
                if (curr_cat == null)
                {
                    var category = new Entities.Category { };
                    if (Txt_name.Text == "")
                    {
                        category = new Entities.Category
                        {
                            name = Txt_name.Text
                        };
                    }
                    else
                    {
                        category = new Entities.Category
                        {
                            name = Txt_name.Text
                        };
                    }

                    App.db.Categories.Add(category);
                    App.db.SaveChanges();
                    MessageBox.Show("Категория успешно создана", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    curr_cat.name = Txt_name.Text;
                }


            }
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Txt_name.Text))
                errorBuilder.AppendLine("Поле обязательно для заполнения.");
            match = name.Matches(Txt_name.Text);
            if (match.Count == 0)
                errorBuilder.AppendLine("Некорректно введено назвоние категории.");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
    }
}
