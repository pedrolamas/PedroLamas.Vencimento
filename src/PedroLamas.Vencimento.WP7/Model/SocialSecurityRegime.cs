using System.Data.Linq.Mapping;
using Cimbalino.Phone.Toolkit.Data;

namespace PedroLamas.Vencimento.Model
{
    [Table]
    public class SocialSecurityRegime : TableObject
    {
        [Column(IsPrimaryKey = true)]
        public int SocialSecurityRegimeId { get; private set; }

        [Column]
        public string Description { get; private set; }

        [Column]
        public double Tax { get; private set; }
    }
}