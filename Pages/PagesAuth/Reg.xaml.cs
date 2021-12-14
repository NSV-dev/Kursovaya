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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kursovaya.Pages.PagesAuth.PagesRegDesk;

namespace Kursovaya.Pages.PagesAuth
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
            App.Current.MainWindow.BeginAnimation(Window.HeightProperty, new DoubleAnimation(App.Current.MainWindow.ActualHeight, 700, TimeSpan.FromSeconds(.3)));
            NewEmpBtn.IsChecked = true;
        }

        private void Frm_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.3);
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);
            if (e.NavigationMode == NavigationMode.New)
            {
                ta.From = new Thickness(500, 0, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 0, 500, 0);
            }
            (e.Content as Page).BeginAnimation(MarginProperty, ta);
        }

        private void NewEmpBtn_Checked(object sender, RoutedEventArgs e)
        {
            NewAdmBtn.IsChecked = false;
            Frm.Navigate(new NewEmpPage());
        }

        private void NewAdmBtn_Checked(object sender, RoutedEventArgs e)
        {
            NewEmpBtn.IsChecked = false;
            Frm.Navigate(new NewAdmPage());
        }
    }
}
