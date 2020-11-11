using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace CodeFirstDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    public class DBContext : DbContext
    { 
        public DbSet<Cliente> Cliente { get; set; }
    }

}
