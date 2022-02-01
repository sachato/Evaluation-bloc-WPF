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
using System.Windows.Shapes;

namespace Evaluation_bloc
{
    public partial class CrudSalarie : Window
    {
        public CrudSalarie()
        {
            InitializeComponent();

            //Liste de Salarié dans le datacontext
            this.DataContext = new ViewsModel.ListViewModel();
            var lstNomAutocomplete = Services.SalarieService.Instance.LstNom();
            Nom.ItemsSource = lstNomAutocomplete;

        }

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
