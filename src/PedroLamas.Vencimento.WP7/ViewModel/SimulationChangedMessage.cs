using GalaSoft.MvvmLight.Messaging;
using PedroLamas.Vencimento.Model;

namespace PedroLamas.Vencimento.ViewModel
{
    public class SimulationChangedMessage : MessageBase
    {
        public SimulationModel OldSimulation { get; set; }
        public SimulationModel NewSimulation { get; set; }

        public SimulationChangedMessage(SimulationModel oldSimulation, SimulationModel newSimulation)
        {
            OldSimulation = oldSimulation;
            NewSimulation = newSimulation;
        }
    }
}