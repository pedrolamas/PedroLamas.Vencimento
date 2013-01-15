using System;
using System.Collections.Generic;
using System.Linq;
using Cimbalino.Phone.Toolkit.Extensions;

namespace PedroLamas.Vencimento.Model
{
    public class MainModel : IMainModel
    {
        private readonly IrsTablesDataContext _dataContext = new IrsTablesDataContext();

        #region Properties

        public IrsYear[] YearList { get; private set; }

        public IrsFiscalResidence[] FiscalResidenceList { get; private set; }

        public IrsRegime[] RegimeList { get; private set; }

        public IrsMaritalState[] MaritalStateList { get; private set; }

        public IrsDependent[] DependentList { get; private set; }

        public SocialSecurityRegime[] SocialSecurityRegimeList { get; private set; }

        public double MonthlyBaseIncome { get; set; }

        public IrsYear Year { get; set; }

        public IrsFiscalResidence FiscalResidence { get; set; }

        public IrsRegime Regime { get; set; }

        public IrsMaritalState MaritalState { get; set; }

        public IrsDependent Dependent { get; set; }

        public SocialSecurityRegime SocialSecurityRegime { get; set; }

        public double DailyLunchAllowance { get; set; }

        public int WorkingDays { get; set; }

        public bool ChristmasVacationsAllowancesInTwelfths { get; set; }

        public bool ChristmasOvertaxed { get; set; }

        public SimulationResultEntry[] MonthlySimulationResult { get; private set; }

        public SimulationResultEntry[] YearlySimulationResult { get; private set; }

        #endregion

        public MainModel()
        {
            YearList = _dataContext.IrsYears
                .ToArray();

            FiscalResidenceList = _dataContext.IrsFiscalResidences
                .ToArray();

            RegimeList = _dataContext.IrsRegimes
                .ToArray();

            MaritalStateList = _dataContext.IrsMaritalStates
                .ToArray();

            DependentList = _dataContext.IrsDependents
                .ToArray();

            SocialSecurityRegimeList = _dataContext.SocialSecurityRegimes
                .ToArray();

            Year = YearList
                .FirstOrDefault(x => x.Year == DateTime.Today.Year) ?? YearList.LastOrDefault();

            FiscalResidence = FiscalResidenceList
                .FirstOrDefault();

            Regime = RegimeList
                .FirstOrDefault();

            MaritalState = MaritalStateList
                .FirstOrDefault();

            Dependent = DependentList
                .FirstOrDefault();

            SocialSecurityRegime = SocialSecurityRegimeList
                .FirstOrDefault();

            WorkingDays = 22;
        }

        public void Simulate()
        {
            var irsTax = GetIrsTax();
            var socialSecurityTax = SocialSecurityRegime.Tax;
            var minimumIncome = 485;
            var dailyLunchAlowance = DailyLunchAllowance;

            var monthlyWorkingDays = WorkingDays;
            var monthlyBaseIncome = MonthlyBaseIncome;
            var monthlyLunchAllowance = dailyLunchAlowance * monthlyWorkingDays;
            var monthlyLunchAllowanceSubjectToTaxes = dailyLunchAlowance > (double)Year.MaxDailyLunchAllowance ? Math.Round(monthlyLunchAllowance * Year.DailyLunchAllowanceTax, 2) : 0;

            var yearlyWorkingDays = monthlyWorkingDays * 12 - 22;
            var yearlyBaseIncome = monthlyBaseIncome * 12;
            var yearlyLunchAllowance = dailyLunchAlowance * yearlyWorkingDays;
            var yearlyLunchAllowanceSubjectToTaxes = dailyLunchAlowance > (double)Year.MaxDailyLunchAllowance ? Math.Round(yearlyLunchAllowance * Year.DailyLunchAllowanceTax, 2) : 0;

            var yearlyChristmasBonusValue = monthlyBaseIncome;
            var yearlyChristmasBonusValueTaxes = 0.0;
            var yearlyVacationsBonusValue = monthlyBaseIncome;

            if (ChristmasOvertaxed)
            {
                var yearlyChritmasBonusIrsTaxes = -Math.Floor(yearlyChristmasBonusValue * irsTax);
                var yearlyChristmasBonusSocialSecurityTaxes = -Math.Round(yearlyChristmasBonusValue * socialSecurityTax, 2);

                yearlyChristmasBonusValueTaxes = -Math.Floor((yearlyChristmasBonusValue + yearlyChritmasBonusIrsTaxes + yearlyChristmasBonusSocialSecurityTaxes - minimumIncome) / 2);

                if (yearlyChristmasBonusValueTaxes > 0)
                    yearlyChristmasBonusValueTaxes = 0;
            }

            var yearlyTotalSubjectToTaxes = yearlyBaseIncome + yearlyChristmasBonusValue + yearlyVacationsBonusValue + yearlyLunchAllowanceSubjectToTaxes;
            var yearlyIrsTaxes = -Math.Floor(yearlyTotalSubjectToTaxes * irsTax);
            var yearlySocialSecurityTaxes = -Math.Round(yearlyTotalSubjectToTaxes * socialSecurityTax, 2);

            var monthlyChristmasGrantValue = 0.0;
            var monthlyChristmasBonusTaxes = 0.0;
            var monthlyVacationsGrantValue = 0.0;

            if (ChristmasVacationsAllowancesInTwelfths)
            {
                monthlyChristmasGrantValue = Math.Round(yearlyChristmasBonusValue / 12, 2);
                monthlyChristmasBonusTaxes = Math.Round(yearlyChristmasBonusValueTaxes / 12, 2);
                monthlyVacationsGrantValue = Math.Round(yearlyVacationsBonusValue / 12, 2);
            }

            var monthlyTotalSubjectToTaxes = monthlyBaseIncome + monthlyChristmasGrantValue + monthlyVacationsGrantValue + monthlyLunchAllowanceSubjectToTaxes;
            var monthlyIrsPaid = -Math.Floor(monthlyTotalSubjectToTaxes * irsTax);
            var monthlySocialSecurityPaid = -Math.Round(monthlyTotalSubjectToTaxes * socialSecurityTax, 2);

            var monthlyParcels = new List<SimulationResultEntry>();

            monthlyParcels.Add(new SimulationResultEntry("vencimento base", monthlyBaseIncome));
            if (monthlyLunchAllowance != 0)
                monthlyParcels.Add(new SimulationResultEntry("subsídio de alimentação ({0} dias)".FormatWithInvariantCulture(monthlyWorkingDays), monthlyLunchAllowance));
            if (monthlyChristmasGrantValue != 0)
                monthlyParcels.Add(new SimulationResultEntry("subsídio de natal (duodécimo)", monthlyChristmasGrantValue));
            if (monthlyChristmasBonusTaxes != 0)
                monthlyParcels.Add(new SimulationResultEntry("sobretaxa do subsídio de natal (duodécimo)", monthlyChristmasBonusTaxes));
            if (monthlyVacationsGrantValue != 0)
                monthlyParcels.Add(new SimulationResultEntry("subsídio de férias (duodécimo)", monthlyVacationsGrantValue));
            if (monthlySocialSecurityPaid != 0)
                monthlyParcels.Add(new SimulationResultEntry("segurança social / cga ({0:P})".FormatWithInvariantCulture(socialSecurityTax), monthlySocialSecurityPaid));
            if (monthlyIrsPaid != 0)
                monthlyParcels.Add(new SimulationResultEntry("irs ({0:P})".FormatWithInvariantCulture(irsTax), monthlyIrsPaid));

            MonthlySimulationResult = monthlyParcels
                .ToArray();

            var yearlyParcels = new List<SimulationResultEntry>();

            yearlyParcels.Add(new SimulationResultEntry("vencimento base", yearlyBaseIncome));
            if (yearlyLunchAllowance != 0)
                yearlyParcels.Add(new SimulationResultEntry("subsídio de alimentação ({0} dias)".FormatWithInvariantCulture(yearlyWorkingDays), yearlyLunchAllowance));
            yearlyParcels.Add(new SimulationResultEntry("subsídio de natal", yearlyChristmasBonusValue));
            if (yearlyChristmasBonusValueTaxes != 0)
                yearlyParcels.Add(new SimulationResultEntry("sobretaxa do subsídio de natal", yearlyChristmasBonusValueTaxes));
            yearlyParcels.Add(new SimulationResultEntry("subsídio de férias", yearlyVacationsBonusValue));
            if (yearlySocialSecurityTaxes != 0)
                yearlyParcels.Add(new SimulationResultEntry("segurança social / cga ({0:P})".FormatWithInvariantCulture(socialSecurityTax), yearlySocialSecurityTaxes));
            if (yearlyIrsTaxes != 0)
                yearlyParcels.Add(new SimulationResultEntry("irs ({0:P})".FormatWithInvariantCulture(irsTax), yearlyIrsTaxes));

            YearlySimulationResult = yearlyParcels
                .ToArray();
        }

        private double GetIrsTax()
        {
            var monthlyBaseIncome = (decimal)MonthlyBaseIncome;

            var irsTable = _dataContext.IrsTables
                .Where(x => x.Year == Year && x.FiscalResidence == FiscalResidence && x.Regime == Regime && x.MaritalState == MaritalState)
                .First();

            var irsTableEntries = _dataContext.IrsTableEntries
                .Where(x => x.IrsTable == irsTable);

            var irsTableEntry = irsTableEntries
                .OrderBy(x => x.IncomeTopRange)
                .Where(x => x.IncomeTopRange >= monthlyBaseIncome)
                .FirstOrDefault();

            if (irsTableEntry == null)
            {
                irsTableEntry = irsTableEntries
                    .OrderByDescending(x => x.Dependents0)
                    .First();
            }

            return irsTableEntry.GetPropertyValue<double>("Dependents" + Dependent.Identifier);
        }
    }
}