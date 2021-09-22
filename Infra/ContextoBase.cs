using Infra.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SolicitacaoEmail> SolicitacaoEmail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
            }
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=DESKTOP-HVNTI80\\DESENVOLVIMENTO;Initial Catalog=Fila_Email_AULA;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;";
            return strCon;
        }

    }
}
