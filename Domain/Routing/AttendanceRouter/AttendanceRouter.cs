namespace Domain.Routing.BaseRouter;

public partial class Router
{
    public class AttendanceRouter : Router
    {
        private const string Prefix = Rule + "Attendance";
        public const string Add = Prefix + "/Add";
        public const string GetAll = Prefix + "/Get-All";
        public const string UpdateStatus = Prefix + "/{id}/status";
    }
}
