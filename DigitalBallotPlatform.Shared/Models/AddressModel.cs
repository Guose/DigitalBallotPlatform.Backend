using System.ComponentModel.DataAnnotations;

namespace DigitalBallotPlatform.Shared.Models
{
    public class AddressModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public int Zipcode { get; set; }
        public string? ShpAddress1 { get; set; }
        public string? ShpAddress2 { get; set; }
        public string? ShpState { get; set; }
        public int? ShpZipcode { get; set; }
    }
}
