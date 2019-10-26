using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using PedroLamas.Vencimento.Model;

namespace PedroLamas.Vencimento.ViewModel
{
    public class SimulationViewModel : ViewModelBase
    {
        private readonly IDataModel _dataModel;

        private SimulationModel _model;

        #region Properties

        public SimulationModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model == value) return;

                _model = value;

                RaisePropertyChanged(() => Model);
                RaisePropertyChanged(() => Description);
            }
        }

        public string Description
        {
            get
            {
                return _model.MonthlyBaseIncome.ToString("C");
            }
        }

        #endregion

        public SimulationViewModel(IDataModel dataModel, SimulationModel model)
        {
            _dataModel = dataModel;

            Model = model;
        }
    }
}