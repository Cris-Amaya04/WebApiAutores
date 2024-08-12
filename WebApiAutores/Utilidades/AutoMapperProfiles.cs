using AutoMapper;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;

namespace WebApiAutores.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Regla de mapeo, se establecen los parametros de lo que va a recibir, y lo que va a retornar
            CreateMap<AutorCreacionDTO, Autor>();

            CreateMap<Autor, AutorDTO>();

            CreateMap<LibroCreacionDTO, Libro>();

            CreateMap<Libro, LibroDTO>();

            CreateMap<ComentarioAutorCreacionDTO, ComentarioAutores>();

            CreateMap<ComentarioAutores, ComentarioAutorDTO>();

            CreateMap<ComentarioLibroCreacionDTO, Comentario>();

            CreateMap<Comentario, ComentarioLibroDTO>();

            


        }
    }
}
