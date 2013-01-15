using System.Data.Linq;
using System.Data.Linq.Mapping;
using Cimbalino.Phone.Toolkit.Data;

namespace PedroLamas.Vencimento.Model
{
    [Table]
    public class IrsYear : TableObject
    {
        [Column(IsPrimaryKey = true)]
        public short Year { get; private set; }

        [Column]
        public bool ChristmasOvertaxed { get; private set; }

        [Column]
        public decimal MaxDailyLunchAllowance { get; private set; }

        [Column]
        public double DailyLunchAllowanceTax { get; private set; }

        [Association(Storage = "IrsTables", OtherKey = "_yearId")]
        public EntitySet<IrsTable> IrsTables { get; private set; }
    }
}