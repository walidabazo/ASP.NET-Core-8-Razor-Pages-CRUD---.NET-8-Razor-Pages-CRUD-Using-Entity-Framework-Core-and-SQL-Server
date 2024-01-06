using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Tutorial.Models;
using Product_Tutorial.Services;

namespace Product_Tutorial.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly Product_Tutorial.Services.ApplicationDbContext _context;

        public DeleteModel(Product_Tutorial.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductTable ProductTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttable = await _context.productTables.FirstOrDefaultAsync(m => m.Id == id);

            if (producttable == null)
            {
                return NotFound();
            }
            else
            {
                ProductTable = producttable;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttable = await _context.productTables.FindAsync(id);
            if (producttable != null)
            {
                ProductTable = producttable;
                _context.productTables.Remove(ProductTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
