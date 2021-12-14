using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Kursovaya.Pages.PagesGen;
using Kursovaya.Pages.PagesEmp;

namespace Kursovaya
{
    public partial class MainWindow : Window
    {
        private Window auth;

        public MainWindow(emp emp, Window wnd)
        {
            auth = wnd;
            InitializeComponent();
            ActiveAcc = emp;
            foreach (var item in ActiveAcc.tasks.ToList())
                if (item.date < DateTime.Now)
                    item.expired = true;
            Core.db.SaveChanges();

            MainTog.IsChecked = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (!auth.IsActive)
                App.Current.Shutdown();
        }

        private emp ActiveAcc;

        private async void MainTog_Checked(object sender, RoutedEventArgs e)
        {
            TasksTog.IsChecked = false;
            AccTog.IsChecked = false;
            Frm.Navigate(new MainEmp(ActiveAcc));
            await Task.Delay(100);
            btn_Click(sender, e);
        }

        private async void TasksTog_Checked(object sender, RoutedEventArgs e)
        {
            MainTog.IsChecked = false;
            AccTog.IsChecked = false;
            Frm.Navigate(new TasksEmp(ActiveAcc));
            await Task.Delay(100);
            btn_Click(sender, e);
        }

        private async void AccTog_Checked(object sender, RoutedEventArgs e)
        {
            MainTog.IsChecked = false;
            TasksTog.IsChecked = false;
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
