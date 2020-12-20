using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppLogger.Controllers.Objects;
using AppLogger.Data;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace AppLogger.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly SqlDatabase _sqlDatabase;

        public LogController(SqlDatabase sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }
        [HttpPost("report")]
        public IActionResult Report( [FromBody] wsInputLog logInfo) 
        {
            try
            {
                var dbResult = _sqlDatabase.reportLog(Guid.Parse( logInfo.apiKey) , logInfo.level, logInfo.message, logInfo.processId, logInfo.property);
                if (dbResult.ReturnCode != 1 || dbResult.SPCode != 1)
                {
                    return BadRequest();
                }

                return Ok("Log has been write inside database");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}