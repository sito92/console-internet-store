using System.Data.Entity;

namespace CarAndHorseStore.Models
{
    public class Horse
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class HorseContext : DbContext
    {
        public HorseContext()
            : base("DatabaseConnectionString")
        {
            
        }

        public DbSet<Horse> Horses { get; set; }
    }
}
