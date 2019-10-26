using System.Collections.Generic;

namespace PedroLamas.Vencimento.Model
{
    public interface IMainModel
    {
        IList<SimulationModel2> Simulations { get; }

        SimulationModel2 SelectedSimulation { get; set; }

        void Save();
    }
}