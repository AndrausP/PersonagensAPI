namespace PersonagensFiltro.DTO;
using Microsoft.EntityFrameworkCore;
using PersonagensFiltro.Entity;

public class DataFile : DbContext
{
    public DataFile(DbContextOptions<DataFile> options) : base(options)
    {
    }
    public DbSet<Personagens> Personagens { get; set; } = null!;
}
    

   
