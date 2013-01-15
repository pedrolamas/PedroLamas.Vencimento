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

            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IWebBrowserService, WebBrowserService>();
            SimpleIoc.Default.Register<IMarketplaceReviewService, MarketplaceReviewService>();
            SimpleIoc.Default.Register<IMarketplaceSearchService, MarketplaceSearchService>();
            SimpleIoc.Default.Register<IShareLinkService, ShareLinkService>();
            SimpleIoc.Default.Register<IEmailComposeService, EmailComposeService>();
            SimpleIoc.Default.Register<IMessageBoxService, MessageBoxService>();
            SimpleIoc.Default.Register<IApplicationSettingsService, ApplicationSettingsService>();
            SimpleIoc.Default.Register<ISystemTrayService, SystemTrayService>();

            SimpleIoc.Default.Register<IMainModel, MainModel>();

            //SimpleIoc.Default.RegisterWithCheck<MainViewModel>();
            //SimpleIoc.Default.RegisterWithCheck<ResultsViewModel>();
            //SimpleIoc.Default.RegisterWithCheck<AboutViewModel>();
        }

        //public MainViewModel Main
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<MainViewModel>();
        //    }
        //}

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
}