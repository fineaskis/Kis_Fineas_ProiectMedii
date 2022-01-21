namespace Kis_Fineas_ProiectMedii.Models
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
