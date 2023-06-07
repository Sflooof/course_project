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
using System.Text.RegularExpressions;

namespace Games.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add_order.xaml
    /// </summary>
    public partial class Add_order : Page
    {
        private Entities.Order curr_order = null;
        Regex name = new Regex(@"^[а-яё]|[a-z]+$");
        MatchCollection match;
        public Add_order()
        {
            InitializeComponent();
        }
        public Add_order(Entities.Order current_order)
        {
            InitializeComponent();
            if (current_order != null)
            {
                curr_order = current_order;
                Txt_user.SelectedIndex = curr_order.users - 1;
                Txt_cost.Text = curr_order.total_cost.ToString();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var users = App.db.Users.OrderBy(p => p.Id).Select(p => p.surname).ToArray();
            for (int i = 0; i < users.Length; i++)
            {
                Txt_user.Items.Add(users[i]);
            }
        }

        private string CheckErrors()
        {
            decimal cost = 0;
            var errorBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Txt_user.Text))
                errorBuilder.AppendLine("Пользователь обязателен для заполнения;");
            if (string.IsNullOrWhiteSpace(Txt_cost.Text))
                errorBuilder.AppendLine("Итоговая цена обязательна для заполнения;");
            else if (decimal.TryParse(Txt_cost.Text, out cost) == false || cost <= 0)
                errorBuilder.AppendLine("Цена товара должна быть положительным числом;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }

        private void Btn_back_Click_1(object sender, RoutedEventArgs e)
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
                var order_com = App.db.Users.Where(c => c.surname == Txt_user.SelectedItem.ToString()).FirstOrDefault();
                if (curr_order == null)
                {
                    var orders = new Entities.Order { };
                    if (Txt_user.Text == "")
                    {
                        orders = new Entities.Order
                        {
                            users = order_com.Id,
                            total_cost = decimal.Parse(Txt_cost.Text),
                        };
                    }
                    else
                    {
                        orders = new Entities.Order
                        {
                            users = order_com.Id,
                            total_cost = decimal.Parse(Txt_cost.Text),
                        };
                    }

                    App.db.Orders.Add(orders);
                    App.db.SaveChanges();
                    MessageBox.Show("Заказ успешно создан", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    curr_order.users = order_com.Id;
                    curr_order.total_cost = decimal.Parse(Txt_cost.Text);

                    App.db.SaveChanges();
                    MessageBox.Show("Заказ успешно создан", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }
    }
}
