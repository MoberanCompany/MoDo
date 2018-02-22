using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Modo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modo.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<CalenderViewModel>();
            SimpleIoc.Default.Register<ListViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
            SimpleIoc.Default.Register<DetailViewModel>();

            SimpleIoc.Default.Register<IWorkRepository, SqLiteWorkRepository>();
        }

        public CalenderViewModel CalenderPage { get { return ServiceLocator.Current.GetInstance<CalenderViewModel>(); } }

        public ListViewModel ListPage { get { return ServiceLocator.Current.GetInstance<ListViewModel>(); } }

        public MainViewModel MainPage { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }

        public SettingViewModel SettingPage { get { return ServiceLocator.Current.GetInstance<SettingViewModel>(); } }

        public DetailViewModel DetailPage { get { return ServiceLocator.Current.GetInstance<DetailViewModel>(); } }
    }
}
