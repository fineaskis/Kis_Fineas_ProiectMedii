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

namespace Kis_Fineas_ProiectMedii.Pages.Devices
{
    public class DeleteModel : PageModel
    {
        private readonly Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext _context;

        public DeleteModel(Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device.FirstOrDefaultAsync(m => m.ID == id);

            if (Device == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device.FindAsync(id);

            if (Device != null)
            {
                _context.Device.Remove(Device);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
