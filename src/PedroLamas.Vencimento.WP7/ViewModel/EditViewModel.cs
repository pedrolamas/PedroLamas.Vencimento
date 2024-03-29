﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PedroLamas.Vencimento.Model;

namespace PedroLamas.Vencimento.ViewModel
{
    public class EditViewModel : ViewModelBase
    {
        private readonly IMainModel _mainModel;
        private readonly IDataModel _dataModel;
        private readonly INavigationService _navigationService;

        private SimulationModel _model;

        #region Properties

        public SimulationModel Model
        {
            get
            {
                return _model;
            }
            private set
            {
                if (_model == value)
                    return;

                _model = value;

                RaisePropertyChanged(() => Model);
                RaisePropertyChanged(() => MonthlyBaseIncome);
                RaisePropertyChanged(() => Year);
                RaisePropertyChanged(() => FiscalResidence);
                RaisePropertyChanged(() => Regime);
                RaisePropertyChanged(() => MaritalState);
                RaisePropertyChanged(() => Dependent);
                RaisePropertyChanged(() => SocialSecurityRegime);
                RaisePropertyChanged(() => DailyLunchAllowance);
                RaisePropertyChanged(() => WorkingDays);
                RaisePropertyChanged(() => ChristmasVacationsAllowancesInTwelfths);
                RaisePropertyChanged(() => ChristmasOvertaxed);
            }
        }

        public string MonthlyBaseIncome
        {
            get
            {
                if (_model == null)
                    return null;

                return Model.MonthlyBaseIncome.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                double monthlyGrossIncome;

                if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out monthlyGrossIncome))
                {
                    if (Model.MonthlyBaseIncome == monthlyGrossIncome)
                        return;

                    Model.MonthlyBaseIncome = monthlyGrossIncome;

                    RaisePropertyChanged(() => MonthlyBaseIncome);
                }
            }
        }

        public IrsYear Year
        {
            get
            {
                if (_model == null) 
                    return null;

                return _dataModel.YearList.FirstOrDefault(x => x.Year == Model.YearId);
            }
            set
            {
                var yearId = value == null ? 0 : value.Year;

                if (Model.YearId == yearId)
                    return;

                Model.YearId = yearId;

                RaisePropertyChanged(() => Year);
            }
        }

        public IrsFiscalResidence FiscalResidence
        {
            get
            {
                if (_model == null)
                    return null;

                return _dataModel.FiscalResidenceList.FirstOrDefault(x => x.FiscalResidenceId == Model.FiscalResidenceId);
            }
            set
            {
                var fiscalResidenceId = value == null ? 0 : value.FiscalResidenceId;

                if (Model.FiscalResidenceId == fiscalResidenceId)
                    return;

                Model.FiscalResidenceId = fiscalResidenceId;

                RaisePropertyChanged(() => FiscalResidence);
            }
        }

        public IrsRegime Regime
        {
            get
            {
                if (_model == null)
                    return null;

                return _dataModel.RegimeList.FirstOrDefault(x => x.RegimeId == Model.RegimeId);
            }
            set
            {
                var regimeId = value == null ? 0 : value.RegimeId;

                if (Model.RegimeId == regimeId)
                    return;

                Model.RegimeId = regimeId;

                RaisePropertyChanged(() => Regime);
            }
        }

        public IrsMaritalState MaritalState
        {
            get
            {
                if (_model == null)
                    return null;

                return _dataModel.MaritalStateList.FirstOrDefault(x => x.MaritalStateId == Model.MaritalStateId);
            }
            set
            {
                var maritalStateId = value == null ? 0 : value.MaritalStateId;

                if (Model.MaritalStateId == maritalStateId)
                    return;

                Model.MaritalStateId = maritalStateId;

                RaisePropertyChanged(() => MaritalState);
            }
        }

        public IrsDependent Dependent
        {
            get
            {
                if (_model == null)
                    return null;

                return _dataModel.DependentList.FirstOrDefault(x => x.DependentId == Model.DependentId);
            }
            set
            {
                var dependentId = value == null ? 0 : value.DependentId;

                if (Model.DependentId == dependentId)
                    return;

                Model.DependentId = dependentId;

                RaisePropertyChanged(() => Dependent);
            }
        }

        public SocialSecurityRegime SocialSecurityRegime
        {
            get
            {
                if (_model == null)
                    return null;

                return _dataModel.SocialSecurityRegimeList.FirstOrDefault(x => x.SocialSecurityRegimeId == Model.SocialSecurityRegimeId);
            }
            set
            {
                var socialSecurityRegimeId = value == null ? 0 : value.SocialSecurityRegimeId;

                if (Model.SocialSecurityRegimeId == socialSecurityRegimeId)
                    return;

                Model.SocialSecurityRegimeId = socialSecurityRegimeId;

                RaisePropertyChanged(() => SocialSecurityRegime);
            }
        }

        public string DailyLunchAllowance
        {
            get
            {
                if (_model == null)
                    return null;

                return Model.DailyLunchAllowance.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                double dailyLunchAllowance;

                if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out dailyLunchAllowance))
                {
                    if (Model.DailyLunchAllowance == dailyLunchAllowance)
                        return;

                    Model.DailyLunchAllowance = dailyLunchAllowance;

                    RaisePropertyChanged(() => DailyLunchAllowance);
                }
            }
        }

        public string WorkingDays
        {
            get
            {
                if (_model == null)
                    return null;

                return Model.WorkingDays.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                int workingDays;

                if (int.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out workingDays))
                {
                    if (Model.WorkingDays == workingDays)
                        return;

                    Model.WorkingDays = workingDays;

                    RaisePropertyChanged(() => WorkingDays);
                }
            }
        }

        public bool ChristmasVacationsAllowancesInTwelfths
        {
            get
            {
                if (_model == null)
                    return false;

                return Model.ChristmasVacationsAllowancesInTwelfths;
            }
            set
            {
                if (Model.ChristmasVacationsAllowancesInTwelfths == value)
                    return;

                Model.ChristmasVacationsAllowancesInTwelfths = value;

                RaisePropertyChanged(() => ChristmasVacationsAllowancesInTwelfths);
            }
        }

        public bool ChristmasOvertaxed
        {
            get
            {
                if (_model == null)
                    return false;

                return Model.ChristmasOvertaxed;
            }
            set
            {
                if (Model.ChristmasOvertaxed == value)
                    return;

                Model.ChristmasOvertaxed = value;

                RaisePropertyChanged(() => ChristmasOvertaxed);
            }
        }

        public IEnumerable<IrsYear> YearList
        {
            get
            {
                return _dataModel.YearList;
            }
        }

        public IEnumerable<IrsFiscalResidence> FiscalResidenceList
        {
            get
            {
                return _dataModel.FiscalResidenceList;
            }
        }

        public IEnumerable<IrsRegime> RegimeList
        {
            get
            {
                return _dataModel.RegimeList;
            }
        }

        public IEnumerable<IrsMaritalState> MaritalStateList
        {
            get
            {
                return _dataModel.MaritalStateList;
            }
        }

        public IEnumerable<IrsDependent> DependentList
        {
            get
            {
                return _dataModel.DependentList;
            }
        }

        public IEnumerable<SocialSecurityRegime> SocialSecurityRegimeList
        {
            get
            {
                return _dataModel.SocialSecurityRegimeList;
            }
        }

        public RelayCommand PageLoadedCommand { get; private set; }

        public RelayCommand ConfirmCommand { get; private set; }

        #endregion

        public EditViewModel(IMainModel mainModel, IDataModel dataModel, INavigationService navigationService)
        {
            _mainModel = mainModel;
            _dataModel = dataModel;
            _navigationService = navigationService;

            ConfirmCommand = new RelayCommand(() =>
            {
                MessengerInstance.Send(new SimulationChangedMessage(_mainModel.SelectedSimulation, _model));

                _navigationService.GoBack();
            });

            PageLoadedCommand = new RelayCommand(() =>
            {
                if (_mainModel.SelectedSimulation == null)
                {
                    _model = new SimulationModel();

                    MonthlyBaseIncome = "0";

                    Year = _dataModel.YearList
                        .FirstOrDefault(x => x.Year == DateTime.Today.Year) ?? dataModel.YearList.LastOrDefault();

                    FiscalResidence = dataModel.FiscalResidenceList
                        .FirstOrDefault();

                    Regime = dataModel.RegimeList
                        .FirstOrDefault();

                    MaritalState = dataModel.MaritalStateList
                        .FirstOrDefault();

                    Dependent = dataModel.DependentList
                        .FirstOrDefault();

                    SocialSecurityRegime = dataModel.SocialSecurityRegimeList
                        .FirstOrDefault();

                    DailyLunchAllowance = "0";

                    WorkingDays = "22";

                    ChristmasVacationsAllowancesInTwelfths = false;

                    ChristmasOvertaxed = false;
                }
                else
                {
                    Model = _mainModel.SelectedSimulation.Clone();
                }
            });
        }
    }
}