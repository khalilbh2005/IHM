using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
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

namespace AnagrammeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private string[] mots;
        //ajouter d'autres propriétés ici si besoin
        private String[] tabMots;
        private int numPartie=0;
        private int coups=0;
        int index;
        
        //
        //
        

        public MainWindow()
        {
            InitializeComponent();
        }
        private void initialiation()
        {
            tabMots = new String[] { "LUNDI", "MARDI", "MERCREDI", "JEUDI", "VENDREDI", "SAMEDI", "DIMANCHE" };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            initialiation();
            nouvellePartie();
        }
        private String Melanger(String chaine)
        {
            Random rnd = new();
            String resultat = "";
            List<int> indexUtilises = new List<int>();
            while (resultat.Length < chaine.Length)
            {
                int index = rnd.Next(chaine.Length);
                if (!indexUtilises.Contains(index))
                {
                    resultat += chaine[index]; 
                    indexUtilises.Add(index);
                }
            }

            return resultat;
        }

       
        private void nouvellePartie()
        {
            Random rnd = new();
            String resultat = "";
            index = rnd.Next(tabMots.Length);
            LBLMot.Content = Melanger(tabMots[index]);
            LBLNbEssaisRestant.Content = 5;
            LSBEssais.Items.Clear();
            TBXProposition.Text = "";
            coups = 0;
        }

        private void motCorrect()
        {
            // Pour WPF uniquement
            MessageBoxResult result = MessageBox.Show("Bravo ! Tu veux rejouer ?", "Fin de partie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                numPartie++;
                String history = "Partie - " + numPartie + " - " + LBLMot.Content + " - Gagnée - "+coups+ " - coups";
                LSBHistorique.Items.Add(history);
                nouvellePartie();
            }
            else {
                this.Close();
            }
        }
        private void motIncorrect()
        {
            int reste = int.Parse(LBLNbEssaisRestant.Content.ToString());
            if (reste > 0)
            {
                reste--;
                coups++;
                LBLNbEssaisRestant.Content = reste;
                String propition = TBXProposition.Text.ToString();
                LSBEssais.Items.Add(propition);
                TBXProposition.Text = "";
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Perdu ! Tu veux rejouer ?", "Fin de partie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    numPartie++;
                    String history = "Partie - " + numPartie + " - " + LBLMot.Content + " - Perdu - " + coups + " - coups";
                    LSBHistorique.Items.Add(history);
                    TBXProposition.Text = "";
                    nouvellePartie();
                }
                else { this.Close(); }
            }
        }
        private void LSBEssais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BTNTester_Click(object sender, RoutedEventArgs e)
        {

            

            if (tabMots[index] == TBXProposition.Text.Trim().ToUpper())
                {
                    motCorrect();
                }
                else
                {
                    motIncorrect();
                }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            numPartie++;
            String history = "Partie - " + numPartie + " - " + LBLMot.Content + " - Perdu - " + coups + " - coups";
            LSBHistorique.Items.Add(history);
            TBXProposition.Text = "";
            nouvellePartie();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }





        //ajouter vos autres méthodes ici
        //
        //
        //

    }
}
