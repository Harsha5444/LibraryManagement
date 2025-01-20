namespace LibraryManagement.Enums
{
    public enum LoginResult
    {
        Success = 1,
        MemberSuccess = 0,
        InvalidCredentials = -1,
        ErrorOccurred = -2,
        UnexpectedError = -3
    }
}
