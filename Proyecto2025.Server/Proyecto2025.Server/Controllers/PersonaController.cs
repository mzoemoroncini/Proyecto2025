using EstudioJuridico.BD.Datos;
using EstudioJuridico.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto2025.Server.Controllers
{
    public class PersonaController
    {
        [ApiController]
        [Route("api/Persona")]
        public class PersonaController : ControllerBase
        {
            private readonly IPersonaRepositorio repositorio;

            public PersonaController(IPersonaRepositorio repositorio)
            {
                this.repositorio = repositorio;
            }

            [HttpGet]
            public async Task<ActionResult<List<Persona>>> GetFull()
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



            [HttpGet("{id:int}")]
            public async Task<ActionResult<Persona>> GetById(int id)
            {
                var entidad = await repositorio.SelectById(id);
                if (entidad is null)
                {
                    return NotFound($"No existe el registro con id: {id}.");
                }

                return Ok(entidad);
            }


            [HttpPost]
            public async Task<ActionResult<int>> Post(Persona DTO)
            {
                try
                {
                    Persona entidad = new Persona
                    {
                        Id = DTO.Id,
                        Nombre = DTO.Nombre,
                        Apellido = DTO.Apellido,
                        Telefono = DTO.Telefono,
                        DNI = DTO.DNI,
                        TasaJusticia_Aportes = DTO.TasaJusticia_Aportes,
                        Mail = DTO.Mail

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
            public async Task<ActionResult> Put(int id, Persona DTO)
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
}
}
