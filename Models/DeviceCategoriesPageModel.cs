using Microsoft.AspNetCore.Mvc.RazorPages;
using Kis_Fineas_ProiectMedii.Data;

namespace Kis_Fineas_ProiectMedii.Models
{
    public class DeviceCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Kis_Fineas_ProiectMediiContext context,
        Device device)
        {
            var allCategories = context.Category;
            var deviceCategories = new HashSet<int>(
            device.DeviceCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    AssignedCategoryDataID = cat.CategoryID,
                    Name = cat.CategoryName,
                    Assigned = deviceCategories.Contains(cat.CategoryID)
                });
            }
        }
        public void UpdateDeviceCategories(Kis_Fineas_ProiectMediiContext context,
        string[] selectedCategories, Device deviceToUpdate)
        {
            if (selectedCategories == null)
            {
                deviceToUpdate.DeviceCategories = new List<DeviceCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var deviceCategories = new HashSet<int>
            (deviceToUpdate.DeviceCategories.Select(c => c.Category.CategoryID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.CategoryID.ToString()))
                {
                    if (!deviceCategories.Contains(cat.CategoryID))
                    {
                        deviceToUpdate.DeviceCategories.Add(
                        new DeviceCategory
                        {
                            DeviceID = deviceToUpdate.ID,
                            CategoryID = cat.CategoryID
                        });
                    }
                }
                else
                {
                    if (deviceCategories.Contains(cat.CategoryID))
                    {
                        DeviceCategory courseToRemove
                        = deviceToUpdate
                        .DeviceCategories
                        .SingleOrDefault(i => i.CategoryID == cat.CategoryID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
