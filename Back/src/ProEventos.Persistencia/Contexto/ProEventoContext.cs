using Microsoft.EntityFrameworkCore;
using ProEventos.Dominio;

namespace ProEventos.Persistencia.Contexto
{
    public class ProEventoContext:DbContext
    {
         public ProEventoContext(DbContextOptions<ProEventoContext> options) : base(options)
         { 
            
         }                

        public DbSet<Evento> Evento { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEvento { get; set; }
        public DbSet<RedeSocial> RedesSociai { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)

         {
             modelBuilder.Entity<PalestranteEvento>()
                 .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

             modelBuilder.Entity<Evento>()
                 .HasMany(e => e.RedesSociais)
                 .WithOne(rs => rs.Evento)
                 .OnDelete(DeleteBehavior.Cascade);

             modelBuilder.Entity<Palestrante>()
                 .HasMany(e => e.RedesSociais)
                 .WithOne(rs => rs.Palestrante)
                 .OnDelete(DeleteBehavior.Cascade);
         }

    }
}