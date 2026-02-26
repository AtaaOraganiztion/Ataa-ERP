namespace Domain.Routing.BaseRouter;

public partial class Router
{
    public partial class RolesRouter
    {
        private const string Root = Rule + "roles";
        
        // Role management
        public const string GetRoles = Root + "/get";
    }
} 