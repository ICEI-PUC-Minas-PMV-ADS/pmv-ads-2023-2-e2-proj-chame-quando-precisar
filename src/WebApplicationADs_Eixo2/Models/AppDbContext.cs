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

            // Configuração da entidade Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Perfil) // Cada usuário tem um perfil
                .WithMany(p => p.Usuarios) // Cada perfil pode estar associado a vários usuários
                .HasForeignKey(u => u.IdPerfil); // Chave estrangeira em Usuarios

            // Configuração da entidade Perfil
            modelBuilder.Entity<Perfil>()
                .HasMany(p => p.Usuarios) // Cada perfil pode estar associado a vários usuários
                .WithOne(u => u.Perfil) // Cada usuário tem um perfil
                .HasForeignKey(u => u.IdPerfil); // Chave estrangeira em Usuarios
            // Defina a chave primária composta usando HasKey
            modelBuilder.Entity<Amigos>()
                .HasKey(a => new { a.Usuario1, a.Usuario2 });

            modelBuilder.Entity<AvaliacaoAgendamento>()
               .HasKey(a => new { a.IdAgendamento, a.Avaliador });



            /* Configuração da entidade Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.DadosUsuarios)
                .WithOne(du => du.Usuario)
                .HasForeignKey<DadosUsuarios>(du => du.IDUser);

            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.IdPerfil);

            modelBuilder.Entity<Usuarios>()
                .HasMany(u => u.Notificacoes)
                .WithOne(n => n.UsuarioDestinatario)
                .HasForeignKey(n => n.IdDestinatario);

            modelBuilder.Entity<Usuarios>()
            .HasMany(u => u.AllCalendario) // Um usuário pode ter várias entradas de calendário
            .WithOne(c => c.Usuario) // Cada entrada de calendário pertence a um único usuário
            .HasForeignKey(c => c.IdUser); // Chave estrangeira em Calendario

            // Configuração da entidade DadosUsuarios
            modelBuilder.Entity<DadosUsuarios>()
                .HasOne(du => du.Usuario)
                .WithOne(u => u.DadosUsuarios)
                .HasForeignKey<Usuarios>(u => u.Id);

            // Configuração da entidade Notificacoes
            modelBuilder.Entity<Notificacoes>()
                .HasOne(n => n.UsuarioDestinatario)
                .WithMany(u => u.Notificacoes)
                .HasForeignKey(n => n.IdDestinatario);

            // Configuração da entidade Perfil
            modelBuilder.Entity<Perfil>()
                .HasMany(p => p.Usuarios)
                .WithOne(u => u.Perfil)
                .HasForeignKey(u => u.IdPerfil);


            modelBuilder.Entity<Amigos>()
                .HasKey(a => new { a.Usuario1, a.Usuario2 });

            modelBuilder.Entity<AvaliacaoAgendamento>()
               .HasKey(a => new { a.IdAgendamento, a.Avaliador });*/


        }


    }
}
