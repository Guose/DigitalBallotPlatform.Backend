namespace DigitalBallotPlatform.Watermark.DTOs
{
    public class WatermarkColorDTO
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Tint { get; set; }
        public string VdfColor1 { get; set; }
        public string VdfColor2 { get; set; }
        public string VdfColor3 { get; set; }

        public WatermarkColorDTO(int id, string color, string tint, string vdfColor1, string vdfColor2, string vdfColor3)
        {
            Id = id;
            Color = color;
            Tint = tint;
            VdfColor1 = vdfColor1;
            VdfColor2 = vdfColor2;
            VdfColor3 = vdfColor3;
        }
    }
}
