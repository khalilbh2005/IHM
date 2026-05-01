using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arborescence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GBXSignup.Visibility = Visibility.Collapsed;
            GBXHelp.Visibility = Visibility.Collapsed;
        }

        private void LNKSignup_Click(object sender, RoutedEventArgs e)
        {
            GBXSignin.Visibility = Visibility.Collapsed;
            GBXHelp.Visibility = Visibility.Collapsed;
            GBXSignup.Visibility = Visibility.Visible;
            
        }

        private void LNKSignin_Click(object sender, RoutedEventArgs e)
        {
            GBXSignup.Visibility = Visibility.Collapsed;
            GBXHelp.Visibility = Visibility.Collapsed;
            GBXSignin.Visibility = Visibility.Visible;
            
        }

        private void BTNSignup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bienvenue chez Arborescence " + TBXUserFirstName.Text);
        }

        private void BTNSignin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bon retour parmi nous " + TBXUserSignin.Text);
        }

        private void LNKHelp_Click(object sender, RoutedEventArgs e)
        {
            GBXSignup.Visibility = Visibility.Visible;
            GBXHelp.Visibility = Visibility.Visible;
            GBXSignin.Visibility = Visibility.Collapsed;
        }

        private void BTNHideHelp_Click(object sender, RoutedEventArgs e)
        {
            GBXSignin.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GBXHelp.Visibility = Visibility.Collapsed;
        }
    }
}