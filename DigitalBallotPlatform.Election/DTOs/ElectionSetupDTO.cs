using System.Globalization;

namespace DigitalBallotPlatform.Election.DTOs
{
    public class ElectionSetupDTO
    {
        private string? _formattedDate;

        public int Id { get; set; }
        public DateTime ElectionDate { get; set; }
        public string Description { get; set; }
        public int WatermarkId { get; set; }
        public int CountyId { get; set; }
        public int BallotSpecsId { get; set; }

        public string FormattedDate
        {
            get => _formattedDate!;
            set
            {
                if (DateTime.TryParseExact(value, "yyyyMMdd", null, DateTimeStyles.None, out DateTime parsedDate))
                {
                    _formattedDate = value;
                    ElectionDate = parsedDate;
                }
                else
                {
                    throw new ArgumentException("Invalid date format. Expected: yyyyMMdd");
                }
            }
        }

        public ElectionSetupDTO(int id, DateTime electionDate, string description, int watermarkId, int countyId, int ballotSpecsId)
        {
            Id = id;
            ElectionDate = electionDate;
            Description = description;
            WatermarkId = watermarkId;
            CountyId = countyId;
            BallotSpecsId = ballotSpecsId;
        }
    }
}
