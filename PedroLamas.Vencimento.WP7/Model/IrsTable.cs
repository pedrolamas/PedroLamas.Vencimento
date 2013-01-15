using System.Data.Linq;
using System.Data.Linq.Mapping;
using Cimbalino.Phone.Toolkit.Data;

namespace PedroLamas.Vencimento.Model
{
    [Table]
    public class IrsTable : TableObject
    {
        [Column(IsPrimaryKey = true)]
        public int IrsTableId { get; private set; }

        [Column(Name = "Year")]
        internal short _yearId;

        private EntityRef<IrsYear> _year;

        [Association(Storage = "_year", ThisKey = "_yearId", OtherKey = "Year", IsForeignKey = true)]
        public IrsYear Year
        {
            get
            {
                return _year.Entity;
            }
        }

        [Column(Name = "FiscalResidenceId")]
        internal int _fiscalResidenceId;

        private EntityRef<IrsFiscalResidence> _fiscalResidence;

        [Association(Storage = "_fiscalResidence", ThisKey = "_fiscalResidenceId", OtherKey = "FiscalResidenceId", IsForeignKey = true)]
        public IrsFiscalResidence FiscalResidence
        {
            get
            {
                return _fiscalResidence.Entity;
            }
        }

        [Column(Name = "RegimeId")]
        internal int _regimeId;

        private EntityRef<IrsRegime> _regime;

        [Association(Storage = "_regime", ThisKey = "_regimeId", OtherKey = "RegimeId", IsForeignKey = true)]
        public IrsRegime Regime
        {
            get
            {
                return _regime.Entity;
            }
        }

        [Column(Name = "MaritalStateId")]
        internal int _maritalStateId;

        private EntityRef<IrsMaritalState> _maritalState;

        [Association(Storage = "_maritalState", ThisKey = "_maritalStateId", OtherKey = "MaritalStateId", IsForeignKey = true)]
        public IrsMaritalState MaritalState
        {
            get
            {
                return _maritalState.Entity;
            }
        }

        [Association(Storage = "IrsTableEntries", OtherKey = "_irsTableId")]
        public EntitySet<IrsTableEntry> IrsTableEntries { get; private set; }
    }
}