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

namespace Kursovaya.Pages.PagesAdm
{
    /// <summary>
    /// Логика взаимодействия для MainAdmPage.xaml
    /// </summary>
    public partial class MainAdmPage : Page
    {
        public MainAdmPage(admin admin)
        {
            InitializeComponent();
            var ActiveUser = admin;

            UserGrid.DataContext = ActiveUser;
            CompanyGrid.DataContext = ActiveUser.company.First();
            EmpGrid.DataContext = Core.db.emp.Where(x => x.company.adminID == ActiveUser.ID).ToList();
            ReportGrid.DataContext = Core.db.reports.Where(x => x.tasks.emp.company.adminID == ActiveUser.ID).ToList();
        }
    }
}
