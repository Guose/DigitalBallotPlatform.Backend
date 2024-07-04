namespace DigitalBallotPlatform.Shared.Models
{
    public class LookupItem
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; } = string.Empty;
    }

    public class NullLookupItem : LookupItem
    {
        public new int? Id { get { return null; } }
    }
}
