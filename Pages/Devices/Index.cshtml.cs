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
    public class IndexModel : PageModel
    {
        private readonly Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext _context;

        public IndexModel(Kis_Fineas_ProiectMedii.Data.Kis_Fineas_ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Device> Device { get;set; }
        public DeviceData DeviceD { get; set; }
        public int DeviceID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            DeviceD = new DeviceData();

            DeviceD.Devices = await _context.Device
            .Include(b => b.Manufacturer)
            .Include(b => b.DeviceCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                DeviceID = id.Value;
                Device device = DeviceD.Devices
                .Where(i => i.ID == id.Value).Single();
                DeviceD.Categories = device.DeviceCategories.Select(s => s.Category);
            }
        }
    }
}
