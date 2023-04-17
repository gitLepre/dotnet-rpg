using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacter());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacter(PostCharacterDto character)
        {
            return Ok(await _characterService.AddCharacter(character));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> PutCharacter(PutCharacterDto character)
        {
            var response = await _characterService.PutCharacter(character);
            if (response.Data is null)
                return NotFound(response);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Object>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Success is false)
                return NotFound(response);
            return Ok(response);
        }
    }
}