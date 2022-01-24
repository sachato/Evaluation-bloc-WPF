using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Evaluation_bloc.Services
{
    class UserService
    {
        #region Singleton

        public Window windowAdminAcces;
        private static UserService instance;
        public static UserService Instance//propriété statique = au niveau de la classe 
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserService();//Autot instenciation la premiere fois qu'elle est appellée
                }
                return instance;
            }
        }
        #endregion
        public void makeAdmin()
        {

            Identification windowAdmin = new Identification();
            windowAdminAcces = windowAdmin;
            windowAdmin.Show();
            
            
        }
    }
}
