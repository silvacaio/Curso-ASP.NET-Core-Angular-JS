﻿using CS.Eventos.IO.Domain.Eventos;
using CS.Eventos.IO.Domain.Organizadores;
using CS.Eventos.IO.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using CS.Eventos.IO.Infra.Data.Extensions;

namespace CS.Eventos.IO.Infra.Data.Context
{
    public class EventosContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EventoMapping());
            modelBuilder.AddConfiguration(new EnderecoMapping());
            modelBuilder.AddConfiguration(new CategoriaMapping());
            modelBuilder.AddConfiguration(new OrganizadorMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EventosIODEMO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));


        }
    }
}