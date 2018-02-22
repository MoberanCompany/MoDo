using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Modo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Modo.ViewModel
{
    public class SettingViewModel : ViewModelBase
    {
        public ICommand InitCommand
        {
            get
            {
                return _initCommand ?? (_initCommand = new RelayCommand(async () =>
                {
                    Messenger.Default.Send(new SetInitCommand() );

                }));
            }
        }
        private ICommand _initCommand;

        
    }
}
