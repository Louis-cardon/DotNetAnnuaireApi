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
    internal class SiteViewModel : ViewModelBase
    {
        private ObservableCollection<Site> _SitesList;

        private bool _visibilityMenu;
        private Site _selectSite;

        #region "Property"

        public ObservableCollection<Site> SitesList
        {
            get { return _SitesList; }
            set { SetProperty(ref _SitesList, value); }
        }

        public bool VisibilityMenu
        {
            get { return _visibilityMenu; }
            set { SetProperty(ref _visibilityMenu, value); }
        }

        public Site SelectSite
        {
            get { return _selectSite; }
            set { SetProperty(ref _selectSite, value); }
        }

        #endregion

        public SiteViewModel()
        {
            VisibleModalDroiteCommand = new ViewModelCommand<Site>(ExecuteVisibleModalDroiteCommand);
            UnvisibleModalDroiteCommand = new ViewModelCommand<object>(ExecuteUnvisibleModalDroiteCommand);

            SaveSiteCommand = new ViewModelCommand<object>(ExecuteSaveSiteCommand, CanExecuteSaveSiteCommand);
            CreateSiteCommand = new ViewModelCommand<object>(ExecuteCreateSiteCommand);
            SaveNewSiteCommand = new ViewModelCommand<object>(ExecuteSaveNewSiteCommand);
            AddSiteCommand = new ViewModelCommand<object>(ExecuteAddSiteCommand);
            DeleteSiteCommand = new ViewModelCommand<Site>(ExecuteDeleteSiteCommand);

            RefreshSite = new ViewModelCommand<object>(ExecuteRefreshSiteCommand);
            GetSites();
        }


        #region "Get"

        private async void GetSites()
        {
            SitesList = new ObservableCollection<Site>();
            var content = await ModeCommun.client.GetStringAsync("Site");
            SitesList = new ObservableCollection<Site>(JsonConvert.DeserializeObject<List<Site>>(content));

        }


        #endregion


        #region "Command"

        public ICommand VisibleModalDroiteCommand { get; }
        private void ExecuteVisibleModalDroiteCommand(Site obj)
        {
            SelectSite = obj;
            VisibilityMenu = true;
        }


        public ICommand DeleteSiteCommand { get; }
        private async void ExecuteDeleteSiteCommand(Site obj)
        {
            SelectSite = obj;
            if (MessageBox.Show("Are you sure you want to delete this Site?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                var response = await ModeCommun.client.DeleteAsync("Site/" + SelectSite.Id);
                SitesList.Remove(SelectSite);
            }
        }


        public ICommand UnvisibleModalDroiteCommand { get; }
        private void ExecuteUnvisibleModalDroiteCommand(object obj)
        {
            VisibilityMenu = false;
        }


        public ICommand SaveSiteCommand { get; }
        private async void ExecuteSaveSiteCommand(object obj)
        {
            if (SelectSite.Id == 0)
            {
                var response = await ModeCommun.client.PostAsJsonAsync("Site", SelectSite);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    GetSites();
                    VisibilityMenu = false;
                }

            }
            else
            {

                var response = await ModeCommun.client.PutAsJsonAsync("Site/" + SelectSite.Id, SelectSite);
                GetSites();
                VisibilityMenu = false;
            }
        }
        private bool CanExecuteSaveSiteCommand(object obj)
        {
            if (SelectSite != null)
            {
                bool validData;
                if (SelectSite.Ville == null)
                    validData = false;
                else
                    if (SelectSite.Ville.Length > 0)
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


        public ICommand CreateSiteCommand { get; }
        private async void ExecuteCreateSiteCommand(object obj)
        {
            SelectSite = new Site();
            VisibilityMenu = true;
        }


        public ICommand SaveNewSiteCommand { get; }
        private async void ExecuteSaveNewSiteCommand(object obj)
        {
            SelectSite = new Site();
            VisibilityMenu = true;
        }


        public ICommand AddSiteCommand { get; }
        private async void ExecuteAddSiteCommand(object obj)
        {
            SelectSite = new Site();
            VisibilityMenu = true;
        }

        public ICommand RefreshSite { get; }
        public async void ExecuteRefreshSiteCommand(object obj)
        {
            GetSites();
        }

        #endregion
    
    }
}
