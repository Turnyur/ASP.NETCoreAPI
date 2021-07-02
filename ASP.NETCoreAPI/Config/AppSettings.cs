using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Config
{
    public class AppSettings
    {
        public SerilogSettings SerilogSettings { get; set; }

    }

    public class SerilogSettings
    {
        public string FilePath { get; set; }
        public string OutputTemplate { get; set; }
    }


}
