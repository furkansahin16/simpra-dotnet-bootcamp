namespace SimpraApi.Base;
public static class Messages
{
    public static class Success
    {
        public const string Created = "{0} is created successfully.";
        public const string Updated = "{0} is updated successfully.";
        public const string Deleted = "{0} is deleted successfully.";
        public const string Get = "{0} is retrieved successfully.";
        public const string List = "{0} list is retrieved successfully.";
        public const string Common = "Operation successful.";
    }

    public static class Error
    {
        public const string Add = "{0} cannot be created!";
        public const string Update = "{0} cannot be updated!";
        public const string Delete = "{0} cannot be deleted!";
        public const string Get = "{0} with id:'{1}' cannot be found!";
        public const string List = "{0} list have no data!";
        public const string UniqueField = "{0}: '{1}' is already in use!";
        public const string DbSave = "An error occurred during saving process!";
        public const string DbTransaction = "An error occurred during saving process. All changes have been undone!";
        public const string DbType = "Invalid db type!";
        public const string ConnectionString = "Connection string cannot be defined for given db type!";
        public const string Validation = "Validation error!";
        public const string Common = "An error has occured. Try again later!";
    }

    public static class User
    {
        public const string InvalidEmail = "Email address: '{0}' is already in use!";
        public const string LoginError = "Invalid username or password!";
        public const string Blocked = "User is blocked!";
        public const string Unauthorized = "Role : [{0}] is unauthorized for this process!";
        public const string Unauthenticated = "You must sign-in or sign-up for this process!";
        public const string LoginSuccess = "Login successful, welcome {0}.";
    }

    public static class Validation
    {
        public const string InvalidRole = $"Invalid role name. [{Roles.Admin}, {Roles.Manager}, {Roles.Standard}]";
        public const string PasswordConfirm = "Passwords do not match!";
        public const string Length = "{0} must be less than {1} character!";
        public const string Empty = "{0} cannot be empty!";
        public const string Format = "Invalid {0} format!";
        public const string Password = "- Has minimum 8, maximum 32 characters in length / At least one uppercase letter.([A-Z)] / At least one lowercase letter. ([a-z]) / At least one digit. ([0-9])";
    }
   
    public static class Log
    {
        public const string Token = "Token is created successfully for User= [{0}].";
        public const string UserSignedUp = "User= [{0}] is successfully signed up";
        public const string UserSignedIn = "User= [{0}] is successfully signed in";
        public const string UserBlocked = "User= [{0}] is blocked";
        public const string UserRoleChanged = "User= [{0}] role successfully changed. Roles= [{1}]";
        public const string UserPasswordError = "User= [{0}] logged in with wrong password. Retry error= '{1}'";
        public const string EntityCreated = "[{0}] is created by [{1}]";
        public const string EntityUpdated = "[{0}] is updated by [{1}]";
        public const string EntityDeleted = "[{0}] is deleted by [{1}]";
        public const string CacheClear = "Cahce cleared.";
        public const string CacheSaved = "Cahce saved= {0}";
        public const string ReadFromCache = "Data read from cache= {0}";
    }
}
