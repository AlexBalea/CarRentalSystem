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

            Booking = new Booking();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("🟢 Booking Submission Started");
            Console.WriteLine($"Received CarID: {Booking.CarID}");
            Console.WriteLine($"Received CustomerID: {Booking.CustomerID}");

            ModelState.Remove("Booking.Car");  // Prevent EF from requiring `Car`
            ModelState.Remove("Booking.Customer");  // Prevent EF from requiring `Customer`

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState is INVALID.");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // Repopulate dropdowns before returning the page
                ViewData["CarID"] = new SelectList(await _context.Cars.ToListAsync(), "CarID", "Make");
                ViewData["CustomerID"] = new SelectList(await _context.Customers.ToListAsync(), "CustomerID", "Name");

                return Page();
            }

            Console.WriteLine($"🟢 Saving Booking: CarID={Booking.CarID}, CustomerID={Booking.CustomerID}");

            try
            {
                _context.Bookings.Add(Booking);
                await _context.SaveChangesAsync();
                Console.WriteLine("✅ Booking saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR Saving Booking: {ex.Message}");
            }

            return RedirectToPage("./Index");
        }




        //_context.Bookings.Add(Booking);
        //  await _context.SaveChangesAsync();
        //return RedirectToPage("./Index");
        //}
    }
}
