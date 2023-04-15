using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacter();
        Character GetCharacterById(int id);
        Character AddCharacter(Character newCharacter);
    }
}