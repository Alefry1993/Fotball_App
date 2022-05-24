using CommunityToolkit.Mvvm.ComponentModel;
using Fotball_App.Core.Constants;
using Fotball_App.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fotball_App.ViewModels
{
    public class TeamEditViewModel : ObservableValidator
    {
        public TeamEditViewModel()
        {
            _teamDto = new TeamDto();
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }
        public TeamEditViewModel(TeamDto teamDto)
        {
            _teamDto = teamDto;
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }

        public static explicit operator TeamDto(TeamEditViewModel t) => new()
        {
            TeamId = t.TeamID,
            TeamName = t.TeamName,
            TeamDescription = t.Description,
            TeamLogo = t.ProfileImage,
            League = t.league,
            players = t.Players,
            Country = t.Country

        };

        private readonly TeamDto _teamDto;
        private readonly List<ValidationResult> _errors = new();

        public string Errors => string.Join(Environment.NewLine, from ValidationResult e in _errors select e.ErrorMessage);

        public new bool HasErrors => Errors.Length > 0;

        public string ProfileImageFullPath => $"{UrlAdresses.ImageApi}/{ProfileImage}";

        public int TeamID
        {
            get => _teamDto.TeamId;
            set => SetProperty(_teamDto.TeamId, value, _teamDto, (_teamDto, id) => _teamDto.TeamId = value);
        }

        public string TeamName
        {
            get => _teamDto.TeamName;
            set => SetProperty(_teamDto.TeamName, value, (name) => _teamDto.TeamName = name);


        }

        public string ProfileImage
        {
            get => _teamDto.TeamLogo;
            set => SetProperty(_teamDto.TeamLogo, value, (profileImage) => _teamDto.TeamLogo = profileImage);
        }


        public string Description
        {
            get => _teamDto.TeamDescription;
            set => SetProperty(_teamDto.TeamDescription, value, (description) => _teamDto.TeamDescription = description);
        }

        public List<LeagueDto> league
        {
            get => _teamDto.League;
            set => SetProperty(_teamDto.League, value, (league) => _teamDto.League = league);
        }

        public List<PlayerDto> Players
        {
            get => _teamDto.players;
            set => SetProperty(_teamDto.players, value, (players) => _teamDto.players = players);
        }

        public string Country
        {
            get => _teamDto.Country;
            set => SetProperty(_teamDto.Country, value, (countries) => _teamDto.Country = countries);
        }
    }
}
