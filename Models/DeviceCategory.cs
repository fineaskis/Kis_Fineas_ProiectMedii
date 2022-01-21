namespace Kis_Fineas_ProiectMedii.Models
{
    public class DeviceCategory
    {
        public int ID { get; set; }
        public int DeviceID { get; set; }
        public Device Device { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
