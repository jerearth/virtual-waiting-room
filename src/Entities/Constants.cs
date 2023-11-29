namespace Entities;

public static class Constants
{
    public const string APPLICATION_NAME = "WaitBuddy";

    public static class TestData
    {
        public const string EMAIL = "wait@buddy.com";
        public const string PASSWORD = "abc123";
    }

    public static class CascadingParameters
    {
        public const string CURRENT_ACCOUNT = "CurrentAccount";
        public const string MAIN_LAYOUT = "MainLayout";
    }

    public static class Limits
    {
        public const int DEFAULT_TOAST_DURATION_IN_MS = 2000;
    }
}
