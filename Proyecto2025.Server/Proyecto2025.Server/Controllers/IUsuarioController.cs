using EstudioJuridico.BD.Datos;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto2025.Server.Controllers
{
    public interface IUsuarioController
    {
        Task<ActionResult> Delete(int id);
        Task<ActionResult<Usuario>> GetById(int id);
        Task<ActionResult<List<Usuario>>> GetFull();
        Task<ActionResult<int>> Post(Usuario DTO);
        Task<ActionResult> Put(int id, Usuario DTO);
    }
}