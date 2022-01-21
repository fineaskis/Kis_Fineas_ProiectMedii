#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kis_Fineas_ProiectMedii.Data;
using Kis_Fineas_ProiectMedii.Models;

namespace Kis_Fineas_ProiectMedii.Pages.Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext _context;

        public DetailsModel(Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(m => m.ManufacturerID == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
