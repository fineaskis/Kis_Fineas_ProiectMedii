#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kis_Fineas_ProiectMedii.Data;
using Kis_Fineas_ProiectMedii.Models;

namespace Kis_Fineas_ProiectMedii.Pages.Devices
{
    public class EditModel : DeviceCategoriesPageModel
    {
        private readonly Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext _context;

        public EditModel(Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Device Device { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device
                .Include(b => b.Manufacturer)
                .Include(b => b.DeviceCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Device == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Device);
            ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(), "ID", "ManufacturerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deviceToUpdate = await _context.Device
            .Include(i => i.Manufacturer)
            .Include(i => i.DeviceCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (deviceToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Device>(
            deviceToUpdate,
            "Device",
            i => i.Name, i => i.Seller,
            i => i.Price, i => i.ManufacturingDate, i => i.Manufacturer))
            {
                UpdateDeviceCategories(_context, selectedCategories, deviceToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateDeviceCategories(_context, selectedCategories, deviceToUpdate);
            PopulateAssignedCategoryData(_context, deviceToUpdate);
            return Page();
        }
   
    }
}
