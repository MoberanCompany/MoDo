using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Modo.Message;
using Modo.Data;
using Modo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Modo.ViewModel
{
    public class DetailViewModel :ViewModelBase
    {
        private IWorkRepository _workRepository;
        public DetailViewModel(IWorkRepository workRepository)
        {
            _workRepository = workRepository;            
        }

        private bool _isEditable;
        public bool IsEditable
        {
            get { return Todo.CompleteTime == null; }
        }

        private Work _todo;
        public Work Todo
        {
            get { return _todo; }
            set { Set(ref _todo, value); }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(async () =>
                {
                    var dialog = new MessageDialog("Delete?");

                    dialog.Commands.Add(new UICommand("Yes") { Id = 0 });
                    dialog.Commands.Add(new UICommand("No") { Id = 1 });
                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;
                    var result = await dialog.ShowAsync();

                    if ((int)result.Id == 0)
                    {
                        _workRepository.DeleteWork(Todo);
                        Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.List, IsTop = true });
                    }                    
                }));
            }
        }
        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(() =>
                {
                    _workRepository.UpdateWork(Todo);
                    Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.List, IsTop = true });
                }));
            }
        }
        private ICommand _completeCommand;
        public ICommand CompleteCommand
        {
            get
            {
                return _completeCommand ?? (_completeCommand = new RelayCommand(() =>
                {
                    Todo.CompleteTime = new DateTime();
                    _workRepository.UpdateWork(Todo);
                    Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.List, IsTop = true });
                }));
            }
        }
    }
}
