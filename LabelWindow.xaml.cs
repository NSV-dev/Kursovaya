using System.Windows;

namespace Kursovaya
{
    public partial class LabelWindow : Window
    {
        public LabelWindow(string text)
        {
            InitializeComponent();
            Lb.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
