using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PedroLamas.Vencimento.Model;

namespace PedroLamas.Vencimento.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.RegisterWithCheck<INavigationService, NavigationService>();
            SimpleIoc.Default.RegisterWithCheck<IStorageService, StorageService>();
            SimpleIoc.Default.RegisterWithCheck<IWebBrowserService, WebBrowserService>();
            SimpleIoc.Default.RegisterWithCheck<IMarketplaceReviewService, MarketplaceReviewService>();
            SimpleIoc.Default.RegisterWithCheck<IMarketplaceSearchService, MarketplaceSearchService>();
            SimpleIoc.Default.RegisterWithCheck<IShareLinkService, ShareLinkService>();
            SimpleIoc.Default.RegisterWithCheck<IEmailComposeService, EmailComposeService>();
            SimpleIoc.Default.RegisterWithCheck<IMessageBoxService, MessageBoxService>();
            SimpleIoc.Default.RegisterWithCheck<IApplicationSettingsService, ApplicationSettingsService>();
            SimpleIoc.Default.RegisterWithCheck<ISystemTrayService, SystemTrayService>();

            SimpleIoc.Default.RegisterWithCheck<IDataModel, DataModel>();
            SimpleIoc.Default.RegisterWithCheck<IMainModel, MainModel>();

            SimpleIoc.Default.RegisterWithCheck<MainViewModel>();
            SimpleIoc.Default.RegisterWithCheck<EditViewModel>();
            //SimpleIoc.Default.RegisterWithCheck<ResultsViewModel>();
            SimpleIoc.Default.RegisterWithCheck<AboutViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public EditViewModel Edit
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditViewModel>();
            }
        }

        //public ResultsViewModel Results
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<ResultsViewModel>();
        //    }
        //}

        //public AboutViewModel About
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<AboutViewModel>();
        //    }
        //}

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

    public static class ExtensionMethods
    {
        public static void RegisterWithCheck<TInterface, TClass>(this SimpleIoc ioc)
            where TInterface : class
            where TClass : class
        {
            if (!ioc.IsRegistered<TInterface>())
            {
                ioc.Register<TInterface, TClass>();
            }
        }

        public static void RegisterWithCheck<TClass>(this SimpleIoc ioc)
            where TClass : class
        {
            if (!ioc.IsRegistered<TClass>())
            {
                ioc.Register<TClass>();
            }
        }
    }
}