using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace DotNetAnnuaireClient.ViewModel
{
    internal class SalarieViewModel : ViewModelBase
    {
        private ObservableCollection<Salarie> _salariesList;

        private bool _visibilityMenu;
        private Salarie _selectSalarie;

        #region "Property"

        public ObservableCollection<Salarie> SalariesList
        {
            get { return _salariesList; }
            set { SetProperty(ref _salariesList, value); }
        }

        public bool VisibilityMenu
        {
            get { return _visibilityMenu; }
            set { SetProperty(ref _visibilityMenu, value); }
        }

        public Salarie SelectSalarie
        {
            get { return _selectSalarie; }
            set { SetProperty(ref _selectSalarie, value); }
        }

        #endregion

        public SalarieViewModel()
        {
            VisibleModalDroiteCommand = new ViewModelCommand<Salarie>(ExecuteVisibleModalDroiteCommand);
            UnvisibleModalDroiteCommand = new ViewModelCommand<object>(ExecuteUnvisibleModalDroiteCommand);

            SaveSalarieCommand = new ViewModelCommand<object>(ExecuteSaveSalarieCommand, CanExecuteSaveSalarieCommand);
            CreateSalarieCommand = new ViewModelCommand<object>(ExecuteCreateSalarieCommand);
            SaveNewSalarieCommand = new ViewModelCommand<object>(ExecuteSaveNewSalarieCommand);
            AddSalarieCommand = new ViewModelCommand<object>(ExecuteAddSalarieCommand);
            DeleteSalarieCommand = new ViewModelCommand<Salarie>(ExecuteDeleteSalarieCommand);

            RefreshSalarie = new ViewModelCommand<object>(ExecuteRefreshSalarieCommand);
            GetSalaries();
        }


        #region "Get"

        private async void GetSalaries()
        {
            SalariesList = new ObservableCollection<Salarie>();
            var content = await ModeCommun.client.GetStringAsync("Salarie");
            SalariesList = new ObservableCollection<Salarie>(JsonConvert.DeserializeObject<List<Salarie>>(content));

        }


        #endregion


        #region "Command"

        public ICommand VisibleModalDroiteCommand { get; }
        private void ExecuteVisibleModalDroiteCommand(Salarie obj)
        {
            SelectSalarie = obj;
            VisibilityMenu = true;
        }


        public ICommand DeleteSalarieCommand { get; }
        private async void ExecuteDeleteSalarieCommand(Salarie obj)
        {
            SelectSalarie = obj;
            if (MessageBox.Show("Are you sure you want to delete this salarie?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                var response = await ModeCommun.client.DeleteAsync("salarie/" + SelectSalarie.Id);
                SalariesList.Remove(SelectSalarie);
            }
        }


        public ICommand UnvisibleModalDroiteCommand { get; }
        private void ExecuteUnvisibleModalDroiteCommand(object obj)
        {
            VisibilityMenu = false;
        }


        public ICommand SaveSalarieCommand { get; }
        private async void ExecuteSaveSalarieCommand(object obj)
        {
            if (SelectSalarie.Id == 0)
            {
                var response = await ModeCommun.client.PostAsJsonAsync("salarie", SelectSalarie);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    GetSalaries();
                    VisibilityMenu = false;
                }

            }
            else
            {

                var response = await ModeCommun.client.PutAsJsonAsync("salarie/" + SelectSalarie.Id, SelectSalarie);
                GetSalaries();
                VisibilityMenu = false;
            }
        }
        private bool CanExecuteSaveSalarieCommand(object obj)
        {
            if (SelectSalarie != null)
            {
                bool validData;
                if (SelectSalarie.Nom == null || SelectSalarie.Prenom == null || SelectSalarie.TelephoneFixe == null || SelectSalarie.TelephonePortable == null || SelectSalarie.Email == null || SelectSalarie.MotDePasse == null || SelectSalarie.SiteId == 0 || SelectSalarie.RoleId == 0 || SelectSalarie.ServiceId == 0)
                    validData = false;
                else
                    if (SelectSalarie.Prenom.Length > 0 && SelectSalarie.Nom.Length > 0 && SelectSalarie.MotDePasse.Length > 0)
                {
                    validData = true;
                }
                else
                {
                    validData = false;
                }
                return validData;
            }
            return false;
        }


        public ICommand CreateSalarieCommand { get; }
        private async void ExecuteCreateSalarieCommand(object obj)
        {
            SelectSalarie = new Salarie();
            VisibilityMenu = true;
        }


        public ICommand SaveNewSalarieCommand { get; }
        private async void ExecuteSaveNewSalarieCommand(object obj)
        {
            SelectSalarie = new Salarie();
            VisibilityMenu = true;
        }


        public ICommand AddSalarieCommand { get; }
        private async void ExecuteAddSalarieCommand(object obj)
        {
            SelectSalarie = new Salarie();
            VisibilityMenu = true;
        }

        public ICommand RefreshSalarie { get; }
        public async void ExecuteRefreshSalarieCommand(object obj)
        {
            GetSalaries();
        }

        #endregion


    }
}
