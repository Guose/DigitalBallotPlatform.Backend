using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace DigitalBallotPlatform.Shared.Models
{
    public class ElectionSetupModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ElectionDate { get; set; }
        public string? Description { get; set; }

        [ForeignKey(nameof(WatermarkId))]
        public int? WatermarkId { get; set; }
        public WatermarkModel? Watermark { get; set; }

        [Required]
        [ForeignKey(nameof(CountyId))]
        public int CountyId { get; set; }
        public CountyModel? County { get; set; }

        [Required]
        [ForeignKey(nameof(BallotSpecsId))]
        public int BallotSpecsId { get; set; }
        public BallotSpecModel? BallotSpec { get; set; }

        public ICollection<PartyModel>? Parties { get; set; }


        private string? _formattedDate;
        [NotMapped]
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
    }
}
