using System.Collections.Generic;
using Cimbalino.Phone.Toolkit.Services;
using Newtonsoft.Json;

namespace PedroLamas.Vencimento.Model
{
    public class MainModel : IMainModel
    {
        private const string SimulationsFilename = @"data.txt";

        private readonly IStorageService _storageService;

        #region Properties

        public IList<SimulationModel2> Simulations { get; private set; }

        public SimulationModel2 SelectedSimulation { get; set; }

        #endregion

        public MainModel(IStorageService storageService)
        {
            _storageService = storageService;

            Load();
        }

        private void Load()
        {
            if (_storageService.FileExists(SimulationsFilename))
                Simulations = JsonConvert.DeserializeObject<List<SimulationModel2>>(_storageService.ReadAllText(SimulationsFilename));
            else
                Simulations = new List<SimulationModel2>();
        }

        public void Save()
        {
            _storageService.WriteAllText(SimulationsFilename, JsonConvert.SerializeObject(Simulations));
        }
    }
}