﻿using GalaSoft.MvvmLight;
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
        public ListViewModel(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public string Title {
            get;
            set;
        }

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
                    this.Title = "";
                }));
            }
        }
        private ICommand _addCommand;
    }
}
