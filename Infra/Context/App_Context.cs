using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class App_Context : DbContext
    {

        public App_Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<LivroAssunto> LivroAssunto { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public DbSet<TpVenda> TpVenda { get; set; }
        public DbSet<LivroTpVenda> LivroTpVenda { get; set; }
      
       

    }
}
