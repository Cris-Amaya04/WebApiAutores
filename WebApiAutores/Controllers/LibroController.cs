using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/Libro")]
    public class LibroController : Controller
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;

        public LibroController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<List<LibroDTO>> Get()
        {
            var libros = await _context.Libros.ToListAsync();

            return _mapper.Map<List<LibroDTO>>(libros);
        }

        [HttpGet("{id:int}")] // Ruta api/Libro/id
        //ActionResult colabora a poder hacer retorno de ciertas funciones, como Ok, notFound
        public async Task<ActionResult<LibroDTO>> Get(int id)
        {
            var exist = await _context.Libros.AnyAsync(x => x.Id == id);

            if (!exist)
                return NotFound();

            var libro = await _context.Libros.Include(libroDB => libroDB.Comentarios).FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<LibroDTO>(libro);
        }

        //[HttpGet("{id:int}")] // Ruta api/Libro/id
        ////ActionResult colabora a poder hacer retorno de ciertas funciones, como Ok, notFound
        //public async Task<ActionResult<Libro>> Get(int id)
        //{
        //    var exist = await _context.Libros.AnyAsync(x => x.Id == id);

        //    if (!exist)
        //        return NotFound();

        //    return await _context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);
        //}

        [HttpGet("libro/{titulo}")] // Ruta api/Libro/titulo
        //ActionResult colabora a poder hacer retorno de ciertas funciones, como Ok, notFound
        public async Task<ActionResult<List<LibroDTO>>> GetName([FromRoute]string titulo)
        {
            var libros = await _context.Libros.Where(title => title.Titulo.Contains(titulo)).ToListAsync();

            if (!libros.Any())
                return NotFound();

            return _mapper.Map<List<LibroDTO>>(libros);
 
        }

        //[HttpGet("libro/{titulo}")] // Ruta api/Libro/titulo
        ////ActionResult colabora a poder hacer retorno de ciertas funciones, como Ok, notFound
        //public async Task<ActionResult<List<Libro>>> GetName(string titulo)
        //{
        //    var exist = await _context.Libros.AnyAsync(x => x.Titulo == titulo);

        //    if (!exist)
        //        return NotFound();

        //    return await _context.Libros.Include(x => x.Autor).Where(title => title.Titulo.Contains(titulo)).ToListAsync();
        //    /*FirstOrDefaultAsync(x => x.Titulo == titulo)*/
        //}

        [HttpPost]

        public async Task<ActionResult> Post(LibroCreacionDTO libroDTO)
        {
            //var exist = await _context.Libros.AnyAsync(x => x.Titulo == libro.Titulo);
            //if (exist)
            //    return BadRequest($"Modificar nombre, el titulo {libro.Titulo} ya existe");

            var autorExiste = await _context.Autores.AnyAsync(x => x.Id == libroDTO.AutorId);
            if (!autorExiste) return BadRequest("Autor no encontrado");

            var libro = _mapper.Map<Libro>(libroDTO);
            _context.Libros.Add(libro);

            await _context.SaveChangesAsync();

            return Ok();

            //[HttpPost]
            //public async Task<ActionResult> Post(Libro libro)
            //{
            //    var exist = await _context.Libros.AnyAsync(x => x.Titulo == libro.Titulo);
            //    if (exist)
            //        return BadRequest($"Modificar nombre, el titulo {libro.Titulo} ya existe");

            //    var autorExiste = await _context.Autores.AnyAsync(x => x.Id == libro.AutorId);
            //    if(!autorExiste) return BadRequest("Autor no encontrado");

            //    _context.Libros.Add(libro);

            //    await _context.SaveChangesAsync();

            //    return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Put(LibroCreacionDTO libroDTO, int id)
        {

            var libro = _mapper.Map<Libro>(libroDTO);
            libro.Id = id;

            var exist = await _context.Libros.AnyAsync(x => x.Id == id);

            if (!exist) 
                return NotFound();

            var autorExiste = await _context.Autores.AnyAsync(x => x.Id == libroDTO.AutorId);
            if (!autorExiste) return BadRequest("Autor no encontrado");

            var tituloExiste = await _context.Libros.AnyAsync(x => x.Titulo == libroDTO.Titulo);

            if (tituloExiste)
                return BadRequest($"Por favor modifique el titulo del libro, el titulo {libroDTO.Titulo} ya está registrado");


            _context.Libros.Update(libro);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _context.Libros.AnyAsync(libro => libro.Id == id);

            if(!exist) 
                return NotFound();

            var libroEliminado = new Libro() { Id = id };

            _context.Libros.Remove(libroEliminado);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
