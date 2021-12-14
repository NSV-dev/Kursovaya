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

namespace Kursovaya.Pages.PagesGen
{
    /// <summary>
    /// Логика взаимодействия для AccPage.xaml
    /// </summary>
    public partial class AccPage : Page
    {
        public AccPage(personality pers)
        {
            InitializeComponent();
            Cb.ItemsSource = Core.db.gender.ToList();
            ActivePers = pers;
            Cb.SelectedIndex = pers.genderID - 1;
            DataContext = pers;
        }

        private personality ActivePers;

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            ActivePers.genderID = Cb.SelectedIndex + 1;
            ActivePers.firstname = Tbfirstname.Text;
            ActivePers.lastname = Tblastname.Text;
            ActivePers.middlename = Tbmiddlename.Text;
            ActivePers.phone = Tbphone.Text;
            ActivePers.email = Tbemail.Text;
            ActivePers.address = Tbaddress.Text;
            ActivePers.dateofbirth = date.SelectedDate.Value;
            Core.db.SaveChanges();
        }

    }
}
