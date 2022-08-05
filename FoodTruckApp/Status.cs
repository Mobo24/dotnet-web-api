using System;
using System.ComponentModel.DataAnnotations;
namespace FoodTruckAPI
{
    public class Status
    {
        public Status()
        {
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string StatusOption { get; set; } = string.Empty;
    }
}

