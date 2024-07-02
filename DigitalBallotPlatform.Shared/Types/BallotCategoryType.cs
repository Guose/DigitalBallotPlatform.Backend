namespace DigitalBallotPlatform.Shared.Types
{
    public enum BallotCategoryType : byte
    {
        Blank = 0,
        Duplicate = 1,
        VoteByMail = 2,
        Office = 3,
        Absentee = 4,
        Poll = 5,
        Provisional = 6,
        Test = 7,
        Testdeck = 8,
    }
}
