using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using pcAdmin.Server.Data;
using pcAdmin.Shared;

namespace pcAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pcAdminController : ControllerBase
    {
        public pcAdminController()
        { }

        




        [HttpPost("gettableslist")]
        public async Task<IActionResult> GetTablesList(DatabaseConnection databaseConnection)
        {
            return base.Ok(await HelperPCAdmin.GetTablesListDB(databaseConnection));
        }

        [HttpPost("gettableinfo")]
        public async Task<IActionResult> GetTableInfo(DatabaseConnection databaseConnection)
        {
            return base.Ok(await HelperPCAdmin.GetTableInfoDB(databaseConnection));
        }

        [HttpPost("gettableprimarykey")]
        public async Task<IActionResult> GetTablePrimaryKey(DatabaseConnection databaseConnection)
        {
            return base.Ok(await HelperPCAdmin.GetTablePrimaryKeyDB(databaseConnection));
        }

        [HttpPost("gettableforeignkey")]
        public async Task<IActionResult> GetTableForeignKey(DatabaseConnection databaseConnection)
        {
            return base.Ok(await HelperPCAdmin.GetTableForeignKeyDB(databaseConnection));
        }

        [HttpPost("gettableindex")]
        public async Task<IActionResult> GetTableIndex(DatabaseConnection databaseConnection)
        {
            return base.Ok(await HelperPCAdmin.GetTableIndexDB(databaseConnection));
        }

        [HttpPost("sendqueryselect")]
        public async Task<IActionResult> SendQuerySelect(DatabaseConnection databaseConnection)
        {

            return base.Ok(await HelperPCAdmin.GetSelectQuery(databaseConnection));
        }

        [HttpPost("sendquery")]
        public async Task<IActionResult> SendQuery(DatabaseConnection databaseConnection)
        {
            return base.Ok(await HelperPCAdmin.GetQuery(databaseConnection));
        }

        [HttpPost("exportcsv")]
        public async Task<IActionResult> ExportCSV(DatabaseConnection databaseConnection)
        {
            
            return base.Ok(await HelperPCAdmin.ExpCSV(databaseConnection));
        }


    }
}
