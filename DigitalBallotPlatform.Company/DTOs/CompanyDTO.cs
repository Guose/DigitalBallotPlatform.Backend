namespace DigitalBallotPlatform.Company.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Fax { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AddressId { get; set; }

        public CompanyDTO(int id, string name, string description, string fax, DateTime updatedAt, int addressId)
        {
            Id = id;
            Name = name;
            Description = description;
            Fax = fax;
            UpdatedAt = updatedAt;
            AddressId = addressId;
        }
    }
}
