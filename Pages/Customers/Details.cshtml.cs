using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Data;
using CarRentalSystem.Models;

namespace CarRentalSystem.Pages_Customers
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalSystem.Data.ApplicationDbContext _context;

        public DetailsModel(CarRentalSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerID == id);

            if (customer is not null)
            {
                Customer = customer;

                return Page();
            }

            return NotFound();
        }
    }
}
