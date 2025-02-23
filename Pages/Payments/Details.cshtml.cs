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
    public class DetailsModel : PageModel
    {
        private readonly CarRentalSystem.Data.ApplicationDbContext _context;

        public DetailsModel(CarRentalSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
