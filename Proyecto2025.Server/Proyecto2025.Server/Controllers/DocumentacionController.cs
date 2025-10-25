using EstudioJuridico.BD.Datos;
using EstudioJuridico.Repositorio.Repositorios;
using EstudioJuridico.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto2025.Server.Controllers
{
 
        [ApiController]
        [Route("api/Documentacion")]
        public class DocumentacionController : ControllerBase
        {
            private readonly IDocumentacionRepositorio repositorio;

            public DocumentacionController(IDocumentacionRepositorio repositorio)
            {
                this.repositorio = repositorio;
            }

            [HttpGet]
            public async Task<ActionResult<List<Documentacion>>> GetFull()
            {
                var lista = await repositorio.Select();
                if (lista == null)
                {
                    return NotFound("No se encontro elementos de la lista, VERIFICAR.");
                }
                if (lista.Count == 0)
                {
                    return Ok("Lista sin registros.");
                }

                return Ok(lista);
            }

        [HttpGet("listacumentacion")] 
        public async Task<ActionResult<List<DocumentacionListadoDTO>>> ListaPais()
        {
            var lista = await repositorio.SelectListaDocumentacion();
            if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("Lista sin registros.");
            }

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
            public async Task<ActionResult<Documentacion>> GetById(int id)
            {
                var entidad = await repositorio.SelectById(id);
                if (entidad is null)
                {
                    return NotFound($"No existe el registro con id: {id}.");
                }

                return Ok(entidad);
            }


            [HttpPost]
            public async Task<ActionResult<int>> Post(Documentacion DTO)
            {
                try
                {
                    Documentacion entidad = new Documentacion
                    {
                        Id = DTO.Id,
                        
                        Descripcion = DTO.Descripcion,
                        FechaCreacion = DTO.FechaCreacion,
                        ArchivoUrl = DTO.ArchivoUrl
                        
                    };
                    var id = await repositorio.Insert(entidad);
                    return Ok(entidad.Id);
                }
                catch (Exception e)
                {
                    return BadRequest($"Error al crear el registro: {e.Message}");
                }
            }

            [HttpPut("{id:int}")]
            public async Task<ActionResult> Put(int id, Documentacion DTO)
            {
                var flag = await repositorio.Update(id, DTO);
                if (!flag)
                {
                    return BadRequest("Datos no validos o el registro no existe.");
                }
                return Ok($"Registro con el id: {id} actualizado correctamente.");
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var flag = await repositorio.Delete(id);
                if (!flag)
                {
                    return NotFound($"No existe el registro con el id: {id} o ya fue eliminado.");
                }

                return Ok($"Registro con el id: {id} eliminado correctamente.");
            }
        }
    }

