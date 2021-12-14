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

namespace Kursovaya.Pages.PagesAuth.PagesRegDesk
{
    /// <summary>
    /// Логика взаимодействия для NewEmpPage.xaml
    /// </summary>
    public partial class NewEmpPage : Page
    {
        public NewEmpPage()
        {
            InitializeComponent();
            Cb.ItemsSource = Core.db.gender.ToList();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                personality pers = new personality()
                {
                    lastname = Tblastname.Text,
                    firstname = Tbfirstname.Text,
                    middlename = Tbmiddlename.Text,
                    gender = (gender)Cb.SelectedItem,
                    email = Tbemail.Text,
                    phone = Tbphone.Text,
                    dateofbirth = date.SelectedDate.Value,
                    address = Tbaddress.Text
                };
                for (int i = 0; i < Core.db.personality.ToList().Count; i++)
                    if (Core.db.personality.ToList()[i].ID != i + 1)
                    {
                        pers.ID = i + 1;
                        break;
                    }
                if (pers.ID == 0)
                    pers.ID = Core.db.personality.ToList().Count + 1;

                emp newuser = new emp()
                {
                    company = Core.db.company.ToList().Where(x => x.code == Convert.ToInt32(CompCod.Text)).First(),
                    login = TbLogin.Text,
                    password = TbPass.Text,
                    roles = Core.db.roles.ToList().Where(x => x.role == "emp").First(),
                    personality = pers
                };
                for (int i = 0; i < Core.db.emp.ToList().Count; i++)
                    if (Core.db.emp.ToList()[i].ID != i + 1)
                    {
                        newuser.ID = i + 1;
                        break;
                    }
                if (newuser.ID == 0)
                    newuser.ID = Core.db.emp.ToList().Count + 1;


                Core.db.personality.Add(pers);
                Core.db.emp.Add(newuser);
                Core.db.SaveChanges();
            }
            catch
            {
                new LabelWindow("Необходимо ввести все данные") { Owner = Window.GetWindow(this) }.Show();
                return;
            }

            new LabelWindow("Вы успешно зарегестрированны") { Owner = Window.GetWindow(this) }.Show();
        }
    }
}
