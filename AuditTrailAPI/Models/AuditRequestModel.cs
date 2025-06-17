using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditTrailAPI.Models
{
    public class AuditRequestModel
    {
         public dynamic ObjectBefore { get; set; }
    public dynamic ObjectAfter { get; set; }
    public string EntityName { get; set; }
    public string UserId { get; set; }
    public AuditAction Action { get; set; }
    }
}