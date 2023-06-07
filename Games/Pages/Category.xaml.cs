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
    /// Логика взаимодействия для Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        public Category()
        {
            InitializeComponent();
            listviewCategory.ItemsSource = App.db.Categories.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void listviewGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bt_detail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bt_add_cat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_category1());
        }

        private void Bt_del_Click(object sender, RoutedEventArgs e)
        {
            var current_cat = (sender as Button).DataContext as Entities.Category;
            if (MessageBox.Show($"Вы уверены, что хотите удалить категорию: {current_cat.name}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.db.Categories.Remove(current_cat);
                App.db.SaveChanges();
                Update();
            }
        }

        private void Bt_edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var current_cat = button.DataContext as Entities.Category;
            NavigationService.Navigate(new Add_category1(current_cat));
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Update()
        {
            var up_games = App.db.Categories.ToList();

            listviewCategory.ItemsSource = up_games;
        }
    }
}
