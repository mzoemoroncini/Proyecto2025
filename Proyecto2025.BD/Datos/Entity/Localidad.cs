using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    [Index(nameof(Codigo), Name = "Localidad_Codigo_UQ", IsUnique = true)]

    public class Localidad 
    {
        

        [Key]
        public int Id { get; set; }
      

        [Required(ErrorMessage = "El Codigo es obligatorio")]
        [MaxLength(3, ErrorMessage = "1 caracter mínimo")]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "El Nombre de la localidad es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NomLocalidad { get; set; }


        //la navegacion del id localidad que sera enviada a la tabla domicilios
        public List<Domicilio>? Domicilios { get; set; } = new List<Domicilio>();

        // clave foranea que recibo atraves de la navegacion de la tabla provincia
        public int ProvinciaID {  get; set; }
        public Provincia? Provincias { get; set; }

    }
}
