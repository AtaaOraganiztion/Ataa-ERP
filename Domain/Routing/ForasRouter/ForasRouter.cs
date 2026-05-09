namespace Domain.Routing.BaseRouter;

public partial class Router
{
    public class Foras : Router
    {
        private const string Prefix = Rule + "Foras";

        public const string Add = Prefix + "/Add";

        public const string UploadFile = Prefix + "/Upload-File/{forasId}";

        public const string Delete = Prefix + "/{id}";
        public const string Update = Prefix + "/{id}";
        public const string GetAll = Prefix + "/Get-All";
        public const string GetAllPaginated = Prefix + "/Paginated";
        public const string GetById = Prefix + "/{id}";

        public const string DownloadFile = Prefix + "/Files/{fileId}";
    }
}
