namespace DigitalBallotPlatform.Watermark.DTOs
{
    public class WatermarkColorDTO
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Tint { get; set; }
        public bool HasHeaderFill { get; set; }

        public WatermarkColorDTO(int id, string color, string tint, bool hasHeaderFill)
        {
            Id = id;
            Color = color;
            Tint = tint;
            HasHeaderFill = hasHeaderFill;
        }
    }
}
