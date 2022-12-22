using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApi.DTOs.Character;

namespace DotNetCoreWebApi.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharcterById(int Id);

        Task<ServiceResponse<List<GetCharacterDTO>>> AddNewCharacter(AddCharacterDTO newCharacter);
        Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacter);

        Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int Id);
    }
}