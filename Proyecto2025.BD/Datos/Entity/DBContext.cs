using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class DBContext : DbContext
    {
        public int Id { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        
    
}
    
}