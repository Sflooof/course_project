﻿using System;
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

        }

        private void Bt_edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bt_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_game(null));
        }
    }
}
