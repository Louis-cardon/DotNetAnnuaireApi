﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using DotNetAnnuaireClient;
using Newtonsoft.Json;

namespace DotNetAnnuaireClient.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        private SalarieViewModel _salarieDataContext;
        public SalarieViewModel SalarieDataContext
        {
            get { return _salarieDataContext; }
            set { SetProperty(ref _salarieDataContext, value); }
        }

        private ServiceViewModel _serviceDataContext;
        public ServiceViewModel ServiceDataContext
        {
            get { return _serviceDataContext; }
            set { SetProperty(ref _serviceDataContext, value); }
        }

        private SiteViewModel _siteDataContext;
        public SiteViewModel SiteDataContext
        {
            get { return _siteDataContext; }
            set { SetProperty(ref _siteDataContext, value); }
        }

        //private UserListViewModel _userListDataContext;
        //public UserListViewModel UserListDataContext
        //{
        //    get { return _userListDataContext; }
        //    set { SetProperty(ref _userListDataContext, value); }
        //}

        //private GestionStockViewModel _gestionStockDataContext;
        //public GestionStockViewModel GestionStockDataContext
        //{
        //    get { return _gestionStockDataContext; }
        //    set { SetProperty(ref _gestionStockDataContext, value); }
        //}

        //private ImageListViewModel _imageDataContext;
        //public ImageListViewModel ImageDataContext
        //{
        //    get { return _imageDataContext; }
        //    set { SetProperty(ref _imageDataContext, value); }
        //}

        //private OrderListViewModel _orderListDataContext;
        //public OrderListViewModel OrderListDataContext
        //{
        //    get { return _orderListDataContext; }
        //    set { SetProperty (ref _orderListDataContext , value); }
        //}

        //private ProviderOrderListViewModel _providerOrderListDataContext;
        //public ProviderOrderListViewModel ProviderOrderListDataContext
        //{
        //    get { return _providerOrderListDataContext; }
        //    set { SetProperty (ref _providerOrderListDataContext , value); }
        //}

        private int _indexTabItem;
        public int IndexTabItem
        {
            get { return _indexTabItem; }
            set { 
                SetProperty (ref _indexTabItem , value);
                switch (_indexTabItem)
                {
                    case 0:
                        SalarieDataContext.ExecuteRefreshSalarieCommand(null);
                        break;
                    case 1:
                        ServiceDataContext.ExecuteRefreshServiceCommand(null);
                        break;
                    case 2:
                        SiteDataContext.ExecuteRefreshSiteCommand(null);
                        break;
                    //case 3:
                    //    UserListDataContext.ExecuteRefreshUserCommand(null);
                    //    break;
                    //case 4:
                    //    OrderListDataContext.ExecuteRefreshOrderCommand(null);
                    //    break;
                    //case 5:
                    //    ProviderOrderListDataContext.ExecuteRefreshOrderCommand(null);
                    //    break;
                    //case 6:
                    //    GestionStockDataContext.GetArticles();
                    //    break;
                    //case 7:
                    //    ImageDataContext.ExecuteRefreshImageCommand(null);
                    //    break;
                }
            }
        }
        public MainWindowViewModel()
        {  
            SalarieDataContext = new SalarieViewModel();
            ServiceDataContext = new ServiceViewModel();
            SiteDataContext = new SiteViewModel();
            //GestionStockDataContext = new GestionStockViewModel();
            //ProviderListDataContext = new ProviderListViewModel();
            //OrderListDataContext = new OrderListViewModel();
            //ImageDataContext = new ImageListViewModel();
            //ProviderOrderListDataContext = new ProviderOrderListViewModel();
        }
    }
}
