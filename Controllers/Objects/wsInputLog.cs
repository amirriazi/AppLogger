using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLogger.Controllers.Objects
{
    public class wsInputLog
    {
        public string apiKey { get; set; }
        public string level { get; set; }
        public string  processId { get; set; }
        public string message { get; set; }
        public string property{ get; set; }
    }
}
