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
    /// Логика взаимодействия для AdmEmpDeskPage.xaml
    /// </summary>
    public partial class AdmEmpDeskPage : Page
    {
        public AdmEmpDeskPage(emp emp)
        {
            InitializeComponent();
            ActiveEmp = emp;
            DataContext = emp;
            Frm.Navigate(new EmpInfoPage(emp));
        }

        private emp ActiveEmp;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frm.Navigate(new AddTaskPage(ActiveEmp));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frm.Navigate(new TaskInfoPage((tasks)LwTasks.SelectedItem));
        }
    }
}
