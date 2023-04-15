using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1, Name = "Sam"}
        };
        public async Task<ServiceResponse<Character>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<Character>();
            characters.Add(newCharacter);
            serviceResponse.Data = newCharacter;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            Character character = characters.FirstOrDefault(c => c.Id == id);
            var serviceResponse = new ServiceResponse<Character>();
            if (character is not null) serviceResponse.Data = character;
            else serviceResponse.Success = false;
            return serviceResponse;
            // throw new KeyNotFoundException("Character with id " + id + " not found");
        }
    }
}