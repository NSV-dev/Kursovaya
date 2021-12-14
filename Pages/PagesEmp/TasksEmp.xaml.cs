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
using Kursovaya.Pages.PagesEmp.TaskDesc;

namespace Kursovaya.Pages.PagesEmp
{
    /// <summary>
    /// Логика взаимодействия для TasksEmp.xaml
    /// </summary>
    public partial class TasksEmp : Page
    {
        public TasksEmp(emp acc)
        {
            InitializeComponent();
            ActiveAcc = acc;
            DataContext = ActiveAcc.tasks.ToList().OrderBy(x=>x.verification).ThenByDescending(x=>x.expired);
        }

        private emp ActiveAcc;

        private void Lw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frm.Navigate(new TaskDescPage((tasks)Lw.SelectedItem));
        }

        private void Frm_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.3);
            ta.To = new Thickness(0, 0, 0, 0);
            ta.From = new Thickness(0, 0, 500, 0);
            (e.Content as Page).BeginAnimation(MarginProperty, ta);
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbSearch.Text!="")
                DataContext = ActiveAcc.tasks.ToList().Where(x=>x.taskname.ToLower().Contains(TbSearch.Text.ToLower())).OrderBy(x => x.verification).ThenByDescending(x => x.expired);
            else
                DataContext = ActiveAcc.tasks.ToList().OrderBy(x => x.verification).ThenByDescending(x => x.expired);
        }
    }
}
