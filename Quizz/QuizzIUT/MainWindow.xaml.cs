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

namespace QuizzIUT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 1;
        private int good = 0;
        private int bad = 0;
        private string[] questions = { "Comment s'appelle le héreos de Dragon ball Z?", "Ou se situe votre IUT" };
        private string[] reponses = { "Sangoku", "Orsay" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SDRModeNuit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void WNDFenetrePrincipale_Loaded(object sender, RoutedEventArgs e)
        {
            if (count > 0)
            {
                TBXReponse.Text = "";
                NextQuestion();
                LBLQuestion.Content = questions[count];
            }


        }

        private void BTNValider1_Click(object sender, RoutedEventArgs e)
        {



            if (TBXReponse.Text == reponses[count])
            {
                MessageBox.Show("Bravo! Bonne réponse!");
                good++;
            }
            else
            {
                bad++;
                MessageBox.Show("la bonne reponse est " + reponses[count]);
            }
            NextQuestion();

            LBLBonnesReponsesValeur.Content = good;
            LBLMauvaisesReponsesValeur.Content = bad;

        }
        private void NextQuestion()
        {
            count++;
            if (count == questions.Length) { count = 0; }
            LBLQuestion.Content = questions[count];
        }

        private void SDRModeNuit_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue == 1)
            {
                Grid.Background = new SolidColorBrush(Colors.Black);
                LBLBonnesReponsesValeur.Foreground = new SolidColorBrush(Colors.White);
                LBLBonnesReponses.Foreground = new SolidColorBrush(Colors.White);
                LBLMauvaisesReponsesValeur.Foreground = new SolidColorBrush(Colors.White);
                LBLQuestion.Foreground = new SolidColorBrush(Colors.White);
                LBLTitre.Foreground = new SolidColorBrush(Colors.White);
                LBLMauvaisesReponses.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (e.NewValue == 0)
            {
                Grid.Background = new SolidColorBrush(Colors.White);
                LBLBonnesReponsesValeur.Foreground = new SolidColorBrush(Colors.Black);
                LBLBonnesReponses.Foreground = new SolidColorBrush(Colors.Black);
                LBLMauvaisesReponsesValeur.Foreground = new SolidColorBrush(Colors.Black);
                LBLQuestion.Foreground = new SolidColorBrush(Colors.Black);
                LBLTitre.Foreground = new SolidColorBrush(Colors.Black);
                LBLMauvaisesReponses.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
    }
}