using EstudioJuridico.BD.Datos;
using EstudioJuridico.BD.Datos.Entity;
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

        //public async Task<Caso?> GetByNumeroExpediente(int NumeroExpediente)
        //{
        //    try
        //    {
        //        Caso? entidad = await context.Casos
        //                                     .FirstOrDefaultAsync(x => x.NumeroExpediente == NumeroExpediente);
        //        return entidad;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<List<Caso?>> GetByTipo(string tipo)
        //{
        //    try
        //    {
        //        if (!Enum.TryParse<TipoCaso>(tipo, out var tipoEnum))
        //            return new List<Caso?>();

        //        List<Caso?> lista = await context.Casos.Where(x => x.Tipo == tipoEnum).ToListAsync();
        //        return lista;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        }
    }


