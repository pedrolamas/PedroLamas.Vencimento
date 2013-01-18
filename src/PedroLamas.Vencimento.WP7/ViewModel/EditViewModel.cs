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

        private double _monthlyBaseIncome;
        private IrsYear _year;
        private IrsFiscalResidence _fiscalResidence;
        private IrsRegime _regime;
        private IrsMaritalState _maritalState;
        private IrsDependent _dependent;
        private SocialSecurityRegime _socialSecurityRegime;
        private double _dailyLunchAllowance;
        private int _workingDays;
        private bool _christmasVacationsAllowancesInTwelfths;
        private bool _christmasOvertaxed;

        #region Properties

        //public SimulationModel2 Model
        //{
        //    get
        //    {
        //        return _mainModel.SelectedSimulation;
        //    }
        //}

        public string MonthlyBaseIncome
        {
            get
            {
                return _monthlyBaseIncome.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                double monthlyBaseIncome;

                if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out monthlyBaseIncome))
                {
                    if (_monthlyBaseIncome == monthlyBaseIncome)
                        return;

                    _monthlyBaseIncome = monthlyBaseIncome;

                    RaisePropertyChanged(() => MonthlyBaseIncome);
                }
            }
        }

        public IrsYear Year
        {
            get
            {
                return _year;
            }
            set
            {
                if (_year == value)
                    return;

                _year = value;

                RaisePropertyChanged(() => Year);
            }
        }

        public IrsFiscalResidence FiscalResidence
        {
            get
            {
                return _fiscalResidence;
            }
            set
            {
                if (_fiscalResidence == value)
                    return;

                _fiscalResidence = value;

                RaisePropertyChanged(() => FiscalResidence);
            }
        }

        public IrsRegime Regime
        {
            get
            {
                return _regime;
            }
            set
            {
                if (_regime == value)
                    return;

                _regime = value;

                RaisePropertyChanged(() => Regime);
            }
        }

        public IrsMaritalState MaritalState
        {
            get
            {
                return _maritalState;
            }
            set
            {
                if (_maritalState == value)
                    return;

                _maritalState = value;

                RaisePropertyChanged(() => MaritalState);
            }
        }

        public IrsDependent Dependent
        {
            get
            {
                return _dependent;
            }
            set
            {
                if (_dependent == value)
                    return;

                _dependent = value;

                RaisePropertyChanged(() => Dependent);
            }
        }

        public SocialSecurityRegime SocialSecurityRegime
        {
            get
            {
                return _socialSecurityRegime;
            }
            set
            {
                if (_socialSecurityRegime == value)
                    return;

                _socialSecurityRegime = value;

                RaisePropertyChanged(() => SocialSecurityRegime);
            }
        }

        public string DailyLunchAllowance
        {
            get
            {
                return _dailyLunchAllowance.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                double dailyLunchAllowance;

                if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out dailyLunchAllowance))
                {
                    if (_dailyLunchAllowance == dailyLunchAllowance)
                        return;

                    _dailyLunchAllowance = dailyLunchAllowance;

                    RaisePropertyChanged(() => DailyLunchAllowance);
                }
            }
        }

        public string WorkingDays
        {
            get
            {
                return _workingDays.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                int workingDays;

                if (int.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out workingDays))
                {
                    if (_workingDays == workingDays)
                        return;

                    _workingDays = workingDays;

                    RaisePropertyChanged(() => WorkingDays);
                }
            }
        }

        public bool ChristmasVacationsAllowancesInTwelfths
        {
            get
            {
                return _christmasVacationsAllowancesInTwelfths;
            }
            set
            {
                if (_christmasVacationsAllowancesInTwelfths == value)
                    return;

                _christmasVacationsAllowancesInTwelfths = value;

                RaisePropertyChanged(() => ChristmasVacationsAllowancesInTwelfths);
            }
        }

        public bool ChristmasOvertaxed
        {
            get
            {
                return _christmasOvertaxed;
            }
            set
            {
                if (_christmasOvertaxed == value)
                    return;

                _christmasOvertaxed = value;

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
                MessengerInstance.Send(new SimulationChangedMessage());

                _navigationService.GoBack();
            });

            PageLoadedCommand = new RelayCommand(() =>
            {
                var simulation = _mainModel.SelectedSimulation;

                if (simulation == null )
                {

                }
                else
                {
                    MonthlyBaseIncome = simulation.MonthlyBaseIncome;
                }
            });
        }
    }
}