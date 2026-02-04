using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.EventTrackerApp
{

    interface IAuditScanner
    {
        void GenerateAuditLogs(Type targetClass);
    }

}
