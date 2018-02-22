using GalaSoft.MvvmLight.Messaging;
using Modo.Helper;
using Modo.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace Modo.View
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Messenger.Default.Register<MovePage>(this, (msg) =>
            {
                Type type = null;

                switch (msg.SourcePageType)
                {
                    case SourcePage.List: type = typeof(ListPage); break;
                    case SourcePage.Calender: type = typeof(CalenderPage); break;
                    case SourcePage.Setting: type = typeof(SettingPage); break;
                    case SourcePage.Detail: type = typeof(DetailPage); break;
                }

                if (type == null) return;

                if (msg.IsTop)
                {
                    MainContent.BackStack.Clear();
                }

                MainContent.Navigate(type);


                checkBackButtonVisivility();
            });

            SystemNavigationManager.GetForCurrentView().BackRequested += BackButtonPage_BackRequested;
        }

        private void BackButtonPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (MainContent.CanGoBack)
            {
                e.Handled = true;
                MainContent.GoBack();
            }

            checkBackButtonVisivility();
        }

        private void checkBackButtonVisivility()
        {
            if (MainContent.BackStack.Count > 1)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
    }
}
