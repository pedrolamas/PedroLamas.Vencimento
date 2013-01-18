using System.Collections.Generic;

namespace PedroLamas.Vencimento.Model
{
    public interface IDataModel
    {
        IEnumerable<IrsYear> YearList { get; }

        IEnumerable<IrsFiscalResidence> FiscalResidenceList { get; }

        IEnumerable<IrsRegime> RegimeList { get; }

        IEnumerable<IrsMaritalState> MaritalStateList { get; }

        IEnumerable<IrsDependent> DependentList { get; }

        IEnumerable<SocialSecurityRegime> SocialSecurityRegimeList { get; }
    }
}