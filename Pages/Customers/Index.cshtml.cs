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
    public class IndexModel : PageModel
    {
        private readonly CarRentalSystem.Data.ApplicationDbContext _context;

        public IndexModel(CarRentalSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
