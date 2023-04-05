using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OMC.Data;
using OMC.Models;
using Microsoft.AspNetCore.Http;


namespace OMC.Pages
{
    public class OrderDetailModel : PageModel
    {
        private readonly OMCContext _context;
        public OrderDetailModel(OMCContext context)
        {
            _context = context;
        }
        public Product Product { get; set; }
        [BindProperty]
        public Order Order { get; set; }
      

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var product = await _context.Product.FirstOrDefaultAsync(p => p.ProductID == id);
            {
                if (product == null)
                {
                    return NotFound();
                }
                //else
                //{
                //    // Check if there is a previous "Waiting" order
                //    bool hasWaitingOrder = _context.Order.Any(o => o.Status == "Waiting");

                //    // Check if there is a previous "Done" order
                //    bool hasDoneOrder = _context.Order.Any(o => o.Status == "Done");

                //    // Add code to handle the result of the queries
                //    if (hasDoneOrder)
                //    {
                //        // Update the current order status to "OnProcess"
                //        Order.ProductID = product.ProductID;
                //        Order.Name = Product.ProductName;
                //        Order.Cup_Price = Order.Cup_Price;
                //        Order.Status = "OnProcess";
                //        _context.Order.Add(Order);
                //        _context.SaveChanges();

                //        // Handle the case where a previous "Done" order exists
                //    }
                //    else if (hasWaitingOrder)
                //    {
                //        Order.ProductID = product.ProductID;
                //        Order.Name = Product.ProductName;
                //        Order.Cup_Price = Order.Cup_Price;
                //        Order.Status = "Waiting";
                //        _context.Order.Add(Order);
                //        _context.SaveChanges();
                //    }
                //    else
                //    {
                //        Order.ProductID = product.ProductID;
                //        Order.Name = Product.ProductName;
                //        Order.Cup_Price = Order.Cup_Price;
                //        Order.Status = "Waiting";
                //        _context.Order.Add(Order);
                //        _context.SaveChanges();
                //    }
                    Order.ProductID = product.ProductID;
                    Order.Name = product.ProductName;
                    Order.Cup_Price = product.ProductPrice;
                    Order.Status = "Waiting";
            }
            


            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
       
    }
}
