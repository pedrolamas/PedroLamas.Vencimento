using System.Collections.Generic;
using System.Linq;

namespace PedroLamas.Vencimento.Model
{
    public class DataModel : IDataModel
    {
        private readonly IrsTablesDataContext _dataContext;

        #region Properties

        public IEnumerable<IrsYear> YearList { get; private set; }

        public IEnumerable<IrsFiscalResidence> FiscalResidenceList { get; private set; }

        public IEnumerable<IrsRegime> RegimeList { get; private set; }

        public IEnumerable<IrsMaritalState> MaritalStateList { get; private set; }

        public IEnumerable<IrsDependent> DependentList { get; private set; }

        public IEnumerable<SocialSecurityRegime> SocialSecurityRegimeList { get; private set; }

        #endregion

        public DataModel()
        {
            _dataContext = new IrsTablesDataContext();

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
        }
    }
}