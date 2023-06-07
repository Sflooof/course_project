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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
            listviewOrder.ItemsSource = App.db.Orders.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Bt_del_Click(object sender, RoutedEventArgs e)
        {
            var current_order = (sender as Button).DataContext as Entities.Order;
            if (MessageBox.Show($"Вы уверены, что хотите удалить заказ?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.db.Orders.Remove(current_order);
                App.db.SaveChanges();
                Update();
            }
        }

        private void Bt_edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var current_order = button.DataContext as Entities.Order;
            NavigationService.Navigate(new Add_order(current_order));
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Bt_add_order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_order());
        }

        private void listviewOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Update()
        {
            var up_order = App.db.Orders.ToList();

            listviewOrder.ItemsSource = up_order;
        }
    }
}
