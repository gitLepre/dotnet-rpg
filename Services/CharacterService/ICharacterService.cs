using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<GetCharacterDto>> AddCharacter(PostCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> PutCharacter(PutCharacterDto newCharacter);
        Task<ServiceResponse<Object>> DeleteCharacter(int id);
    }
}