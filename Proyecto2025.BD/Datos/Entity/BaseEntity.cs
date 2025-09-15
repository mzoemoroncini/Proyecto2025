using Proyecto2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class BaseEntity : IBaseEntity
    {
            public int Id { get; set; }
            ENUMEstadoRegistro EstadoRegistro { get; set; }

    }
}
