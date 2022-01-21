namespace Kis_Fineas_ProiectMedii.Models
{
    public class DeviceData
    {
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<DeviceCategory> DeviceCategories { get; set; }
    }
}
