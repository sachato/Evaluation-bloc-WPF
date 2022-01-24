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
    class ServiceViewModel : ViewModelBase
    {
        public ObservableCollection<Service> ListeServices { get; }
        private readonly ICollectionView collectionViewService;
        public Service ServiceSelected
        {
            get
            {
                return (Service)collectionViewService.CurrentItem;
                //return collectionViewSalarie.CurrentItem as contact;
            }
        }

        public ServiceViewModel()
        {
            //on recupere la liste brute de modele
            List<Service> lstService = Services.ServiceService.Instance.ChargerService();


            //on initialise l'observable
            ListeServices = new ObservableCollection<Service>();


            foreach (Service item in lstService)
            {
                ListeServices.Add(item);
            }


            //definition de la collection view
            collectionViewService = CollectionViewSource.GetDefaultView(ListeServices);

            collectionViewService.CurrentChanged += CollectionView_CurrentChangedService;
        }

        private void CollectionView_CurrentChangedService(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ServiceSelected");
        }

        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(() => {
                        Services.ServiceService.Instance.Enregistrer(ServiceSelected);
                        //Mise a jour de la liste de contact
                        NotifyPropertyChanged("ListService");
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
                        bool check = Services.ServiceService.Instance.Delete(ServiceSelected);
                        //Mise a jour de la liste de contact
                        if (check)
                        {
                            ListeServices.Remove(ServiceSelected);
                            NotifyPropertyChanged("ListService");
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
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(() =>
                    {
                        //creation du nouveau client
                        Service newservice = new Service();
                        //L'ajouter a la liste
                        ListeServices.Add(newservice);
                        //avertir la vue que la liste a changée
                        NotifyPropertyChanged("ListeService");
                        //placement sur le client qui viens d'etre cree
                        collectionViewService.MoveCurrentToLast();
                    });
                }
                return newCommand;
            }

        }


    }
}