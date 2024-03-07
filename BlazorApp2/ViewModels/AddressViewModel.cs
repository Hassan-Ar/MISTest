using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.ViewModels
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
