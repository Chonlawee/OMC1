using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OMC.Data;
using OMC.Models;

namespace OMC.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly OMCContext _context;

        public CreateModel(OMCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } 


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            byte[] bytes = null;


            if (Product.ImgFile != null)
            {
                using (Stream fs = Product.ImgFile
                    .OpenReadStream())
                {
                    using(BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                    Product.ProductImage = Convert.ToBase64String(bytes, 0, bytes.Length);
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
