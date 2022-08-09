using pcAdmin.Shared;

namespace pcAdmin.Client.Services
{
    public interface IDBService
    {
        event Action OnChange;
        Task<HttpResponseMessage> ConnectionStringSqlServer(SqlServer sqlServer);
    }
}
