using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using PedroLamas.Vencimento.Model;

namespace PedroLamas.Vencimento.ViewModel
{
    public class ResultsViewModel : ViewModelBase
    {
        private readonly IMainModel _mainModel;
        private readonly IDataModel _dataModel;

        #region Properties


        #endregion

        public ResultsViewModel(IMainModel mainModel, IDataModel dataModel)
        {
            _mainModel = mainModel;
            _dataModel = dataModel;
        }
    }
}