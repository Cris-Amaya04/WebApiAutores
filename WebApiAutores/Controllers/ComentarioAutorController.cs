using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/comentario")]
    public class ComentarioAutorController : Controller
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;

        public ComentarioAutorController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ComentarioAutorDTO>>> Get()
        {
            var comentarios = await _context.ComentarioAut.ToListAsync();

            return _mapper.Map<List<ComentarioAutorDTO>>(comentarios);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<ComentarioAutorDTO>> GetId([FromRoute] int id)
        {
            var comentario = await _context.ComentarioAut.FirstOrDefaultAsync(x => x.Id == id);

            if (comentario == null)
                return NotFound();

            return _mapper.Map<ComentarioAutorDTO>(comentario);
        }

        [HttpPost]

        public async Task<IActionResult> Post(ComentarioAutorCreacionDTO comentarioAutorDTO)
        {
            var comentario = _mapper.Map<ComentarioAutores>(comentarioAutorDTO);

            _context.ComentarioAut.Add(comentario);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        
        public async Task<IActionResult> Put(ComentarioAutorCreacionDTO comentarioauDTO, int id)
        {
            var comentario = _mapper.Map<ComentarioAutores>(comentarioauDTO);
            comentario.Id = id;

            var exist = await _context.ComentarioAut.AnyAsync(x => x.Id == id);

            var autorExiste = await _context.Autores.AnyAsync(x => x.Id == comentarioauDTO.AutorId);
            if (!autorExiste)
                return BadRequest("Autor no encontrado");

            _context.ComentarioAut.Update(comentario);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var existe = await _context.ComentarioAut.AnyAsync(x => x.Id == id);

            if (!existe)
                return NotFound();

            var comentarioEliminado = new ComentarioAutores() { Id = id };

            _context.ComentarioAut.Remove(comentarioEliminado);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
