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

namespace Kursovaya.Pages.PagesAdm.AdmEmpDescPages
{
    /// <summary>
    /// Логика взаимодействия для EmpInfoPage.xaml
    /// </summary>
    public partial class EmpInfoPage : Page
    {
        public EmpInfoPage(emp emp)
        {
            InitializeComponent();
            ActiveEmp = emp;
            DataContext = emp.personality;
        }

        private emp ActiveEmp;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.db.SaveChanges();
        }
    }
}
