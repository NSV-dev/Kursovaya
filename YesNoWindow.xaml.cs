using System.Windows;

namespace Kursovaya
{
    public partial class YesNoWindow : Window
    {
        public YesNoWindow(string text)
        {
            InitializeComponent();
            Lb.Content = text;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
