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
    /// Логика взаимодействия для Manufacture.xaml
    /// </summary>
    public partial class Manufacture : Page
    {
        public Manufacture()
        {
            InitializeComponent();
            listviewManufacture.ItemsSource = App.db.Manufacturers.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }


        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Bt_del_Click(object sender, RoutedEventArgs e)
        {
            var current_cat = (sender as Button).DataContext as Entities.Manufacturer;
            if (MessageBox.Show($"Вы уверены, что хотите удалить производителя: {current_cat.name}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.db.Manufacturers.Remove(current_cat);
                App.db.SaveChanges();
                Update();
            }
        }

        private void Bt_edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var current_man = button.DataContext as Entities.Manufacturer;
            NavigationService.Navigate(new Add_manufacture1(current_man));
        }

        private void listviewManufacture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Update()
        {
            var up_man = App.db.Manufacturers.ToList();

            listviewManufacture.ItemsSource = up_man;
        }

        private void Bt_add_man_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_manufacture1());
        }
    }
}
