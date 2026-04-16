namespace Domain.Routing.BaseRouter;

public partial class Router
{
    public class Activity : Router
    {
        private const string Prefix = Rule + "Activity";

        public const string Add = Prefix + "/Add";

        // ✅ NEW: Dedicated file upload endpoint
        public const string UploadFile = Prefix + "/Upload-File/{activityId}";

        public const string Delete = Prefix + "/{id}";
        public const string Update = Prefix + "/{id}";
        public const string GetAll = Prefix + "/Get-All";
        public const string GetAllPaginated = Prefix + "/Paginated";
        public const string GetById = Prefix + "/{id}";

        // (Optional but recommended)
        public const string DownloadFile = Prefix + "/Files/{fileId}";
    }
}