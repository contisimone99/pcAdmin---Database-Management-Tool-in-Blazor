using pcAdmin.Shared;
using System.Net.Http.Json;

namespace pcAdmin.Client.Services
{
    public class DBService : IDBService
    {
        private readonly HttpClient _httpClient;

        public DBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public async Task<HttpResponseMessage> ConnectionStringSqlServer(SqlServer sqlServer)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/dbms", sqlServer);
            OnChange.Invoke();
            return result;
        }
    }
}
