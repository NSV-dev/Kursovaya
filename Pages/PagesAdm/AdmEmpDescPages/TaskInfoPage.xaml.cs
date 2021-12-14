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
    /// Логика взаимодействия для TaskInfoPage.xaml
    /// </summary>
    public partial class TaskInfoPage : Page
    {
        public TaskInfoPage(tasks task)
        {
            InitializeComponent();
            ActiveTask = task;
            DataContext = task;
        }

        private tasks ActiveTask;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (new YesNoWindow("Вы уверены что хотите удалить задачу?") { Owner = Window.GetWindow(this) }.ShowDialog().Value)
            {
                Core.db.tasks.Remove(ActiveTask);
                Core.db.SaveChanges();
                new LabelWindow("Задача удалена") { Owner = Window.GetWindow(this) }.Show();
            }
        }
    }
}
