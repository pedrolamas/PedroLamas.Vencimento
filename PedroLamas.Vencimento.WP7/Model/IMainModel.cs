namespace PedroLamas.Vencimento.Model
{
    public interface IMainModel
    {
        IrsYear[] YearList { get; }

        IrsFiscalResidence[] FiscalResidenceList { get; }

        IrsRegime[] RegimeList { get; }

        IrsMaritalState[] MaritalStateList { get; }

        IrsDependent[] DependentList { get; }

        SocialSecurityRegime[] SocialSecurityRegimeList { get; }

        double MonthlyBaseIncome { get; set; }

        IrsYear Year { get; set; }

        IrsFiscalResidence FiscalResidence { get; set; }

        IrsRegime Regime { get; set; }

        IrsMaritalState MaritalState { get; set; }

        IrsDependent Dependent { get; set; }

        SocialSecurityRegime SocialSecurityRegime { get; set; }

        double DailyLunchAllowance { get; set; }

        int WorkingDays { get; set; }

        bool ChristmasVacationsAllowancesInTwelfths { get; set; }

        bool ChristmasOvertaxed { get; set; }

        SimulationResultEntry[] MonthlySimulationResult { get; }

        SimulationResultEntry[] YearlySimulationResult { get; }

        void Simulate();
    }
}