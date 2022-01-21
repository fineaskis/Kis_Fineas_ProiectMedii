namespace Kis_Fineas_ProiectMedii.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<DeviceCategory> DeviceCategories { get; set; }

    }
}
