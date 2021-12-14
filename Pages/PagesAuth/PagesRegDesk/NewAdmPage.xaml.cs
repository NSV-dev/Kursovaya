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
    /// Логика взаимодействия для NewAdmPage.xaml
    /// </summary>
    public partial class NewAdmPage : Page
    {
        public NewAdmPage()
        {
            InitializeComponent();
            Cb.ItemsSource = Core.db.gender.ToList();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (company c in Core.db.company.ToList())
                    if (c.code == Convert.ToInt32(CompCod.Text))
                    {
                        if (new YesNoWindow("Такой код компании уже существует.\nСгенирировать случайный?") { Owner = Window.GetWindow(this) }.ShowDialog().Value)
                        {
                            Random rnd = new Random();
                            int value = rnd.Next(100000, 999999);
                            while (CompCod.Text == Convert.ToString(value))
                                value = rnd.Next(100000, 999999);
                            CompCod.Text = Convert.ToString(value);
                        }
                        else
                            CompCod.Text = "";
                        return;
                    }

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

                admin newuser = new admin()
                {
                    login = TbLogin.Text,
                    password = TbPass.Text,
                    roles = Core.db.roles.ToList().Where(x => x.role == "admin").First(),
                    personality = pers
                };
                for (int i = 0; i < Core.db.admin.ToList().Count; i++)
                    if (Core.db.admin.ToList()[i].ID != i + 1)
                    {
                        newuser.ID = i + 1;
                        break;
                    }
                if (newuser.ID == 0)
                    newuser.ID = Core.db.admin.ToList().Count + 1;

                company comp = new company()
                {
                    compname = CompName.Text,
                    code = Convert.ToInt32(CompCod.Text),
                    admin = newuser
                };
                for (int i = 0; i < Core.db.company.ToList().Count; i++)
                    if (Core.db.company.ToList()[i].ID != i + 1)
                    {
                        comp.ID = i + 1;
                        break;
                    }
                if (comp.ID == 0)
                    comp.ID = Core.db.company.ToList().Count + 1;

                Core.db.personality.Add(pers);
                Core.db.admin.Add(newuser);
                Core.db.company.Add(comp);
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
