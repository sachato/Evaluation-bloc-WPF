using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Evaluation_bloc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            //ijection de donnee dans la bdd
            //Services.SalarieService.Instance.Seed();
            //recuperation de la siste des salarié dans le datacontext
            this.DataContext = new ViewsModel.ListViewModel();
            var lstNomAutocomplete = Services.SalarieService.Instance.LstNom();
            Nom.ItemsSource = lstNomAutocomplete;
        }

        //methode de recherche par trois filtre : Site, Service et Nom
        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            //Initialisation des variables filtre
            string site = Site.Text;
            string service = Service.Text;
            string nom = Nom.Text;

            //Nouvelle liste de Salarié dans le data context
            this.DataContext = new ViewsModel.ListViewModel(site, service, nom);
        }


    }
}
