using EstudioJuridico.BD.Datos;
using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.Repositorio.Repositorios
{
    public interface ICasoRepositorio : IRepositorio<Caso>
    {
        Task CasoResumen(string tipo);
        Task<bool> Delete(int id);
        Task<Caso?> SelectByNumeroExpediente(int NumeroExpediente);
        Task<List<Caso?>> SelectByTipo(string tipo);
    }
}
