using Domain.Equipments;
using Microsoft.EntityFrameworkCore;


namespace Application.Interface.Context;

    public interface IDataBaseContext
    {
        public DbSet<Equipment> Equipments { get; set; }
       
    }

