namespace PruebaTecnica.Service
{
    public interface ISessionService
    {
        string GetAuthenticatedUser();
    }

    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetAuthenticatedUser()
        {
            return _httpContextAccessor.HttpContext?.Items["User"]?.ToString();
        }
    }
}
