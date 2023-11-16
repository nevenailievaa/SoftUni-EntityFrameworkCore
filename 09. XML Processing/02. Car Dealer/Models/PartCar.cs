using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class PartCar
    {
        //Part
        public int PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; } = null!; 


        //Car
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!; 
    }
}
