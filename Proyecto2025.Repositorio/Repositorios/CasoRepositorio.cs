using EstudioJuridico.BD.Datos;
using EstudioJuridico.BD.Datos.Entity;
using EstudioJuridico.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.Repositorio.Repositorios
{
    public class CasoRepositorio : Repositorio<Caso>, ICasoRepositorio
    {
        private readonly AppDBContext context;

        public CasoRepositorio(AppDBContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<CasoListadoDTO>> SelectListaCaso()
        {
            var lista = await context.Casos
                                    .Select(p => new CasoListadoDTO
                                    {
                                        NumeroExpediente = p.NumeroExpediente,
                                        DatosCaso = $"{p.Estado} - {p.Tipo}"
                                    })
                                    .ToListAsync();
            return lista;
        }
        public async Task<Caso?> GetByNumeroExpediente(int NumeroExpediente)
       {
            try
            {
               Caso? entidad = await context.Casos
                                            .FirstOrDefaultAsync(x => x.NumeroExpediente == NumeroExpediente);
               return entidad;
           }
           catch (Exception e)
          {
              throw;
           }
        


    }
    }
}

