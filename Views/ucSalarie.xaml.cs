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

namespace Evaluation_bloc.Views
{
    /// <summary>
    /// Logique d'interaction pour ucSalarie.xaml
    /// </summary>
    public partial class ucSalarie : UserControl
    {
        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (value.Length < 6 || value.Length > 50)
                {
                    throw new ArgumentException("Name should be between range 6-50");
                }

                _nom = value;
            }
        }
        public ucSalarie()
        {
            InitializeComponent();
        }

        
    }
}
