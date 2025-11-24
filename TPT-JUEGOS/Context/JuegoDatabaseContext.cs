using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPT_JUEGOS.Models;
using System.Collections.Generic;

namespace TPT_JUEGOS.Context
{
    public class JuegoDatabaseContext : DbContext
    {
        public JuegoDatabaseContext(DbContextOptions<JuegoDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Juego> Juegos { get; set; }

        public DbSet<CatalogoJuegos> CatalogoJuegos { get; set; }
    }
}
