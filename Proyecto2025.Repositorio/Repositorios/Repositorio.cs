using EstudioJuridico.BD.Datos.Entity;
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
    public class Repositorio<E> : IRepositorio<E> where E : class
    {
        private readonly AppDBContext context;

        public Repositorio(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            var entityType = typeof(E);
            var idProperty = entityType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty == null)
                throw new InvalidOperationException($"El tipo {entityType.Name} no tiene una propiedad pública 'Id'.");

            return await context.Set<E>()
                .AnyAsync(x => (int)idProperty.GetValue(x)! == id);
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E?> SelectById(int id)
        {
            var entityType = typeof(E);
            var idProperty = entityType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty == null)
                throw new InvalidOperationException($"El tipo {entityType.Name} no tiene una propiedad pública 'Id'.");

            return await context.Set<E>()
                .FirstOrDefaultAsync(x => (int)idProperty.GetValue(x)! == id);
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                // Usar reflexión para establecer EstadoRegistro si existe
                var estadoProp = typeof(E).GetProperty("EstadoRegistro", BindingFlags.Public | BindingFlags.Instance);
                if (estadoProp != null && estadoProp.CanWrite)
                {
                    estadoProp.SetValue(entidad, ENUMEstadoRegistro.Activo);
                }

                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();

                // Usar reflexión para obtener el valor de la propiedad Id
                var idProp = typeof(E).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
                if (idProp == null)
                    throw new InvalidOperationException($"El tipo {typeof(E).Name} no tiene una propiedad pública 'Id'.");

                return (int)idProp.GetValue(entidad)!;
            }
            catch (Exception err) { throw; }
        }

        public async Task<bool> Update(int id, E entidad)
        {
            // Obtener la propiedad "Id" mediante reflexión
            var idProperty = typeof(E).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty == null)
                throw new InvalidOperationException($"El tipo {typeof(E).Name} no tiene una propiedad pública 'Id'.");

            var entidadId = (int)idProperty.GetValue(entidad)!;
            if (id != entidadId)
            {
                return false;
            }

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

        public async Task<bool> Delete(int id, E entidad)
        {
            // Obtener la propiedad "Id" mediante reflexión
            var idProperty = typeof(E).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty == null)
                throw new InvalidOperationException($"El tipo {typeof(E).Name} no tiene una propiedad pública 'Id'.");

            var entidadId = (int)idProperty.GetValue(entidad)!;
            if (id != entidadId) return false;
            var existe = await Existe(id);

            if (!existe) return false;
            try
            {
                context.Set<E>().Remove(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception err) { throw err; }
        }
    }
}