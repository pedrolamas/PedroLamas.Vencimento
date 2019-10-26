using System.Collections.Generic;

namespace PedroLamas.Vencimento.Model
{
    public interface IMainModel
    {
        IList<SimulationModel> Simulations { get; }

        SimulationModel SelectedSimulation { get; set; }

        void Save();
    }
}