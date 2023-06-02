﻿namespace SimpraApi.Business;
public static class Messages
{
	#region SuccessMessages
	public const string AddSuccess = "{0} is added successfully";
	public const string AddRangeSuccess = "{0}s are added successfully";
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
    public const string EmailError = "Email address: '{0}' is already in use.";
    public const string DbError = "An error occurred during saving process.";
    public const string DbErrorTransaction = "An error occurred during saving process. All changes have been undone";
    #endregion
}
