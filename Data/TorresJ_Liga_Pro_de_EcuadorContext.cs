using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TorresJ_Liga_Pro_de_Ecuador.Models;

namespace _Liga_Pro_de_Ecuador.Data
{
    public class TorresJ_Liga_Pro_de_EcuadorContext : DbContext
    {
        public TorresJ_Liga_Pro_de_EcuadorContext (DbContextOptions<TorresJ_Liga_Pro_de_EcuadorContext> options)
            : base(options)
        {
        }

        public DbSet<TorresJ_Liga_Pro_de_Ecuador.Models.Jugador> Jugador { get; set; } = default!;
    }
}
