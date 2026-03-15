namespace Domain.Routing.BaseRouter;

public partial class Router
{
    public partial class AuthinticationRouter
    {
        private const string Root = Rule + "users";
        
        // Authentication endpoints
        public const string Login = Root + "/login";
        public const string Register = Root + "/register";
        
        // User management
        public const string GetMe = Root + "/me";
        public const string GetUsers = Root + "/get";
        public const string UpdateUser = Root + "/{userId}";
        public const string UpdateUserProfileImage = Root + "/profile-image";
        public const string UpdateMe = Root + "/profile-update";
        public const string UpdateUserRoles = Root + "/{userId}/roles";
        public const string GetUserRoles = Root + "/{userId}/roles";
        public const string DeleteUser = Root + "/{userId}";
        
    }
} 