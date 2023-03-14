using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OMC.Data;
using OMC.Hubs;
using OMC.Models;
namespace OMC.Pages
{
    public class waitingorderModel : PageModel
    {
        private readonly OMCContext _context;
        private readonly IHubContext<Queuehub> _queueHubContext;

        public waitingorderModel(OMCContext context, IHubContext<Queuehub> queueHubContext)
        {
            _context = context;
            _queueHubContext = queueHubContext;
        }
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id,string status)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            else
            {
                Order = order;
            }
            return Page();

        }
        public async Task<IActionResult> UpdateQueuePositions(int orderId)
        {
            var order = await _context.Order.FindAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            // Set the queue position based on the order ID
            var queuePosition = _context.Order
                .Where(o => o.Status == "Waiting" && o.OrderId <= order.OrderId)
                .Count();

            order.QueuePosition = queuePosition;

            if (order.Status == "Done")
            {
                // Decrement the queue position by 1
                order.QueuePosition = await _context.Order.Where(o => o.Status == "Waiting" && o.OrderId != orderId)
                    .CountAsync() - 1;
            }
            else
            {
                // Increment the queue position by 1
                order.QueuePosition = await _context.Order.Where(o => o.Status == "Waiting" && o.OrderId != orderId)
                    .CountAsync() + 1;
            }


            await _context.SaveChangesAsync();

            // Send a signal to update the countdown
            await _queueHubContext.Clients.All.SendAsync("UpdateCountdown", queuePosition);

            return RedirectToAction(nameof(Index));
        }

    }
}
