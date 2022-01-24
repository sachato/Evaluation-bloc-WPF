﻿using Evaluation_bloc.Model;
using Evaluation_bloc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Evaluation_bloc.ViewsModel
{
    class ListViewModel : ViewModelBase
    {
        public ObservableCollection<Salarie> ListeSalaries { get; }
        public ObservableCollection<Site> ListeSites { get; }
        public ObservableCollection<Service> ListeServices { get; }

        private readonly ICollectionView collectionViewSalarie;
        private readonly ICollectionView collectionViewSite;
        private readonly ICollectionView collectionViewService;

        public Salarie SalarieSelected
        {
            get
            {
                return (Salarie)collectionViewSalarie.CurrentItem;
                //return collectionViewSalarie.CurrentItem as contact;
            }
        }

        public Site SiteSelected
        {
            get
            {
                return (Site)collectionViewSite.CurrentItem;
                //return collectionViewSalarie.CurrentItem as contact;
            }
        }

        public Service ServiceSelected
        {
            get
            {
                return (Service)collectionViewService.CurrentItem;
                //return collectionViewSalarie.CurrentItem as contact;
            }
        }

        public ListViewModel(string siteNom = "", string serviceNom = "", string nom = "")
        {
            //on recupere la liste brute de modele
            List<Salarie> lst = Services.SalarieService.Instance.ChargerSalarie();
            List<Site> lstSite = Services.SiteService.Instance.ChargerSites();
            List<Service> lstService = Services.ServiceService.Instance.ChargerService();


            //on initialise l'observable
            ListeSalaries = new ObservableCollection<Salarie>();
            ListeSites = new ObservableCollection<Site>();
            ListeServices = new ObservableCollection<Service>();


            int service;
            int site;


            if(siteNom != "")
            {
                site = Services.SiteService.Instance.GetId(siteNom);
            }
            else
            {
                site = -1;
            }
            if(serviceNom != "")
            {
                service = Services.ServiceService.Instance.GetId(serviceNom);
            }
            else
            {
                service = -1;
            }
            

            //Dans la liste on met tout les items de la liste brute dans l'observable

            if (nom != "" &&  site != -1 && service != -1 )
            {
                foreach (Salarie item in lst)
                {
                    if (item.Nom == nom && item.Site == site && item.Service == service)
                    {
                        var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                        ListeSalaries.Add(test);
                    }
                }
            }
            else
            {
                if (nom != "" && site != -1)
                {
                    foreach (Salarie item in lst)
                    {
                        if (item.Nom == nom && item.Site == site)
                        {
                            var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                            ListeSalaries.Add(test);
                        }
                    }
                }
                else
                {
                    if (site != -1 && service != -1)
                    {
                        foreach (Salarie item in lst)
                        {
                            if (item.Site == site && item.Service == service)
                            {
                                var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                                ListeSalaries.Add(test);
                            }
                        }
                    }
                    else
                    {
                        if (nom != "" && service != -1)
                        {
                            foreach (Salarie item in lst)
                            {
                                if (item.Nom == nom && item.Service == service)
                                {
                                    var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                                    ListeSalaries.Add(test);
                                }
                            }
                        }
                        else
                        {
                            if (service != -1)
                            {
                                foreach (Salarie item in lst)
                                {
                                    if (item.Service == service)
                                    {
                                        var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                                        ListeSalaries.Add(test);
                                    }
                                }
                            }
                            else
                            {
                                if (nom != "")
                                {
                                    foreach (Salarie item in lst)
                                    {
                                        if (item.Nom == nom)
                                        {
                                            var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                                            ListeSalaries.Add(test);
                                        }
                                    }
                                }
                                else
                                {
                                    if (site != -1)
                                    {
                                        foreach (Salarie item in lst)
                                        {
                                            if (item.Site == site)
                                            {
                                                var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                                                ListeSalaries.Add(test);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (Salarie item in lst)
                                        {
                                            var test = new Salarie { Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service) };
                                            ListeSalaries.Add(test);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            foreach (Site item in lstSite)
            {
                ListeSites.Add(item);
            }

            foreach (Service item in lstService)
            {
                ListeServices.Add(item);
            }


            //definition de la collection view
            collectionViewSalarie = CollectionViewSource.GetDefaultView(ListeSalaries);
            collectionViewSite = CollectionViewSource.GetDefaultView(ListeSites);
            collectionViewService = CollectionViewSource.GetDefaultView(ListeServices);

            collectionViewSalarie.CurrentChanged += CollectionView_CurrentChanged;
            collectionViewSite.CurrentChanged += CollectionView_CurrentChangedSite;
            collectionViewService.CurrentChanged += CollectionView_CurrentChangedService;
        }

        private void CollectionView_CurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("SalarieSelected");
        }

        private void CollectionView_CurrentChangedSite(object sender, EventArgs e)
        {
            NotifyPropertyChanged("SiteSelected");
        }

        private void CollectionView_CurrentChangedService(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ServiceSelected");
        }


        private ICommand makeAdmin;

        public ICommand MakeAdmin
        {
            get
            {
                if (makeAdmin == null)
                {
                    makeAdmin = new RelayCommand(() =>
                    {
                        Services.UserService.Instance.makeAdmin();
                    });
                }
                return makeAdmin;
            }
        }
    }
}
