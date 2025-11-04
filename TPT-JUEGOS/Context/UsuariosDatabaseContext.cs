using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPT_JUEGOS.Models;
using System.Collections.Generic;

namespace TPT_JUEGOS.Context
{
    public class UsuariosDatabaseContext : DbContext
    {
        public UsuariosDatabaseContext(DbContextOptions<UsuariosDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    
    }
}
