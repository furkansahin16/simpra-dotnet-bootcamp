namespace SimpraApi.Base;
public static class Messages
{
    #region SuccessMessages
    public const string AddSuccess = "{0} is added successfully";
    public const string UpdateSuccess = "{0} is updated successfully";
    public const string DeleteSuccess = "{0} is deleted successfully";
    public const string GetSuccess = "{0} is retrieved successfully";
    public const string ListSuccess = "{0} list is retrieved successfully";
    #endregion

    #region ErrorMessages
    public const string AddError = "{0} cannot be added.";
    public const string UpdateError = "{0} cannot be updated.";
    public const string DeleteError = "{0} cannot be deleted.";
    public const string GetError = "{0} with id:'{1}' cannot be found";
    public const string ListError = "{0} list have no data";
    public const string UniqueFieldError = "{0}: '{1}' is already in use.";
    public const string DbError = "An error occurred during saving process.";
    public const string DbTransactionError = "An error occurred during saving process. All changes have been undone";
    public const string DbTypeError = "Invalid db type";
    public const string ConnectionStringError = "Connection string cannot be defined for given db type";
    public const string ValidationError = "Validation error.";
    public const string GeneralError = "An error has occured. Try again later.";
    #endregion

    #region UserMessages
    public const string TokenSuccess = "Token is created successfully";
    public const string EmailError = "Email address: '{0}' is already in use.";
    public const string PasswordConfirmError = "Passwords do not match!";
    public const string TokenError = "Invalid username or password";
    public const string Blocked = "User is blocked";
    public const string Unauthorized = "Role : {0} is anauthorized for this process";
    public const string Unauthenticate = "You must sign-in or sign-up for this process";
    #endregion

    #region ValidationMessages
    public const string LengthError = "{0} must be less than {1} character";
    public const string EmptyError = "{0} cannot be empty";
    public const string FormatError = "Invalid {0} format";
    public const string PasswordFormat = "- Has minimum 8, maximum 32 characters in length / At least one uppercase letter.([A-Z)] / At least one lowercase letter. ([a-z]) / At least one digit. ([0-9])";
    #endregion
}
