using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OMC.Models;
using OMC.Data;
namespace OMC.Pages.Products
{
    public class ProductDetailsModel : PageModel
    {
        private readonly OMC.Data.OMCContext _context;


        public ProductDetailsModel(OMC.Data.OMCContext context)
        {
            _context = context;
        }
        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
