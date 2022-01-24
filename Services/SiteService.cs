using Evaluation_bloc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Evaluation_bloc.Services
{
    class SiteService
    {
        #region Singleton

        private static SiteService instance;
        public static SiteService Instance//propriété statique = au niveau de la classe 
        {
            get
            {
                if (instance == null)
                {
                    instance = new SiteService();//Autot instenciation la premiere fois qu'elle est appellée
                }
                return instance;
            }
        }
        #endregion

        //Creation de la liste des sites
        public List<Site> ChargerSites()
        {
            List<Site> lst = new List<Site>();
            using (SalarieContext context = new SalarieContext())
            {
                var lst1 = context.Sites.ToList();
                lst.AddRange(lst1);
            }

            return lst;
        }

        //recuperation de l'id du site a partir d'un nom
        //-2 signifie que le site n'existe pas
        public int GetId(string nom)
        {
            int idSite = -2;
            List<Site> lst = new List<Site>();
            using (SalarieContext context = new SalarieContext())
            {
                var lst1 = context.Sites.ToList();
                lst.AddRange(lst1);
            }
            foreach(Site item in lst)
            {
                if(item.Ville == nom)
                {
                    idSite = item.Id;
                }
            }
            return idSite;
        }

        public void Enregistrer(Site site)
        {
            using (SalarieContext context = new SalarieContext())
            {
                context.Sites.Update((Site)site);
                context.SaveChanges();
            }
         }

        public bool Delete(Site site)
        {
            //variable pour savoir si on continue la suppretion ou si un salarie uttilise le site
            bool continuer = true;
            var lstSalarie = Services.SalarieService.Instance.ChargerSalarie();
            foreach(Salarie item in lstSalarie)
            {
                //on verifie que le site ne soit pas uttilisé par un salarie
                if(item.Site == site.Id)
                {
                    continuer = false;
                }
            }
            //pas de salarie uttilisant le site, on efface
            if (continuer)
            {
                using (SalarieContext context = new SalarieContext())
                {
                    context.Sites.Remove((Site)site);
                    context.SaveChanges();
                }
                return true;
            }
            //un salarie uttilisant le filtre, on ne supprime pas
            else
            {
                MessageBox.Show("Impossible de supprimer ce site, un uttilisateur y est associé");
                return false;
            }
            
        }

    }
}
