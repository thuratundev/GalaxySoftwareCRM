namespace GalaxySoftwareCRM.Client.Services
{
    public class FilterService
    {
        public bool IsCustomerVisible { get; set; } = false;
        public bool IsTownshipVisible { get; set; } = false; 
        public bool IsCustomerGroupVisible { get; set; } = false;



        public Int16? SelectedTownshipId { get; set; }
        public Int16? SelectedCustomerGroupId { get; set; }

        public Action FilterVisibilityCommand { get; set; }
        public Action RequeryCommand { get; set; }
    }
}
