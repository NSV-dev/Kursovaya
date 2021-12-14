using System.Windows;

namespace Kursovaya
{
    public partial class TbWindow : Window
    {
        public TbWindow(reports rep)
        {
            InitializeComponent();
            ActiveRep = rep;
        }

        private reports ActiveRep;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActiveRep.description = Tb.Text;
            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            ActiveRep.description = "";
            Close();
        }
    }
}
