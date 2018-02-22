using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Modo.Data;
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
        private IWorkRepository _workRepository;
        public SettingViewModel(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public ICommand InitCommand
        {
            get
            {
                return _initCommand ?? (_initCommand = new RelayCommand(async () =>
                {
                    var dialog = new MessageDialog("모든 데이터가 삭제됩니다. \n그래도 삭제하시겠습니까?");

                    dialog.Commands.Add(new UICommand("네") { Id = 0 });
                    dialog.Commands.Add(new UICommand("아니요") { Id = 1 });
                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;
                    var result = await dialog.ShowAsync();

                    if ((int)result.Id == 0)
                    {
                        //do your task 
                        _workRepository.Reset();
                    }
                    else
                    {
                        //skip your task 
                    }
                }));
            }
        }
        private ICommand _initCommand;

        
    }
}
