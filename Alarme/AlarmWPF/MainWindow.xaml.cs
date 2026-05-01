using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AlarmWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        //Un cercle
        private Ellipse ellipse;
        //3 aiguilles
        private Line minutes;
        private Line hours;
        private Line seconds;
       

        public MainWindow()
        {
            InitializeComponent();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            double longueurAiguilleSeconde = ellipse.Width / 2;
            seconds.X2 = ellipse.Width / 2 + Math.Cos(15 * Math.PI / 30 - DateTime.Now.Second * Math.PI / 30) * longueurAiguilleSeconde;
            seconds.Y2 = ellipse.Height / 2 + Math.Sin(-15 * Math.PI / 30 + DateTime.Now.Second * Math.PI / 30) * longueurAiguilleSeconde;
            //-------Minutes 
            minutes.X2 = ellipse.Width / 2 + Math.Cos(15 * Math.PI / 30 - DateTime.Now.Minute * Math.PI / 30) * (longueurAiguilleSeconde / 1.5);
            minutes.Y2 = ellipse.Height / 2 + Math.Sin(-15 * Math.PI / 30 + DateTime.Now.Minute * Math.PI / 30) * (longueurAiguilleSeconde / 1.5);
            //---------Hours
            hours.X2 = ellipse.Width / 2 + -Math.Cos(15 * Math.PI / 30 - DateTime.Now.Hour * Math.PI / 30) * (longueurAiguilleSeconde / 1.5);
            hours.Y2 = ellipse.Height / 2 + Math.Sin(-15 * Math.PI / 30 + DateTime.Now.Hour * Math.PI / 30) * (longueurAiguilleSeconde / 1.5);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            //Définit combien de secondes entre chaque déclenchement de l'événement Tick 
            timer.Interval = TimeSpan.FromSeconds(1);
            //Associe une procédure événementielle à l'événement Tick du Timer, il vous faut écrire cette procédure événementielle
            timer.Tick += timer_Tick;
            //Lance le Timer, obligatoire sinon rien ne se passe
            timer.Start();

            ellipse = new Ellipse();
            CNVClock.Children.Add(ellipse);
            ellipse.Width = 300;
            ellipse.Height = 300;
            ellipse.Stroke = Brushes.Gray; ellipse.StrokeThickness = 1;
            //--------------
            seconds = new Line();
            CNVClock.Children.Add(seconds);
            seconds.Stroke = Brushes.Red; seconds.StrokeThickness = 1;
            //Le point d'origine est au centre du cercle
            seconds.X1 = ellipse.Width / 2;
            seconds.Y1 = ellipse.Height / 2;
            //Je définis la longueur de l'aiguille, je pourrais mettre une autre valeur
            double longueurAiguilleSeconde = ellipse.Width / 2;
            seconds.X2 = ellipse.Width / 2 + Math.Cos(15 * Math.PI / 30 - DateTime.Now.Second * Math.PI / 30) * longueurAiguilleSeconde;
            seconds.Y2 = ellipse.Height / 2 + Math.Sin(-15 * Math.PI / 30 + DateTime.Now.Second * Math.PI / 30) * longueurAiguilleSeconde;
            //----------------
            minutes = new Line();
            CNVClock.Children.Add(minutes);
            minutes.Stroke = Brushes.Black; seconds.StrokeThickness = 1;
            //Le point d'origine est au centre du cercle
            minutes.X1 = ellipse.Width / 2;
            minutes.Y1 = ellipse.Height / 2;
            //Je définis la longueur de l'aiguille, je pourrais mettre une autre valeur
            minutes.X2 = ellipse.Width / 2 + Math.Cos(15 * Math.PI / 30 - DateTime.Now.Minute * Math.PI / 30) * (longueurAiguilleSeconde/1.5);
            minutes.Y2 = ellipse.Height / 2 + Math.Sin(-15 * Math.PI / 30 + DateTime.Now.Minute * Math.PI / 30) * (longueurAiguilleSeconde/1.5);
            //--------------
            hours = new Line();
            CNVClock.Children.Add(hours);
            hours.Stroke = Brushes.Black; seconds.StrokeThickness = 1;
            //Le point d'origine est au centre du cercle
            hours.X1 = ellipse.Width / 2;
            hours.Y1 = ellipse.Height / 2;
            //Je définis la longueur de l'aiguille, je pourrais mettre une autre valeur
            hours.X2 = ellipse.Width / 2 + -Math.Cos(15 * Math.PI / 30 - DateTime.Now.Hour * Math.PI / 30) * (longueurAiguilleSeconde / 1.5);
            hours.Y2 = ellipse.Height / 2 + Math.Sin(-15 * Math.PI / 30 + DateTime.Now.Hour * Math.PI / 30) * (longueurAiguilleSeconde / 1.5);
            //==============
            TBXHeurs.Text = "";
            TBXMinutes.Text = "";

        }

        private void BTNAjouter_Click(object sender, RoutedEventArgs e)
        {
            int heurs;
            int minutes;
            heurs = Int32.Parse(TBXHeurs.Text);
            minutes = Int32.Parse(TBXMinutes.Text);
            if ((heurs >= 0 && heurs <= 23) && (minutes >= 0 && minutes < 60))
            {
                string H=TBXHeurs.Text;
                string M=TBXMinutes.Text;
                if (heurs.ToString().Length<2)
                {
                    H = '0' + heurs.ToString();
                }
                if (minutes.ToString().Length < 2)
                {
                    M = '0' + minutes.ToString();
                }
                DateTime today = DateTime.Today;
                LBSDateTime.Items.Add(today.ToString("dd/MM/yyyy") + " "+ H +":"+M);
            }
            else MessageBox.Show("temps erroné");
        }

        private void BTNSupprimer_Click(object sender, RoutedEventArgs e)
        {
           
                LBSDateTime.Items.Remove(LBSDateTime.SelectedItem);
            
        }

        private void Window_LayoutUpdated(object sender, EventArgs e)
        {
            DateTime maintenant = DateTime.Now;
            string dateHeureMinutes = maintenant.ToString("dd/MM/yyyy HH:mm");

            for (int i = 0; i < LBSDateTime.Items.Count; i++)
            {
                if (LBSDateTime.Items[i].ToString() == dateHeureMinutes)
                {
                    Console.Beep();
                    MessageBox.Show("C'est l'heure " + dateHeureMinutes);
                    
                }
            }
        }
    }
}
