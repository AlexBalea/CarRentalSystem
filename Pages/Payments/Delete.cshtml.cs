using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Data;
using CarRentalSystem.Models;

namespace CarRentalSystem.Pages_Payments
{
    public class DeleteModel : PageModel
    {
        private readonly CarRentalSystem.Data.ApplicationDbContext _context;

        public DeleteModel(CarRentalSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FirstOrDefaultAsync(m => m.PaymentID == id);

            if (payment is not null)
            {
                Payment = payment;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                Payment = payment;
                _context.Payments.Remove(Payment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
