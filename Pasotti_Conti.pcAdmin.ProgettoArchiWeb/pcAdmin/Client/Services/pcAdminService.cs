using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pcAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TableIndex = pcAdmin.Shared.TableIndex;

namespace pcAdmin.Client.Services
{
    public class PCAdminService : IPCAdminService
    {
        private readonly HttpClient _httpClient;

        public PCAdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<TablesList> TablesList { get; set; } = new List<TablesList>();
        public List<TableInfo> TableInfo { get; set; } = new List<TableInfo>();
        public List<TablePrimaryKey> TablePrimaryKey { get; set; } = new List<TablePrimaryKey>();
        public List<TableForeignKey> TableForeignKey { get; set; } = new List<TableForeignKey>();
        public List<TableIndex> TableIndex { get; set; } = new List<TableIndex>();
        public List<object[]> SelectQuery { get; set; } = new List<object[]>();





        public event Action OnChange;



        
        public async Task<List<TablesList>> GetTablesList(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableslist", databaseConnection);
            TablesList = await result.Content.ReadFromJsonAsync<List<TablesList>>();
            return TablesList;
        }
        public async Task<List<TableInfo>> GetTableInfo(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableinfo", databaseConnection);
            TableInfo = await result.Content.ReadFromJsonAsync<List<TableInfo>>();
            return TableInfo;
        }
        public async Task<List<TablePrimaryKey>> GetTablePrimaryKey(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableprimarykey", databaseConnection);
            TablePrimaryKey = await result.Content.ReadFromJsonAsync<List<TablePrimaryKey>>();
            return TablePrimaryKey;
        }
        public async Task<List<TableForeignKey>> GetTableForeignKey(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableforeignkey", databaseConnection);
            TableForeignKey = await result.Content.ReadFromJsonAsync<List<TableForeignKey>>();
            return TableForeignKey;
        }

        public async Task<List<TableIndex>> GetTableIndex(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/gettableindex", databaseConnection);
            TableIndex = await result.Content.ReadFromJsonAsync<List<TableIndex>>();
            return TableIndex;
        }

        public async Task<List<object[]>> SendQuery(DatabaseConnection databaseConnection)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/pcadmin/sendquery", databaseConnection);
            SelectQuery = await result.Content.ReadFromJsonAsync<List<object[]>>();
            return SelectQuery;

        }
    }
}
