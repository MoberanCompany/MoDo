using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Modo.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Modo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // 메뉴리스트 선택이 변경될 경우
        public int MenuIndex
        {
            get { return _menuIndex; }
            set
            {
                if (Set(ref _menuIndex, value))
                {
                    switch (value)
                    {
                        case 0: Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.List }); break;
                        case 1: Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.Calender }); break;
                        case 2: Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.Setting }); break;
                    }
                }
            }
        }
        private int _menuIndex;

        public bool IsPanOpen
        {
            get { return _isPaneOpen; }
            set { Set(ref _isPaneOpen, value); }
        }
        public bool _isPaneOpen = false;

        public ICommand PaneOpenCommand
        {
            get
            {
                return _paneOpenCommand ?? (_paneOpenCommand = new RelayCommand(() =>
                {
                    IsPanOpen = !IsPanOpen;
                }));
            }
        }
        private ICommand _paneOpenCommand;
    }
}
