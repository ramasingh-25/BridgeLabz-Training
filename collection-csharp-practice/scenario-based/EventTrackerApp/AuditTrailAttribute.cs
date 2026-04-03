using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.EventTrackerApp
{
    using System;

    // Custom annotation for audit
    [AttributeUsage(AttributeTargets.Method)]
    class AuditTrailAttribute : Attribute
    {
        public string ActionType;
        public string PerformedBy;

        public AuditTrailAttribute(string actionType, string performedBy)
        {
            ActionType = actionType;
            PerformedBy = performedBy;
        }
    }

    // Controller class
    class UserActionController
    {
        [AuditTrail("LOGIN", "User")]
        public void Login()
        {
        }

        [AuditTrail("UPLOAD", "User")]
        public void UploadFile()
        {
        }

        [AuditTrail("DELETE", "Admin")]
        public void DeleteFile()
        {
        }

        public void HelperMethod()
        {
        }
    }

}
