using Games.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace Games.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add_game : Page
    {
        private Entities.Game curr_game = null;
        private byte[] img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Resources\");
        //public string img_cur = null;
        private Game game = new Game();
        string photoName;
        public Add_game(Entities.Game game)
        {
            InitializeComponent();
            if (game != null)
            {
                curr_game = game;
                Txt_name.Text = curr_game.name;
                Txt_description.Text = curr_game.description;
                Txt_equipment.Text = curr_game.equipment;
                Cb_category.SelectedIndex = curr_game.category - 1;
                Cb_manufacturer.SelectedIndex = curr_game.manufacturer - 1;
                Txt_release_year.Text = curr_game.release_year.ToString();
                if (curr_game.photo != null)
                {
                    Img_photo.Source = new ImageSourceConverter()
                        .ConvertFrom(img) as ImageSource;
                }
            }
        }

        public Add_game()
        {
            InitializeComponent();
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
                var category = App.db.Categories.Where(c => c.name == Cb_category.SelectedItem.ToString()).FirstOrDefault();
                var manufacturer = App.db.Manufacturers.Where(c => c.name == Cb_manufacturer.SelectedItem.ToString()).FirstOrDefault();
                if (curr_game == null)
                {
                    var car = new Entities.Game
                    {
                        name = Txt_name.Text,
                        description = Txt_description.Text,
                        equipment = Txt_equipment.Text,
                        category = category.Id,
                        manufacturer = manufacturer.Id,
                        release_year = DateTime.Parse(Txt_release_year.Text),
                        cost = Convert.ToDecimal(Txt_coust.Text),
                        photo = photoName
                };

                    App.db.Games.Add(car);
                    App.db.SaveChanges();
                    MessageBox.Show("Игра успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    curr_game.name = Txt_name.Text;
                    curr_game.description = Txt_description.Text;
                    curr_game.equipment = Txt_equipment.Text;
                    curr_game.category = category.Id;
                    curr_game.manufacturer = manufacturer.Id;
                    curr_game.release_year = DateTime.Parse(Txt_release_year.Text);
                    curr_game.cost = Convert.ToDecimal(Txt_coust.Text);

                    if (img != null)
                        curr_game.photo = photoName;
                    App.db.SaveChanges();
                    MessageBox.Show("Игра успешно обновлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                NavigationService.GoBack();
            }
        }

        private void Btn_img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file_img = new OpenFileDialog();
            file_img.Multiselect = false;
            file_img.Filter = "Image | *.png; *.jpg; *.jpeg";
            if (file_img.ShowDialog() == true)
            {
                img = File.ReadAllBytes(file_img.FileName);
                
                Img_photo.Source = new ImageSourceConverter()
                    .ConvertFrom(img) as ImageSource;
                photoName = Path.GetFileName(file_img.FileName);
                
                path += photoName;
                File.Copy(file_img.FileName, path);
                
            }
        }

        private string CheckErrors()
        {
            decimal cost = 0;
            var errorBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Txt_name.Text))
                errorBuilder.AppendLine("Название игры обязательно для заполнения;");
            if (string.IsNullOrWhiteSpace(Txt_description.Text))
                errorBuilder.AppendLine("Описание игры обязательно для заполнения;");
            if (string.IsNullOrWhiteSpace(Txt_equipment.Text))
                errorBuilder.AppendLine("Содержимое игры обязательно для заполнения;");
            if (Cb_category.SelectedItem == null)
                errorBuilder.AppendLine("Выберите категорию игры;");
            if (Cb_manufacturer.SelectedItem == null)
                errorBuilder.AppendLine("Выберите производителя игры;");
            if (string.IsNullOrWhiteSpace(Txt_coust.Text))
                errorBuilder.AppendLine("Цена игры обязательна для заполнения;");
            if (string.IsNullOrWhiteSpace(Txt_release_year.Text))
                errorBuilder.AppendLine("Год выпуска обязателен для заполнения;");
            else if (decimal.TryParse(Txt_coust.Text, out cost) == false || cost <= 0)
                errorBuilder.AppendLine("Цена товара должна быть положительным числом;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var combox_cat = App.db.Categories.OrderBy(p => p.Id).Select(p => p.name).ToArray();
            var combox_man = App.db.Manufacturers.OrderBy(p => p.Id).Select(p => p.name).ToArray();
            for (int i = 0; i < combox_cat.Length; i++)
                Cb_category.Items.Add(combox_cat[i]);
            for (int i = 0; i < combox_man.Length; i++)
                Cb_manufacturer.Items.Add(combox_man[i]);
        }
    }
}
