#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kis_Fineas_ProiectMedii.Models;

namespace Kis_Fineas_ProiectMedii.Data
{
    public class Kis_Fineas_ProiectMediiContext : DbContext
    {
        public Kis_Fineas_ProiectMediiContext (DbContextOptions<Kis_Fineas_ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<Kis_Fineas_ProiectMedii.Models.Device> Device { get; set; }

        public DbSet<Kis_Fineas_ProiectMedii.Models.Manufacturer> Manufacturer { get; set; }

        public DbSet<Kis_Fineas_ProiectMedii.Models.Category> Category { get; set; }
    }
}
