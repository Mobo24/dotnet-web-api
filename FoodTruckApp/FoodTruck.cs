using System;
using System.ComponentModel.DataAnnotations;
namespace FoodTruckAPI
{
    public class FoodTruck
    {
        public FoodTruck()
        { }
        public int id { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        public double latitude { get; set; } = 0.0;

        public double longitude { get; set; } = 0.0;

        public int FoodTruckTypeID { get; set; }

        public FoodTruckType? FoodTruckType{get; set;}


    }
}

