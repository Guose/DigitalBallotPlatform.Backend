namespace DigitalBallotPlatform.Shared.Types
{
    public enum MailClassType : byte
    {
        None = 0,

        // Federal indicia (par avion)
        Federal = 1,

        // First-Class indicia, presort, affix postage, or metered
        FirstClass = 2,

        // Nonprofit indicia
        Nonprofit = 3,
    }
}
