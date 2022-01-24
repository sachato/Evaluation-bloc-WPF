using Evaluation_bloc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Evaluation_bloc.Services
{
    class SalarieService
    {
        #region Singleton

        private static SalarieService instance;
        public static SalarieService Instance//propriété statique = au niveau de la classe 
        {
            get
            {
                if (instance == null)
                {
                    instance = new SalarieService();//Autot instenciation la premiere fois qu'elle est appellée
                }
                return instance;
            }
        }
        #endregion
        public void Seed()
        {
            using (SalarieContext context = new SalarieContext())
            {

                context.Services.Add(new Service { Nom = "Production" });
                context.Services.Add(new Service { Nom = "Accueil" });
                context.Services.Add(new Service { Nom = "Comercial" });

                context.Sites.Add(new Site { Ville = "Nante" });
                context.Sites.Add(new Site { Ville = "Toulouse" });
                context.Sites.Add(new Site { Ville = "Nice" });
                context.Sites.Add(new Site { Ville = "Lille" });

                context.Salaries.Add(new Salarie { Nom = "Verse", Prenom = "Alain", Email = "alain.verse@entreprise.com", TelFixe = "0534292345", TelPortable = "0712097698", Service = 10, Site = 7 });
                context.Salaries.Add(new Salarie { Nom = "Terrieur", Prenom = "Alex", Email = "alex.terrieur@entreprise.com", TelFixe = "0636153091", TelPortable = "0732761204", Service = 11, Site = 8 });
                context.Salaries.Add(new Salarie { Nom = "Orial", Prenom = "Édith", Email = "édith.orial@entreprise.com", TelFixe = "0534292347", TelPortable = "0712047698", Service = 12, Site = 9 });
                context.Salaries.Add(new Salarie { Nom = "Hun", Prenom = "Jeff", Email = "jeff.hun@entreprise.com", TelFixe = "0636243091", TelPortable = "0732987204", Service = 11, Site = 8 });

                context.SaveChanges();
            }

        }

        public List<Salarie> ChargerSalarie()
        {
            List<Salarie> lst = new List<Salarie>();
            using (SalarieContext context = new SalarieContext())
            {
                var lst1 = context.Salaries.ToList();
                lst.AddRange(lst1);
            }

            return lst;
        }

        public string GetNomSite(int pk)
        {
            string nom;
            using (SalarieContext context = new SalarieContext())
            {
                var site = context.Sites.Find(pk);
                nom = site.Ville;
            }
            return nom;
        }

        public string GetNomService(int pk)
        {
            string nom;
            using (SalarieContext context = new SalarieContext())
            {
                var site = context.Services.Find(pk);
                nom = site.Nom;
            }
            return nom;
        }
        

        public void Enregistrer(Salarie salarie)
        {
            int idService = ServiceService.Instance.GetId(salarie.ServiceNom);
            int idSite = SiteService.Instance.GetId(salarie.SiteNom);
            List<Service> lstService = ServiceService.Instance.ChargerService();
            List<Site> lstSite = SiteService.Instance.ChargerSites();
            int compteurSite = 0;
            int compteurService = 0;
            Regex emailValidator = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            bool email = emailValidator.IsMatch(salarie.Email);

            foreach (Site item in lstSite)
            {
                if(item.Id == idSite)
                {
                    compteurSite += 1;
                }
            }

            foreach (Service item in lstService)
            {
                if (item.Id == idService)
                {
                    compteurService += 1;
                }
            }

            if (compteurService > 0 && compteurSite > 0 && email)
            {
                Salarie enregistremoi = new Salarie { Id = salarie.Id, Nom = salarie.Nom, Prenom = salarie.Prenom, Email = salarie.Email, TelFixe = salarie.TelFixe, TelPortable = salarie.TelPortable, Service = ServiceService.Instance.GetId(salarie.ServiceNom), Site = SiteService.Instance.GetId(salarie.SiteNom) };
                using (SalarieContext context = new SalarieContext())
                {
                    context.Salaries.Update((Salarie)enregistremoi);
                    context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Attention, il y a une erreur dans le formulaire !");
            }
        }

        public bool Delete(Salarie salarie)
        {
            using (SalarieContext context = new SalarieContext())
            {
                context.Salaries.Remove((Salarie)salarie);
                context.SaveChanges();
            }
            return true;
        }
    }
}