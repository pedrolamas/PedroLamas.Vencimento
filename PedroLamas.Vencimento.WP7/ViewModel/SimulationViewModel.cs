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

        public SimulationModel2 Model { get; private set; }

        public string MonthlyBaseIncome
        {
            get
            {
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

        public SimulationViewModel(IDataModel dataModel, SimulationModel2 model)
        {
            _dataModel = dataModel;

            Model = model;
        }
    }
}