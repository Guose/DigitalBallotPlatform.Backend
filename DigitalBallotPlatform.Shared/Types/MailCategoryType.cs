namespace DigitalBallotPlatform.Shared.Types
{
    public enum MailCategoryType : byte
    {
        // Non mail
        None = 0,

        // Absentee
        ABS = 1,

        // Absentee, Id required
        ABS_ID = 2,

        // Imported, but not processed or mailed per county
        AUDIT = 3,

        // Military
        MIL = 4,

        // Military, Id required
        MIL_ID = 5,

        // Military Overseas
        MILOS = 6,

        // Military Overseas, Id required
        MILOS_ID = 7,

        // Permanent Absentee
        PERM = 8,

        // Permanent Absentee, Id required
        PERM_ID = 9,

        // Overseas
        SEA = 10,

        // Overseas, Id required
        SEA_ID = 11,

        // Vote By Mail
        VBM = 12,

        // Vote By Mail, Id required
        VBM_ID = 13,

        // Process & return to county
        VBM_OFC = 14,

        // Process & return to county, ID required
        VBM_OFC_ID = 15,
    }
}
