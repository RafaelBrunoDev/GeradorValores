using GeradorValores.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace GeradorValores.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<tbl_funcionarios> Funcionarios { get; set; }
        public DbSet<tbl_funcionarios_valor_hora> FuncionariosValorHora { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_funcionarios_valor_hora>()
                .HasRequired(fvh => fvh.Funcionario)
                .WithMany(f => f.ValoresHora)
                .HasForeignKey(fvh => fvh.id_funcionario)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }




}