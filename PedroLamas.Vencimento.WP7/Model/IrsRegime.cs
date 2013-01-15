using System.Data.Linq;
using System.Data.Linq.Mapping;
using Cimbalino.Phone.Toolkit.Data;

namespace PedroLamas.Vencimento.Model
{
    [Table]
    public class IrsRegime : TableObject
    {
        [Column(IsPrimaryKey = true)]
        public int RegimeId { get; private set; }

        [Column]
        public string Description { get; private set; }

        [Association(Storage = "IrsTables", OtherKey = "_regimeId")]
        public EntitySet<IrsTable> IrsTables { get; private set; }
    }
}