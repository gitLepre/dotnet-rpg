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
        public Character AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return newCharacter;
        }

        public List<Character> GetAllCharacter()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            Character character = characters.FirstOrDefault(c => c.Id == id);
            if (character is not null) return character;
            throw new KeyNotFoundException("Character with id " + id + " not found");
        }
    }
}