using EstudioJuridico.BD.Datos;
using EstudioJuridico.Repositorio.Repositorios;
using EstudioJuridico.BD.Datos.Entity;
using EstudioJuridico.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto2025.Shared.ENUM;
using System.Collections.Generic;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/Caso")]
    public class CasoController : ControllerBase
    {
        private readonly ICasoRepositorio repositorio;

        public CasoController(ICasoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Caso>>> GetFull()
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
        public async Task<ActionResult<Caso>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(entidad);
        }

        [HttpGet("SelectByNumeroExpediente/{NumeroExpediente}")]  
        public async Task<ActionResult<Caso>> SelectByNumeroExpediente(int NumeroExpediente)
        {
            var entidad = await repositorio.SelectByNumeroExpediente(NumeroExpediente);
            if (entidad is null)
            {
                return NotFound($"No existe registro con el Numero Expediente: {NumeroExpediente}.");
            }

            return Ok(entidad);
        }
         
        

        [HttpGet("SelectByTipo/{Tipo}")]
        public async Task<ActionResult<CasoResumenDTO>> SelectByTipo(string tipo)
        {
            await repositorio.CasoResumen(tipo);
            return Ok(); 
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CasoCrearDTO DTO)
        {
            try
            {
                Caso entidad = new Caso
                {
                   //Id = DTO.Id,                   
                    NumeroExpediente = DTO.NumeroExpediente,
                    FechaInicio = DTO.FechaInicio,
                    Estado = DTO.Estado,
                    Descripcion = DTO.Descripcion,
                    Tipo = DTO.Tipo
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
        public async Task<ActionResult> Put(int id, Caso DTO)
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
