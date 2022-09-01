using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pcAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableIndex = pcAdmin.Shared.TableIndex;

namespace pcAdmin.Client.Services
{
    public interface IPCAdminService
    {
        event Action OnChange;
        List<TablesList> TablesList { get; set; }
        List<TableInfo> TableInfo { get; set; }
        List<TablePrimaryKey> TablePrimaryKey { get; set; }
        List<TableForeignKey> TableForeignKey { get; set; }
        List<TableIndex> TableIndex { get; set; }
        List<object[]> SelectQuery { get; set; }


        Task<List<TablesList>> GetTablesList(DatabaseConnection databaseConnection);
        Task<List<TableInfo>> GetTableInfo(DatabaseConnection databaseConnection);
        Task<List<TablePrimaryKey>> GetTablePrimaryKey(DatabaseConnection databaseConnection);
        Task<List<TableForeignKey>> GetTableForeignKey(DatabaseConnection databaseConnection);
        Task<List<TableIndex>> GetTableIndex(DatabaseConnection databaseConnection);
        Task<List<object[]>> SendQuery(DatabaseConnection databaseConnection);




    }
}
