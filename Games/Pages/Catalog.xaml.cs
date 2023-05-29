﻿using Games.Entities;
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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public Entities.Game game1;
        public Catalog()
        {
            InitializeComponent();
            listviewGame.ItemsSource = App.db.Games.ToList();
            if (App.CurrentUser == null || App.CurrentUser.role == 2)
            {
                Bt_add.Visibility = Visibility.Collapsed;
            }
            game1 = App.db.Games.ToList().FirstOrDefault();
            //var all_type = App.db.Games.get
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //        NavigationService.Navigate(new Add_game());
        //}


        private void listviewGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bt_detail_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Game_detail());
        }

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Bt_del_Click(object sender, RoutedEventArgs e)
        {
            var current_games = (sender as Button).DataContext as Entities.Game;
            if (MessageBox.Show($"Вы уверены, что хотите удалить машину: {current_games.name} " +
                    $"{current_games.manufacturer}?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.db.Games.Remove(current_games);
                App.db.SaveChanges();
                UpdateGames();
            }
            //var current_games = (sender as Button).DataContext as Entities.Game;
            //if (App.db.Games.FirstOrDefault(p => p.Article ==  current_games.Article) == null)
            //{
            //    if (MessageBox.Show($"Вы уверены, что хотите удалить товар: {current_games.name}\nАртикул: " +
            //        $"{current_games.name}?",
            //        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            //    {
            //        App.db.Games.Remove(current_games);
            //        App.db.SaveChanges();
            //        UpdateGames();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Нельзя удалить товар\nПричина: на данный товар существует заказ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void Bt_edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var currentProduct = button.DataContext as Entities.Game;
            NavigationService.Navigate(new Add_game(currentProduct));
        }

        private void Bt_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_game());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            var up_games = App.db.Games.ToList();
            listviewGame.ItemsSource = up_games;
        }

        private void Bt_add_cat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_category1());
        }

        private void Bt_add_man_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_manufacture1());
        }

        private void TB_find_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                listviewGame.ItemsSource = App.db.Games.Where(item => item.name == TB_find.Text || item.name.Contains(TB_find.Text)).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Combo_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGames();
        }
        
        private void UpdateGames()
        {
            var games = App.db.Games.ToList();
            if (Combo_type.SelectedIndex == 0)
            {
                games = games.OrderBy(p => p.release_year).ToList();
            }
            else if (Combo_type.SelectedIndex == 1)
            {
                games = games.OrderBy(p => p.cost).ToList();
            }
            else
            {
                games = games.OrderByDescending(p => p.cost).ToList();
            }
            listviewGame.ItemsSource = games;
        }
    }
}
