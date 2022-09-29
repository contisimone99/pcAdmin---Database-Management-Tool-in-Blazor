using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pcAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace pcAdmin.Client.Services
{
    public class PCAdminService : IPCAdminService
    {
        private readonly HttpClient _httpClient;

        public PCAdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public TablesList TablesList { get; set; } = new TablesList();
        public List<object[]> TableInfo { get; set; } = new List<object[]>();
        public TablePrimaryKey TablePrimaryKey { get; set; } = new TablePrimaryKey();
        public TableForeignKey TableForeignKey { get; set; } = new TableForeignKey();
        public TableIndexDB TableIndex { get; set; } = new TableIndexDB();
        public List<List<object[]>> SelectQuery { get; set; } = new List<List<object[]>>();
        public Response QueryResponse { get; set; }
        public Response ExportResponse { get; set; }

        public event Action OnChange;



        
        public async Task<TablesList> GetTablesList(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableslist", databaseConnection);
            TablesList = await result.Content.ReadFromJsonAsync<TablesList>();
            return TablesList;
        }

        public async Task<List<object[]>> GetTableInfo(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableinfo", databaseConnection);
            TableInfo = await result.Content.ReadFromJsonAsync<List<object[]>>();
            return TableInfo;
        }
        public async Task<TablePrimaryKey> GetTablePrimaryKey(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableprimarykey", databaseConnection);
            TablePrimaryKey = await result.Content.ReadFromJsonAsync<TablePrimaryKey>();
            return TablePrimaryKey;
        }
        public async Task<TableForeignKey> GetTableForeignKey(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableforeignkey", databaseConnection);
            TableForeignKey = await result.Content.ReadFromJsonAsync<TableForeignKey>();
            return TableForeignKey;
        }
        public async Task<TableIndexDB> GetTableIndex(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableindex", databaseConnection);
            TableIndex = await result.Content.ReadFromJsonAsync<TableIndexDB>();
            return TableIndex;
        }

        public async Task<List<List<object[]>>> SendQuerySelect(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/sendqueryselect", databaseConnection);
            SelectQuery.Add(await result.Content.ReadFromJsonAsync<List<object[]>>());
            return SelectQuery;
        }
        public async Task<Response> SendQuery(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/sendquery", databaseConnection);
            QueryResponse = await result.Content.ReadFromJsonAsync<Response>();
            return QueryResponse;
        }

        public async Task<Response> ExportCSV(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/exportcsv", databaseConnection);
            ExportResponse = await result.Content.ReadFromJsonAsync<Response>();
            return ExportResponse;
        }
    }
}
