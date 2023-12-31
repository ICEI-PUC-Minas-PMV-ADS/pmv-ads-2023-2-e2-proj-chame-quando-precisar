﻿using Microsoft.EntityFrameworkCore;

namespace WebApplicationADs_Eixo2.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Perfil> Perfils { get; set;}

        public DbSet<DadosUsuarios> DadosUsuarios { get; set; }

        public DbSet<Deficiencia> Deficiencia { get; set; }

        public DbSet<Calendario> Calendarios { get; set;}

        public DbSet<Agendamento> Agendamentos { get; set;}

        //public DbSet<Amigos> Amigos { get; set;}

        public DbSet<Avaliacao> Avaliacao { get; set;}

        //public DbSet<MensagensPrivadas> MensagensPrivadas { get; set;}

        //public DbSet<Notificacoes> Notificacoes { get; set;}

        //public DbSet<Preferencias> Preferencias { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //USUARIOS
            // Configuração do relacionamento entre Usuarios e DADOSUSUARIOS
            modelBuilder.Entity<Usuarios>()
            .HasKey(u => u.Id);
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.DadosUsuarios)
                .WithOne(d => d.Usuario)
                .HasForeignKey<DadosUsuarios>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade);
            // Configuração do relacionamento entre Usuarios e Agendamentos
            modelBuilder.Entity<Usuarios>()
           .HasMany(u => u.Agendamentos)
           .WithOne(a => a.Colaborador)
           .HasForeignKey(a => a.IdColaborador);
            // Configuração do relacionamento entre Usuarios e Perfil
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.IdPerfil);

            //DADOS USUARIOS
            modelBuilder.Entity<DadosUsuarios>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<DadosUsuarios>()
                .HasOne(d => d.Deficiencia)
                .WithMany()
                .HasForeignKey(d => d.IdDeficiencia);

            //CALENDARIO
            modelBuilder.Entity<Calendario>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Calendario>()
           .HasOne(c => c.Usuario)      
            .WithMany(u => u.Calendarios) 
            .HasForeignKey(c => c.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);
            //AGENDAMENTO

            modelBuilder.Entity<Agendamento>()
            .HasKey(a => a.Id);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Calendario)
                .WithOne(c => c.Agendamento)
                .HasForeignKey<Agendamento>(a => a.IdCalendario)
                .OnDelete(DeleteBehavior.NoAction); ;

            //AVALIACAO
            modelBuilder.Entity<Avaliacao>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Avaliacoes)
                .HasForeignKey(a => a.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Agendamento)
                .WithMany(c => c.Avaliacoes)
                .HasForeignKey(a => a.IdAgendamento)
                .OnDelete(DeleteBehavior.NoAction);



            // Configuração da entidade Usuarios
            //modelBuilder.Entity<Usuarios>()
            //.HasOne(u => u.Perfil) // Cada usuário tem um perfil
            // .WithMany(p => p.Usuarios) // Cada perfil pode estar associado a vários usuários
            // .HasForeignKey(u => u.IdPerfil); // Chave estrangeira em Usuarios

            // modelBuilder.Entity<DadosUsuarios>()
            //entity.HasNoKey()

            // .HasOne(u => u.Deficiencia) // Cada usuário tem umA DEFICIENCIA
            //  .WithMany(d => d.DadosUsuarios) // Cada perfil pode estar associado a vários usuários
            //  .HasForeignKey(u => u.IdDeficiencia); // Chave estrangeira em Usuarios

            // Configuração da entidade Perfil
            // modelBuilder.Entity<Perfil>()
            // .HasMany(p => p.Usuarios) // Cada perfil pode estar associado a vários usuários
            //  .WithOne(u => u.Perfil) // Cada usuário tem um perfil
            ///   .HasForeignKey(u => u.IdPerfil); // Chave estrangeira em Usuarios
            // Defina a chave primária composta usando HasKey
            //modelBuilder.Entity<Amigos>()
            //  .HasKey(a => new { a.Usuario1, a.Usuario2 });

            //modelBuilder.Entity<AvaliacaoAgendamento>()
            //.HasKey(a => new { a.IdAgendamento, a.Avaliador });



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
