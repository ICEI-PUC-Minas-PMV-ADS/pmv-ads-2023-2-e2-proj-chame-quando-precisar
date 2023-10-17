using Microsoft.EntityFrameworkCore;

namespace WebApplicationADs_Eixo2.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Agendamento> agendamentos { get; set;}

        public DbSet<Amigos> Amigos { get; set;}

       

        public DbSet<AvaliacaoAgendamento> AvaliacaoAgendamentos { get; set;}

        public DbSet<Calendario> Calendarios { get; set;}

        public DbSet<DadosUsuarios> DadosUsuarios { get; set;}

        public DbSet<Deficiencia> Deficiencia { get; set;}

        public DbSet<MensagensPrivadas> MensagensPrivadas { get; set;}

        public DbSet<Notificacoes> Notificacoes { get; set;}

        public DbSet<Perfil> Perfils { get; set;}

        public DbSet<Preferencias> Preferencias { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defina a chave primária composta usando HasKey
            modelBuilder.Entity<Amigos>()
                .HasKey(a => new { a.Usuario1, a.Usuario2 });

            modelBuilder.Entity<AvaliacaoAgendamento>()
               .HasKey(a => new { a.IdAgendamento, a.Avaliador });


        }

    }
}
