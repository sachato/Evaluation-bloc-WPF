using Evaluation_bloc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Evaluation_bloc.Services
{
    class ServiceService
    {

        #region Singleton

        private static ServiceService instance;
        public static ServiceService Instance//propriété statique = au niveau de la classe 
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceService();//Autot instenciation la premiere fois qu'elle est appellée
                }
                return instance;
            }
        }
        #endregion
        public List<Service> ChargerService()
        {
            List<Service> lst = new List<Service>();
            using (SalarieContext context = new SalarieContext())
            {
                var lst1 = context.Services.ToList();
                lst.AddRange(lst1);
            }

            return lst;
        }

        public int GetId(string nom)
        {
            int idService = -2;
            List<Service> lst = new List<Service>();
            using (SalarieContext context = new SalarieContext())
            {
                var lst1 = context.Services.ToList();
                lst.AddRange(lst1);
            }
            foreach (Service item in lst)
            {
                if (item.Nom == nom)
                {
                    idService = item.Id;
                }
            }
            return idService;
        }


        public void Enregistrer(Service service)
        {
            using (SalarieContext context = new SalarieContext())
            {
                context.Services.Update((Service)service);
                context.SaveChanges();
            }
        }

        public bool Delete(Service service)
        {
            bool continuer = true;
            var lstSalarie = Services.SalarieService.Instance.ChargerSalarie();
            foreach (Salarie item in lstSalarie)
            {
                if (item.Service == service.Id)
                {
                    continuer = false;
                }
            }
            if (continuer)
            {
                using (SalarieContext context = new SalarieContext())
                {
                    context.Services.Remove((Service)service);
                    context.SaveChanges();
                }
                return true;
            }
            else
            {
                MessageBox.Show("Impossible de supprimer ce service, un uttilisateur y est associé");
                return false;
            }

        }
    }


}
