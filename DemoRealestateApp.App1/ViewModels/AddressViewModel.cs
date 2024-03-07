using System.ComponentModel.DataAnnotations;

namespace Demo.RealestateApp1.App.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Street { get; set; }=string.Empty;
    }
}
