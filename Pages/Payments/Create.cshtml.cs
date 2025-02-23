using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalSystem.Data;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Pages_Payments
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalSystem.Data.ApplicationDbContext _context;

        public CreateModel(CarRentalSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BookingID");
            return Page();
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
           

            if (!ModelState.IsValid)
            {
                
                ViewData["BookingID"] = new SelectList(await _context.Bookings.ToListAsync(), "BookingID", "BookingID");
                return Page();
            }

            
            try
            {
                _context.Payments.Add(Payment);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR Saving Payment: {ex.Message}");
            }

            return RedirectToPage("./Index");
        }

    }
}
