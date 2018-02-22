using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Modo.Data;
using Modo.Message;
using Modo.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Modo.ViewModel
{
    public class ListViewModel : ViewModelBase
    {
        private IWorkRepository _workRepository;
        private DetailViewModel _detailVm;
        public ListViewModel(IWorkRepository workRepository, DetailViewModel detailVm)
        {
            _workRepository = workRepository;
            _detailVm = detailVm;
        }

        public List<Work> Todos
        {
            get
            {
                return _workRepository?.GetWorks(IsShowCompleted);
            }
        }

        public Work Todo
        {
            get { return _todo; }
            set
            {
                if (Set(ref _todo, value))
                {
                    if (value != null)
                    {
                        _detailVm.Todo = value;
                        Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.Detail, IsTop = false });
                    }
                }
            }
        }
        private Work _todo;

        public bool IsShowCompleted
        {
            get { return _isShowCompleted; }
            set
            {
                Set(ref _isShowCompleted, value);
                RaisePropertyChanged(() => Todos);
            }
        }
        private bool _isShowCompleted = false;

        /// <summary>
        /// todo 타이틀
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// todo 추가 버튼
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(() =>
                {
                    Work newWork = new Work();
                    newWork.CreateTime = DateTime.Now;
                    newWork.Title = this.Title;
                    var id = _workRepository.InsertWork(newWork);
                    // 토스트
                    ToastService.ShowToastNotification("Modo : 목록이 추가되었습니다.");


                    RaisePropertyChanged(() => Todos);
                }));
            }
        }
        private ICommand _addCommand;


    }

    public class ToastService
    {
        public static void ShowToastNotification(String message)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(message));

            // Set image
            // Images must be less than 200 KB in size and smaller than 1024 x 1024 pixels.
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", "ms-appx:///Assets/Logo.scale-240.png");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "logo");

            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "short");

            // toast navigation
            var toastNavigationUriString = "#/MainPage.xaml?param1=12345";
            var toastElement = ((XmlElement)toastXml.SelectSingleNode("/toast"));
            toastElement.SetAttribute("launch", toastNavigationUriString);

            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
