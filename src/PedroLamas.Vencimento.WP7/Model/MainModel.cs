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

        public IList<SimulationModel> Simulations { get; private set; }

        public SimulationModel SelectedSimulation { get; set; }

        #endregion

        public MainModel(IStorageService storageService)
        {
            _storageService = storageService;

            Load();
        }

        private void Load()
        {
            Simulations = _storageService.FileExists(SimulationsFilename) 
                ? JsonConvert.DeserializeObject<List<SimulationModel>>(_storageService.ReadAllText(SimulationsFilename)) 
                : new List<SimulationModel>();
        }

        public void Save()
        {
            _storageService.WriteAllText(SimulationsFilename, JsonConvert.SerializeObject(Simulations));
        }
    }
}