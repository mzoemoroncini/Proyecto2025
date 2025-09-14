using Proyecto2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    internal interface IBaseEntity
    {
            int Id { get; set; }
            ENUMEstadoRegistro EstadoRegistro { get; set; }
    }

}
