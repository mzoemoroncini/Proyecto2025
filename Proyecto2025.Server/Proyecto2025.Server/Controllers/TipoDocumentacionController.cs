using EstudioJuridico.BD.Datos;
using EstudioJuridico.Repositorio.Repositorios;
using EstudioJuridico.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto2025.Shared.ENUM;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/TipoDocumentacion")]
    public class TipoDocumentacionController : ControllerBase
    {
        private readonly ITipoDocumentacionRepositorio repositorio;

        public TipoDocumentacionController(ITipoDocumentacionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentacion>>> GetFull()
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

        [HttpGet("listatipodocumento")] 
        public async Task<ActionResult<List<TipoDocumentacionListadoDTO>>> ListaTipoDocumentacion()
        {
            var lista = await repositorio.SelectListaTipoDocumentacion();
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
        public async Task<ActionResult<TipoDocumentacion>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(entidad);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(TipoDocumentacion DTO)
        {
            try
            {
                TipoDocumentacion entidadtd = new TipoDocumentacion
                {
                    Id = DTO.Id,
                    Nombre = DTO.Nombre,

                };
                var id = await repositorio.Insert(entidadtd);
                return Ok(entidadtd.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el registro: {e.Message}");
            }
        }

        

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, TipoDocumentacion DTO)
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
