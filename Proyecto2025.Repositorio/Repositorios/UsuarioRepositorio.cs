using EstudioJuridico.BD.Datos;
using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.Repositorio.Repositorios
{
   
        public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
        {
            private readonly AppDBContext context;

            public UsuarioRepositorio(AppDBContext context) : base(context)
            {
                this.context = context;
            }
        }
}


