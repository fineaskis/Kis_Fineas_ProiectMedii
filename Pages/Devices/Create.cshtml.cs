#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kis_Fineas_ProiectMedii.Data;
using Kis_Fineas_ProiectMedii.Models;

namespace Kis_Fineas_ProiectMedii.Pages.Devices
{
    public class CreateModel : DeviceCategoriesPageModel
    {
        private readonly Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext _context;

        public CreateModel(Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(), "ID", "ManufacturerName");
            var device = new Device();
            device.DeviceCategories = new List<DeviceCategory>();
            PopulateAssignedCategoryData(_context, device);

        return Page();
        }

        [BindProperty]
        public Device Device { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newDevice = new Device();
            if (selectedCategories != null)
            {
                newDevice.DeviceCategories = new List<DeviceCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new DeviceCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newDevice.DeviceCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Device>(
            newDevice,
            "Device",
            i => i.Name, i => i.Seller,
            i => i.Price, i => i.ManufacturingDate, i => i.ManufacturerID))
            {
                _context.Device.Add(newDevice);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newDevice);
            return Page();
        }
    }
}
