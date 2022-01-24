using Evaluation_bloc.Model;
using Evaluation_bloc.Services;
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
    class SalarieViewModel : ViewModelBase
    {
        public ObservableCollection<Salarie> ListeSalaries { get; }
        private readonly ICollectionView collectionViewSalarie;
        public Salarie SalarieSelected
        {
            get
            {
                return (Salarie)collectionViewSalarie.CurrentItem;
                //return collectionViewSalarie.CurrentItem as contact;
            }
        }

        public SalarieViewModel()
        {
            //on recupere la liste brute de modele
            List<Salarie> lstSalarie = Services.SalarieService.Instance.ChargerSalarie();


            //on initialise l'observable
            ListeSalaries = new ObservableCollection<Salarie>();


            foreach (Salarie item in lstSalarie)
            {
                    var test = new Salarie {Id = item.Id, Nom = item.Nom, Prenom = item.Prenom, Email = item.Email, TelFixe = item.TelFixe, TelPortable = item.TelPortable, SiteNom = SalarieService.Instance.GetNomSite(item.Site), ServiceNom = SalarieService.Instance.GetNomService(item.Service), Service=item.Service, Site=item.Site};
                    ListeSalaries.Add(test);  
            }


            //definition de la collection view
            collectionViewSalarie = CollectionViewSource.GetDefaultView(ListeSalaries);

            collectionViewSalarie.CurrentChanged += CollectionView_CurrentChangedSite;
        }

        private void CollectionView_CurrentChangedSite(object sender, EventArgs e)
        {
            NotifyPropertyChanged("SalarieSelected");
        }

        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(() => {
                        Services.SalarieService.Instance.Enregistrer(SalarieSelected);
                        //Mise a jour de la liste de contact
                        NotifyPropertyChanged("ListSalarie");
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
                        bool check = Services.SalarieService.Instance.Delete(SalarieSelected);
                        //Mise a jour de la liste de contact
                        if (check)
                        {
                            ListeSalaries.Remove(SalarieSelected);
                            NotifyPropertyChanged("ListSalarie");
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
                        Salarie newsalarie = new Salarie();
                        //L'ajouter a la liste
                        ListeSalaries.Add(newsalarie);
                        //avertir la vue que la liste a changée
                        NotifyPropertyChanged("ListeSalarie");
                        //placement sur le client qui viens d'etre cree
                        collectionViewSalarie.MoveCurrentToLast();
                    });
                }
                return newCommand;
            }

        }


    }
}