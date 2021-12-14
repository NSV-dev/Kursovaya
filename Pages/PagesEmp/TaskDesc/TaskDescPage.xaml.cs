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

namespace Kursovaya.Pages.PagesEmp.TaskDesc
{
    /// <summary>
    /// Логика взаимодействия для TaskDescPage.xaml
    /// </summary>
    public partial class TaskDescPage : Page
    {
        public TaskDescPage(tasks task)
        {
            InitializeComponent();
            DataContext = task;
            ActiveTask = task;
        }

        private tasks ActiveTask;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
var item = new reports();

new TbWindow(item) { Owner = Window.GetWindow(this) }.ShowDialog();

for (int i = 0; i < Core.db.reports.ToList().Count; i++)
    if (Core.db.reports.ToList()[i].ID != i + 1)
    {
        item.ID = i + 1;
        break;
    }
if (item.ID == 0)
    item.ID = Core.db.reports.ToList().Count + 1;

item.taskID = ActiveTask.ID;
item.tasks = ActiveTask;
if (item.description != "")
{
    Core.db.reports.Add(item);
    ActiveTask.verification = true;
    Core.db.SaveChanges();
}
else
    new LabelWindow("Необходимо ввести описание проделанной работы") { Owner = Window.GetWindow(this) }.ShowDialog();
        }
    }
}
