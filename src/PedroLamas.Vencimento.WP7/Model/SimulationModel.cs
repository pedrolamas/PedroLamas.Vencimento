using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace PedroLamas.Vencimento.Model
{
    public class SimulationModel : ObservableObject
    {
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

        public double MonthlyBaseIncome
        {
            get
            {
                return _monthlyBaseIncome;
            }
            set
            {
                if (_monthlyBaseIncome == value) return;

                _monthlyBaseIncome = value;

                RaisePropertyChanged(() => MonthlyBaseIncome);
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
                if (_year == value) return;

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
                if (_fiscalResidence == value) return;

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
                if (_regime == value) return;

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
                if (_maritalState == value) return;

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
                if (_dependent == value) return;

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
                if (_socialSecurityRegime == value) return;

                _socialSecurityRegime = value;

                RaisePropertyChanged(() => SocialSecurityRegime);
            }
        }

        public double DailyLunchAllowance
        {
            get
            {
                return _dailyLunchAllowance;
            }
            set
            {
                if (_dailyLunchAllowance == value) return;

                _dailyLunchAllowance = value;

                RaisePropertyChanged(() => DailyLunchAllowance);
            }
        }

        public int WorkingDays
        {
            get
            {
                return _workingDays;
            }
            set
            {
                if (_workingDays == value) return;

                _workingDays = value;

                RaisePropertyChanged(() => WorkingDays);
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
                if (_christmasVacationsAllowancesInTwelfths == value) return;

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
                if (_christmasOvertaxed == value) return;

                _christmasOvertaxed = value;

                RaisePropertyChanged(() => ChristmasOvertaxed);
            }
        }

        #endregion
    }

    public class SimulationModel2
    {
        #region Properties

        public double MonthlyBaseIncome { get; set; }

        public int YearId { get; set; }

        public int FiscalResidenceId { get; set; }

        public int RegimeId { get; set; }

        public int MaritalStateId { get; set; }

        public int DependentId { get; set; }

        public int SocialSecurityRegimeId { get; set; }

        public double DailyLunchAllowance { get; set; }

        public int WorkingDays { get; set; }

        public bool ChristmasVacationsAllowancesInTwelfths { get; set; }

        public bool ChristmasOvertaxed { get; set; }

        #endregion

        public SimulationModel2 Clone()
        {
            return new SimulationModel2()
            {
                MonthlyBaseIncome = this.MonthlyBaseIncome,
                FiscalResidenceId = this.FiscalResidenceId,
                RegimeId = this.RegimeId,
                MaritalStateId = this.MaritalStateId,
                DependentId = this.DependentId,
                SocialSecurityRegimeId = this.SocialSecurityRegimeId,
                DailyLunchAllowance = this.DailyLunchAllowance,
                WorkingDays = this.WorkingDays,
                ChristmasVacationsAllowancesInTwelfths = this.ChristmasVacationsAllowancesInTwelfths,
                ChristmasOvertaxed = this.ChristmasOvertaxed
            };
        }
    }
}