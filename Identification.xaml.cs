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
    public partial class Identification : Window
    {
        public Identification()
        {
            InitializeComponent();
        }

        private void Pass_Click(object sender, RoutedEventArgs e)
        {
            //initialisation de la variable password
            //Il est mieux de cacher le password par hash
            var password = pass.Password;

            //Si le mot de passe est correct, affichage de la fenetre admin + fermeture de la fenetre d'identification
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
