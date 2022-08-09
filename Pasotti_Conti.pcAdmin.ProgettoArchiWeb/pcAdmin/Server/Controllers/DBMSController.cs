using Microsoft.AspNetCore.Mvc;
using pcAdmin.Server.Data;
using pcAdmin.Shared;

namespace pcAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBMSController : ControllerBase
    {
        private string _connectionString;

        [HttpPost]
        public async Task<IActionResult> CreateConnectionString(SqlServer sqlServer)
        {
            _connectionString = "Server=" + sqlServer.Server + ";Database=" + sqlServer.Database + ";User Id=" + sqlServer.Username + ";Password=" + sqlServer.Password + ";";
           
            return Ok();
        }

    }
}
