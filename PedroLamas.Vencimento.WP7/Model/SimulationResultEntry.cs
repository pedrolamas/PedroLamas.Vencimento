namespace PedroLamas.Vencimento.Model
{
    public class SimulationResultEntry
    {
        #region Properties

        public string Description { get; private set; }

        public double Value { get; private set; }

        #endregion

        public SimulationResultEntry(string description, double value)
        {
            Description = description;
            Value = value;
        }
    }
}