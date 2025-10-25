using EstudioJuridico.BD.Datos;
using EstudioJuridico.BD.Datos.Entity;
using EstudioJuridico.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.Repositorio.Repositorios
{
    public interface ITipoDocumentacionRepositorio : IRepositorio<TipoDocumentacion>
    {
        Task<List<TipoDocumentacionListadoDTO>> SelectListaTipoDocumentacion();
    }
}
