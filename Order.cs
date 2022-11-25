using CPS.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CPS
{
    public class Order
    {
        [WorkingDays]
        public string? DateRequired { get; set; }

        [Range(11.5, 15)]
        public double Size { get; set; }

        public string? Notes { get; set; }

        [MultipleOf1000]
        public int Quantity { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Required]
        public string CustomerName { get; set; }


      


    }
}