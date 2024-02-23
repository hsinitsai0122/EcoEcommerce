namespace ASP_EcoEcommerce.Handlers
{
    public abstract class SessionManager
    {
        protected readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContext) 
        {
            _session = httpContext.HttpContext.Session;
        }
    }
}
