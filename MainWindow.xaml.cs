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
        public byte[] hashed;
        public MainWindow()
        {
            
            InitializeComponent();
            //Services.SalarieService.Instance.Seed();
            this.DataContext = new ViewsModel.ListViewModel();
            Application.Current.Properties["Admin"] = false;
        }

        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            string site = Site.Text;
            var service = Service.Text;
            string nom = Nom.Text;
            this.DataContext = new ViewsModel.ListViewModel(site, service, nom);
        }
    }
}
