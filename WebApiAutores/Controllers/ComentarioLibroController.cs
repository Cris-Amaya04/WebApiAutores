using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libro/{LibroId}/comentariolibro")] //Estableciendo una ruta más específica
    public class ComentarioLibroController : Controller
    {
        private readonly AplicationContext _context;
        private IMapper _mapper;

        public ComentarioLibroController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<ComentarioLibroDTO>>> Get(int LibroId)
        {
            var libroExiste = await _context.Libros.AnyAsync(libroDB => libroDB.Id == LibroId);

            if (!libroExiste)
                return NotFound();

            var comentarios = await _context.ComentarioLibros.Where(com => com.LibroId == LibroId).ToListAsync();

            return _mapper.Map<List<ComentarioLibroDTO>>(comentarios); //Convierte desde el mapper a una lista de comentarios
        }


        [HttpPost]

        public async Task<ActionResult> Post([FromRoute] int LibroId, [FromBody] ComentarioLibroCreacionDTO comentarioCreacionDTO)
        {
            var libroExiste = await _context.Libros.AnyAsync(libroDB => libroDB.Id == LibroId);

            if (!libroExiste)
                return NotFound();

            var comentario = _mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.LibroId = LibroId;
            _context.ComentarioLibros.Add(comentario);

            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpPut]

        public async Task<ActionResult> Put([FromRoute] int LibroId, ComentarioLibroCreacionDTO comentariolibDTO, int id)
        {
            var comentario = _mapper.Map<Comentario>(comentariolibDTO);
            comentario.Id = id;
            comentario.LibroId = LibroId;

            var existe = await _context.ComentarioLibros.AnyAsync(x => x.Id == id);

            var libroExiste = await _context.Libros.AnyAsync(libroDB => libroDB.Id == LibroId);
            if (!libroExiste)
                return NotFound();

            _context.ComentarioLibros.Update(comentario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]

        public async Task<ActionResult> Delete([FromRoute] int LibroId, int id)
        {
            var existe = await _context.ComentarioLibros.AnyAsync(x => x.Id == id);

            if (!existe)
                return NotFound();

            var libroExiste = await _context.Libros.AnyAsync(libroDB => libroDB.Id == LibroId);
            if (!libroExiste)
                return NotFound();

            var comentariolibEliminado = new Comentario() { Id = id };

            _context.ComentarioLibros.Remove(comentariolibEliminado);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
