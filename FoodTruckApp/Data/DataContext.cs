using System;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<FoodTruckType> FoodTruckTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}

