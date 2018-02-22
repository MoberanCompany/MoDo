using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Modo.Data;
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
                return _workRepository?.GetWorks();
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
                    int newWorkId = -1;
                    Work newWork = new Work();
                    newWork.CreateTime = DateTime.Now;
                    newWork.Title = this.Title;
                    var id = _workRepository.InsertWork(newWork);
                    // 추가 기능
                    //Messenger.Default.Send(new MovePage { SourcePageType = SourcePage.Detail, IsTop = false });
                }));
            }
        }
        private ICommand _addCommand;


    }
}
