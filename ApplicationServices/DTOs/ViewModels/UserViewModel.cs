namespace ApplicationServices.DTOs.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; } = null!;

        public string User { get; set; } = null!;

        public string Position { get; set; }

        public int Phone { get; set; }

        public string Gmail { get; set; } = null!;

        public string TypeContact { get; set; }
    }
}
