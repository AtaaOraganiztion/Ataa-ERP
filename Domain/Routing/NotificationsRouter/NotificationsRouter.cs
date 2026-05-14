namespace Domain.Routing.BaseRouter;

public partial class Router
{
    public class Notifications : Router
    {
        private const string Prefix = Rule + "Notifications";

        public const string Latest = Prefix + "/Latest";
        public const string MarkAsRead = Prefix + "/{id}/Read";
    }
}
