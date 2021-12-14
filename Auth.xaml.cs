using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Kursovaya.Pages.PagesAuth;

namespace Kursovaya
{
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
            LoginBtn.IsChecked = true;
        }

        private void LoginBtn_Checked(object sender, RoutedEventArgs e)
        {
            SignupBtn.IsChecked = false;
            var page = new Login();
            Frm.Navigate(page);
        }

        private void SignupBtn_Checked(object sender, RoutedEventArgs e)
        {
            LoginBtn.IsChecked = false;
            var page = new Reg();
            Frm.Navigate(page);
        }

        private void Frm_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.3);
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);
            ta.From = new Thickness(0, 0, 0, 500);
            (e.Content as Page).BeginAnimation(MarginProperty, ta);
        }
    }
}
