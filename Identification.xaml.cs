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
    /// Logique d'interaction pour Identification.xaml
    /// </summary>
    public partial class Identification : Window
    {
        public Identification()
        {
            InitializeComponent();

        }

        private void Pass_Click(object sender, RoutedEventArgs e)
        {
            var password = pass.Password;
            if(password == "azerty")
            {
                Admin admin = new Admin();
                admin.Show();
                Window toClose = Services.UserService.Instance.windowAdminAcces;
                toClose.Close();
            }
        }
    }
}
