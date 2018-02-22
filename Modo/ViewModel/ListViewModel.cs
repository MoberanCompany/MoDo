using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Modo.Message;
using Modo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Modo.ViewModel
{
    public class ListViewModel : ViewModelBase
    {
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(() =>
                {
                    Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.Detail, IsTop = false });
                }));
            }
        }
        private ICommand _addCommand;
    }
}
