﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Cimbalino.Phone.Toolkit.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using PedroLamas.Vencimento.Model;
using Cimbalino.Phone.Toolkit.Services;

namespace PedroLamas.Vencimento.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMainModel _mainModel;
        private readonly IDataModel _dataModel;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;

        private bool _isSelectionEnabled;
        private bool _isListEmpty;

        #region Properties

        public ObservableCollection<SimulationViewModel> Simulations { get; private set; }

        public RelayCommand<SimulationViewModel> ShowSimulationCommand { get; private set; }

        public RelayCommand<SimulationViewModel> EditSimulationCommand { get; private set; }

        public RelayCommand NewSimulationCommand { get; private set; }

        public RelayCommand EnableSelectionCommand { get; private set; }

        public RelayCommand<IList<SimulationViewModel>> DeleteSimulationCommand { get; private set; }

        public RelayCommand ShowAboutCommand { get; private set; }

        public RelayCommand<CancelEventArgs> BackKeyPressCommand { get; private set; }

        public bool IsSelectionEnabled
        {
            get
            {
                return _isSelectionEnabled;
            }
            set
            {
                if (_isSelectionEnabled == value)
                    return;

                _isSelectionEnabled = value;

                RaisePropertyChanged(() => IsSelectionEnabled);
                RaisePropertyChanged(() => ApplicationBarSelectedIndex);
            }
        }

        public bool IsSimulationsListEmpty
        {
            get
            {
                return _isListEmpty;
            }
            set
            {
                if (_isListEmpty == value)
                    return;

                _isListEmpty = value;

                RaisePropertyChanged(() => IsSimulationsListEmpty);

                EnableSelectionCommand.RaiseCanExecuteChanged();
            }
        }

        public int ApplicationBarSelectedIndex
        {
            get
            {
                return _isSelectionEnabled ? 1 : 0;
            }
        }

        #endregion

        public MainViewModel(IMainModel mainModel, IDataModel dataModel, INavigationService navigationService, IMessageBoxService messageBoxService)
        {
            _mainModel = mainModel;
            _dataModel = dataModel;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;

            Simulations = _mainModel.Simulations
                .Select(x => new SimulationViewModel(_dataModel, x))
                .ToObservableCollection();

            ShowSimulationCommand = new RelayCommand<SimulationViewModel>(simulation =>
            {
                _mainModel.SelectedSimulation = simulation.Model;

                _navigationService.NavigateTo("/View/ResultsPage.xaml");
            });

            EditSimulationCommand = new RelayCommand<SimulationViewModel>(simulation =>
            {
                _mainModel.SelectedSimulation = simulation.Model;

                _navigationService.NavigateTo("/View/EditPage.xaml");
            });

            NewSimulationCommand = new RelayCommand(() =>
            {
                _mainModel.SelectedSimulation = CreateNewSimulationModel();

                _navigationService.NavigateTo("/View/EditPage.xaml");
            });

            EnableSelectionCommand = new RelayCommand(() =>
            {
                IsSelectionEnabled = true;
            }, () => !IsSimulationsListEmpty);

            DeleteSimulationCommand = new RelayCommand<IList<SimulationViewModel>>(items =>
            {
                if (items == null || items.Count == 0)
                    return;

                _messageBoxService.Show("Está prestes a apagar as simulações seleccionadas", "Tem a certeza?", new[] { "eliminar", "cancelar" }, button =>
                {
                    if (button != 0)
                        return;

                    var itemsToRemove = items
                        .ToArray();

                    foreach (var item in itemsToRemove)
                    {
                        _mainModel.Simulations.Remove(item.Model);

                        Simulations.Remove(item);
                    }

                    _mainModel.Save();

                    IsSimulationsListEmpty = (Simulations.Count == 0);
                });
            });

            ShowAboutCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(new Uri("/View/AboutPage.xaml", UriKind.Relative));
            });

            BackKeyPressCommand = new RelayCommand<CancelEventArgs>(e =>
            {
                if (IsSelectionEnabled)
                {
                    IsSelectionEnabled = false;

                    e.Cancel = true;
                }
            });

            MessengerInstance.Register<SimulationChangedMessage>(this, message =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (!_mainModel.Simulations.Contains(_mainModel.SelectedSimulation))
                    {
                        _mainModel.Simulations.Add(_mainModel.SelectedSimulation);

                        Simulations.Add(new SimulationViewModel(_dataModel, _mainModel.SelectedSimulation));
                    }

                    IsSimulationsListEmpty = false;

                    _mainModel.Save();
                });
            });

            IsSimulationsListEmpty = (Simulations.Count == 0);
        }

        private SimulationModel2 CreateNewSimulationModel()
        {
            return new SimulationModel2
            {
                YearId = DateTime.Today.Year,
                FiscalResidenceId = _dataModel.FiscalResidenceList.FirstOrDefault().FiscalResidenceId,
                RegimeId = _dataModel.RegimeList.FirstOrDefault().RegimeId,
                MaritalStateId = _dataModel.MaritalStateList.FirstOrDefault().MaritalStateId,
                DependentId = _dataModel.DependentList.FirstOrDefault().DependentId,
                SocialSecurityRegimeId = _dataModel.SocialSecurityRegimeList.FirstOrDefault().SocialSecurityRegimeId,
                WorkingDays = 22
            };
        }
    }
}