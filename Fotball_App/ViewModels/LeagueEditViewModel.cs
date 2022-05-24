using CommunityToolkit.Mvvm.ComponentModel;
using Fotball_App.Core.Constants;
using Fotball_App.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fotball_App.ViewModels
{
    public class LeagueEditViewModel : ObservableValidator
    {
        public LeagueEditViewModel()
        {
            _LeagueDto = new LeagueDto();
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }
        public LeagueEditViewModel(LeagueDto LeagueDto)
        {
            _LeagueDto = LeagueDto;
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }

        public static explicit operator LeagueDto(LeagueEditViewModel l) => new()
        {
            LeagueId = l.LeagueID,
            LeagueName = l.LeagueName,
            Nationality = l.Nationality,
            About = l.About,
            Founded = l.Founded,
            LeagueLogo = l.ProfileImage,
            Teams = l.Teams
        };

        private readonly LeagueDto _LeagueDto;
        private readonly List<ValidationResult> _errors = new();

        public string Errors => string.Join(Environment.NewLine, from ValidationResult e in _errors select e.ErrorMessage);

        public new bool HasErrors => Errors.Length > 0;

        public string ProfileImageFullPath => $"{UrlAdresses.ImageApi}/{ProfileImage}";

        public int LeagueID
        {
            get => _LeagueDto.LeagueId;
            set => SetProperty(_LeagueDto.LeagueId, value, _LeagueDto, (_LeagueDto, id) => _LeagueDto.LeagueId = value);
        }


        public string LeagueName
        {
            get => _LeagueDto.LeagueName;
            set => SetProperty(_LeagueDto.LeagueName, value, (name) => _LeagueDto.LeagueName = name);

        }

        public string Nationality
        {
            get => _LeagueDto.Nationality;
            set => SetProperty(_LeagueDto.Nationality, value, (country) => _LeagueDto.Nationality = country);


        }

        public string ProfileImage
        {
            get => _LeagueDto.LeagueLogo;
            set => SetProperty(_LeagueDto.LeagueLogo, value, (profileImage) => _LeagueDto.LeagueLogo = profileImage);
        }

        public string About
        {
            get => _LeagueDto.About;
            set => SetProperty(_LeagueDto.About, value, (about) => _LeagueDto.About = about);
        }

        public string Founded
        {
            get => _LeagueDto.Founded;
            set => SetProperty(_LeagueDto.Founded, value, (founded) => _LeagueDto.Founded = founded);
        }

        public List<TeamDto> Teams
        {
            get => _LeagueDto.Teams;
            set => SetProperty(_LeagueDto.Teams, value, (teams) => _LeagueDto.Teams = teams);
        }
    }
}
