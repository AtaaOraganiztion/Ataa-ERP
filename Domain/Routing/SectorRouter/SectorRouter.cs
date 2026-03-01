using System.Data;

namespace Domain.Routing.BaseRouter;

public partial class Router
{
    public class SectorRouter : Router
    {
        private const string Prefix = Rule + "Sector";
        public const string Add = Prefix + "/Add";
        public const string Delete = Prefix + "/{id}";
        public const string Update = Prefix + "/{id}";
        public const string GetAll = Prefix + "/Get-All";
        public const string GetAllPaginated = Prefix + "/Paginated";
        public const string GetById = Prefix + "/{id}";
    }
}