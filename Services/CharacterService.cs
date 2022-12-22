using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCoreWebApi.DTOs.Character;

namespace DotNetCoreWebApi.Services
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ID=1, Name="SAM"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddNewCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>(); 
            var newchar = _mapper.Map<Character>(newCharacter);
            newchar.ID = characters.Max(c => c.ID) + 1;
            characters.Add(newchar);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try{
            var character = characters.FirstOrDefault(c => c.ID == Id);
            if(character is null)
                throw new Exception($"Character with Id: {Id} not found !");
            
            characters.Remove(character);

            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            }
            catch(Exception ex){
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message.ToString();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>(); 
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharcterById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>(); 
            var character =  characters.FirstOrDefault(c => c.ID == Id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try{
            var character = characters.FirstOrDefault(c => c.ID == updateCharacter.ID);
            if(character is null)
                throw new Exception($"Character with Id: {updateCharacter.ID} not found !");
            character.Name = updateCharacter.Name;
            character.Defencse = updateCharacter.Defencse;
            character.Strength = updateCharacter.Strength;
            character.Intelligence = updateCharacter.Intelligence;
            character.HitPoints = updateCharacter.HitPoints;
            character.Class = updateCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            }
            catch(Exception ex){
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message.ToString();
            }

            return serviceResponse;
        }
    }
}