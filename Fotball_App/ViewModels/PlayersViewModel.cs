using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fotball_App.Contracts.Services;
using Fotball_App.Contracts.ViewModels;
using Fotball_App.Core.Contracts.Services;
using Fotball_App.Core.Dtos;
using Fotball_App.Views;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Fotball_App.ViewModels
{
    public class PlayersViewModel : ObservableRecipient, INavigationAware
    {

        private readonly IPlayerService _playerService;
        private readonly INavigationService _navigationService;

        public PlayersViewModel(IPlayerService playerService, INavigationService navigationService)
        {
            _playerService = playerService;
            _navigationService = navigationService;
        }

        private PlayerEditViewModel _selectedPlayer;
        public PlayerEditViewModel Selected
        {
            get => _selectedPlayer;
            set => SetProperty(ref _selectedPlayer, value);
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(async () =>
                    {
                        PlayerEditViewModel newPlayer = new() { ProfileImage = "PlayerUnknown.png" };
                        PlayerEditPage page = new(newPlayer);

                        ContentDialog dialog = new()
                        {
                            Title = "Add a new Player",
                            Content = page,
                            PrimaryButtonText = "Add",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        newPlayer.PropertyChanged += (sender, e) => dialog.IsPrimaryButtonEnabled = !newPlayer.HasErrors;

                        ContentDialogResult result = await dialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var PlayerDTO = await _playerService.CreatePlayerAsync((PlayerDto)newPlayer);
                            PlayerEditViewModel player = new(PlayerDTO);

                            Players.Add(player);
                            Selected = player;
                        }
                    });
                }

                return _addCommand;
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand<PlayerEditViewModel>(async param =>
                    {
                        ContentDialog deleteDialog = new()
                        {
                            Title = "Delete player permanently?",
                            Content = "If you delete this player, the player will be lost. Are you sure you want to delete it?",
                            PrimaryButtonText = "Yes",
                            CloseButtonText = "No",
                            DefaultButton = ContentDialogButton.Close,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        ContentDialogResult result = await deleteDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            if (await _playerService.DeletePlayerAsync((PlayerDto)param))
                            {
                                _ = Players.Remove(param);
                            }
                        }
                    }, param => param != null);
                }

                return _deleteCommand;
            }
        }

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand<PlayerEditViewModel>(async param =>
                    {
                        PlayerEditViewModel updatePlayer = _selectedPlayer;
                        PlayerEditPage page = new(updatePlayer);

                        ContentDialog updateDialog = new()
                        {
                            Title = "Update Player",
                            Content = page,
                            PrimaryButtonText = "Update",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        updatePlayer.PropertyChanged += (sender, e) => updateDialog.IsPrimaryButtonEnabled = !updatePlayer.HasErrors;

                        ContentDialogResult result = await updateDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var TeamDTO = await _playerService.UpdatePlayerAsync((PlayerDto)param);

                            _ = Players.Remove(param);
                            Players.Add(updatePlayer);
                        }
                    }, param => param != null);
                }
                return _updateCommand;
            }
        }

        public ObservableCollection<PlayerEditViewModel> Players { get; private set; } = new();

        public async void OnNavigatedTo(object parameter)
        {
            if (Players.Count == 0)
            {
                var PlayerDtos = await _playerService.GetPlayersAsync();

                foreach (var playerDto in PlayerDtos)
                {
                    Players.Add(new PlayerEditViewModel(playerDto));
                }
            }

        }

        public void OnNavigatedFrom()
        {
        }

        public void EnsureItemSelected()
        {
            if (Selected == null && Players.Count > 0)
            {
                Selected = Players.First();
            }
        }
    }
}
