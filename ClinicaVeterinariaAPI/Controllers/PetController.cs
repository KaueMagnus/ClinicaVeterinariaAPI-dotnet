using ClinicaVeterinariaApi.Models;
using ClinicaVeterinariaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinariaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _petService.GetAllAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pet pet)
        {
            if (string.IsNullOrWhiteSpace(pet.Nome) || string.IsNullOrWhiteSpace(pet.Especie))
                return BadRequest("Nome e espécie são obrigatórios.");

            try
            {
                var created = await _petService.CreatePetAsync(pet);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pet pet)
        {
            var updated = await _petService.UpdateAsync(id, pet);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _petService.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}