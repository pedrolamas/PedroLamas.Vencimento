using GalaSoft.MvvmLight.Messaging;
using PedroLamas.Vencimento.Model;

namespace PedroLamas.Vencimento.ViewModel
{
    public class SimulationChangedMessage : MessageBase
    {
        public SimulationModel2 SimulationModel { get; private set; }

        public SimulationChangedMessage(SimulationModel2 simulationModel)
        {
            SimulationModel = simulationModel;
        }
    }
}