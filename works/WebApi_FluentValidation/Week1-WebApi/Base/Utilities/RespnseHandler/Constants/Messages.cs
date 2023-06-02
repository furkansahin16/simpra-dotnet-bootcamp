namespace Week1_WebApi.Base.Utilities.RespnseHandler.Constants
{
    public static class Messages
    {
        #region SuccessMessages
        public const string AddSuccess = "Data added successfully.";
        public const string UpdateSuccess = "Data updated successfully.";
        public const string DeleteSuccess = "Data updated successfully.";
        public const string GetSuccess = "Data retrieved successfully.";
        public const string ListSuccess = "Data list retrieved successfully.";
        #endregion
        #region ErrorMessages
        public const string AddError = "Data cannot be added.";
        public const string UpdateError = "Data cannot be updated.";
        public const string DeleteError = "Data cannot be deleted.";
        public const string GetError = "Data not found";
        public const string ListError = "Data list cannot be retrieved.";
        #endregion
    }
}
