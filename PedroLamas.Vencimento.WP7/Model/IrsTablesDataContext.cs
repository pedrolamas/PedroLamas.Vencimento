using System.Data.Linq;

namespace PedroLamas.Vencimento.Model
{
    public class IrsTablesDataContext : DataContext
    {
        public static string DBConnectionString = "Data Source = 'appdata:/IRSTables.sdf'; File Mode = read only;";
        //public static string DBConnectionString = "Data Source = 'isostore:/IRSTables.sdf'";

        public IrsTablesDataContext()
            : base(DBConnectionString)
        {
        }

        public Table<IrsYear> IrsYears;

        public Table<IrsTable> IrsTables;

        public Table<IrsTableEntry> IrsTableEntries;

        public Table<IrsFiscalResidence> IrsFiscalResidences;

        public Table<IrsRegime> IrsRegimes;

        public Table<IrsMaritalState> IrsMaritalStates;

        public Table<IrsDependent> IrsDependents;

        public Table<SocialSecurityRegime> SocialSecurityRegimes;
    }
}