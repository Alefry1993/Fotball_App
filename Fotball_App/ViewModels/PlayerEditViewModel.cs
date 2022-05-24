using CommunityToolkit.Mvvm.ComponentModel;
using Fotball_App.Core.Constants;
using Fotball_App.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fotball_App.ViewModels
{
    public class PlayerEditViewModel : ObservableValidator
    {
        public PlayerEditViewModel()
        {
            _playerDto = new PlayerDto();
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }
        public PlayerEditViewModel(PlayerDto playerDto)
        {
            _playerDto = playerDto;
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }

        public static explicit operator PlayerDto(PlayerEditViewModel p) => new()
        {
            PlayerId = p.PlayerID,
            PlayerName = p.PlayerName,
            Age = p.Age,
            club = p.Club,
            ProfileImage = p.ProfileImage,
            National = p.National
        };

        private readonly PlayerDto _playerDto;
        private readonly List<ValidationResult> _errors = new();

        public string Errors => string.Join(Environment.NewLine, from ValidationResult e in _errors select e.ErrorMessage);

        public new bool HasErrors => Errors.Length > 0;

        public string ProfileImageFullPath => $"{UrlAdresses.ImageApi}/{ProfileImage}";

        public int PlayerID
        {
            get => _playerDto.PlayerId;
            set => SetProperty(_playerDto.PlayerId, value, _playerDto, (_playerDto, id) => _playerDto.PlayerId = value);
        }


        public string PlayerName
        {
            get => _playerDto.PlayerName;
            set => SetProperty(_playerDto.PlayerName, value, (name) => _playerDto.PlayerName = name);

            
        }


        public int Age
        {
            get => _playerDto.Age;
            set => SetProperty(_playerDto.Age, value, (age) => _playerDto.Age = age);


        }


        public string ProfileImage
        {
            get => _playerDto.ProfileImage;
            set => SetProperty(_playerDto.ProfileImage, value, (profileImage) => _playerDto.ProfileImage = profileImage);
        }

        public List<TeamDto> Club
        {
            get => _playerDto.club;
            set => SetProperty(_playerDto.club, value, (club) => _playerDto.club = club);
        }

        public string National
        {
            get => _playerDto.National;

            set => SetProperty(_playerDto.National, value, (nation) => _playerDto.National = nation);
            
        }
    }
}
