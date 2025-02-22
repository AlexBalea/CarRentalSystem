using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Data;
using CarRentalSystem.Models;

namespace CarRentalSystem.Pages_Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalSystem.Data.ApplicationDbContext _context;

        public DetailsModel(CarRentalSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.CarID == id);

            if (car is not null)
            {
                Car = car;

                return Page();
            }

            return NotFound();
        }
    }
}
