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

namespace Kursovaya.Pages.PagesAdm.ReportDescpages
{
    /// <summary>
    /// Логика взаимодействия для ReportDescPage.xaml
    /// </summary>
    public partial class ReportDescPage : Page
    {
        public ReportDescPage(reports rep)
        {
            InitializeComponent();
            ActiveRep = rep;
            DataContext = ActiveRep;
        }

        private reports ActiveRep;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (new YesNoWindow("Вы уверены, что хотите удалить отчет?") { Owner = Window.GetWindow(this) }.ShowDialog().Value)
            {
                Core.db.reports.Remove(ActiveRep);
                Core.db.tasks.Remove(Core.db.tasks.ToList().Where(x => x.ID == ActiveRep.taskID).Single());
                Core.db.SaveChanges();
            }
        }
    }
}
