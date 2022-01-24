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
            this.DataContext = new ViewsModel.SalarieViewModel();
        }
    }
}
