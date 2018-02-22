using GalaSoft.MvvmLight;
using Modo.Data;
using Modo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modo.ViewModel
{
    public class DetailViewModel :ViewModelBase
    {
        public Work Todo
        {
            set
            {
                _todo = value;
                // 코드
            }
        }

        private Work _todo;

        private IWorkRepository _workRepository;

        public DetailViewModel(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }
    }
}
