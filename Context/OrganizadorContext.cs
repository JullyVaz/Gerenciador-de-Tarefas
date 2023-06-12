using Microsoft.EntityFrameworkCore;


using ApiTarefas.Models;

namespace ApiTarefas.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }

        

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}