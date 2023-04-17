using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {

        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacter(PostCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = _mapper.Map<Character>(newCharacter);
            try
            {
                character.Id = characters.Max(c => c.Id) + 1;

            }
            catch (Exception ex)
            {
                character.Id = 0;

            }

            characters.Add(character);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(_mapper.Map<Character>(character));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> PutCharacter(PutCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character is null)
                    throw new Exception($"Character with id {updatedCharacter.Id} not found");


                serviceResponse.Data = _mapper.Map<GetCharacterDto>(_mapper.Map(updatedCharacter, character));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Object>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<Object>();
            serviceResponse.Data = null;
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == id);
                if (character is null)
                    throw new Exception($"Character with id {id} not found");

                characters.Remove(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

    }
}