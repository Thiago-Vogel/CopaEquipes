using AppCore.Implementations;
using AppCore.Models;
using Copa.AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Infrastructure.DataTypes
{
    public class EF_Context : DbContext
    {
        public EF_Context(DbContextOptions<EF_Context> options) : base(options)
        {

        }
        DbSet<Equipe>  Equipes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Equipe>().HasIndex(e => e.Nome).IsUnique();
        }
    }
}
