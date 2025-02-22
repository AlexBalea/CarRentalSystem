using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Data;
using CarRentalSystem.Models;

namespace CarRentalSystem.Pages_Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CarID"] = new SelectList(await _context.Cars.ToListAsync(), "CarID", "Make");
            ViewData["CustomerID"] = new SelectList(await _context.Customers.ToListAsync(), "CustomerID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"ALEXXXX: Validation Error: {error.ErrorMessage}");
                }


                ViewData["CarID"] = new SelectList(await _context.Cars.ToListAsync(), "CarID", "Make");
                ViewData["CustomerID"] = new SelectList(await _context.Customers.ToListAsync(), "CustomerID", "Name");
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
