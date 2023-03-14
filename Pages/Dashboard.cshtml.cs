using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OMC.Data;
using OMC.Models;

namespace OMC.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly OMCContext _context;
        public DashboardModel(OMCContext context)
        {
            _context = context;
        }
        public IList<Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
               Order = await _context.Order.ToListAsync();
            }
        }
    }
}

