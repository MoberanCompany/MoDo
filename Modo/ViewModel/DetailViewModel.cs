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

namespace Modo.ViewModel
{
    public class DetailViewModel :ViewModelBase
    {
        private IWorkRepository _workRepository;
        public DetailViewModel(IWorkRepository workRepository)
        {
            _workRepository = workRepository;            
        }

        private Work _todo;
        public Work Todo
        {
            get { return _todo; }
            set
            {
                Set(ref _todo, value);
                // 코드
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(() =>
                {
                    _workRepository.DeleteWork(Todo);
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
                }));
            }
        }
    }
}
