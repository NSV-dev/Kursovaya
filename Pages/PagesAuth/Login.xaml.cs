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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya.Pages.PagesAuth
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            App.Current.MainWindow.BeginAnimation(Window.HeightProperty, new DoubleAnimation(App.Current.MainWindow.ActualHeight, 450, TimeSpan.FromSeconds(.3)));
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            foreach (emp item in Core.db.emp.ToList())
                if (item.login == TbLogin.Text && item.password == Password.Password)
                {
                    var wnd = new MainWindow(item, App.Current.MainWindow);
                    wnd.Owner = (Window)Parent;
                    wnd.Show();
                    App.Current.MainWindow.Hide();
                    return;
                }
            foreach (admin item in Core.db.admin.ToList())
                if (item.login == TbLogin.Text && item.password == Password.Password)
                {
                    var wnd = new MainAdm(item, App.Current.MainWindow);
                    wnd.Owner = (Window)Parent;
                    wnd.Show();
                    App.Current.MainWindow.Hide();
                    return;
                }
            new LabelWindow("Неверный логин или пароль"){ Owner = App.Current.MainWindow }.Show();
        }
    }
}
