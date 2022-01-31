using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_bloc.Model
{
    class SalarieContext : DbContext
    {
        //les entités ...

        public DbSet<Site> Sites { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Salarie> Salaries { get; set; }


        //la configuration à la base de données SqlServer locale
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sacha\Source\Repos\Evaluation-bloc-WPF\Data\Database1.mdf;Integrated Security=True");


        //Les relations entre les entités
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
