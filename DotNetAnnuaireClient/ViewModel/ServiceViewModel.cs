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
    internal class ServiceViewModel : ViewModelBase
    {
        private ObservableCollection<Service> _ServicesList;

        private bool _visibilityMenu;
        private Service _selectService;

        #region "Property"

        public ObservableCollection<Service> ServicesList
        {
            get { return _ServicesList; }
            set { SetProperty(ref _ServicesList, value); }
        }

        public bool VisibilityMenu
        {
            get { return _visibilityMenu; }
            set { SetProperty(ref _visibilityMenu, value); }
        }

        public Service SelectService
        {
            get { return _selectService; }
            set { SetProperty(ref _selectService, value); }
        }

        #endregion

        public ServiceViewModel ()
        {
            VisibleModalDroiteCommand = new ViewModelCommand<Service>(ExecuteVisibleModalDroiteCommand);
            UnvisibleModalDroiteCommand = new ViewModelCommand<object>(ExecuteUnvisibleModalDroiteCommand);

            SaveServiceCommand = new ViewModelCommand<object>(ExecuteSaveServiceCommand, CanExecuteSaveServiceCommand);
            CreateServiceCommand = new ViewModelCommand<object>(ExecuteCreateServiceCommand);
            SaveNewServiceCommand = new ViewModelCommand<object>(ExecuteSaveNewServiceCommand);
            AddServiceCommand = new ViewModelCommand<object>(ExecuteAddServiceCommand);
            DeleteServiceCommand = new ViewModelCommand<Service>(ExecuteDeleteServiceCommand);

            RefreshService = new ViewModelCommand<object>(ExecuteRefreshServiceCommand);
            GetServices();
        }


        #region "Get"

        private async void GetServices()
        {
            ServicesList = new ObservableCollection<Service>();
            var content = await ModeCommun.client.GetStringAsync("Service");
            ServicesList = new ObservableCollection<Service>(JsonConvert.DeserializeObject<List<Service>>(content));

        }


        #endregion


        #region "Command"

        public ICommand VisibleModalDroiteCommand { get; }
        private void ExecuteVisibleModalDroiteCommand(Service obj)
        {
            SelectService = obj;
            VisibilityMenu = true;
        }


        public ICommand DeleteServiceCommand { get; }
        private async void ExecuteDeleteServiceCommand(Service obj)
        {
            SelectService = obj;
            if (MessageBox.Show("Are you sure you want to delete this service?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                var response = await ModeCommun.client.DeleteAsync("Service/" + SelectService.Id);
                ServicesList.Remove(SelectService);
            }
        }


        public ICommand UnvisibleModalDroiteCommand { get; }
        private void ExecuteUnvisibleModalDroiteCommand(object obj)
        {
            VisibilityMenu = false;
        }


        public ICommand SaveServiceCommand { get; }
        private async void ExecuteSaveServiceCommand(object obj)
        {
            if (SelectService.Id == 0)
            {
                var response = await ModeCommun.client.PostAsJsonAsync("Service", SelectService);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    GetServices();
                    VisibilityMenu = false;
                }

            }
            else
            {

                var response = await ModeCommun.client.PutAsJsonAsync("Service/" + SelectService.Id, SelectService);
                GetServices();
                VisibilityMenu = false;
            }
        }
        private bool CanExecuteSaveServiceCommand(object obj)
        {
            if (SelectService != null)
            {
                bool validData;
                if (SelectService.Nom == null)
                    validData = false;
                else
                    if (SelectService.Nom.Length > 0)
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


        public ICommand CreateServiceCommand { get; }
        private async void ExecuteCreateServiceCommand(object obj)
        {
            SelectService = new Service();
            VisibilityMenu = true;
        }


        public ICommand SaveNewServiceCommand { get; }
        private async void ExecuteSaveNewServiceCommand(object obj)
        {
            SelectService = new Service();
            VisibilityMenu = true;
        }


        public ICommand AddServiceCommand { get; }
        private async void ExecuteAddServiceCommand(object obj)
        {
            SelectService = new Service();
            VisibilityMenu = true;
        }

        public ICommand RefreshService { get; }
        public async void ExecuteRefreshServiceCommand(object obj)
        {
            GetServices();
        }

        #endregion


    }
}
