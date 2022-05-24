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
    public class TeamsViewModel : ObservableRecipient, INavigationAware
    {

        private readonly ITeamService _teamService;
        private readonly INavigationService _navigationService;

        public TeamsViewModel(ITeamService teamService, INavigationService navigationService)
        {
            _teamService = teamService;
            _navigationService = navigationService;
        }

        private TeamEditViewModel _selectedTeam;
        public TeamEditViewModel Selected
        {
            get => _selectedTeam;
            set => SetProperty(ref _selectedTeam, value);
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
                        TeamEditViewModel newTeam = new() { ProfileImage = "TeamUnknown.png" };
                        TeamEditPage page = new(newTeam);

                        ContentDialog dialog = new()
                        {
                            Title = "Add a new Team",
                            Content = page,
                            PrimaryButtonText = "Add",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        newTeam.PropertyChanged += (sender, e) => dialog.IsPrimaryButtonEnabled = !newTeam.HasErrors;

                        ContentDialogResult result = await dialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var TeamDTO = await _teamService.CreateTeamAsync((TeamDto)newTeam);
                            TeamEditViewModel team = new(TeamDTO);

                            Teams.Add(team);
                            Selected = team;
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
                    _deleteCommand = new RelayCommand<TeamEditViewModel>(async param =>
                    {
                        ContentDialog deleteDialog = new()
                        {
                            Title = "Delete team permanently?",
                            Content = "If you delete this team, the team will be lost. Are you sure you want to delete it?",
                            PrimaryButtonText = "Yes",
                            CloseButtonText = "No",
                            DefaultButton = ContentDialogButton.Close,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        ContentDialogResult result = await deleteDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            if (await _teamService.DeleteTeamAsync((TeamDto)param))
                            {
                                _ = Teams.Remove(param);
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
                    _updateCommand = new RelayCommand<TeamEditViewModel>(async param =>
                    {
                        TeamEditViewModel updateTeam = _selectedTeam;
                        TeamEditPage page = new(updateTeam);

                        ContentDialog updateDialog = new()
                        {
                            Title = "Update Team",
                            Content = page,
                            PrimaryButtonText = "Update",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        updateTeam.PropertyChanged += (sender, e) => updateDialog.IsPrimaryButtonEnabled = !updateTeam.HasErrors;

                        ContentDialogResult result = await updateDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var TeamDTO = await _teamService.UpdateTeamAsync((TeamDto)param);

                            _ = Teams.Remove(param);
                            Teams.Add(param);
                        }
                    }, param => param != null);
                }
                return _updateCommand;
            }
        }

        public ObservableCollection<TeamEditViewModel> Teams { get; private set; } = new();

        public async void OnNavigatedTo(object parameter)
        {
            if (Teams.Count == 0)
            {
                var TeamDtos = await _teamService.GetTeamsAsync();

                foreach (var TeamDto in TeamDtos)
                {
                    Teams.Add(new TeamEditViewModel(TeamDto));
                }
            }

        }

        public void OnNavigatedFrom()
        {
        }

        public void EnsureItemSelected()
        {
            if (Selected == null && Teams.Count > 0)
            {
                Selected = Teams.First();
            }
        }
    }
}
