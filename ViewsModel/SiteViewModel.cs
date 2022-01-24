using Evaluation_bloc.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Evaluation_bloc.ViewsModel
{
    class SiteViewModel : ViewModelBase
    {
        public ObservableCollection<Site> ListeSites { get; }
        private readonly ICollectionView collectionViewSite;
        public Site SiteSelected
        {
            get
            {
                return (Site)collectionViewSite.CurrentItem;
                //return collectionViewSalarie.CurrentItem as contact;
            }
        }

        public SiteViewModel()
        {
            //on recupere la liste brute de modele
            List<Site> lstSite = Services.SiteService.Instance.ChargerSites();


            //on initialise l'observable
            ListeSites = new ObservableCollection<Site>();
            
            //creation de la liste de Site
            foreach (Site item in lstSite)
            {
                ListeSites.Add(item);
            }

           
            //definition de la collection view
            collectionViewSite = CollectionViewSource.GetDefaultView(ListeSites);

            collectionViewSite.CurrentChanged += CollectionView_CurrentChangedSite;
        }

        private void CollectionView_CurrentChangedSite(object sender, EventArgs e)
        {
            NotifyPropertyChanged("SiteSelected");
        }



        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {

                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(() => {
                        Services.SiteService.Instance.Enregistrer(SiteSelected);
                        //Mise a jour de la liste de contact
                        NotifyPropertyChanged("ListSite");
                    });
                }
                return saveCommand;
            }
        }

        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(() => {
                        bool check = Services.SiteService.Instance.Delete(SiteSelected);
                        //Mise a jour de la liste de contact
                        if (check)
                        {
                            ListeSites.Remove(SiteSelected);
                            NotifyPropertyChanged("ListSite");
                        }
                    });
                }
                return deleteCommand;
            }
        }

        private ICommand newCommand;
        public ICommand NewCommand
        {
            get
            {
                if(newCommand == null)
                {
                    newCommand = new RelayCommand(() =>
                    {
                        //creation du nouveau client
                        Site newsite = new Site();
                        //L'ajouter a la liste
                        ListeSites.Add(newsite);
                        //avertir la vue que la liste a changée
                        NotifyPropertyChanged("ListeSite");
                        //placement sur le client qui viens d'etre cree
                        collectionViewSite.MoveCurrentToLast();
                    });
                }
                return newCommand;
            }
            
        }


    }
}
