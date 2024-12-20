using Application.Interface.Context;
using Domain.Equipments;
using Microsoft.EntityFrameworkCore;


namespace Persistence;
public class DataBaseContext : DbContext, IDataBaseContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
      : base(options)
    {

    }

    public DbSet<Equipment> Equipments { get; set; }
}
