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
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        public AddTaskPage(emp emp)
        {
            InitializeComponent();
            Emp = emp;
        }

        private emp Emp;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tasks newtask = new tasks()
                {
                    empID = Emp.ID,
                    date = Date.SelectedDate.Value,
                    taskname = TbTitle.Text,
                    description = TbDesc.Text,
                    verification = false
                };


                for (int i = 0; i < Core.db.tasks.ToList().Count; i++)
                    if (Core.db.tasks.ToList()[i].ID != i + 1)
                    {
                        newtask.ID = i + 1;
                        break;
                    }
                if (newtask.ID == 0)
                    newtask.ID = Core.db.tasks.ToList().Count + 1;

                Core.db.tasks.Add(newtask);
                Core.db.SaveChanges();
            }
            catch
            {
                new LabelWindow("Необходимо ввести все данные") { Owner = Window.GetWindow(this) }.Show();
                return;
            }
            new LabelWindow("Задача успешно добавлена") { Owner = Window.GetWindow(this) }.ShowDialog();
        }
    }
}
