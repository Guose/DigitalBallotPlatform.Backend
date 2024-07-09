namespace DigitalBallotPlatform.Platform.DTOs
{
    public class AddressDetailsDTO
    {
        public string? CountyName { get; set; }
        public string? CompanyName { get; set; }
        public string StreetAddress1 { get; set; } = string.Empty;
        public string? StreetAddress2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int ZipCode { get; set; }
    }
}
