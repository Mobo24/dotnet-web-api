using System;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckAPI
{
    public class FoodTruckType
    {
        public FoodTruckType()
        {
        }
        public int Id { get; set; }

        [StringLength(20)]
        public string FoodTruckName { get; set; } = string.Empty;
    }
}

