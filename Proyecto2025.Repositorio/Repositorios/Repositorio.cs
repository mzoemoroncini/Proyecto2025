﻿using EstudioJuridico.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Proyecto2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace EstudioJuridico.Repositorio.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IBaseEntity
    {
        private readonly AppDBContext context;

        public Repositorio(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = await context.Set<E>()
                                       .AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E?> SelectById(int id)
        {
            return await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                entidad.EstadoRegistro = ENUMEstadoRegistro.Activo;
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err) { throw err; }
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id) return false;

            var existe = await Existe(id);
            if (!existe) return false;

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception err) { throw err; }
        }
        public async Task<bool> Delete(int id)
        {
            var entidad = await context.Set<E>().FindAsync(id);
            if (entidad == null) return false;

            try
            {
                context.Set<E>().Remove(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

    }
}