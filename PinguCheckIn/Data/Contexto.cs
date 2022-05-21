
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace PinguCheckIn.Data
{
    public class Contexto : PinguCheckInContext
    {

        public Contexto()
        {
            this.Database.SetCommandTimeout(90);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder configuracoes)
        {
            if (!configuracoes.IsConfigured)
            {
                this.ConfigurarConexao(configuracoes);
            }
        }

        private void ConfigurarConexao(DbContextOptionsBuilder configuracoes)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


            var conexao = configuration.GetConnectionString("PinguCheckInContext");

            configuracoes.UseSqlServer(conexao, options => options.EnableRetryOnFailure());
        }

        ~Contexto()
        {
            this.Dispose();
            GC.Collect();
        }
    }
}
