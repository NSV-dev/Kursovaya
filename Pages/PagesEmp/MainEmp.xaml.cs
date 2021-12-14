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

namespace Kursovaya.Pages.PagesEmp
{
    /// <summary>
    /// Логика взаимодействия для MainEmp.xaml
    /// </summary>
    public partial class MainEmp : Page
    {
        public MainEmp(emp emp)
        {
            InitializeComponent();

            var ActiveUser = emp;
            var AllTasks = Core.db.tasks.Where(x => x.empID == ActiveUser.ID).ToList();

            UserPanel.DataContext = ActiveUser;
            TaskPanel.DataContext = AllTasks;
            AdminPanel.DataContext = ActiveUser.company.admin.personality;

            TbExp.Text = AllTasks.Where(x => x.expired == true).Count().ToString();
            ExpList.ItemsSource = AllTasks.Where(x => x.expired == true).ToList();

            TbWait.Text = AllTasks.Where(x => x.verification == true).Count().ToString();
            WaitList.ItemsSource = AllTasks.Where(x => x.verification == true).ToList();
        }
    }
}
