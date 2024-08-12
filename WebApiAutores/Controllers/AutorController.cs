using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;
using WebApiAutores.Utilidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autor")]
    public class AutorController : Controller
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;

        public AutorController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AutorDTO>>> Get()
        {
            //Se dirige a la base de datos en la tabla autores y lo convierte en tipo lista
            var autores = await _context.Autores.ToListAsync();

            return _mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpGet("{id:int}")]

        //FromBody indica que la variable viene del cuerpo, tambien se puede agregar FromRoute, FromHeader, son utiles cuando se usan diversos parametros
        public async Task<ActionResult<AutorDTO>> GetId([FromRoute]int id)
        {

            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id); //Realizacion de la busqueda del autor

            if (autor == null)
                return NotFound();

            return _mapper.Map<AutorDTO>(autor); //Convertir a autor DTO
        }


        [HttpGet("{nombre}")]

        public async Task<ActionResult<List<AutorDTO>>> Get([FromRoute] string nombre)
        {

            var autores = await _context.Autores.Where(autor => autor.Nombre.Contains(nombre)).ToListAsync(); //Realizacion de la busqueda del autor

            if (!autores.Any())
                return NotFound();

            return _mapper.Map<List<AutorDTO>>(autores); //Convertir a autor DTO
        }

        //[HttpGet("autor/{nombre}")]

        //public async Task<ActionResult<Autor>>GetName(string nombre)
        //{
        //    var exists = await _context.Autores.AnyAsync(x => x.Nombre == nombre);

        //    if(!exists)
        //        return NotFound();

        //    return await _context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Nombre == nombre);
        //}

        [HttpPost]

        public async Task<IActionResult> Post(AutorCreacionDTO autorDTO) //Autor autor
        {
            //DTO: Data Transfer Object
            //Se utiliza el mapeo y en ella se coloca el valor de retorno
            var autor = _mapper.Map<Autor>(autorDTO); //new Autor() { Nombre = autorDTO.Nombre };

            var exist = await _context.Autores.AnyAsync(x => x.Nombre == autorDTO.Nombre);

            if (exist)      
                return BadRequest($"Modificar nombre, el autor {autorDTO.Nombre} ya existe");

            else
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
                // Ok es el codigo 200, que quiere decir que la petición fue exitosa
                return Ok();
        }

        //Se asigna la ruta única
        //HttpPut es un metodo de actualizacion de datos
        [HttpPut("{id:int}")] //api/autor/id

        public async Task<IActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
                return BadRequest("El id enviado no coincide con el autor");

            //Retorna un booleano que confirma si existe o no
            var exist = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!exist)
                return NotFound();

            var nameExist = await _context.Autores.AnyAsync(x => x.Nombre == autor.Nombre);

            if (nameExist)
                return BadRequest($"Por favor modifique el nombre, el autor {autor.Nombre} ya existe");

          
            _context.Autores.Update(autor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")] // api/autor/id

        public async Task<IActionResult> Delete(int id)
        {
            //Retorna un booleano que confirma si existe o no
            var exist = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!exist)
                return NotFound();

            // Crea un objeto autor para completar el proceso de delete
            var autorEliminado = new Autor() { Id = id };

            _context.Autores.Remove(autorEliminado);
            await _context.SaveChangesAsync();
            return Ok();
        
        }
    }
}
