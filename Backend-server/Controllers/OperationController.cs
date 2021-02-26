using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<OperationController> _logger;

        public OperationController(ILogger<OperationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("site/{operation}")]
        public string siteOperation(string operation)
        {
            if (operation == "start") {
                string commandToExecute = @"c:\windows\system32\inetsrv\appcmd.exe";
                Process process = new Process();
                var processInfo = new ProcessStartInfo("cmd", "/c " + commandToExecute + " start site /site.name:hzsite");
                System.Diagnostics.Process.Start(processInfo);
                return "starting site ...";
            }
            else if (operation == "stop")
            {
                string commandToExecute = @"c:\windows\system32\inetsrv\appcmd.exe";
                Process process = new Process();
                var processInfo = new ProcessStartInfo("cmd", "/c " + commandToExecute + " stop site /site.name:hzsite");
                System.Diagnostics.Process.Start(processInfo);
                return "stopping site ...";
            } else
            {
                //string commandToExecute = @"c:\windows\system32\inetsrv\appcmd.exe";
                string commandToExecute = @"c:\windows\system32\inetsrv\appcmd.exe";
                Process process = new Process();
                //stop
                var processInfo1 = new ProcessStartInfo("cmd", "/c " + commandToExecute + " stop site /site.name:hzsite");
                System.Diagnostics.Process.Start(processInfo1);
                //start
                var processInfo2 = new ProcessStartInfo("cmd", "/c " + commandToExecute + " start site /site.name:hzsite");
                System.Diagnostics.Process.Start(processInfo2);
                return "restarting site ...";
            }
        }
    }
}
