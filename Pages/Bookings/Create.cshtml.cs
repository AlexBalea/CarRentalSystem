using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Data;
using CarRentalSystem.Models;
using System.Linq;
using System.Threading.Tasks;

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
        public Booking Booking { get; set; }   // Ensures Booking is initialized

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CarID"] = new SelectList(await _context.Cars.ToListAsync(), "CarID", "Make");
            ViewData["CustomerID"] = new SelectList(await _context.Customers.ToListAsync(), "CustomerID", "Name");

            Booking = new Booking
            {
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(1)

            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
         

            ModelState.Remove("Booking.Car");  
            ModelState.Remove("Booking.Customer");  

            if (!ModelState.IsValid)
            {
                ViewData["CarID"] = new SelectList(await _context.Cars.ToListAsync(), "CarID", "Make");
                ViewData["CustomerID"] = new SelectList(await _context.Customers.ToListAsync(), "CustomerID", "Name");
                return Page();
            }

          

            try
            {
                _context.Bookings.Add(Booking);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR Saving Booking: {ex.Message}");
            }

            return RedirectToPage("./Index");
        }

    }
}