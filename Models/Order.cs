using Microsoft.Build.Framework;

namespace OMC.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; } = "Coffee";
        [Required]
        public string Sugar { get; set; } = "Nomal";
        public int Cup_Amount { get; set; }
        public int Cup_Price { get; set; }
        public string Status { get; set; } = "Waiting";
        public int ProductID { get; set; }
        
        public int QueuePosition { get; set; } // new property for queue positon 
        public Product? Product { get; set; } 
    }
}
