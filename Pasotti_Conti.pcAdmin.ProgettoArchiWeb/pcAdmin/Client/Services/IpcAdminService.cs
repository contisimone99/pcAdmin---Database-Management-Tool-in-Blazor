using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pcAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace pcAdmin.Client.Services
{
    public interface IPCAdminService
    {
        event Action OnChange;
        TablesList TablesList { get; set; }
        List<object[]> TableInfo { get; set; }
        TablePrimaryKey TablePrimaryKey { get; set; }
        TableForeignKey TableForeignKey { get; set; }
        TableIndexDB TableIndex { get; set; }
        List<List<object[]>> SelectQuery { get; set; }
        Response QueryResponse { get; set; }
        Response ExportResponse { get; set; }




        Task<TablesList> GetTablesList(DatabaseConnection databaseConnection);
        Task<List<object[]>> GetTableInfo(DatabaseConnection databaseConnection);
        Task<TablePrimaryKey> GetTablePrimaryKey(DatabaseConnection databaseConnection);
        Task<TableForeignKey> GetTableForeignKey(DatabaseConnection databaseConnection);
        Task<TableIndexDB> GetTableIndex(DatabaseConnection databaseConnection);
        Task<List<List<object[]>>> SendQuerySelect(DatabaseConnection databaseConnection);
        Task<Response> SendQuery(DatabaseConnection databaseConnection);
        Task<Response> ExportCSV(DatabaseConnection databaseConnection);






    }
}
