using System;
using System.Collections.Generic;
using System.IO;
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
using Games.Entities;
using Path = System.IO.Path;

namespace Games.Pages
{
    /// <summary>
    /// Логика взаимодействия для Game_detail.xaml
    /// </summary>
    public partial class Game_detail : Page
    {
        //private Entities.Game curr_game = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Resources\");
        public Game_detail(Game game)
        {
            InitializeComponent();
            if (game != null)
            {
                if (game.photo != null)
                {
                    Img_photo.Source = new ImageSourceConverter()
                        .ConvertFrom(game.photo) as ImageSource;
                }
                name.Text = game.name;
                description.Text = game.description;
                equipment.Text = game.equipment;
                var cur_category = App.db.Category.Where(m => m.Id == game.category).FirstOrDefault();
                category.Text = cur_category.name;
                var cur_manufacturer = App.db.Manufacturer.Where(m => m.Id == game.manufacturer).FirstOrDefault();
                manufacturer.Text = cur_manufacturer.name;
                release_year.Text = game.release_year.ToString();
                cost.Text = game.cost.ToString();
            }

        }

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void listviewGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
