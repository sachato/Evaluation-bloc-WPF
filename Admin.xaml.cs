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
    /// <summary>
    /// Logique d'interaction pour Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Service_Click(object sender, RoutedEventArgs e)
        {
            CrudService servicewindow = new CrudService();
            servicewindow.Show();
        }

        private void Salarie_Click(object sender, RoutedEventArgs e)
        {
            CrudSalarie salariewindow = new CrudSalarie();
            salariewindow.Show();
        }

        private void Site_Click(object sender, RoutedEventArgs e)
        {
            CrudSite sitewindow = new CrudSite();
            sitewindow.Show();
        }
    }
}
