using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DoctoLib.Core;
using DoctoLib.Data;

namespace DoctoLib.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly DoctoLib.Data.DoctoLibDbContext _context;

        public IndexModel(DoctoLib.Data.DoctoLibDbContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; }

        public async Task OnGetAsync()
        {
            Doctor = await _context.Doctors.ToListAsync();
        }
    }
}
