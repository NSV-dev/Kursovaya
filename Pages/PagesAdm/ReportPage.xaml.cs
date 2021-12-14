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
using Kursovaya.Pages.PagesAdm.ReportDescpages;

namespace Kursovaya.Pages.PagesAdm
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private company comp;

        public ReportPage(admin adm)
        {
            InitializeComponent();
            comp = adm.company.First();
            DataContext = Core.db.reports.Where(s => s.tasks.emp.companyID == comp.ID).ToList();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frm.Navigate(new ReportDescPage((reports)Lw.SelectedItem));
        }

        private void Frm_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.3);
            ta.To = new Thickness(0, 0, 0, 0);
            ta.From = new Thickness(500, 0, 0, 0);
            (e.Content as Page).BeginAnimation(MarginProperty, ta);
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbSearch.Text != "")
                DataContext = Core.db.reports.Where(s => s.tasks.taskname.Contains(TbSearch.Text) && s.tasks.emp.companyID == comp.ID).ToList();
            else
                DataContext = Core.db.reports.Where(s => s.tasks.emp.companyID == comp.ID).ToList();
        }
    }
}
