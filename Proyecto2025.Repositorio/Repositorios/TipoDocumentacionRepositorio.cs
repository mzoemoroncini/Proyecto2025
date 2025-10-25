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
   
        public class TipoDocumentacionRepositorio : Repositorio<TipoDocumentacion>, ITipoDocumentacionRepositorio
        {
            private readonly AppDBContext context;

            public TipoDocumentacionRepositorio(AppDBContext context) : base(context)
            {
                this.context = context;
            }

        public async Task<List<TipoDocumentacionListadoDTO>> SelectListaTipoDocumentacion()
        {
            var lista = await context.TipoDocumentos
                                    .Select(p => new TipoDocumentacionListadoDTO
                                    {
                                        Id = p.Id,
                                        Nombre = p.Nombre
                                         })
                                    .ToListAsync();
            return lista;
        }
    }
    
}
