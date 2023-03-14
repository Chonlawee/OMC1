using System.ComponentModel.DataAnnotations.Schema;

namespace OMC.Models
{

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = "Coffee";
        public int ProductPrice { get; set; }

        public string ProductImage { get; set; } = "Don't have image";

        [NotMapped]
        public IFormFile? ImgFile { get; set; }

    }
     
}

