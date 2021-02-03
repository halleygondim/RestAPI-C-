using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models.Context
{
    public class OracleContext : DbContext
    {
        public OracleContext() { } 

        public OracleContext(DbContextOptions<OracleContext> options) : base(options) {}

        //QUAIS BASES DE DADOS IREMOS USAR, OU SEJA, QUAIS SÃO AS TABELAS.
   
        public DbSet<User> Users { get; set; }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Acessorio> Acessorios { get; set; }
        public DbSet<AcessorioVeiculo> AcessoriosVeiculos { get; set; }

  

    }
}
