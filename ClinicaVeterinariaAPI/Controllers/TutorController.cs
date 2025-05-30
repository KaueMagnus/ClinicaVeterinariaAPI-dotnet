using ClinicaVeterinariaApi.Models;
using ClinicaVeterinariaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinariaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _tutorService;

        public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tutores = await _tutorService.GetAllAsync();
            return Ok(tutores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tutor = await _tutorService.GetByIdAsync(id);
            if (tutor == null)
                return NotFound();
            return Ok(tutor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tutor tutor)
        {
            try
            {
                var created = await _tutorService.CreateTutorAsync(tutor);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tutor tutor)
        {
            var updated = await _tutorService.UpdateAsync(id, tutor);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tutorService.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
