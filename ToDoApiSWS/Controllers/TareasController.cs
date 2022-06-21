using Microsoft.AspNetCore.Mvc;
using ToDoApiSWS.Models;

namespace ToDoApiSWS.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase {
        private readonly TareaService _tareaService;

        public TareasController(TareaService service) {
            _tareaService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetAll() {
            var tareas = await _tareaService.GetAllAsync();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetById(string id) {
            var tarea = await _tareaService.GetByIdAsync(id);
            if (tarea == null) {
                return NotFound();
            }
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tarea tarea) {
            await _tareaService.CreateAsync(tarea);
            return Ok(tarea);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Tarea updatedTarea) {
            var queriedTarea = await _tareaService.GetByIdAsync(id);
            if (queriedTarea == null) {
                return NotFound();
            }
            await _tareaService.UpdateAsync(id, updatedTarea);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id) {
            var tarea = await _tareaService.GetByIdAsync(id);
            if (tarea == null) {
                return NotFound();
            }
            await _tareaService.DeleteAsync(id);
            return NoContent();
        }
    }
}