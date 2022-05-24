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
    public class LeaguesViewModel : ObservableRecipient, INavigationAware
    {

        private readonly ILeagueService _leagueService;
        private readonly INavigationService _navigationService;

        public LeaguesViewModel(ILeagueService leagueService, INavigationService navigationService)
        {
            _leagueService = leagueService;
            _navigationService = navigationService;
        }

        private LeagueEditViewModel _selectedLeague;
        public LeagueEditViewModel Selected
        {
            get => _selectedLeague;
            set => SetProperty(ref _selectedLeague, value);
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
                        LeagueEditViewModel newLeague = new() { ProfileImage = "LeagueUnknown.png" };
                        LeagueEditPage page = new(newLeague);

                        ContentDialog dialog = new()
                        {
                            Title = "Add a new League",
                            Content = page,
                            PrimaryButtonText = "Add",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        newLeague.PropertyChanged += (sender, e) => dialog.IsPrimaryButtonEnabled = !newLeague.HasErrors;

                        ContentDialogResult result = await dialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var LeagueDTO = await _leagueService.CreateLeagueAsync((LeagueDto)newLeague);
                            LeagueEditViewModel league = new(LeagueDTO);

                            Leagues.Add(league);
                            Selected = league;
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
                    _deleteCommand = new RelayCommand<LeagueEditViewModel>(async param =>
                    {
                        ContentDialog deleteDialog = new()
                        {
                            Title = "Delete league permanently?",
                            Content = "If you delete this league, the league will be lost. Are you sure you want to delete it?",
                            PrimaryButtonText = "Yes",
                            CloseButtonText = "No",
                            DefaultButton = ContentDialogButton.Close,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        ContentDialogResult result = await deleteDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            if (await _leagueService.DeleteLeagueAsync((LeagueDto)param))
                            {
                                _ = Leagues.Remove(param);
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
                    _updateCommand = new RelayCommand<LeagueEditViewModel>(async param =>
                    {
                        LeagueEditViewModel updateLeague = _selectedLeague;
                        LeagueEditPage page = new(updateLeague);

                        ContentDialog updateDialog = new()
                        {
                            Title = "Update League",
                            Content = page,
                            PrimaryButtonText = "Update",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        updateLeague.PropertyChanged += (sender, e) => updateDialog.IsPrimaryButtonEnabled = !updateLeague.HasErrors;

                        ContentDialogResult result = await updateDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var LeagueDTO = await _leagueService.UpdateLeagueAsync((LeagueDto)param);

                            _ = Leagues.Remove(param);
                            Leagues.Add(updateLeague);
                        }
                    }, param => param != null);
                }
                return _updateCommand;
            }
        }

        public ObservableCollection<LeagueEditViewModel> Leagues { get; private set; } = new();

        public async void OnNavigatedTo(object parameter)
        {
            if (Leagues.Count == 0)
            {
                var LeagueDtos = await _leagueService.GetLeaguesAsync();

                foreach (var OneLeague in LeagueDtos)
                {
                    Leagues.Add(new LeagueEditViewModel(OneLeague));
                }
            }

        }

        public void OnNavigatedFrom()
        {
        }

        public void EnsureItemSelected()
        {
            if (Selected == null && Leagues.Count > 0)
            {
                Selected = Leagues.First();
            }
        }
    }
}
