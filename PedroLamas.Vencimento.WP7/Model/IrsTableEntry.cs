using System.Data.Linq;
using System.Data.Linq.Mapping;
using Cimbalino.Phone.Toolkit.Data;

namespace PedroLamas.Vencimento.Model
{
    [Table]
    public class IrsTableEntry : TableObject
    {
        [Column(IsPrimaryKey = true)]
        public int IrsTableEntryId { get; private set; }

        [Column]
        public decimal IncomeTopRange { get; private set; }

        [Column]
        public double Dependents0 { get; private set; }

        [Column]
        public double Dependents1 { get; private set; }

        [Column]
        public double Dependents2 { get; private set; }

        [Column]
        public double Dependents3 { get; private set; }

        [Column]
        public double Dependents4 { get; private set; }

        [Column]
        public double Dependents5 { get; private set; }

        [Column(Name = "IrsTableId")]
        internal int _irsTableId;

        private EntityRef<IrsTable> _irsTable;

        [Association(Storage = "_irsTable", ThisKey = "_irsTableId", OtherKey = "IrsTableId", IsForeignKey = true)]
        public IrsTable IrsTable
        {
            get
            {
                return _irsTable.Entity;
            }
        }
    }
}