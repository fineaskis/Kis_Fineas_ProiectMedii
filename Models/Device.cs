using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kis_Fineas_ProiectMedii.Models
{
    public class Device
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Device Name")]
        public string Name { get; set; }

        public string Seller { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(300, 8000)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ManufacturingDate { get; set; }
        public int ManufacturerID { get; set; }
        
        public Manufacturer Manufacturer { get; set; }
        public ICollection<DeviceCategory> DeviceCategories { get; set; }
    }
}
