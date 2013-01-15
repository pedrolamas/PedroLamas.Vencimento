using System.Data.Linq.Mapping;
using Cimbalino.Phone.Toolkit.Data;

namespace PedroLamas.Vencimento.Model
{
    [Table]
    public class IrsDependent : TableObject
    {
        [Column(IsPrimaryKey = true)]
        public int DependentId { get; private set; }

        [Column]
        public string Description { get; private set; }

        [Column]
        public byte Identifier { get; private set; }
    }
}