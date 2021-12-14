using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Kursovaya.Pages.PagesAdm;
using Kursovaya.Pages.PagesGen;

namespace Kursovaya
{
    public partial class MainAdm : Window
    {
        private Window auth;

        public MainAdm(admin acc, Window wnd)
        {
            auth = wnd;
            InitializeComponent();
            ActiveAcc = acc;
            MainTog.IsChecked = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!auth.IsActive)
                App.Current.Shutdown();
        }

        private admin ActiveAcc;

        private async void MainTog_Checked(object sender, RoutedEventArgs e)
        {
            EmpTog.IsChecked = false;
            ReportTog.IsChecked = false;
            AccTog.IsChecked = false;
            Frm.Navigate(new MainAdmPage(ActiveAcc));
            await Task.Delay(100);
            btn_Click(sender, e);
        }

        private async void EmpTog_Checked(object sender, RoutedEventArgs e)
        {
            MainTog.IsChecked = false;
            ReportTog.IsChecked = false;
            AccTog.IsChecked = false;
            Frm.Navigate(new AdmEmpPage(ActiveAcc));
            await Task.Delay(100);
            btn_Click(sender, e);
        }

        private async void ReportTog_Checked(object sender, RoutedEventArgs e)
        {
            MainTog.IsChecked = false;
            EmpTog.IsChecked = false;
            AccTog.IsChecked = false;
            Frm.Navigate(new ReportPage(ActiveAcc));
            await Task.Delay(100);
            btn_Click(sender, e);
        }

        private async void AccTog_Checked(object sender, RoutedEventArgs e)
        {
            MainTog.IsChecked = false;
            EmpTog.IsChecked = false;
            ReportTog.IsChecked = false;
            Frm.Navigate(new AccPage(ActiveAcc.personality));
            await Task.Delay(100);
            btn_Click(sender, e);
        }

        private void ExitTog_Checked(object sender, RoutedEventArgs e)
        {
            auth.Show();
            Close();
        }

        private void Frm_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.3);
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);
            ta.From = new Thickness(500, 0, 0, 0);
            (e.Content as Page).BeginAnimation(MarginProperty, ta);
        }

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.3);
            if (MenuSP.Visibility == Visibility.Visible)
            {
                ta.From = new Thickness(0, 20, 0, 0);
                ta.To = new Thickness(0, 20, 100, 0);
                MenuSP.BeginAnimation(MarginProperty, ta);
                await Task.Delay(100);
                MenuSP.Visibility = Visibility.Hidden;
            }
            else
            {
                ta.From = new Thickness(0, 20, 100, 0);
                ta.To = new Thickness(0, 20, 0, 0);
                MenuSP.BeginAnimation(MarginProperty, ta);
                await Task.Delay(100);
                MenuSP.Visibility = Visibility.Visible;
            }
        }
    }
}
